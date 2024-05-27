USE SoftUni;
GO

-- Get Salary before increase.
SELECT FirstName, LastName, Salary FROM Employees;
GO

-- Increase Salary by 10%.
UPDATE Employees SET Salary = Salary * 1.1;

-- Get Salary after increase.
SELECT FirstName, LastName, Salary FROM Employees;
GO