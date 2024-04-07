DROP DATABASE IF EXISTS GestStock;
GO
CREATE DATABASE GestStock;
GO              -- Sempre que faço um GO, sei que os comandos criados até aqui vão ser executados
USE GestStock;	-- "Esta conexão vai usar esta database: GestStock"
GO

CREATE TABLE produto (	
    codigo                  INT             NOT NULL,
    nome                    VARCHAR(30)     NOT NULL,
    preco                   REAL            NOT NULL,
    iva                     REAL            NOT NULL,
    unidades                INT,    -- Pode ser null (indisponível em armazém)
    PRIMARY KEY (codigo),
    CHECK (codigo > 0),
    CHECK (unidades >= 0),
    CHECK (preco > 0),
    CHECK (iva >= 0 AND iva <= 1)
);

CREATE TABLE tipo_fornecedor (
    codigo                  INT             NOT NULL,
    designacao              VARCHAR(30)     NOT NULL,
    PRIMARY KEY (codigo),
    CHECK (codigo > 0)
);

CREATE TABLE fornecedor (
    nif                     INT             NOT NULL,
    nome                    VARCHAR(30)     NOT NULL,
    fax                     INT             NOT NULL,
    endereco                VARCHAR(30),
    condpag                 VARCHAR(10)     NOT NULL,   
    tipo                    INT             NOT NULL,   -- Participação total
    PRIMARY KEY (nif),
    FOREIGN KEY (tipo) REFERENCES tipo_fornecedor(codigo),
    CHECK (nif >= 100000000 AND nif <= 999999999),
    CHECK (fax >= 0)  
);

CREATE TABLE encomenda (
    numero                  INT             NOT NULL,
    [data]                  DATE            NOT NULL,
    fornecedor              INT             NOT NULL,   -- Participação total
    PRIMARY KEY (numero),
    FOREIGN KEY (fornecedor) REFERENCES fornecedor(nif),
    CHECK (numero > 0) 
);

CREATE TABLE item (
    numEnc                  INT,    -- encomenda.numero (NOT NULL)
    codProd                 INT,    -- produto.codigo (NOT NULL)
    unidades                INT,
    PRIMARY KEY (numEnc, codProd),
    FOREIGN KEY (numEnc) REFERENCES encomenda(numero),  
    FOREIGN KEY (codProd) REFERENCES produto(codigo),
    CHECK (unidades > 0)
);  



