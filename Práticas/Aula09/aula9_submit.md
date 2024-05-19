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
    END;
GO
```

### *c)* 

```
CREATE TRIGGER tgr_gerente_dep ON Company.department
AFTER INSERT, UPDATE
AS	
BEGIN
	IF EXISTS (SELECT COUNT(*) 
				FROM inserted, department 
				WHERE inserted.Mgr_ssn = department.Mgr_ssn
				GROUP BY inserted.Mgr_ssn, department.Mgr_ssn
				HAVING COUNT(*) > 1)
		BEGIN
			RAISERROR('O funcionário não pode ser gerente de 2 departamentos.', 16, 1)   
			ROLLBACK TRANSACTION                                                    
		END;
END;
```

### *d)* 

```
CREATE TRIGGER tgr_salary_employee ON employee
AFTER INSERT, UPDATE
AS
    BEGIN
        IF EXISTS (
            SELECT emp.Ssn
            FROM 
            ((employee emp JOIN department dep ON emp.Dno = dep.Dnumber)
            JOIN employee mgr ON dep.Mgr_ssn = mgr.Ssn)
            WHERE emp.Ssn IN (
				SELECT Ssn FROM inserted
			) AND emp.Salary > mgr.Salary
        )
        BEGIN
            UPDATE emp
            SET emp.Salary = mgr.Salary - 1
            FROM 
            ((employee emp JOIN department dep ON emp.Dno = dep.Dnumber)
            JOIN employee mgr ON dep.Mgr_ssn = mgr.Ssn)
            WHERE emp.Ssn IN (
				SELECT Ssn FROM inserted
			) AND emp.Salary > mgr.Salary
        END;
    END;
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
CREATE FUNCTION employeeDeptHighAverage(@dno int) RETURNS @table TABLE (pname varchar(50), pnumber int, plocation varchar(30), dnum int, budget real, totalbudget real)
AS
	BEGIN
		declare @pname as varchar(50), @pnumber as int, @plocation as varchar(30), @dnum as int, @budget as real, @totalbudget as real;

		declare cursorDept cursor 
		for select Pname, Pnumber, Plocation, Dnum, Sum(Hours * Salary/(40*4) * 4) AS Budget
			from Company.project join Company.works_on on Pnumber=Pno join Company.employee on Essn=Ssn
			where Dnum=@dno
			group by Pname, Pnumber, Plocation, Dnum
			order by Pnumber

		open cursorDept

		fetch cursorDept into @pname, @pnumber, @plocation, @dnum, @budget

		select @totalbudget = 0

		while @@FETCH_STATUS = 0
			BEGIN
				SET @totalBudget += @budget
				insert into @table values (@pname, @pnumber, @plocation, @dnum, @budget, @totalbudget)
				fetch cursorDept into @pname, @pnumber, @plocation, @dnum, @budget
			END
		return
	END;*
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
Stored Procedure:

    Mais valias 
                - Podem aceitar parâmetros e devolvem diversos conjuntos de dados
                - Podem ser chamadas dentro de outras Procedures
                - Permitem realizar muitas operações

UDF:
    Mais valias
                - Aceitam parâmetros
                - Podem ser utilizadas em SELECT, WHERE e HAVING

Diferenças: As UDF podem ser utilizadas em SELECT/WHERE/HAVING, ao contrários das Stored Procedures. Além disso as UDF retornam um único valor, escalar ou table, enquanto que as SP podem retornar zero, single ou multiple values. Mais uma diferença vem do facto de as UDF serem limitadas no que toca a tratamento de exceções e não podem controlar transações 
```
