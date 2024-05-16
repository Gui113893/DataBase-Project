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
    id_patente INT PRIMARY KEY,
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
    id_fornecedor INT PRIMARY KEY,
    telefone VARCHAR(20) NOT NULL,
    rua VARCHAR(100) NOT NULL,
    codigo_postal VARCHAR(10) NOT NULL,
    localidade VARCHAR(100) NOT NULL
);
GO


-- Tabela Produto
CREATE TABLE Produto (
    id_produto INT PRIMARY KEY,
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
    nif INT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    sexo CHAR(1) NOT NULL,
    email VARCHAR(100),
    telefone VARCHAR(20),
    rua VARCHAR(100),
    codigo_postal VARCHAR(10),
    localidade VARCHAR(100),
    salario DECIMAL(5,2) CHECK (salario > 740) NOT NULL,  
);
GO


-- Tabela Diretor
CREATE TABLE Diretor (
    nif INT PRIMARY KEY,
    FOREIGN KEY (nif) REFERENCES Pessoa(nif) ON DELETE CASCADE
);
GO


-- Tabela SubEmpresa
CREATE TABLE SubEmpresa (
    id INT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    diretor INT,
    FOREIGN KEY (diretor) REFERENCES Diretor(nif) ON DELETE SET NULL
);
GO


-- Tabela Loja
CREATE TABLE Loja (
    id_loja INT PRIMARY KEY,
    telefone VARCHAR(20) NOT NULL,
    rua VARCHAR(100) NOT NULL,
    codigo_postal VARCHAR(10) NOT NULL,
    localidade VARCHAR(100) NOT NULL,
    subempresa INT,
    gerente INT,
    FOREIGN KEY (subempresa) REFERENCES SubEmpresa(id) ON DELETE SET NULL,
    -- Como o gerente depende da tabela Funcionario, a FK é adicionada mais em baixo (CTRL-F -> FK para Loja)
);
GO


-- Tabela Funcionario
CREATE TABLE Funcionario (
    nif INT PRIMARY KEY,
    tipo VARCHAR(20) NOT NULL CHECK (tipo IN ('Efetivo', 'Part-Time')),
    loja INT,
    FOREIGN KEY (nif) REFERENCES Pessoa(nif) ON DELETE CASCADE,
    FOREIGN KEY (loja) REFERENCES Loja(id_loja) ON DELETE SET NULL,
);
GO


-- Tabela Contrato
CREATE TABLE Contrato (
    id_contrato INT PRIMARY KEY,
    data_inicio DATE NOT NULL,
    data_fim DATE,
);
GO


-- Tabela Efetivo
CREATE TABLE Efetivo (
    nif INT PRIMARY KEY,
    contrato INT UNIQUE,
    FOREIGN KEY (nif) REFERENCES Funcionario(nif) ON DELETE CASCADE,
    FOREIGN KEY (contrato) REFERENCES Contrato(id_contrato) ON DELETE CASCADE
);
GO


-- Tabela Part-Time
CREATE TABLE Part_Time (
    nif INT PRIMARY KEY,
    horas_semanais INT NOT NULL CHECK (horas_semanais >= 0 AND horas_semanais <= 40),
    FOREIGN KEY (nif) REFERENCES Funcionario(nif) ON DELETE CASCADE,
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
REFERENCES Funcionario(nif) 
ON DELETE SET NULL;
