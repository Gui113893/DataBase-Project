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
