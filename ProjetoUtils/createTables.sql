USE master
GO
if exists (select * from sysdatabases where name='CompanyBrandManager')
		drop database CompanyBrandManager
go

CREATE DATABASE CompanyBrandManager;
GO

USE CompanyBrandManager;
GO

-- TABELAS
-- Tabela Patente

CREATE TABLE Patente (
    id_patente INT IDENTITY(1,1) PRIMARY KEY,
    data_registo DATE NOT NULL,
    data_vencimento DATE NOT NULL,
    logo VARCHAR(100),
);
GO


-- Tabela Pat_Locs
CREATE TABLE Pat_Locs (
    patente INT PRIMARY KEY,
    Ploc VARCHAR(100) NOT NULL,
    FOREIGN KEY (patente) REFERENCES Patente(id_patente) ON DELETE CASCADE
);
GO


-- Tabela Marca
CREATE TABLE Marca (
    patente INT PRIMARY KEY,
    nome VARCHAR(100) UNIQUE,
    FOREIGN KEY (patente) REFERENCES Patente(id_patente) ON DELETE CASCADE
);
GO


-- Tabela Fornecedor
CREATE TABLE Fornecedor (
    id_fornecedor INT IDENTITY(1,1) PRIMARY KEY,
    telefone VARCHAR(20) NOT NULL,
    rua VARCHAR(100) NOT NULL,
    codigo_postal VARCHAR(10) NOT NULL,
    localidade VARCHAR(100) NOT NULL
);
GO


-- Tabela Produto
CREATE TABLE Produto (
    id_produto INT IDENTITY(1,1) PRIMARY KEY,
    preco DECIMAL(10, 2) NOT NULL,
    nome VARCHAR(100) NOT NULL,
    marca INT NOT NULL,
    FOREIGN KEY (marca) REFERENCES Marca(patente) ON DELETE CASCADE -- OR SET NULL
);
GO


-- Tabela Stock_Fornecido
CREATE TABLE Stock_Fornecido (
    fornecedor INT,
    produto INT,
    quantidade INT,
    PRIMARY KEY (fornecedor, produto),
    FOREIGN KEY (fornecedor) REFERENCES Fornecedor(id_fornecedor) ON DELETE CASCADE,
    FOREIGN KEY (produto) REFERENCES Produto(id_produto) ON DELETE CASCADE
);
GO


-- Tabela Pessoa
CREATE TABLE Pessoa (
    nif NUMERIC(9,0) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    sexo CHAR(1) NOT NULL,
    email VARCHAR(100),
    telefone VARCHAR(20),
    rua VARCHAR(100),
    codigo_postal VARCHAR(10),
    localidade VARCHAR(100),
    tipo VARCHAR(20) NOT NULL CHECK (tipo IN ('Efetivo', 'Part-Time', 'Diretor')),
    salario DECIMAL(10,2) CHECK (salario > 740) NOT NULL,  
);
GO


-- Tabela Diretor
CREATE TABLE Diretor (
    nif NUMERIC(9,0) PRIMARY KEY,
    FOREIGN KEY (nif) REFERENCES Pessoa(nif) ON UPDATE CASCADE
);
GO


-- Tabela SubEmpresa
CREATE TABLE SubEmpresa (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    diretor NUMERIC(9,0),
    FOREIGN KEY (diretor) REFERENCES Diretor(nif) ON UPDATE CASCADE
);
GO


-- Tabela Loja
CREATE TABLE Loja (
    id_loja INT IDENTITY(1,1) PRIMARY KEY,
    telefone VARCHAR(20) NOT NULL,
    rua VARCHAR(100) NOT NULL,
    codigo_postal VARCHAR(10) NOT NULL,
    localidade VARCHAR(100) NOT NULL,
    subempresa INT NOT NULL,
    gerente NUMERIC(9,0),
    FOREIGN KEY (subempresa) REFERENCES SubEmpresa(id),
    -- Como o gerente depende da tabela Funcionario, a FK é adicionada mais em baixo (CTRL-F -> FK para Loja)
);
GO


-- Tabela Funcionario
CREATE TABLE Funcionario (
    nif NUMERIC(9,0) PRIMARY KEY,
    loja INT,
    FOREIGN KEY (nif) REFERENCES Pessoa(nif) ON UPDATE CASCADE,
    FOREIGN KEY (loja) REFERENCES Loja(id_loja) ON UPDATE CASCADE,
);
GO


-- Tabela Contrato
CREATE TABLE Contrato (
    id_contrato INT IDENTITY(1,1) PRIMARY KEY,
    data_inicio DATE NOT NULL,
    data_fim DATE NOT NULL,
);
GO


-- Tabela Efetivo
CREATE TABLE Efetivo (
    nif NUMERIC(9,0) PRIMARY KEY,
    contrato INT UNIQUE,
    FOREIGN KEY (nif) REFERENCES Funcionario(nif) ON UPDATE CASCADE,
    FOREIGN KEY (contrato) REFERENCES Contrato(id_contrato) ON UPDATE CASCADE
);
GO


-- Tabela Part-Time
CREATE TABLE Part_Time (
    nif NUMERIC(9,0) PRIMARY KEY,
    horas_semanais INT NOT NULL CHECK (horas_semanais >= 0 AND horas_semanais <= 40),
    FOREIGN KEY (nif) REFERENCES Funcionario(nif) ON UPDATE CASCADE,
);
GO


-- Tabela Stock_Loja
CREATE TABLE Stock_Loja (
    loja INT,
    produto INT,
    quantidade INT,
    PRIMARY KEY (loja, produto),
    FOREIGN KEY (loja) REFERENCES Loja(id_loja) ON DELETE CASCADE,
    FOREIGN KEY (produto) REFERENCES Produto(id_produto) ON DELETE CASCADE
);
GO

-- FK para Loja
ALTER TABLE Loja
ADD FOREIGN KEY (gerente)
REFERENCES Funcionario(nif);
