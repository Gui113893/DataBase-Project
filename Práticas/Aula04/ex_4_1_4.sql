CREATE TABLE MÉDICO(
	Id							INT								,
	Nome						VARCHAR(20)				NOT NULL,
	Especialidade				VARCHAR(30)				NOT NULL,
	PRIMARY KEY(Id)
);
CREATE TABLE PACIENTE(
	Num_utente					INT								,
	Nome						VARCHAR(20)				NOT NULL,
	Data_nascimento				DATE					NOT NULL,
	Endereço					VARCHAR(50)				NOT NULL,
	PRIMARY KEY(Num_utente)
);
CREATE TABLE FARMÁCIA(
	Nif							INT								,
	Nome						VARCHAR(30)				NOT NULL,
	Endereço					VARCHAR(50)				NOT NULL,
	Telefone					INT						NOT NULL	CHECK(Telefone<=999999999),
	PRIMARY KEY(Nif)
);
CREATE TABLE PRESCRIÇÃO(
	Num							INT								,
	Data						DATE					NOT NULL,
	Médico						INT						NOT NULL	REFERENCES MÉDICO(Id),
	Paciente					INT						NOT NULL	REFERENCES PACIENTE(Num_utente),
	Data_processamento			DATE							,
	Farmácia					INT									REFERENCES FARMÁCIA(Nif),
	PRIMARY KEY(Num)
);
CREATE TABLE FARMACÊUTICA(
	Num_registo					INT								,
	Nome						VARCHAR(20)				NOT NULL,
	Endereço					VARCHAR(50)				NOT NULL,
	Telefone					INT						NOT NULL	CHECK(Telefone<=999999999),
	PRIMARY KEY(Num_registo)
);
CREATE TABLE FÁRMACO(
	Nome						VARCHAR(30)						,
	Farmacêutica				INT									REFERENCES FARMACÊUTICA(Num_registo),
	Fórmula						VARCHAR(100)			NOT NULL,
	PRIMARY KEY(Nome, Farmacêutica)
);
CREATE TABLE PRESCRIÇÃO_FÁRMACO(
	Num_prescrição				INT									REFERENCES PRESCRIÇÃO(Num),
	Fármaco						VARCHAR(30)						,
	Farmacêutica				INT								,
	PRIMARY KEY(Num_prescrição, Fármaco, Farmacêutica),
	FOREIGN KEY(Fármaco, Farmacêutica) REFERENCES FÁRMACO(Nome, Farmacêutica)
);
CREATE TABLE VENDE(
	Farmácia					INT									REFERENCES FARMÁCIA(Nif),
	Fármaco						VARCHAR(30)						,
	Farmacêutica				INT								,
	PRIMARY KEY(Farmácia, Fármaco, Farmacêutica),
	FOREIGN KEY(Fármaco, Farmacêutica) REFERENCES FÁRMACO(Nome, Farmacêutica)
);