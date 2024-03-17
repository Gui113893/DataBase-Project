CREATE DATABASE Encomendas
GO
USE Encomendas
GO


CREATE TABLE Produto
(
    codigo              INT             PRIMARY KEY     NOT NULL,
    nome                VARCHAR(100)                    NOT NULL,
    preco               DECIMAL(10,2)                   NOT NULL,
    num_unidades        INT                             NOT NULL,
    IVA                 DECIMAL(10,2),
);

CREATE TABLE Tipo_Fornecedor
(
    cod_interno         INT             PRIMARY KEY     NOT NULL,
    nome                VARCHAR(100)                    NOT NULL,
);



CREATE TABLE Fornecedor
(
    nif                 INT             PRIMARY KEY     NOT NULL    CHECK (nif >= 100000000 AND nif <= 999999999),
    nome                VARCHAR(100)                    NOT NULL,
    addr                VARCHAR(100),
    fax                 INT             UNIQUE                            CHECK (fax >= 100000000 AND fax <= 999999999),
    tipo                INT                             NOT NULL,
    cod_pagamento       INT             UNIQUE          NOT NULL,

    FOREIGN KEY (tipo) REFERENCES Tipo_Fornecedor(cod_interno),
);



CREATE TABLE Encomenda
(
    num                 INT             PRIMARY KEY     NOT NULL,
    data                DATE                            NOT NULL,
    fornecedor          INT             UNIQUE          NOT NULL,   

    FOREIGN KEY (fornecedor) REFERENCES Fornecedor(nif),
);


CREATE TABLE Contem
(
    encomenda           INT             NOT NULL,
    produto             INT             NOT NULL,
    num_unidades        INT             NOT NULL,

    PRIMARY KEY (encomenda, produto),
    FOREIGN KEY (encomenda) REFERENCES Encomenda(num),
    FOREIGN KEY (produto) REFERENCES Produto(codigo),
);