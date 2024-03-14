-- Create the new database if it does not exist already
USE master
GO
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'Ex4_1_1'
)
CREATE DATABASE DatabaseName

-- Create the schema if it does not exist already
USE Ex4_1_1
GO
IF NOT EXISTS (
    SELECT schema_name
        FROM information_schema.schemata
        WHERE schema_name = N'RentACar'
)
EXEC('CREATE SCHEMA RentACar')

-- Create a new table called 'CLIENTE' in schema 'RentACar'
-- Drop the table if it already exists
IF OBJECT_ID('RentACar.CLIENTE', 'U') IS NOT NULL
DROP TABLE RentACar.CLIENTE
GO
CREATE TABLE RentACar.CLIENTE
(
    NIF         INT             PRIMARY KEY     NOT NULL    CHECK (NIF >= 100000000 AND NIF <= 999999999),
    nome        VARCHAR(100)                    NOT NULL,
    endereco    VARCHAR(100),
    num_carta   INT             UNIQUE          NOT NULL    CHECK (num_carta >= 100000000 AND num_carta <= 999999999),
);

-- Create a new table called 'ALUGUER' in schema 'RentACar'
-- Drop the table if it already exists
IF OBJECT_ID('RentACar.ALUGUER', 'U') IS NOT NULL
DROP TABLE RentACar.ALUGUER
GO

CREATE TABLE RentACar.ALUGUER
(
    numero      INT             PRIMARY KEY     NOT NULL,
    data        DATE                            NOT NULL,
    duracao     INT                             NOT NULL,
    cliente     INT                             NOT NULL,
    balcao      INT                             NOT NULL,
    veiculo     INT                             NOT NULL,

    FOREIGN KEY (cliente) REFERENCES RentACar.CLIENTE(NIF),
    FOREIGN KEY (balcao) REFERENCES RentACar.BALCAO(numero),
);
GO

-- Create a new table called 'BALCAO' in schema 'RentACar'
-- Drop the table if it already exists
IF OBJECT_ID('RentACar.BALCAO', 'U') IS NOT NULL
DROP TABLE RentACar.BALCAO
GO
-- Create the table in the specified schema
CREATE TABLE RentACar.BALCAO
(
    numero      INT             PRIMARY KEY     NOT NULL,
    nome        VARCHAR(100),                    
    endereco    VARCHAR(100),                    
);
GO

-- Create a new table called 'VEICULO' in schema 'RentACar'
-- Drop the table if it already exists
IF OBJECT_ID('RentACar.VEICULO', 'U') IS NOT NULL
DROP TABLE RentACar.VEICULO
GO
-- Create the table in the specified schema
CREATE TABLE RentACar.VEICULO
(
    matricula       CHAR(8)         PRIMARY KEY     NOT NULL,
    marca           VARCHAR(100)                    NOT NULL,
    tipo_veiculo    VARCHAR(100)                    NOT NULL,
    ano             INT                             NOT NULL,

    FOREIGN KEY (tipo_veiculo) REFERENCES RentACar.TIPO_VEICULO(codigo),
);
GO

-- Create a new table called 'TIPO_VEICULO' in schema 'RentACar'
-- Drop the table if it already exists
IF OBJECT_ID('RentACar.TIPO_VEICULO', 'U') IS NOT NULL
DROP TABLE RentACar.TIPO_VEICULO

-- Create the table in the specified schema
CREATE TABLE RentACar.TIPO_VEICULO
(
    codigo          INT             PRIMARY KEY     NOT NULL,
    arcondicionado  BIT,
    designacao      VARCHAR(100)                    NOT NULL, 
);

-- Create a new table called 'SIMILARIDADE' in schema 'RentACar'
-- Drop the table if it already exists
IF OBJECT_ID('RentACar.SIMILARIDADE', 'U') IS NOT NULL
DROP TABLE RentACar.SIMILARIDADE
GO
-- Create the table in the specified schema
CREATE TABLE RentACar.SIMILARIDADE
(
    cod_veiculo1    INT                NOT NULL,
    cod_veiculo2    INT                NOT NULL,

    FOREIGN KEY (cod_veiculo1) REFERENCES RentACar.TIPO_VEICULO(codigo),
    FOREIGN KEY (cod_veiculo2) REFERENCES RentACar.TIPO_VEICULO(codigo),
    PRIMARY KEY (cod_veiculo1, cod_veiculo2),
);
GO

-- Create a new table called 'LIGEIRO' in schema 'RentACar'
-- Drop the table if it already exists
IF OBJECT_ID('RentACar.LIGEIRO', 'U') IS NOT NULL
DROP TABLE RentACar.LIGEIRO
GO
-- Create the table in the specified schema
CREATE TABLE RentACar.LIGEIRO
(
    codigo         INT             PRIMARY KEY      NOT NULL,
    numlugares     INT                              NOT NULL,
    portas         INT                              NOT NULL,
    combustivel    VARCHAR(100)                     NOT NULL,

    FOREIGN KEY (codigo) REFERENCES RentACar.TIPO_VEICULO(codigo),
);
GO


-- Create a new table called 'PESADO' in schema 'RentACar'
-- Drop the table if it already exists
IF OBJECT_ID('RentACar.PESADO', 'U') IS NOT NULL
DROP TABLE RentACar.PESADO
GO
-- Create the table in the specified schema
CREATE TABLE RentACar.PESADO
(
    codigo         INT             PRIMARY KEY      NOT NULL,
    peso           INT                              NOT NULL,
    passageiros    INT                              NOT NULL,

    FOREIGN KEY (codigo) REFERENCES RentACar.TIPO_VEICULO(codigo),
);
GO
