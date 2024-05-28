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