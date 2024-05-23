USE Hotel;
GO

-- Before truncate.
SELECT * FROM Occupancies;
GO

TRUNCATE TABLE Occupancies;
GO

-- After truncate.
SELECT * FROM Occupancies;
GO