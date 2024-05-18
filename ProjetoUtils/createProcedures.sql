-- Procedure para adicionar um diretor
CREATE PROCEDURE AddDirector
    @Nif NUMERIC(9,0),
    @Nome VARCHAR(100),
    @Sexo CHAR(1),
    @Email VARCHAR(100),
    @Telefone VARCHAR(20),
    @Rua VARCHAR(100),
    @CodigoPostal VARCHAR(10),
    @Localidade VARCHAR(100),
    @Salario DECIMAL(10,2)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Inserir na tabela Pessoa
        INSERT INTO Pessoa (nif, nome, sexo, email, telefone, rua, codigo_postal, localidade, tipo, salario)
        VALUES (@Nif, @Nome, @Sexo, @Email, @Telefone, @Rua, @CodigoPostal, @Localidade, 'Diretor', @Salario);

        -- Inserir na tabela Diretor
        INSERT INTO Diretor (nif)
        VALUES (@Nif);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Procedure para adicionar um funcionário part-time
CREATE PROCEDURE AddPartTimeEmployee
    @Nif NUMERIC(9,0),
    @Nome VARCHAR(100),
    @Sexo CHAR(1),
    @Email VARCHAR(100),
    @Telefone VARCHAR(20),
    @Rua VARCHAR(100),
    @CodigoPostal VARCHAR(10),
    @Localidade VARCHAR(100),
    @Salario DECIMAL(10,2),
    @Loja INT,
    @HorasSemanais INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Inserir na tabela Pessoa
        INSERT INTO Pessoa (nif, nome, sexo, email, telefone, rua, codigo_postal, localidade, tipo, salario)
        VALUES (@Nif, @Nome, @Sexo, @Email, @Telefone, @Rua, @CodigoPostal, @Localidade, 'Part-Time', @Salario);

        -- Inserir na tabela Funcionario
        INSERT INTO Funcionario (nif, loja)
        VALUES (@Nif,  @Loja);

        -- Inserir na tabela Part-Time
        INSERT INTO Part_Time (nif, horas_semanais)
        VALUES (@Nif, @HorasSemanais);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Procedure para adicionar um funcionário efetivo
CREATE PROCEDURE AddEffectiveEmployee
    @Nif NUMERIC(9,0),
    @Nome VARCHAR(100),
    @Sexo CHAR(1),
    @Email VARCHAR(100),
    @Telefone VARCHAR(20),
    @Rua VARCHAR(100),
    @CodigoPostal VARCHAR(10),
    @Localidade VARCHAR(100),
    @Salario DECIMAL(10,2),
    @Loja INT,
    @InicioContrato DATE,
    @FimContrato DATE
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Inserir na tabela Pessoa
        INSERT INTO Pessoa (nif, nome, sexo, email, telefone, rua, codigo_postal, localidade, tipo, salario)
        VALUES (@Nif, @Nome, @Sexo, @Email, @Telefone, @Rua, @CodigoPostal, @Localidade, 'Efetivo', @Salario);

        -- Inserir na tabela Funcionario
        INSERT INTO Funcionario (nif, loja)
        VALUES (@Nif,  @Loja);

        -- Inserir na tabela Contrato
        INSERT INTO Contrato (data_inicio, data_fim)
        VALUES (@InicioContrato, @FimContrato);

        -- Capturar o ID gerado para o contrato
        DECLARE @ContratoId INT;
        SET @ContratoId = SCOPE_IDENTITY();

        -- Inserir na tabela Efetivo
        INSERT INTO Efetivo (nif, contrato)
        VALUES (@Nif, @ContratoId);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO 

-- Procedure para deletar um diretor
CREATE PROCEDURE DeleteDirector
    @Nif NUMERIC(9,0)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Atualiza as subempresas para definir o diretor como NULL
        UPDATE SubEmpresa
        SET diretor = NULL
        WHERE diretor = @Nif;

        -- Deleta o Diretor da tabela Diretor
        DELETE FROM Diretor
        WHERE nif = @Nif;

        -- Deleta o Diretor da tabela Pessoa
        DELETE FROM Pessoa
        WHERE nif = @Nif;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Procedure para deletar um funcionário efetivo
CREATE PROCEDURE DeleteEfetivo
    @Nif NUMERIC(9,0)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        DECLARE @deleted_contrato INT;

        -- Captura o contrato do efetivo a ser deletado
        SELECT @deleted_contrato = contrato FROM Efetivo WHERE nif = @Nif;

        -- Se o Efetivo deletado for gerente de alguma loja, definir o gerente como NULL
        UPDATE Loja
        SET gerente = NULL
        WHERE gerente = @Nif;

        -- Deleta o Efetivo da tabela Efetivo
        DELETE FROM Efetivo
        WHERE nif = @Nif;

        -- Deleta o Contrato relacionado
        DELETE FROM Contrato
        WHERE id_contrato = @deleted_contrato;

        -- Deleta o Funcionario relacionado
        DELETE FROM Funcionario
        WHERE nif = @Nif;

        -- Finalmente, deleta a Pessoa da tabela Pessoa
        DELETE FROM Pessoa
        WHERE nif = @Nif;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Procedure para deletar um funcionário part-time
CREATE PROCEDURE DeletePartTime
    @Nif NUMERIC(9,0)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Se o Part-Time deletado for gerente de alguma loja, definir o gerente como NULL
        UPDATE Loja
        SET gerente = NULL
        WHERE gerente = @Nif;

        -- Deleta o Part-Time da tabela Part_Time
        DELETE FROM Part_Time
        WHERE nif = @Nif;

        -- Deleta o Funcionario relacionado
        DELETE FROM Funcionario
        WHERE nif = @Nif;

        -- Finalmente, deleta a Pessoa da tabela Pessoa
        DELETE FROM Pessoa
        WHERE nif = @Nif;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Procedure para deletar uma pessoa
CREATE PROCEDURE DeletePerson
    @Nif NUMERIC(9,0)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipo VARCHAR(20);

    -- Captura o tipo da pessoa a ser deletada
    SELECT @tipo = tipo
    FROM Pessoa
    WHERE nif = @Nif;

    -- Chama a procedure correspondente com base no tipo da pessoa
    IF @tipo = 'Diretor'
    BEGIN
        EXEC DeleteDirector @Nif = @Nif;
    END
    ELSE IF @tipo = 'Efetivo'
    BEGIN
        EXEC DeleteEfetivo @Nif = @Nif;
    END
    ELSE IF @tipo = 'Part-Time'
    BEGIN
        EXEC DeletePartTime @Nif = @Nif;
    END
END;
GO



