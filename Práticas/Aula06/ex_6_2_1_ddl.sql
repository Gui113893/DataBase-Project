DROP DATABASE IF EXISTS Company;
GO
CREATE DATABASE Company;
GO
USE Company;
GO


CREATE TABLE department (
    Dname           VARCHAR(30)             NOT NULL,
    Dnumber         INT                     NOT NULL,
    Mgr_ssn         INT,
    Mgr_start_date  DATE,
    PRIMARY KEY (Dnumber),
    -- FOREIGN KEY (Mgr_ssn) REFERENCES employee(Ssn) -- Erro!
    CHECK (Dnumber > 0),
    CHECK (Mgr_ssn > 0)
);


CREATE TABLE employee (
    Fname           VARCHAR(15)             NOT NULL,
    Minit           CHAR                    NOT NULL,
    Lname           VARCHAR(15)             NOT NULL,
    Ssn             INT                     NOT NULL,
    Bdate           DATE                    NOT NULL,
    [Address]       VARCHAR(30)             NOT NULL,
    Sex             CHAR                    NOT NULL,
    Salary          INT                     NOT NULL,
    Super_ssn       INT,   
    Dno             INT                     NOT NULL,
    PRIMARY KEY (Ssn),
    FOREIGN KEY (Super_ssn) REFERENCES employee(Ssn),
    -- FOREIGN KEY (Dno) REFERENCES department(Dnumber) Adicionar depois de inserir os dados
);


CREATE TABLE [dependent] (
    Essn            INT                     NOT NULL,
    Dependent_name  VARCHAR(15)             NOT NULL,
    Sex             CHAR                    NOT NULL,
    Bdate           DATE                    NOT NULL,
    Relationship    VARCHAR(8)              NOT NULL,
    PRIMARY KEY (Essn, Dependent_name),
    FOREIGN KEY (Essn) REFERENCES employee(Ssn)
)


CREATE TABLE dept_location (
    Dnumber         INT                     NOT NULL,
    Dlocation       VARCHAR(15)             NOT NULL,
    PRIMARY KEY (Dnumber, Dlocation),
    FOREIGN KEY (Dnumber) REFERENCES department(Dnumber)
);


CREATE TABLE project (
    Pname           VARCHAR(15)             NOT NULL,
    Pnumber         INT                     NOT NULL,
    Plocation       VARCHAR(15)             NOT NULL,
    Dnum            INT                     NOT NULL,
    PRIMARY KEY (Pnumber),
    FOREIGN KEY (Dnum) REFERENCES department(Dnumber),
    CHECK (Pnumber > 0),
    CHECK (Dnum > 0)
);


CREATE TABLE works_on (
    Essn            INT                     NOT NULL,
    Pno             INT                     NOT NULL,
    [Hours]         INT                     NOT NULL,
    PRIMARY KEY (Essn, Pno),
    FOREIGN KEY (Essn) REFERENCES employee(Ssn),
    FOREIGN KEY (Pno) REFERENCES project(Pnumber),
    CHECK ([Hours] > 0)
);



