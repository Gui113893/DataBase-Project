# BD: Guião 9


## ​9.1
 
### *a)*

```
GO
CREATE PROC Delete_Employee @Emp_Ssn INT
AS
    BEGIN
        DELETE FROM [dependent] WHERE Essn = @Emp_Ssn;
        UPDATE employee SET Super_ssn = NULL WHERE Super_ssn = @Emp_Ssn;
		UPDATE department SET Mgr_ssn = NULL WHERE Mgr_ssn = @Emp_Ssn;
		UPDATE department SET Mgr_start_date = NULL WHERE Mgr_ssn = @Emp_Ssn;
        DELETE FROM works_on WHERE Essn = @Emp_Ssn;
        DELETE FROM employee WHERE Ssn = @Emp_Ssn;       
    END
GO
```

### *b)* 

```
IF Object_Id('DepartmentMgr') IS NOT NULL 
DROP PROCEDURE DepartmentMgr;

GO
CREATE PROC DepartmentMgr
AS
    BEGIN
            SELECT *
            FROM employee
            JOIN department ON employee.Ssn = department.Mgr_ssn;

			SELECT TOP 1 e.ssn, DATEDIFF(YEAR, department.Mgr_start_date, GETDATE()) AS years_as_manager
            FROM employee e
			JOIN department ON e.Ssn = department.Mgr_ssn
            WHERE e.Ssn IN (SELECT DISTINCT Mgr_ssn FROM department)
            ORDER BY department.Mgr_start_date;
    END
GO
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
