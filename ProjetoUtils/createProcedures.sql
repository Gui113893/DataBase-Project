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

-- Procedure para adicionar uma marca
CREATE PROCEDURE AddMarca
    @Nome VARCHAR(100),
    @Data_registo DATE,
    @Data_vencimento DATE
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Inserir na tabela Patente
        INSERT INTO Patente (data_registo, data_vencimento, logo)
        VALUES (@Data_registo, @Data_vencimento, 'logo');

        DECLARE @PatenteId INT;
        SET @PatenteId = SCOPE_IDENTITY();    

        -- Inserir na tabela Marca
        INSERT INTO Marca (patente, marcaNome)
        VALUES (@PatenteId, @Nome);

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

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE PROCEDURE SearchPessoa
    @nome_pessoa VARCHAR(100),
    @tipo VARCHAR(20),
    @nome_subempresa VARCHAR(100),
    @id_loja INT
AS
BEGIN
    WITH PessoaFiltrada AS (
        SELECT DISTINCT P.*
        FROM Pessoa P
        LEFT JOIN Funcionario F ON P.nif = F.nif
        LEFT JOIN Loja L ON F.loja = L.id_loja
        LEFT JOIN SubEmpresa SE ON L.subempresa = SE.id
        LEFT JOIN Diretor D ON SE.diretor = D.nif
        WHERE 
            (P.nome LIKE '%' + @nome_pessoa + '%' OR @nome_pessoa IS NULL)
            AND (SE.nome LIKE '%' + @nome_subempresa + '%' OR @nome_subempresa IS NULL)
            AND (L.id_loja = @id_loja OR @id_loja IS NULL OR SE.id IS NULL)
            AND (P.tipo = @tipo OR @tipo IS NULL)
            OR 
            (
                P.nif IN (
                    SELECT diretor
                    FROM SubEmpresa
                    JOIN Loja ON SubEmpresa.id = Loja.subempresa
                    WHERE nome LIKE '%' + @nome_subempresa + '%'
                    AND @id_loja = Loja.id_loja
                )
                AND (P.tipo = @tipo OR @tipo IS NULL)
            )
            OR 
            (
                @id_loja IS NULL
                AND P.nif IN (
                    SELECT diretor
                    FROM SubEmpresa
                    WHERE nome LIKE '%' + @nome_subempresa + '%'
                )
                AND (P.tipo = @tipo OR @tipo IS NULL)
            )
    )
    SELECT 
        P.*,
        Salario_Medios.Salario_Medio
    FROM 
        PessoaFiltrada P
    LEFT JOIN (
        SELECT 
            P.tipo,
            AVG(P.salario) AS Salario_Medio
        FROM 
            PessoaFiltrada P
        GROUP BY 
            P.tipo
    ) Salario_Medios
    ON P.tipo = Salario_Medios.tipo;
END;
GO





