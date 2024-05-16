GO
CREATE PROC DepartmentMgr
AS
    BEGIN
            SELECT e.ssn, DATEDIFF(YEAR, e.start_date, GETDATE()) AS years_as_manager
            FROM employees e
            WHERE e.employee_id IN (SELECT DISTINCT manager_id FROM departments)
            ORDER BY e.start_date ASC;

            SELECT *
            FROM employees
            JOIN departments ON employees.employee_id = departments.manager_id;
    END
GO

