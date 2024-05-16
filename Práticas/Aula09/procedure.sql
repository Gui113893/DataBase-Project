CREATE TRIGGER PreventMultipleManagers
ON department
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT Mgr_ssn
        FROM inserted
        GROUP BY Mgr_ssn
        HAVING COUNT(*) > 1
    )
    BEGIN
        RAISERROR ('Um funcionário não pode ser definido como gerente de mais de um departamento.', 16, 1)
        ROLLBACK TRANSACTION
    END
END

