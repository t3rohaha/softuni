-- =============================================================================
-- SoftUni SoftUni SoftUni SoftUni SoftUni SoftUni SoftUni SoftUni SoftUni
-- =============================================================================

USE SoftUni;
GO

-- =============================================================================
-- FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS
-- =============================================================================

-- Problem 01. Salary level function
CREATE FUNCTION dbo.GetSalaryLevel
(
    @salary decimal(18, 4)
)
RETURNS varchar(10)
AS
BEGIN
    DECLARE @level varchar(10);

    SET @level = CASE
        WHEN @salary < 30000 THEN 'Low'
        WHEN @salary <= 50000 THEN 'Average'
        ELSE 'High'
    END;   

    RETURN @level;
END
GO

SELECT
    FirstName,
    Salary,
    dbo.GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees;
GO

-- Problem 02. Employees by salary level
CREATE PROCEDURE dbo.EmployeesBySalaryLevel
(
    @level varchar(10)
)
AS
BEGIN
    SELECT
        FirstName AS [First Name],
        LastName AS [Last Name]
    FROM Employees
    WHERE dbo.GetSalaryLevel(Salary) = @level
END
GO

EXEC dbo.EmployeesBySalaryLevel 'high';
GO

-- Problem 03. Define Function
CREATE FUNCTION dbo.IsWordComprised
(
    @setOfLetters varchar(50),
    @word varchar(50)
)
RETURNS bit
AS
BEGIN
    DECLARE @result bit = 1;
    DECLARE @i int = 1;

    WHILE (@i <= LEN(@word))
    BEGIN
        IF CHARINDEX(SUBSTRING(@word, @i, 1), @setOfLetters) = 0
        BEGIN
            SET @result = 0;
            BREAK;
        END

        SET @i = @i + 1;
    END

    RETURN @result;
END
GO

SELECT dbo.IsWordComprised('oistmiahf', 'Sofia') AS Result;
SELECT dbo.IsWordComprised('oistmiahf', 'halves') AS Result;
SELECT dbo.IsWordComprised('bobr', 'Rob') AS Result;
SELECT dbo.IsWordComprised('pppp', 'Guy') AS Result;
GO

-- =============================================================================
-- Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank Bank
-- =============================================================================

USE Bank;
GO

-- Problem 04. Future value function
CREATE FUNCTION dbo.CalculateFutureValue
(
    @initial decimal(18, 2),
    @rate float,
    @years int
)
RETURNS decimal(18, 2)
AS
BEGIN
    DECLARE @result decimal(18, 2) = @initial * POWER(1 + (@rate / 100), @years);

    RETURN @result;
END
GO

SELECT dbo.CalculateFutureValue(1000, 10, 5) AS FutureValue;
GO

-- Problem 05. Calculating interest
CREATE PROCEDURE dbo.CalculateFutureValueForAccount
(
    @accountId int,
    @rate float
)
AS
BEGIN
    SELECT
        a.Id AS AccountId,
        ah.FirstName,
        ah.LastName,
        Balance,
        dbo.CalculateFutureValue (Balance, @rate, 5) AS [Balance After 5 Years]
    FROM Accounts a
    JOIN AccountHolders ah
    ON a.AccountHolderId = ah.Id
    WHERE a.Id = @accountId;
END
GO

EXEC dbo.CalculateFutureValueForAccount 1, 10;
