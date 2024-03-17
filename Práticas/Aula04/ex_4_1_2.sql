CREATE TABLE AIRPORT(
	Airport_code				INT								,
	City						VARCHAR(20)				NOT NULL,
	State						VARCHAR(20)						,
	Name						VARCHAR(30)				NOT NULL,
	PRIMARY KEY(Airport_code)
);
CREATE TABLE AIRPLANE_TYPE(
	Type_name					VARCHAR(20)						,
	Max_seats					INT						NOT NULL,
	Company						VARCHAR(20)				NOT NULL,
	PRIMARY KEY(Type_name)
);
CREATE TABLE AIRPLANE(
	Airplane_id					INT								,
	Total_no_of_seats			INT						NOT NULL,
	Airplane_type				VARCHAR(20)				NOT NULL	REFERENCES AIRPLANE_TYPE(Type_name),
	PRIMARY KEY(Airplane_id)
);
CREATE TABLE SEAT(
	Seat_no						INT								,
	Airplane					INT									REFERENCES AIRPLANE(Airplane_id),
	Customer_name				VARCHAR(20)						,
	Cphone						INT								,
	PRIMARY KEY(Seat_no, Airplane)
);
CREATE TABLE FLIGHT(
	Number						INT								,
	Airline						VARCHAR(30)				NOT NULL,
	Weekdays					INT						NOT NULL,
	PRIMARY KEY(Number)
);
CREATE TABLE FLIGHT_LEG(
	Leg_no						INT								,
	Flight						INT									REFERENCES FLIGHT(Number),
	Scheduled_dep_time			DATETIME				NOT NULL,
	Dep_airport					INT						NOT NULL	REFERENCES AIRPORT(Airport_code),
	Scheduled_arr_time			DATETIME				NOT NULL,
	Arr_airport					INT						NOT NULL	REFERENCES AIRPORT(Airport_code),
	PRIMARY KEY(Leg_no, Flight)
);
CREATE TABLE LEG_INSTANCE(
	Date						DATE							,
	Flight						INT								,
	Leg_no						INT								,
	No_of_avail_seats			INT						NOT NULL,
	Airplane					INT						NOT NULL	REFERENCES AIRPLANE(Airplane_id),
	Dep_time					TIME					NOT NULL,
	Dep_airport					INT						NOT NULL	REFERENCES AIRPORT(Airport_code),
	Arr_time					TIME					NOT NULL,
	Arr_airport					INT						NOT NULL	REFERENCES AIRPORT(Airport_code),
	PRIMARY KEY(Date, Flight, Leg_no),
	FOREIGN KEY(Leg_no, Flight) REFERENCES FLIGHT_LEG(Leg_no, Flight),
)
CREATE TABLE FARE(
	Code						INT								,
	Flight						INT									REFERENCES FLIGHT(Number),
	Amount						INT						NOT NULL,
	Restrictions				VARCHAR(300)			NOT NULL,
	PRIMARY KEY(Code, Flight)
);
CREATE TABLE CAN_LAND(
	Airport						INT									REFERENCES AIRPORT(Airport_code),
	Airplane_type				VARCHAR(20)							REFERENCES AIRPLANE_TYPE(Type_name),
	PRIMARY KEY(Airport, Airplane_type)
);