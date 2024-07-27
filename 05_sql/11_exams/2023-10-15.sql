-- =============================================================================
-- MSSQL Server Exam 15 Oct 2023 MSSQL Server Exam 15 Oct 2023 MSSQL Server Exam 
-- =============================================================================

-- =============================================================================
-- TOURIST AGENCY TOURIST AGENCY TOURIST AGENCY TOURIST AGENCY TOURIST AGENCY TO
-- =============================================================================

-- =============================================================================
-- DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL D
-- =============================================================================

-- =============================================================================
-- PROBLEM 01: DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL DDL D
-- =============================================================================

PRINT 'CREATING DATABASE...';
CREATE DATABASE SoftUni_TouristAgencyDB;
GO

USE SoftUni_TouristAgencyDB;

PRINT 'CREATING TABLES...';

CREATE TABLE Countries
(
    Id int IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT PK_Countries_Id PRIMARY KEY (Id)
);

CREATE TABLE Destinations
(
    Id int IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    CountryId int NOT NULL,
    CONSTRAINT PK_Destinations_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Destinations_CountryId FOREIGN KEY (CountryId) REFERENCES Countries (Id)
);

CREATE TABLE Rooms
(
    Id int IDENTITY,
    [Type] varchar(40) NOT NULL,
    Price decimal(18, 2) NOT NULL,
    BedCount int NOT NULL,
    CONSTRAINT PK_Rooms_Id PRIMARY KEY (Id),
    CONSTRAINT CHK_Rooms_BedCount CHECK (BedCount BETWEEN 1 AND 10)
);

CREATE TABLE Hotels
(
    Id int IDENTITY,
    [Name] varchar(50) NOT NULL,
    DestinationId int NOT NULL,
    CONSTRAINT PK_Hotels_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Hotels_DestinationId FOREIGN KEY (DestinationId) REFERENCES Destinations (Id)
);

CREATE TABLE Tourists
(
    Id int IDENTITY,
    [Name] nvarchar(80) NOT NULL,
    PhoneNumber varchar(20) NOT NULL,
    Email varchar(80),
    CountryId int NOT NULL,
    CONSTRAINT PK_Tourists_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Tourists_CountryId FOREIGN KEY (CountryId) REFERENCES Countries (Id)
);

CREATE TABLE Bookings
(
    Id int IDENTITY,
    ArrivalDate datetime2 NOT NULL,
    DepartureDate datetime2 NOT NULL,
    AdultsCount int NOT NULL,
    ChildrenCount int NOT NULL,
    TouristId int NOT NULL,
    HotelId int NOT NULL,
    RoomId int NOT NULL,
    CONSTRAINT PK_Bookings_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Bookings_TouristId FOREIGN KEY (TouristId) REFERENCES Tourists (Id),
    CONSTRAINT FK_Bookings_HotelId FOREIGN KEY (HotelId) REFERENCES Hotels (Id),
    CONSTRAINT FK_Bookings_RoomId FOREIGN KEY (RoomId) REFERENCES Rooms (Id),
    CONSTRAINT CHK_Bookings_AdultsCount CHECK (AdultsCount BETWEEN 1 AND 10),
    CONSTRAINT CHK_Bookings_ChildrenCount CHECK (ChildrenCount BETWEEN 0 AND 9)
);

CREATE TABLE HotelsRooms
(
    HotelId int NOT NULL,
    RoomId int NOT NULL,
    CONSTRAINT PK_HotelRooms_Id PRIMARY KEY (HotelId, RoomId),
    CONSTRAINT FK_HotelRooms_HotelId FOREIGN KEY (HotelId) REFERENCES Hotels (Id),
    CONSTRAINT FK_HotelRooms_RoomId FOREIGN KEY (RoomId) REFERENCES Rooms (Id)
);

GO

-- =============================================================================
-- DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML D
-- =============================================================================

-- =============================================================================
-- PROBLEM 02: INSERT INSERT INSERT INSERT INSERT INSERT INSERT INSERT INSERT IN
-- =============================================================================

INSERT INTO Tourists
([Name], PhoneNumber, Email, CountryId)
VALUES
('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6);

INSERT INTO Bookings
(ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6);

GO

-- =============================================================================
-- PROBLEM 03: UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UP
-- =============================================================================

SELECT * FROM Bookings
WHERE (DATEPART(YEAR, ArrivalDate) = 2023) AND
    (DATEPART(MONTH, ArrivalDate) = 12);

UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE (DATEPART(YEAR, ArrivalDate) = 2023) AND
    (DATEPART(MONTH, ArrivalDate) = 12);

SELECT * FROM Tourists
WHERE PATINDEX('%MA%', [Name]) != 0;

UPDATE Tourists
SET Email = NULL
WHERE PATINDEX('%MA%', [Name]) != 0;

GO

-- =============================================================================
-- PROBLEM 04: DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DE
-- =============================================================================

SELECT * FROM Tourists
WHERE RIGHT([Name], 5) = 'Smith';

BEGIN TRY
    BEGIN TRANSACTION;

    DELETE b FROM Bookings b
    JOIN Tourists t ON b.TouristId = t.Id
    WHERE RIGHT(t.Name, 5) = 'Smith';

    DELETE FROM Tourists
    WHERE RIGHT([Name], 5) = 'Smith';

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH

GO

-- =============================================================================
-- QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERY
-- =============================================================================

-- =============================================================================
-- PROBLEM 05: BOOKINGS BY PRICE OF ROOM AND ARRIVAL DATE
-- =============================================================================

SELECT 
    FORMAT(b.ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate,
    b.AdultsCount,
    b.ChildrenCount
    FROM Bookings b
JOIN Rooms r ON b.RoomId = r.Id
ORDER BY r.Price DESC, b.ArrivalDate;

-- =============================================================================
-- PROBLEM 06: HOTELS BY COUNT OF BOOKINGS
-- =============================================================================

SELECT
    b.HotelId AS Id,
    h.Name
    FROM Bookings b
JOIN Hotels h ON b.HotelId = h.Id
JOIN HotelsRooms hr ON hr.HotelId = h.Id
JOIN Rooms r ON hr.RoomId = r.Id
WHERE r.Type = 'VIP Apartment'
GROUP BY b.HotelId, h.Name
ORDER BY COUNT(b.HotelId) DESC;

-- =============================================================================
-- PROBLEM 07: HOTELS BY COUNT OF BOOKINGS
-- =============================================================================

SELECT t.Id, t.[Name], t.PhoneNumber FROM Tourists t
LEFT JOIN Bookings b ON b.TouristId = t.Id
WHERE b.Id IS NULL
ORDER BY t.Name;

-- =============================================================================
-- PROBLEM 08: FIRST 10 BOOKINGS
-- =============================================================================

SELECT TOP(10)
    h.Name AS HotelName,
    d.Name AS DestinationName,
    c.Name AS CountryName
    FROM Bookings b
JOIN Hotels h ON b.HotelId = h.Id
JOIN Destinations d ON h.DestinationId = d.Id
JOIN Countries c ON d.CountryId = c.Id
WHERE ArrivalDate < '2023-12-31' AND
      HotelId % 2 != 0
ORDER BY CountryName, ArrivalDate;

-- =============================================================================
-- PROBLEM 09: TOURISTS BOOKED IN HOTELS
-- =============================================================================

SELECT 
    h.Name AS HotelName,
    r.Price AS RoomPrice
    FROM Tourists t
JOIN Bookings b ON b.TouristId = t.Id
JOIN Hotels h ON b.HotelId = h.Id
JOIN Rooms r ON b.RoomId = r.Id
WHERE RIGHT(t.Name, 2) != 'EZ'
ORDER BY r.Price DESC;

-- =============================================================================
-- PROBLEM 10: HOTELS REVENUE
-- =============================================================================

WITH CTE_BookingsTotal (HotelName, TotalPrice)
AS
(
    SELECT
        h.Name AS HotelName,
        DATEDIFF(day, b.ArrivalDate, b.DepartureDate) * r.Price AS TotalPrice
        FROM Bookings b
    JOIN Hotels h ON b.HotelId = h.Id
    JOIN Rooms r ON b.RoomId = r.Id
)
SELECT
    HotelName,
    SUM(TotalPrice) AS HotelRevenue
    FROM CTE_BookingsTotal
GROUP BY HotelName
ORDER BY HotelRevenue DESC;

GO

-- =============================================================================
-- PROGRAMMABILITY PROGRAMMABILITY PROGRAMMABILITY PROGRAMMABILITY PROGRAMMABILI
-- =============================================================================

-- =============================================================================
-- PROBLEM 11: ROOMS WITH TOURISTS
-- =============================================================================

CREATE FUNCTION udf_RoomsWithTourists
(
    @name varchar(40)
)
RETURNS int
BEGIN
    DECLARE @totalTourists int;

    SELECT 
        @totalTourists = SUM(AdultsCount + ChildrenCount)
        FROM Bookings b
    JOIN Rooms r ON b.RoomId = r.Id
    WHERE r.Type = @name;

    RETURN @totalTourists;
END

GO

-- =============================================================================
-- PROBLEM 12: SEARCH FOR TOURISTS FROM A SPECIFIC COUNTRY
-- =============================================================================

CREATE PROCEDURE usp_SearchByCountry
(
    @Country nvarchar(50)
)
AS
BEGIN
    SELECT 
        T.Name,
        T.PhoneNumber,
        T.Email,
        COUNT(*) AS CountOfBookings
        FROM Tourists T
    JOIN Countries C ON T.CountryId = C.Id
    JOIN Bookings B ON B.TouristId = T.Id
    WHERE C.Name = @Country
    GROUP BY T.Name, T.PhoneNumber, T.Email
    ORDER BY T.Name, CountOfBookings DESC;
END

GO