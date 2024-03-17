CREATE TABLE M�DICO(
	Id							INT								,
	Nome						VARCHAR(20)				NOT NULL,
	Especialidade				VARCHAR(30)				NOT NULL,
	PRIMARY KEY(Id)
);
CREATE TABLE PACIENTE(
	Num_utente					INT								,
	Nome						VARCHAR(20)				NOT NULL,
	Data_nascimento				DATE					NOT NULL,
	Endere�o					VARCHAR(50)				NOT NULL,
	PRIMARY KEY(Num_utente)
);
CREATE TABLE FARM�CIA(
	Nif							INT								,
	Nome						VARCHAR(30)				NOT NULL,
	Endere�o					VARCHAR(50)				NOT NULL,
	Telefone					INT						NOT NULL	CHECK(Telefone<=999999999),
	PRIMARY KEY(Nif)
);
CREATE TABLE PRESCRI��O(
	Num							INT								,
	Data						DATE					NOT NULL,
	M�dico						INT						NOT NULL	REFERENCES M�DICO(Id),
	Paciente					INT						NOT NULL	REFERENCES PACIENTE(Num_utente),
	Data_processamento			DATE							,
	Farm�cia					INT									REFERENCES FARM�CIA(Nif),
	PRIMARY KEY(Num)
);
CREATE TABLE FARMAC�UTICA(
	Num_registo					INT								,
	Nome						VARCHAR(20)				NOT NULL,
	Endere�o					VARCHAR(50)				NOT NULL,
	Telefone					INT						NOT NULL	CHECK(Telefone<=999999999),
	PRIMARY KEY(Num_registo)
);
CREATE TABLE F�RMACO(
	Nome						VARCHAR(30)						,
	Farmac�utica				INT									REFERENCES FARMAC�UTICA(Num_registo),
	F�rmula						VARCHAR(100)			NOT NULL,
	PRIMARY KEY(Nome, Farmac�utica)
);
CREATE TABLE PRESCRI��O_F�RMACO(
	Num_prescri��o				INT									REFERENCES PRESCRI��O(Num),
	F�rmaco						VARCHAR(30)						,
	Farmac�utica				INT								,
	PRIMARY KEY(Num_prescri��o, F�rmaco, Farmac�utica),
	FOREIGN KEY(F�rmaco, Farmac�utica) REFERENCES F�RMACO(Nome, Farmac�utica)
);
CREATE TABLE VENDE(
	Farm�cia					INT									REFERENCES FARM�CIA(Nif),
	F�rmaco						VARCHAR(30)						,
	Farmac�utica				INT								,
	PRIMARY KEY(Farm�cia, F�rmaco, Farmac�utica),
	FOREIGN KEY(F�rmaco, Farmac�utica) REFERENCES F�RMACO(Nome, Farmac�utica)
);