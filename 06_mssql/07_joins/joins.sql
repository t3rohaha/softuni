USE SoftUni;
GO

-- Problem 01: Employee Address
-- INNER JOIN example.
SELECT TOP(5) EmployeeId, Jobtitle, e.AddressId, a.AddressText
FROM Employees e
INNER JOIN Addresses a
ON e.AddressId = a.AddressId
ORDER BY AddressId
GO

-- Problem 02: Addresses with Towns
-- INNER JOIN multiple tables example.
SELECT TOP(50) FirstName, LastName, t.Name AS Town, AddressText
FROM Employees e
INNER JOIN Addresses a
ON e.AddressId = a.AddressId
INNER JOIN Towns t
ON a.TownID = t.TownID
ORDER BY FirstName, LastName;
GO

-- Problem 03: Sales Employee
-- Filter after INNER JOIN example.
SELECT EmployeeID, FirstName, LastName, d.Name AS DepartmentName
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID;
GO

-- Problem 04: Employee Departments
-- Filter after INNER JOIN example.
SELECT EmployeeID, FirstName, Salary, d.Name AS DepartmentName
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID;
GO

-- Problem 05: Employees Without Project
-- LEFT JOIN example.
SELECT TOP(3) e.EmployeeID, e.FirstName 
FROM Employees e
LEFT JOIN EmployeesProjects ep
ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID;
GO

-- Problem 05: Employees Without Project
-- RIGHT JOIN example.
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM EmployeesProjects ep
RIGHT JOIN Employees e
ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID;
GO

-- Problem 06: Employees Hired After
-- INNER JOIN with filtering example.
SELECT FirstName, LastName, HireDate, d.Name AS DeptName
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01'
AND d.Name IN ('Finance', 'Sales')
ORDER BY e.HireDate;
GO

-- Problem 07: Employees With Project
-- INNER JOIN multiple tables example.
SELECT TOP(5) e.EmployeeID, FirstName, p.Name AS ProjectName
FROM Employees e
INNER JOIN EmployeesProjects ep
ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13'
AND p.EndDate IS NULL
ORDER BY EmployeeID;
GO

-- Problem 08: Employee 24
-- INNER JOIN multiple tables with CASE.
SELECT e.EmployeeID, e.FirstName,
CASE
    WHEN p.StartDate < '2005-01-01' THEN p.Name
    ELSE NULL
END AS ProjectName
FROM Employees e
LEFT JOIN EmployeesProjects ep
ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24;
GO

-- Problem 09: Employee Manager
-- INNER JOIN self reference.
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
FROM Employees e
INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY EmployeeID;
GO

-- Problem 10: Employee Summary
-- INNER JOIN multiple tables example.
SELECT TOP(50)
    e.EmployeeID,
    CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
    CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
    d.Name AS DepartmentName
FROM Employees e
INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
ORDER BY EmployeeID;
GO

-- Problem 11: Min Average Salary
-- CTE example.
WITH CTE_AverageDepartmentSalary (DepartmentID, MinSalary)
AS
(
    SELECT DepartmentID, AVG(Salary) AS MinSalary
    FROM Employees
    GROUP BY DepartmentID
)
SELECT MIN(MinSalary) AS MinAverageSalary
FROM CTE_AverageDepartmentSalary;
GO

-- Geography DB --
-- Geography DB --
-- Geography DB --

USE Geography;
GO

-- Problem 12: Highest Peaks in Bulgaria
-- INNER JOIN multiple tables example.
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries c
INNER JOIN MountainsCountries mc
ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains m
ON mc.MountainID = m.ID
INNER JOIN Peaks p
ON p.MountainID = m.ID
WHERE c.CountryCode = 'BG'
AND p.Elevation > 2835
ORDER BY p.Elevation DESC;
GO

-- Problem 13: Count Mountain Ranges
-- INNER JOIN and GROUP example.
SELECT c.CountryCode, COUNT(*) AS MountainRanges
FROM Countries c
INNER JOIN MountainsCountries mc
ON c.CountryCode = mc.CountryCode
GROUP BY c.CountryCode
ORDER BY MountainRanges DESC;
GO

-- Problem 14: Countries with Rivers
-- LEFT JOIN example.
SELECT TOP(5) CountryName, r.RiverName
FROM Countries c
LEFT JOIN CountriesRivers cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r
ON cr.RiverID = r.ID
WHERE ContinentCode = 'AF'
ORDER BY CountryName;
GO

-- TODO: Problem 15: Continents and Currencies
WITH CTE_MostUsedCurrencies (ContinentCode, CurrencyCode, CurrencyUsageCount)
AS
(
    SELECT ContinentCode, CurrencyCode, COUNT(*) AS CurrencyUsageCount
    FROM Countries
    GROUP BY ContinentCode, CurrencyCode
    HAVING COUNT(*) != 1
)
SELECT ContinentCode, CurrencyCode, MAX(CurrencyUsageCount) AS CurrencyUsageCount
FROM CTE_MostUsedCurrencies
GROUP BY ContinentCode, CurrencyCode
ORDER BY ContinentCode;
GO

-- Problem 16: Countries without any Mountains
-- LEFT JOIN example.
SELECT COUNT(*) AS [No Mountain Countries Count]
FROM Countries c
LEFT JOIN MountainsCountries mc
ON mc.CountryCode = c.CountryCode
WHERE MountainId IS NULL;
GO

-- Problem 17: Highest Peak and Longest River by Country
-- JOIN multiple tables.
SELECT CountryName, MAX(p.Elevation) AS HighestPeak, MAX(Length) AS LongestRiver
FROM Countries c
JOIN MountainsCountries mc
ON c.CountryCode = mc.CountryCode
JOIN Peaks p
ON mc.MountainId = p.MountainId
JOIN CountriesRivers cr
ON c.CountryCode = cr.CountryCode
JOIN Rivers r
ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeak DESC, LongestRiver DESC, CountryName ASC;
GO

-- TODO: Problem 18: Highest Peak Name and Elevation by Country
SELECT CountryName, 
       p.PeakName AS [Highest Peak Name],
       MAX(p.Elevation) [Highest Peak Elevation],
       m.MountainRange AS Mountain
FROM Countries c
LEFT JOIN MountainsCountries mc
ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m
ON mc.MountainId = m.Id
LEFT JOIN Peaks p
ON p.MountainId = m.Id
GROUP BY CountryName
ORDER BY CountryName, [Highest Peak Name]