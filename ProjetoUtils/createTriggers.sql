CREATE TRIGGER trg_delete_pessoa
ON Pessoa
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @deleted_nif NUMERIC(9,0);
    DECLARE @deleted_tipo VARCHAR(20);
    SELECT @deleted_nif = nif, @deleted_tipo = tipo FROM deleted;
    IF @deleted_tipo = 'Diretor'
    BEGIN
        EXEC DeleteDirector @Nif = @deleted_nif;
    END
    ELSE IF @deleted_tipo = 'Efetivo'
    BEGIN
        EXEC DeleteEfetivo @Nif = @deleted_nif;
    END
    ELSE IF @deleted_tipo = 'Part-Time'
    BEGIN
        EXEC DeletePartTime @Nif = @deleted_nif;
    END
    DELETE FROM Pessoa
    WHERE nif = @deleted_nif;
END;
GO

CREATE TRIGGER trg_instead_of_update_pessoa
ON Pessoa
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @novo_nif NUMERIC(9,0);
    DECLARE @antigo_nif NUMERIC(9,0);
    DECLARE @nome VARCHAR(100);
    DECLARE @email VARCHAR(100);
    DECLARE @sexo CHAR(1);
    DECLARE @telefone VARCHAR(20);
    DECLARE @rua VARCHAR(100);
    DECLARE @codigo_postal VARCHAR(10);
    DECLARE @localidade VARCHAR(100);
    DECLARE @tipo VARCHAR(20);
    DECLARE @salario DECIMAL(10,2);
    DECLARE @loja INT;
    DECLARE @isGerente BIT = 0;

    -- Captura os valores antigos e novos
    SELECT @novo_nif = i.nif, @nome = i.nome, @email = i.email, @sexo = i.sexo, @telefone = i.telefone, @rua = i.rua, @codigo_postal = i.codigo_postal, @localidade = i.localidade, @tipo = i.tipo, @salario = i.salario
    FROM inserted i

    SELECT @antigo_nif = d.nif
    FROM deleted d;

    IF (@tipo = 'Part-Time' OR @tipo = 'Efetivo') AND @novo_nif <> @antigo_nif
    BEGIN
        IF EXISTS (SELECT 1 FROM Loja WHERE gerente = @antigo_nif)
        BEGIN
            SET @isGerente = 1;
            -- Se a pessoa a ser atualizada é gerente de uma loja e está a mudar de nif, atualiza o gerente da loja a null enquanto a pessoa não é atualizada
            SELECT @loja = id_loja
            FROM Loja
            WHERE gerente = @antigo_nif;

            UPDATE Loja SET gerente = NULL WHERE id_loja = @loja;
        END
    END

    -- Atualiza a tabela Pessoa
    UPDATE Pessoa
    SET nif = @novo_nif, nome = @nome, email = @email, sexo = @sexo, telefone = @telefone, rua = @rua, codigo_postal = @codigo_postal, localidade = @localidade, tipo = @tipo, salario = @salario
    WHERE nif = @antigo_nif;

    IF (@tipo = 'Part-Time' OR @tipo = 'Efetivo') AND @novo_nif <> @antigo_nif AND @isGerente = 1
    BEGIN
        UPDATE Loja SET gerente = @novo_nif
        WHERE id_loja = @loja;
    END
END;
GO

CREATE TRIGGER trg_after_update_funcionario
ON Funcionario
AFTER UPDATE
AS
BEGIN

    SET NOCOUNT ON;
    DECLARE @oldLoja INT;
    DECLARE @newLoja INT;
    DECLARE @nif NUMERIC(9,0);

    SELECT @oldLoja = deleted.loja, @newLoja = inserted.loja, @nif = inserted.nif
    FROM deleted
    INNER JOIN inserted ON deleted.nif = inserted.nif;

    -- Se o funcionário a ser updated está a mudar de loja e é gerente da loja da qual se está a mudar
    IF EXISTS (SELECT 1 FROM Loja WHERE gerente = @nif) AND @oldLoja <> @newLoja
    BEGIN
        -- Atualiza o gerente da loja antiga para NULL
        UPDATE Loja
        SET gerente = NULL
        WHERE id_loja = @oldLoja;
    END;
END;
GO

CREATE TRIGGER trg_delete_loja
ON Loja
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @deleted_id INT;
    DECLARE @deleted_gerente NUMERIC(9,0);
    DECLARE @nifs_todelete TABLE (nif INT);

    -- Captura o ID da loja a ser deletada
    SELECT @deleted_id = id_loja, @deleted_gerente = gerente FROM deleted;

    -- Se a loja a ser deletada tem um gerente, atualiza o gerente para NULL
    IF @deleted_gerente IS NOT NULL
    BEGIN
        UPDATE Loja
        SET gerente = NULL
        WHERE id_loja = @deleted_id;
    END

    -- Encontrar os funcionário da loja para depois os eliminar
    INSERT INTO @nifs_todelete 
    SELECT nif
    FROM Funcionario
    WHERE loja = @deleted_id;

    DECLARE @nif INT;
    DECLARE funcionario_cursor CURSOR FOR
    SELECT nif FROM @nifs_todelete;

    OPEN funcionario_cursor;

    FETCH NEXT FROM funcionario_cursor INTO @nif;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        DELETE FROM Pessoa WHERE nif = @nif;
        FETCH NEXT FROM funcionario_cursor INTO @nif;
    END
    CLOSE funcionario_cursor;
    DEALLOCATE funcionario_cursor;

    -- Finalmente dar delete a loja
    DELETE FROM Loja
    WHERE id_loja = @deleted_id;
END;
GO

CREATE TRIGGER trg_update_loja
ON Loja
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @oldGerente NUMERIC(9,0);
    DECLARE @newGerente NUMERIC(9,0);
    DECLARE @loja INT;

    SELECT @oldGerente = deleted.gerente, @newGerente = inserted.gerente, @loja = inserted.id_loja
    FROM deleted
    INNER JOIN inserted ON deleted.id_loja = inserted.id_loja;

    -- Se o gerente da loja foi alterado
    IF @oldGerente <> @newGerente OR (@oldGerente IS NULL AND @newGerente IS NOT NULL)
    BEGIN
        -- Garante que o novo gerente pertence á loja alterada
        IF NOT EXISTS (SELECT 1 FROM Funcionario WHERE nif = @newGerente AND loja = @loja)
        BEGIN
        RAISERROR ('O novo gerente não pertence á loja', 16, 1);
        ROLLBACK TRANSACTION;
        END;
    END;

END;
GO

CREATE TRIGGER trg_ValidarQuantidadeProduto
ON Stock_Loja
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @id_produto INT;
    DECLARE @quantidade_nova INT;
    DECLARE @quantidade_total_lojas INT;
    DECLARE @quantidade_fornecida INT;
    DECLARE @marca INT;
    DECLARE @loja INT;
    DECLARE @localidade_loja VARCHAR(100);
    DECLARE cur CURSOR FOR
    SELECT produto, quantidade, loja
    FROM inserted;
    OPEN cur;
    FETCH NEXT FROM cur INTO @id_produto, @quantidade_nova, @loja;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @quantidade_total_lojas = dbo.fn_QuantidadeProdutoLojas(@id_produto);
        SELECT @quantidade_fornecida = dbo.fn_TotalFornecidoPorProduto(@id_produto);
        SELECT @marca = marca
        FROM Produto
        WHERE id_produto = @id_produto;
        SELECT @localidade_loja = localidade
        FROM Loja
        WHERE id_loja = @loja;
        IF @quantidade_total_lojas > @quantidade_fornecida
        BEGIN
            RAISERROR('A quantidade total em circulação do produto %d ultrapassa a quantidade fornecida.', 16, 1, @id_produto);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF NOT EXISTS (
            SELECT 1
            FROM Pat_Locs
            WHERE patente = @marca AND Ploc = @localidade_loja
        )
        BEGIN
            RAISERROR('Não é possível adicionar quantidade do produto %d na loja %d, pois a localidade %s não é permitida para a marca.', 16, 1, @id_produto, @loja, @localidade_loja);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        FETCH NEXT FROM cur INTO @id_produto, @quantidade_nova, @loja;
    END
    CLOSE cur;
    DEALLOCATE cur;
END;
GO

CREATE TRIGGER trg_eliminar_produtos_localidade
ON Pat_Locs
AFTER DELETE
AS
BEGIN
    DECLARE @marca INT;
    DECLARE @localidade VARCHAR(100);
    DECLARE @id_produto INT;
    DECLARE @loja INT;

    DECLARE cur CURSOR FOR
    SELECT patente, Ploc
    FROM deleted;

    OPEN cur;
    FETCH NEXT FROM cur INTO @marca, @localidade;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE produtos_cursor CURSOR FOR
        SELECT produto, loja
        FROM Stock_Loja
        WHERE produto IN (
            SELECT id_produto
            FROM Produto
            WHERE marca = @marca
        ) AND loja IN (
            SELECT id_loja
            FROM Loja
            WHERE localidade = @localidade
        );

        OPEN produtos_cursor;
        FETCH NEXT FROM produtos_cursor INTO @id_produto, @loja;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            DELETE FROM Stock_Loja
            WHERE produto = @id_produto AND loja = @loja;

            FETCH NEXT FROM produtos_cursor INTO @id_produto, @loja;
        END

        CLOSE produtos_cursor;
        DEALLOCATE produtos_cursor;

        FETCH NEXT FROM cur INTO @marca, @localidade;
    END

    CLOSE cur;
    DEALLOCATE cur;
END;
GO

-- Trigger que não deixa que um fornecedor de uma localidade forneça um produto cuja patente não contém essa localidade
CREATE TRIGGER trg_ValidarFornecedorProduto
ON Stock_Fornecido
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @id_produto INT;
    DECLARE @fornecedor INT;
    DECLARE @marca INT;
    DECLARE @localidade VARCHAR(100);

    SELECT @id_produto = inserted.produto, @fornecedor = inserted.fornecedor
    FROM inserted;

    SELECT @marca = marca
    FROM Produto
    WHERE id_produto = @id_produto;

    SELECT @localidade = localidade
    FROM Fornecedor
    WHERE id_fornecedor = @fornecedor;

    IF NOT EXISTS (
        SELECT 1
        FROM Pat_Locs
        WHERE patente = @marca AND Ploc = @localidade
    )
    BEGIN
        RAISERROR('Fornecedor %d não pode forneceder quantidade do produto %d, pois a localidade %s não é permitida para a marca.', 16, 1, @fornecedor, @id_produto, @localidade);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO