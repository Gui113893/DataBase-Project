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
    FOREIGN KEY (patente) REFERENCES Patente(id_patente)
);
GO


-- Tabela Marca
CREATE TABLE Marca (
    patente INT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    FOREIGN KEY (patente) REFERENCES Patente(id_patente)
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
    FOREIGN KEY (marca) REFERENCES Marca(patente)
);
GO


-- Tabela Stock_Fornecido
CREATE TABLE Stock_Fornecido (
    fornecedor INT,
    produto INT,
    quantidade INT,
    PRIMARY KEY (fornecedor, produto),
    FOREIGN KEY (fornecedor) REFERENCES Fornecedor(id_fornecedor),
    FOREIGN KEY (produto) REFERENCES Produto(id_produto)
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
    FOREIGN KEY (nif) REFERENCES Pessoa(nif)
);
GO


-- Tabela SubEmpresa
CREATE TABLE SubEmpresa (
    id INT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    diretor INT,
    FOREIGN KEY (diretor) REFERENCES Diretor(nif)
);
GO


-- Tabela Loja
CREATE TABLE Loja (
    id_loja INT PRIMARY KEY,
    telefone VARCHAR(20) NOT NULL,
    rua VARCHAR(100) NOT NULL,
    codigo_postal VARCHAR(10) NOT NULL,
    localidade VARCHAR(100) NOT NULL,
    subempresa INT NOT NULL,
    gerente INT,
    FOREIGN KEY (subempresa) REFERENCES SubEmpresa(id),
    FOREIGN KEY (gerente) REFERENCES Funcionario(nif)
);
GO


-- Tabela Funcionario
CREATE TABLE Funcionario (
    nif INT PRIMARY KEY,
    tipo VARCHAR(20) NOT NULL CHECK (tipo IN ('Efetivo', 'Part-Time')),
    loja INT NOT NULL,
    FOREIGN KEY (nif) REFERENCES Pessoa(nif),
    FOREIGN KEY (loja) REFERENCES Loja(id_loja)
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
    contrato INT NOT NULL,
    FOREIGN KEY (nif) REFERENCES Funcionario(nif),
    FOREIGN KEY (contrato) REFERENCES Contrato(id_contrato)
);
GO


-- Tabela Part-Time
CREATE TABLE Part_Time (
    nif INT PRIMARY KEY,
    horas_semanais INT NOT NULL CHECK (horas_semanais >= 0 AND horas_semanais <= 40),
    FOREIGN KEY (nif) REFERENCES Funcionario(nif)
);
GO


-- Tabela Stock_Loja
CREATE TABLE Stock_Loja (
    loja INT,
    produto INT,
    quantidade INT,
    PRIMARY KEY (loja, produto),
    FOREIGN KEY (loja) REFERENCES Loja(id_loja),
    FOREIGN KEY (produto) REFERENCES Produto(id_produto)
);
GO
