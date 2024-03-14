CREATE DATABASE Conferencia
GO
USE Conferencia
GO

CREATE TABLE Artigo
(
    num_registo         INT             PRIMARY KEY     NOT NULL,
    titulo              VARCHAR(100)                    NOT NULL,
);

CREATE TABLE Instituição
(
    endereco            VARCHAR(100)                          NOT NULL,
    nome                VARCHAR(100)    PRIMARY KEY           NOT NULL,
);

CREATE TABLE Pessoa
(
    email               VARCHAR(100)    PRIMARY KEY           NOT NULL,
    nome                VARCHAR(100)                          NOT NULL, 
    instituicao         VARCHAR(100)                          NOT NULL,

    FOREIGN KEY (instituicao) REFERENCES Instituição(nome),
);

CREATE TABLE Autor
(
    email               VARCHAR(100)    PRIMARY KEY           NOT NULL,

    FOREIGN KEY (email) REFERENCES Pessoa(email),
);

CREATE TABLE Tem
(
    autor                VARCHAR(100)               NOT NULL,
    artigo               INT                        NOT NULL,

    PRIMARY KEY (autor, artigo),
    FOREIGN KEY (autor) REFERENCES Autor(email),
    FOREIGN KEY (artigo) REFERENCES Artigo(num_registo),
);

CREATE TABLE Participante
(
    email               VARCHAR(100)    PRIMARY KEY           NOT NULL,
    morada              VARCHAR(100),
    data_inscricao      DATE                                  NOT NULL,

    FOREIGN KEY (email) REFERENCES Pessoa(email),
);

CREATE TABLE Comprovativo
(
    localizacao         VARCHAR(100)    PRIMARY KEY           NOT NULL,
    instituicao         VARCHAR(100)                          NOT NULL,

    FOREIGN KEY (instituicao) REFERENCES Instituição(nome),
);

CREATE TABLE Não_Estudante
(
    email               VARCHAR(100)    PRIMARY KEY           NOT NULL,
    ref_transacao       INT                                   NOT NULL,

    FOREIGN KEY (email) REFERENCES Participante(email),
);

CREATE TABLE Estudante
(
    email               VARCHAR(100)    PRIMARY KEY           NOT NULL,
    comprovativo        VARCHAR(100)                          NOT NULL,

    FOREIGN KEY (email) REFERENCES Participante(email),
    FOREIGN KEY (comprovativo) REFERENCES Comprovativo(localizacao),
);
