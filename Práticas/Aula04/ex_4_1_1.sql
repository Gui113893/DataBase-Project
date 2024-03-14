CREATE DATABASE RentACar
GO
USE RentACar
GO

CREATE TABLE CLIENTE
(
    NIF         INT             PRIMARY KEY     NOT NULL    CHECK (NIF >= 100000000 AND NIF <= 999999999),
    nome        VARCHAR(100)                    NOT NULL,
    endereco    VARCHAR(100),
    num_carta   INT             UNIQUE          NOT NULL    CHECK (num_carta >= 100000000 AND num_carta <= 999999999),
);



CREATE TABLE BALCAO
(
    numero      INT             PRIMARY KEY     NOT NULL,
    nome        VARCHAR(100),                    
    endereco    VARCHAR(100),                    
);
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

CREATE TABLE TIPO_VEICULO
(
    codigo          INT             PRIMARY KEY     NOT NULL,
    arcondicionado  BIT,
    designacao      VARCHAR(100)                    NOT NULL, 
);


CREATE TABLE VEICULO
(
    matricula       CHAR(8)         PRIMARY KEY     NOT NULL,
    marca           VARCHAR(100)                    NOT NULL,
    tipo_veiculo    INT								NOT NULL,
    ano             INT                             NOT NULL,

    FOREIGN KEY (tipo_veiculo) REFERENCES TIPO_VEICULO(codigo),
);
GO


CREATE TABLE SIMILARIDADE
(
    cod_veiculo1    INT                NOT NULL,
    cod_veiculo2    INT                NOT NULL,

    FOREIGN KEY (cod_veiculo1) REFERENCES TIPO_VEICULO(codigo),
    FOREIGN KEY (cod_veiculo2) REFERENCES TIPO_VEICULO(codigo),
    PRIMARY KEY (cod_veiculo1, cod_veiculo2),
);
GO

CREATE TABLE LIGEIRO
(
    codigo         INT             PRIMARY KEY      NOT NULL,
    numlugares     INT                              NOT NULL,
    portas         INT                              NOT NULL,
    combustivel    VARCHAR(100)                     NOT NULL,

    FOREIGN KEY (codigo) REFERENCES TIPO_VEICULO(codigo),
);
GO


CREATE TABLE PESADO
(
    codigo         INT             PRIMARY KEY      NOT NULL,
    peso           INT                              NOT NULL,
    passageiros    INT                              NOT NULL,

    FOREIGN KEY (codigo) REFERENCES TIPO_VEICULO(codigo),
);
GO
