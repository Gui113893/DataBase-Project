-- Create the new database if it does not exist already
USE master
GO
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'Ex4_1_1'
)
CREATE DATABASE DatabaseName


-- Create a new table called 'CLIENTE''
-- Drop the table if it already exists
IF OBJECT_ID('CLIENTE', 'U') IS NOT NULL
DROP TABLE CLIENTE
GO
CREATE TABLE CLIENTE
(
    NIF         INT             PRIMARY KEY     NOT NULL    CHECK (NIF >= 100000000 AND NIF <= 999999999),
    nome        VARCHAR(100)                    NOT NULL,
    endereco    VARCHAR(100),
    num_carta   INT             UNIQUE          NOT NULL    CHECK (num_carta >= 100000000 AND num_carta <= 999999999),
);

-- Create a new table called 'ALUGUER'
-- Drop the table if it already exists
IF OBJECT_ID('ALUGUER', 'U') IS NOT NULL
DROP TABLE ALUGUER
GO

CREATE TABLE ALUGUER
(
    numero      INT             PRIMARY KEY     NOT NULL,
    data        DATE                            NOT NULL,
    duracao     INT                             NOT NULL,
    cliente     INT                             NOT NULL,
    balcao      INT                             NOT NULL,
    veiculo     INT                             NOT NULL,

    FOREIGN KEY (cliente) REFERENCES CLIENTE(NIF),
    FOREIGN KEY (balcao) REFERENCES BALCAO(numero),
);
GO

-- Create a new table called 'BALCAO' in schema '
-- Drop the table if it already exists
IF OBJECT_ID('BALCAO', 'U') IS NOT NULL
DROP TABLE BALCAO
GO
-- Create the table in the specified schema
CREATE TABLE BALCAO
(
    numero      INT             PRIMARY KEY     NOT NULL,
    nome        VARCHAR(100),                    
    endereco    VARCHAR(100),                    
);
GO

-- Create a new table called 'VEICULO' in schema '
-- Drop the table if it already exists
IF OBJECT_ID('VEICULO', 'U') IS NOT NULL
DROP TABLE VEICULO
GO
-- Create the table in the specified schema
CREATE TABLE VEICULO
(
    matricula       CHAR(8)         PRIMARY KEY     NOT NULL,
    marca           VARCHAR(100)                    NOT NULL,
    tipo_veiculo    VARCHAR(100)                    NOT NULL,
    ano             INT                             NOT NULL,

    FOREIGN KEY (tipo_veiculo) REFERENCES TIPO_VEICULO(codigo),
);
GO

-- Create a new table called 'TIPO_VEICULO' in schema '
-- Drop the table if it already exists
IF OBJECT_ID('TIPO_VEICULO', 'U') IS NOT NULL
DROP TABLE TIPO_VEICULO

-- Create the table in the specified schema
CREATE TABLE TIPO_VEICULO
(
    codigo          INT             PRIMARY KEY     NOT NULL,
    arcondicionado  BIT,
    designacao      VARCHAR(100)                    NOT NULL, 
);

-- Create a new table called 'SIMILARIDADE' in schema '
-- Drop the table if it already exists
IF OBJECT_ID('SIMILARIDADE', 'U') IS NOT NULL
DROP TABLE SIMILARIDADE
GO
-- Create the table in the specified schema
CREATE TABLE SIMILARIDADE
(
    cod_veiculo1    INT                NOT NULL,
    cod_veiculo2    INT                NOT NULL,

    FOREIGN KEY (cod_veiculo1) REFERENCES TIPO_VEICULO(codigo),
    FOREIGN KEY (cod_veiculo2) REFERENCES TIPO_VEICULO(codigo),
    PRIMARY KEY (cod_veiculo1, cod_veiculo2),
);
GO

-- Create a new table called 'LIGEIRO' in schema '
-- Drop the table if it already exists
IF OBJECT_ID('LIGEIRO', 'U') IS NOT NULL
DROP TABLE LIGEIRO
GO
-- Create the table in the specified schema
CREATE TABLE LIGEIRO
(
    codigo         INT             PRIMARY KEY      NOT NULL,
    numlugares     INT                              NOT NULL,
    portas         INT                              NOT NULL,
    combustivel    VARCHAR(100)                     NOT NULL,

    FOREIGN KEY (codigo) REFERENCES TIPO_VEICULO(codigo),
);
GO


-- Create a new table called 'PESADO' in schema '
-- Drop the table if it already exists
IF OBJECT_ID('PESADO', 'U') IS NOT NULL
DROP TABLE PESADO
GO
-- Create the table in the specified schema
CREATE TABLE PESADO
(
    codigo         INT             PRIMARY KEY      NOT NULL,
    peso           INT                              NOT NULL,
    passageiros    INT                              NOT NULL,

    FOREIGN KEY (codigo) REFERENCES TIPO_VEICULO(codigo),
);
GO
