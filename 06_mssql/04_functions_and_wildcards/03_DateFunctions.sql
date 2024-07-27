USE Orders;
GO

-- 00. Date functions.
SELECT ProductName,
    OrderDate,
    DATEADD(day, 3, OrderDate) AS [Pay Due],
    DATEADD(month, 1, OrderDate) AS [Deliver Due]
FROM Orders;
GO

USE SoftUni;
GO

-- 01. Date functions.
SELECT CONCAT(FirstName, ' ', LastName) AS [Fullname],
    DATEDIFF(year, HireDate, GETDATE()) AS [Serving Years],
    DATEDIFF(month, HireDate, GETDATE()) AS [Serving Months],
    DATEDIFF(day, HireDate, GETDATE()) AS [Serving Days],
    DATEDIFF(minute, HireDate, GETDATE()) AS [Serving Minutes]
FROM Employees
ORDER BY [Serving Minutes] DESC;
GO