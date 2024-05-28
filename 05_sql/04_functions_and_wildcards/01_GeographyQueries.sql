USE Geography;
GO

-- 00. String functions.
SELECT CountryName, IsoCode FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(LOWER(CountryName), 'a', '')) >= 3
ORDER BY IsoCode;
GO

-- 00. Wildcards.
SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode;

-- 01. JOINs (topic not covered yet), string functions.
SELECT PeakName, RiverName,
    LOWER(CONCAT(PeakName, SUBSTRING(RiverName, 2, LEN(RiverName)-1))) AS Mix
FROM Peaks AS P, Rivers AS R
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix;
GO