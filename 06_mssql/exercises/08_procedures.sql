-- =============================================================================
-- SoftUni SoftUni SoftUni SoftUni SoftUni SoftUni SoftUni SoftUni SoftUni
-- =============================================================================

USE SoftUni;
GO

-- =============================================================================
-- PROCEDURES PROCEDURES PROCEDURES PROCEDURES PROCEDURES PROCEDURES PROCEDURES
-- =============================================================================

-- Problem 01. Employees with salary above 35000
CREATE PROCEDURE dbo.GetEmployeesSalaryAbove35000
AS
BEGIN
    SELECT
        FirstName AS [First Name],
        LastName AS [Last Name]
    FROM Employees
    WHERE Salary > 35000;
END
GO

EXEC dbo.GetEmployeesSalaryAbove35000;
GO

-- Problem 02. Employees with salary above number
CREATE PROCEDURE dbo.GetEmployeesSalaryAboveNumber
(
    @number decimal(18, 4)
)
AS
BEGIN
    SELECT
        FirstName AS [First Name],
        LastName AS [Last Name]
    FROM Employees
    WHERE Salary >= @number;
END
GO

EXEC dbo.GetEmployeesSalaryAboveNumber 50000;
GO

-- Problem 03. Town names starting with
CREATE PROCEDURE dbo.GetTownsStartingWith
(
    @string varchar
)
AS
BEGIN
    SELECT Name AS Town
    FROM Towns
    WHERE SUBSTRING(Name, 1, LEN(@string)) = @string;
END
GO

EXEC dbo.GetTownsStartingWith 'b';
GO

-- Problem 04. Employees from town
CREATE PROCEDURE dbo.GetEmployeesFromTown
(
    @townName varchar(50)
)
AS
BEGIN
    SELECT
        FirstName AS [First Name],
        LastName AS [Last Name]
    FROM Employees e
    JOIN Addresses a
    ON e.AddressId = a.AddressId
    JOIN Towns t
    ON a.TownId = t.TownId
    WHERE t.Name = @townName;
END
GO

EXEC dbo.GetEmployeesFromTown Sofia;
GO

-- Problem 05. Delete employees and departments
CREATE PROCEDURE dbo.DeleteEmployeesFromDepartment
(
    @departmentId int
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        PRINT('Delete EmployeesProjects');
        DELETE FROM EmployeesProjects
        WHERE EmployeeId IN
        (
            SELECT EmployeeId
            FROM Employees
            WHERE DepartmentId = @departmentId
        );

        PRINT('Alter Departments');
        ALTER TABLE Departments
        ALTER COLUMN ManagerId int NULL;

        PRINT('Update Departments');
        UPDATE Departments
        SET ManagerId = NULL
        WHERE DepartmentId = @departmentId;

        PRINT('Delete Employees');
        DELETE FROM Employees
        WHERE DepartmentId = @departmentId;

        PRINT('Delete Department');
        DELETE FROM Departments
        WHERE DepartmentId = @departmentId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage nvarchar(max) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH

    SELECT COUNT(*) AS [Employees Count AFTER Delete]
    FROM Employees
    WHERE DepartmentId = @departmentId;
END

-- One of the employees in department with id= 1 is manager of department,
-- so there is error on FK_Departments_Employees.
EXEC dbo.DeleteEmployeesFromDepartment 1;
GO

-- =============================================================================
-- Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank
-- =============================================================================

USE SoftUni_Bank;
GO

-- Problem 06: Find Full Name
CREATE PROCEDURE dbo.GetHoldersFullName
AS
BEGIN
    SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
    FROM AccountHolders;
END
GO

EXEC dbo.GetHoldersFullName;
GO

-- Problem 07. People with balance higher than
CREATE PROCEDURE dbo.GetHoldersWithBalanceHigherThan
(
    @balance money
)
AS
BEGIN
    WITH CTE_TotalBalance (AccountHolderId, TotalBalance)
    AS
    (
        SELECT 
            AccountHolderId,
            SUM(Balance) AS TotalBalance
        FROM Accounts a
        GROUP BY AccountHolderId
    )
    SELECT
        AccountHolderId,
        CONCAT(FirstName, ' ', LastName) AS FullName,
        TotalBalance
    FROM AccountHolders ah
    JOIN CTE_TotalBalance tb
    ON ah.Id = tb.AccountHolderId
    WHERE TotalBalance >= @balance
    ORDER BY TotalBalance DESC;
END

EXEC dbo.GetHoldersWithBalanceHigherThan 10000;
GO