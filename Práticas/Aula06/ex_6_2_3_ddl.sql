DROP DATABASE IF EXISTS Prescricao;
GO
CREATE DATABASE Prescricao;
GO
USE Prescricao;
GO

CREATE TABLE medico (
    numSNS              INT             NOT NULL,
    nome                VARCHAR(30)     NOT NULL,
    especialidade       VARCHAR(30),
    PRIMARY KEY (numSNS),
    CHECK (numSNS > 0)
);

CREATE TABLE paciente (
    numUtente           INT             NOT NULL,
    nome                VARCHAR(30)     NOT NULL,
    dataNasc            DATE            NOT NULL,
    endereco            VARCHAR(50)     NOT NULL,
    PRIMARY KEY (numUtente),
    CHECK (numUtente > 0)
);

CREATE TABLE farmacia (
    nome                VARCHAR(30)     NOT NULL,
    telefone            INT,
    endereco            VARCHAR(50),
    PRIMARY KEY (nome),
    CHECK (telefone >= 100000000 AND telefone <= 999999999)
);

CREATE TABLE farmaceutica (
    numReg              INT             NOT NULL,
    nome                VARCHAR(30)     NOT NULL,
    endereco            VARCHAR(50),
    PRIMARY KEY (numReg),
    CHECK (numReg > 0)
);

CREATE TABLE farmaco (
    nome                VARCHAR(30)     NOT NULL,
    formula             VARCHAR(30)     NOT NULL,
    numRegFarm          INT             NOT NULL, -- Participação total (um fármaco tem de ter obrigatoriamente uma farmacêutica associada)
    PRIMARY KEY (nome),
    FOREIGN KEY (numRegFarm) REFERENCES farmaceutica(numReg),
);

CREATE TABLE prescricao (
    numPresc           INT              NOT NULL,
    numUtente          INT,             -- Participação parcial
    numMedico          INT              NOT NULL, -- Participação total (uma prescrição tem de ter obrigatoriamente um médico)
    farmacia           VARCHAR(30),
    dataProc           DATE,
    PRIMARY KEY (numPresc),
    FOREIGN KEY (numMedico) REFERENCES medico(numSNS),
    FOREIGN KEY (numUtente) REFERENCES paciente(numUtente),
    FOREIGN KEY (farmacia) REFERENCES farmacia(nome),
    CHECK (numPresc > 0)
);

CREATE TABLE presc_farmaco (
    numPresc           INT,             -- Já digo em PRESCRIÇÃO que não pode ser null
    numRegFarm         INT,             
    nomeFarmaco        VARCHAR(30),     -- Já digo em FÁRMACO que não pode ser null
    PRIMARY KEY (nomeFarmaco, numPresc),
    FOREIGN KEY (numPresc) REFERENCES prescricao(numPresc),
    FOREIGN KEY (numRegFarm) REFERENCES farmaceutica(numReg),
    FOREIGN KEY (nomeFarmaco) REFERENCES farmaco(nome)
);