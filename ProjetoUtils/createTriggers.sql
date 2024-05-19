CREATE TRIGGER trg_delete_pessoa
ON Pessoa
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @deleted_nif NUMERIC(9,0);
    DECLARE @deleted_tipo VARCHAR(20);

    -- Captura o NIF e o tipo da pessoa a ser deletada
    SELECT @deleted_nif = nif, @deleted_tipo = tipo FROM deleted;

    -- Chama a procedure correspondente com base no tipo da pessoa
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
