-- THIS SQL SCRIPT CONTAINS EXAMPLES OF GROUPING AND AGGREGATE FUNCTIONS.
-- THIS SQL SCRIPT CONTAINS EXAMPLES OF GROUPING AND AGGREGATE FUNCTIONS.
-- THIS SQL SCRIPT CONTAINS EXAMPLES OF GROUPING AND AGGREGATE FUNCTIONS.

USE [Gringotts];
GO

-- Check table names.
SELECT name
FROM sys.tables;
GO

-- Problem 01: Record's count.
SELECT COUNT(*) AS [Rows Count]
FROM WizzardDeposits;
GO

-- Problem 02: Longest magic wand.
SELECT MAX(MagicWandSize) AS [Longest Magic Wand]
FROM WizzardDeposits;
GO

-- Problem 03: Longest magic wand per deposit groups.
SELECT DepositGroup, MAX(MagicWandSize) AS [Longest Magic Wand]
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY [Longest Magic Wand] DESC
GO

-- Problem 04: Select the two deposit groups with smallest avg MWS.
SELECT TOP(2)
    DepositGroup, AVG(MagicWandSize) AS [MWS avg]
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY [MWS avg]
GO

-- Problem 05: Deposit group total deposit.
SELECT DepositGroup, SUM(DepositAmount) AS [Total Deposits]
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY [Total Deposits] DESC;
GO

-- Problem 06: Select total deposits.
SELECT DepositGroup, SUM(DepositAmount) AS [Total Deposits]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
ORDER BY [Total Deposits] DESC;
GO

-- Problem 07: Select total deposits and then filter, approach 1. 
SELECT DepositGroup, SUM(DepositAmount) AS [Total Deposits]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY [Total Deposits] DESC;
GO

-- Problem 07: Select total deposits and then filter, approach 2. 
SELECT DepositGroup, TotalDeposits
FROM (
    SELECT DepositGroup, SUM(DepositAmount) AS TotalDeposits
    FROM WizzardDeposits
    WHERE MagicWandCreator = 'Ollivander family'
    GROUP BY DepositGroup
) AS SubQuery
WHERE TotalDeposits < 150000
ORDER BY TotalDeposits DESC;
GO

-- Problem 08: Select DepositGroup, MagicWandCreator, MinDepositCharge.
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup;
GO

-- Problem 09: Age groups.
SELECT AgeGroup, COUNT(*) AS WizzardsCount
FROM (
    SELECT
        CASE
            WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
            WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
            WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
            WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
            WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
            WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
            ELSE '[61+]'
        END AS AgeGroup
    FROM WizzardDeposits
) AS SubQuery
GROUP BY AgeGroup;
GO

-- Problem 10: First letter, approach 1.
SELECT DISTINCT SUBSTRING(FirstName, 1, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY FirstLetter;
GO

-- Problem 10: First letter, approach 2.
SELECT SUBSTRING(FirstName, 1, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName,1, 1)
ORDER BY FirstLetter
GO

-- Problem 11:
-- Each [DepositGroup]
-- Expired / Not Expired
-- Average [DepositInterest]
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC
GO

-- TODO: Problem 12*: Rich wizzard, poor wizard.
SELECT *
FROM WizzardDeposits;
GO

-- Problem 13: Departments Total Salaries.
USE SoftUni;
GO

SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId;
GO

-- Problem 14: Employees minimum salaries.
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID;
GO

-- Problem 15: Employees average salaries, approach 1 with CTE (topic not
-- covered yet).
WITH
    EmployeesCTE
    AS
    (
        SELECT *
        FROM Employees
        WHERE Salary > 30000
    ),
    FilteredEmployeesCTE
    AS
    (
        SELECT *
        FROM EmployeesCTE
        WHERE ManagerID != 42
    ),
    DepartmentSalariesCTE
    AS
    (
        SELECT DepartmentID,
            CASE DepartmentID
            WHEN 1 THEN Salary + 5000
            ELSE Salary
        END AS Salary
        FROM FilteredEmployeesCTE
    )
SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM DepartmentSalariesCTE
GROUP BY DepartmentID;
GO

-- Problem 16: Select max salary by deparment.
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
WHERE Salary < 30000 OR Salary > 70000
GROUP BY DepartmentID;
GO

-- Problem 17: Count employees without manager.
SELECT COUNT(*) EmployeesWithoutMangerCount
FROM Employees
WHERE ManagerID IS NULL;
GO

-- TODO: Problem 18*: 3rd highest salary.

-- TODO: Problem 19**: Salary Challenge