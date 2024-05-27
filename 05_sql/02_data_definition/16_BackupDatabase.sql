-- Can't say if this works as I run SQL Server in Docker, and have
-- difficulties to find where the bak file is saved.
-- The proccess should be something like this tho.
BACKUP DATABASE [SoftUni] TO DISK = './SoftUni.bak';
GO

USE master;
GO
DROP DATABASE [SoftUni];
GO

RESTORE DATABASE [SoftUni] FROM DISK = './SoftUni.bak';
GO