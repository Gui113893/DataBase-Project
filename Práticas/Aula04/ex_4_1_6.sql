CREATE TABLE PESSOA(
	CC							INT									CHECK(CC <= 99999999),
	Nome						VARCHAR(20)				NOT NULL,
	Morada						VARCHAR(50)				NOT NULL,
	Data_nascimento				DATE					NOT NULL,
	PRIMARY KEY(CC)
);
CREATE TABLE ADULTO(
	CC							INT									REFERENCES PESSOA(CC),
	email						VARCHAR(40)				NOT NULL,
	Contacto					INT						NOT NULL	CHECK(Contacto <= 999999999),
	PRIMARY KEY(CC)
);
CREATE TABLE PROFESSOR(
	CC							INT									REFERENCES ADULTO(CC),
	NUM_FUNCIONÁRIO				INT						NOT NULL,
	PRIMARY KEY(CC)
);
CREATE TABLE ENCARREGADO_DE_EDUCAÇÃO(
	CC							INT									REFERENCES ADULTO(CC),
	Rel_aluno					VARCHAR(10)						,
	Aluno						VARCHAR(20)				NOT NULL,
	PRIMARY KEY(CC)
);
CREATE TABLE PESSOA_AUTORIZADA(
	CC							INT									REFERENCES ADULTO(CC),
	Aluno						VARCHAR(20)				NOT NULL,
	PRIMARY KEY(CC)
);
CREATE TABLE TURMA(
	Id							INT								,
	Classe						INT						NOT NULL	CHECK(Classe < 5),
	Designação					VARCHAR(10)				NOT NULL,
	N_max_alunos				INT						NOT NULL,
	Ano_letivo					INT						NOT NULL,
	Professor					INT						NOT NULL	REFERENCES PROFESSOR(CC),
	PRIMARY KEY(Id)
);
CREATE TABLE ALUNO(
	CC							INT									REFERENCES PESSOA(CC),
	Encarregado_de_educação		INT						NOT NULL	REFERENCES ENCARREGADO_DE_EDUCAÇÃO(CC),
	Turma						INT						NOT NULL	REFERENCES TURMA(Id),
	PRIMARY KEY(CC)
);
CREATE TABLE ATIVIDADE(
	Id							INT								,
	Custo						INT						NOT NULL,
	Designação					VARCHAR(30)				NOT NULL,
	PRIMARY KEY(Id)
);
CREATE TABLE TEM(
	Atividade					INT						NOT NULL	REFERENCES ATIVIDADE(Id),
	Turma						INT						NOT NULL	REFERENCES TURMA(Id),
	PRIMARY KEY(Atividade, Turma)
);
CREATE TABLE FREQUENTA(
	Atividade					INT						NOT NULL	REFERENCES ATIVIDADE(Id),
	Aluno						INT						NOT NULL	REFERENCES ALUNO(CC),
	PRIMARY KEY(Atividade, Aluno)
);