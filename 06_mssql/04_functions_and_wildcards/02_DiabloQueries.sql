USE Diablo;
GO

-- 00. Date functions.
SELECT Name, FORMAT(Start, 'yyyy-MM-dd') AS Start FROM Games
WHERE YEAR(Start) IN (2011, 2012)
ORDER BY Start, Name;
GO

-- 01. String functions.
SELECT Username,
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
SELECT Name,
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