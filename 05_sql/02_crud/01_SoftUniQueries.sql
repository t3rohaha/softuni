USE SoftUni;
GO

-- 00. Find all information about Departments.
SELECT * FROM Departments;
GO

-- 01. Find all Department Names.
SELECT Name FROM Departments;
GO

-- 02. Find Salary of each Employee.
SELECT FirstName, LastName, Salary FROM Employees;
GO

-- 03. Find Full Name of each Employee.
SELECT FirstName + ' ' + LastName AS [Full Name] FROM Employees;
GO

-- 04. Find Email of each Employee.
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Email] FROM Employees;
GO

-- 05. Find unique salaries.
SELECT DISTINCT Salary FROM Employees;
GO

-- 06. Find all info about Sales Representative Employees.
SELECT * FROM Employees WHERE JobTitle = 'Sales Representative';
GO

-- 07. Find Names of all Employees by Salary in range.
SELECT FirstName + ' ' + LastName AS [Full Name] FROM Employees
WHERE Salary BETWEEN 20000 AND 30000;
GO

-- 08. Find Names of all Employees.
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600);
GO

-- 09. Find all Employees without a manager.
SELECT FirstName, LastName FROM Employees
WHERE ManagerId IS NULL;
GO

-- 10. Find all Employees with salary more than 50000.
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC;
GO

-- 11. Find 5 best paid Employees.
SELECT TOP(5) FirstName, LastName, Salary FROM Employees
ORDER BY Salary DESC;
GO

-- 12. Find all employees except marketing.
SELECT FirstName, LastName FROM Employees
WHERE DepartmentId != 4;
GO

-- 13. Sort Employees table.
SELECT * FROM Employees
ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName;
GO

-- 14. Create view Employees with Salaries.
CREATE VIEW v_EmployeesSalaries AS
SELECT FirstName, LastName, Salary FROM Employees;
GO

-- 15. Create view Employees with Job Titles.
CREATE VIEW v_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName, ' ', COALESCE(MiddleName + ' ', ''), LastName)
AS [Full Name] FROM Employees;
GO

-- 16. Distinct Job Titles.
SELECT DISTINCT JobTitle FROM Employees;
GO

-- 17. Find first 10 started projects.
SELECT TOP(10) * FROM Projects
ORDER BY StartDate;
GO

-- 18. Last 7 Hired Employees.
SELECT TOP(7) FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC;
GO

-- 19. Increase salaries.
UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentId IN (1, 2, 4, 1);
GO