GO
CREATE PROC Delete_Employee @Emp_Ssn INT
AS
    BEGIN
        DELETE FROM [dependent] WHERE Essn = @Emp_Ssn;
        UPDATE employee SET Super_ssn = NULL WHERE Super_ssn = @Emp_Ssn;
        DELETE FROM works_on WHERE Essn = @Emp_Ssn;
        DELETE FROM employee WHERE Ssn = @Emp_Ssn;       
    END
GO

EXEC Delete_Employee 123456789