-- =============================================================================
-- DATA DEFINITION DATA DEFINITION DATA DEFINITION DATA DEFINITION DATA DEFINITI
-- =============================================================================

-- =============================================================================
-- SOFTUNI DATABASE SOFTUNI DATABASE SOFTUNI DATABASE SOFTUNI DATABASE SOFTUNI D
-- =============================================================================

USE SoftUni;
GO

-- 00. Wildcard example %.
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%';
GO

-- 01. Wildcard example %.
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%';
GO

-- 02. Operators, Date and time functions.
SELECT FirstName FROM Employees
WHERE DepartmentId IN (3, 10) AND
      YEAR(HireDate) > 1995 AND
      YEAR(HireDate) < 2005
GO

-- 03. Wildcard, logical and pattern matching operators.
SELECT FirstName, JobTitle FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'
GO

-- 04. String functions and matching operators.
SELECT * FROM Towns
WHERE LEN(Name) IN (5, 6)
ORDER BY Name;
GO

-- 05. Matching operators and wildcards.
SELECT * FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name
GO

-- 06. Matching operators and wildcards.
SELECT * FROM Towns
WHERE Name LIKE '[^RBD]%'
ORDER BY Name
GO

-- 07. Views.
CREATE VIEW v_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE YEAR(HireDate) > 2000;
GO

-- 08. String functions.
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5;
GO

-- =============================================================================
-- GEOGRAPHY DATABASE GEOGRAPHY DATABASE GEOGRAPHY DATABASE GEOGRAPHY DATABASE G
-- =============================================================================

USE SoftUni_Geography;
GO

-- 00. String functions.
SELECT CountryName, IsoCode FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(LOWER(CountryName), 'a', '')) >= 3
ORDER BY IsoCode;
GO

-- 01. Wildcards.
SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode;

-- 02. JOINs (topic not covered yet), string functions.
SELECT
      PeakName,
      RiverName,
      LOWER(CONCAT(PeakName, SUBSTRING(RiverName, 2, LEN(RiverName)-1))) AS Mix
      FROM Peaks AS P, Rivers AS R
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix;
GO

-- =============================================================================
-- DIABLO DATABASE DIABLO DATABASE DIABLO DATABASE DIABLO DATABASE DIABLO DATABA
-- =============================================================================

USE SoftUni_Diablo;
GO

-- 00. Date functions.
SELECT Name, FORMAT(Start, 'yyyy-MM-dd') AS Start FROM Games
WHERE YEAR(Start) IN (2011, 2012)
ORDER BY Start, Name;
GO

-- 01. String functions.
SELECT
      Username,
      RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
      FROM Users
ORDER BY [Email Provider];
GO

-- 02. Pattern matching and wildcards.
SELECT Username, IpAddress AS [IP Address] FROM Users
WHERE IpAddress LIKE '[1-9][0-9][0-9].1%.%.[1-9][0-9][0-9]'
ORDER BY Username;
GO

-- 03. Control flow (topic not covered yet).
SELECT
      Name,
      CASE
            WHEN DATEPART(hour, Start) < 12 THEN 'Morning'
            WHEN DATEPART(hour, Start) < 18 THEN 'Afternoon'
            ELSE 'Evening'
      END AS [Part of the Day],
      CASE
            WHEN Duration <= 3 THEN 'Extra Short'
            WHEN Duration <= 6 THEN 'Short'
            WHEN Duration > 6 THEN 'Long'
      ELSE 'Extra Long'
      END AS [Duration] FROM Games
ORDER BY Name, Duration, [Part of the Day];

-- =============================================================================
-- DATE FUNCTIONS DATE FUNCTIONS DATE FUNCTIONS DATE FUNCTIONS DATE FUNCTIONS DA
-- =============================================================================

USE SoftUni_Orders;
GO

-- 00. Date functions.
SELECT
      ProductName,
      OrderDate,
      DATEADD(day, 3, OrderDate) AS [Pay Due],
      DATEADD(month, 1, OrderDate) AS [Deliver Due]
      FROM Orders;
GO

USE SoftUni;
GO

-- 01. Date functions.
SELECT 
      CONCAT(FirstName, ' ', LastName) AS [Fullname],
      DATEDIFF(year, HireDate, GETDATE()) AS [Serving Years],
      DATEDIFF(month, HireDate, GETDATE()) AS [Serving Months],
      DATEDIFF(day, HireDate, GETDATE()) AS [Serving Days],
      DATEDIFF(minute, HireDate, GETDATE()) AS [Serving Minutes]
      FROM Employees
ORDER BY [Serving Minutes] DESC;
GO