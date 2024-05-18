# BD: Guião 9


## ​9.1
 
### *a)*

```
... Write here your answer ...
```

### *b)* 

```
... Write here your answer ...
```

### *c)* 

```
... Write here your answer ...
```

### *d)* 

```
... Write here your answer ...
```

### *e)* 

```
GO
CREATE FUNCTION employee_works_on (@Ssn INT) RETURNS Table
AS
	RETURN(
		SELECT Pname, Plocation FROM works_on, project
		WHERE Pno=Pnumber AND @Ssn=Essn
	)
GO
```

### *f)* 

```
GO
CREATE FUNCTION dpt_high_salaries (@Dno INT) RETURNS Table
AS
	RETURN(
		SELECT Fname, Minit, Lname, Ssn, Salary, employee.Dno 
		FROM employee JOIN (
			SELECT Dno, AVG(Salary) AS Avg_Salary FROM employee
			GROUP BY Dno
		) AS avg_salaries
		ON employee.Dno=avg_salaries.Dno
		WHERE @Dno=employee.Dno and Salary > Avg_Salary
	)
GO
```

### *g)* 

```
... Write here your answer ...
```

### *h)* 

```
-- After
GO
CREATE TRIGGER Del_dep ON department
AFTER DELETE
AS
	BEGIN
		DECLARE @Dname AS varchar(30)
		DECLARE @Dnumber AS int
		DECLARE @Mgr_ssn AS int
		DECLARE @Mgr_start_date AS date
		SELECT @Dname = Dname, @Dnumber = Dnumber, @Mgr_ssn = Mgr_ssn, @Mgr_start_date = Mgr_start_date FROM deleted;
		IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES  
		WHERE TABLE_NAME = 'department_deleted')) 
			INSERT INTO department_deleted VALUES (@Dname, @Dnumber, @Mgr_ssn, @Mgr_start_date)
		ELSE
			BEGIN
				CREATE TABLE department_deleted(
					Dname           VARCHAR(30)             NOT NULL,
					Dnumber         INT                     NOT NULL,
					Mgr_ssn         INT,
					Mgr_start_date  DATE,
				)
				INSERT INTO department_deleted VALUES (@Dname, @Dnumber, @Mgr_ssn, @Mgr_start_date)
			END
	END
GO

-- Instead of
GO
CREATE TRIGGER Del_dep ON department
INSTEAD OF DELETE
AS
	BEGIN
		DECLARE @Dname AS varchar(30)
		DECLARE @Dnumber AS int
		DECLARE @Mgr_ssn AS int
		DECLARE @Mgr_start_date AS date
		SELECT @Dname = Dname, @Dnumber = Dnumber, @Mgr_ssn = Mgr_ssn, @Mgr_start_date = Mgr_start_date FROM deleted;
		IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES  
		WHERE TABLE_NAME = 'department_deleted')) 
			INSERT INTO department_deleted VALUES (@Dname, @Dnumber, @Mgr_ssn, @Mgr_start_date)
		ELSE
			BEGIN
				CREATE TABLE department_deleted(
					Dname           VARCHAR(30)             NOT NULL,
					Dnumber         INT                     NOT NULL,
					Mgr_ssn         INT,
					Mgr_start_date  DATE,
				)
				INSERT INTO department_deleted VALUES (@Dname, @Dnumber, @Mgr_ssn, @Mgr_start_date)
			END
		DELETE FROM department WHERE Dnumber = @Dnumber
	END
GO
```

### *i)* 

```
... Write here your answer ...
```
