-- =============================================================================
-- MSSQL Server Exam 05 Dec 2023 MSSQL Server Exam 05 Dec 2023 MSSQL Server Exam 
-- =============================================================================

-- =============================================================================
-- RAILWAYS RAILWAYS RAILWAYS RAILWAYS RAILWAYS RAILWAYS RAILWAYS RAILWAYS RAILW
-- =============================================================================

-- =============================================================================
-- Problem 01: DDL
-- =============================================================================

CREATE DATABASE SoftUni_RailwaysDB;
GO

PRINT 'CREATING DATABASE...';

USE SoftUni_RailwaysDB;

CREATE TABLE Towns
(
    Id int IDENTITY,
    [Name] nvarchar(30) NOT NULL,
    CONSTRAINT PK_Towns_Id PRIMARY KEY (Id)
);

CREATE TABLE Trains
(
    Id int IDENTITY,
    HourOfDeparture varchar(5) NOT NULL,
    HourOfArrival varchar(5) NOT NULL,
    DepartureTownId int NOT NULL,
    ArrivalTownId int NOT NULL,
    CONSTRAINT PK_Trains_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Trains_DepartureTownId FOREIGN KEY (DepartureTownId) REFERENCES Towns(Id),
    CONSTRAINT FK_Trains_ArrivalTownId FOREIGN KEY (ArrivalTownId) REFERENCES Towns(Id)
);

CREATE TABLE RailwayStations
(
    Id int IDENTITY,
    [Name] varchar(50) NOT NULL,
    TownId int NOT NULL,
    CONSTRAINT PK_RailwayStations_Id PRIMARY KEY (Id),
    CONSTRAINT FK_RailwayStations_TownId FOREIGN KEY (TownId) REFERENCES Towns(Id)
);

CREATE TABLE TrainsRailwayStations
(
    TrainId int NOT NULL,
    RailwayStationId int NOT NULL,
    CONSTRAINT PK_TrainsRailwayStations_Id PRIMARY KEY (TrainId, RailwayStationId),
    CONSTRAINT FK_TrainsRailwayStations_TrainId FOREIGN KEY (TrainId) REFERENCES Trains(Id),
    CONSTRAINT FK_TrainsRailwayStations_RailwayStationId FOREIGN KEY (RailwayStationId) REFERENCES RailwayStations(Id),
);

CREATE TABLE Passengers
(
    Id int IDENTITY,
    [Name] nvarchar(80) NOT NULL,
    CONSTRAINT PK_Passengers_Id PRIMARY KEY (Id)
);

CREATE TABLE Tickets
(
    Id int IDENTITY,
    Price decimal(10, 2) NOT NULL,
    DateOfDeparture date NOT NULL,
    DateOfArrival date NOT NULL,
    TrainId int NOT NULL,
    PassengerId int NOT NULL,
    CONSTRAINT PK_Tickets_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Tickets_TrainId FOREIGN KEY (TrainId) REFERENCES Trains(Id),
    CONSTRAINT FK_Tickets_PassengerId FOREIGN KEY (PassengerId) REFERENCES Passengers(Id)
);

CREATE TABLE MaintenanceRecords
(
    Id int IDENTITY,
    DateOfMaintenance date NOT NULL,
    Details varchar(2000) NOT NULL,
    TrainId int NOT NULL,
    CONSTRAINT PK_MaintenanceRecords_Id PRIMARY KEY (Id),
    CONSTRAINT FK_MaintenanceRecords_TrainId FOREIGN KEY (TrainId) REFERENCES Trains(Id)
);

PRINT 'COMPLETE!'

GO

-- =============================================================================
-- DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML D
-- =============================================================================

-- =============================================================================
-- Problem 02: INSERT
-- =============================================================================

USE SoftUni_RailwaysDB;

PRINT 'INSERTING DATA...';

INSERT INTO Trains
(HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES
('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7),
('10:15', '12:15', 15, 5);

INSERT INTO TrainsRailwayStations
(TrainId, RailwayStationId)
VALUES
(36, 1), (36, 4), (36, 7), (36, 31), (36, 57), 
(37, 13), (37, 16), (37, 54), (37, 60),
(38, 10), (38, 22), (38, 50), (38, 52),
(39, 3), (39, 19), (39, 31), (39, 68),
(40, 7), (39, 13), (39, 41), (39, 52);

INSERT INTO Tickets
(Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES
(90.00, '2023-12-01', '2023-12-01', 36, 1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22);

PRINT 'COMPLETE!';

GO

-- =============================================================================
-- Problem 03: UPDATE
-- =============================================================================

USE SoftUni_RailwaysDB;

PRINT 'UPDATING TICKETS...';

UPDATE Tickets
SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
    DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE DateOfDeparture > '2023-10-31';

PRINT 'COMPLETE!';

GO

-- =============================================================================
-- Problem 04: DELETE
-- =============================================================================

USE SoftUni_RailwaysDB;

PRINT 'DELETING TRAINS...';

BEGIN TRY
    BEGIN TRANSACTION;

    DELETE tickets FROM Tickets
    JOIN Trains ON tickets.TrainId = trains.Id
    JOIN Towns ON trains.DepartureTownId = towns.Id
    WHERE towns.Name = 'Berlin';

    DELETE mr FROM MaintenanceRecords mr
    JOIN Trains ON mr.TrainId = trains.Id
    JOIN Towns ON trains.DepartureTownId = towns.Id
    WHERE towns.Name = 'Berlin';

    DELETE trs FROM TrainsRailwayStations trs
    JOIN Trains ON trs.TrainId = trains.Id
    JOIN Towns ON trains.DepartureTownId = towns.Id
    WHERE towns.Name = 'Berlin';

    DELETE trains FROM Trains 
    JOIN Towns ON trains.DepartureTownId = towns.Id
    WHERE towns.Name = 'Berlin';

    COMMIT TRANSACTION;
    PRINT 'COMPLETE!'
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'ERROR!'
END CATCH

GO

-- =============================================================================
-- QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERY
-- =============================================================================

-- =============================================================================
-- Problem 05: TICKETS BY PRICE AND DATE OF DEPARTURE
-- =============================================================================

USE SoftUni_RailwaysDB;

SELECT
    DateOfDeparture,
    Price AS TicketPrice
    FROM Tickets
ORDER BY Price, DateOfDeparture DESC;

GO

-- =============================================================================
-- Problem 06: PASSENGERS WITH THEIR TICKETS
-- =============================================================================

USE SoftUni_RailwaysDB;

SELECT 
    p.Name AS PassengerName,
    t.Price AS TicketPrice,
    t.DateOfDeparture,
    t.TrainId AS TrainId FROM tickets t
JOIN Passengers p ON t.PassengerId = p.Id
ORDER BY t.Price DESC, p.Name;

GO

-- =============================================================================
-- Problem 07: RAILWAY STATIONS WITHOUT PASSING TRAINS
-- =============================================================================

USE SoftUni_RailwaysDB;

SELECT 
    t.Name AS Town,
    rs.Name AS RailwayStation
    FROM RailwayStations rs
JOIN Towns t ON rs.TownId = t.Id
FULL JOIN TrainsRailwayStations trs ON trs.RailwayStationId = rs.Id
WHERE trs.TrainId IS NULL
ORDER BY t.Name, rs.Name;

GO

-- =============================================================================
-- Problem 08: FIRST 3 TRAINS BETWEEN 08:00 AND 08:59
-- =============================================================================

USE SoftUni_RailwaysDB;

SELECT TOP(3)
    trains.Id AS TrainId,
    trains.HourOfDeparture,
    tickets.Price AS TicketPrice,
    towns.Name AS Destination
    FROM Trains
JOIN Tickets ON tickets.TrainId = trains.Id
JOIN Towns ON trains.ArrivalTownId = towns.Id
WHERE tickets.Price > 50 AND
    SUBSTRING(trains.HourOfDeparture, 1, 2) = '08'
ORDER BY tickets.Price;

GO

-- =============================================================================
-- Problem 09: COUNT OF PASSENGERS PAID MORE THAN AVERAGE WITH ARRIVAL TOWNS
-- =============================================================================

USE SoftUni_RailwaysDB;

SELECT
    [Name] AS TownName,
    COUNT(*) AS PassangersCount
    FROM Towns
JOIN Trains ON trains.ArrivalTownId = towns.id
JOIN Tickets ON tickets.TrainId = trains.Id
WHERE tickets.Price > 76.99
GROUP BY towns.Name
ORDER BY TownName;

GO

-- =============================================================================
-- Problem 10: MAINTENANCE INSPECTION WITH TOWN AND STATION
-- =============================================================================

USE SoftUni_RailwaysDB;

SELECT
    t.Id AS TrainId,
    towns.Name AS DepartureTown,
    mr.Details
    FROM MaintenanceRecords mr
JOIN Trains t ON t.Id = mr.TrainId
JOIN Towns ON towns.Id = t.DepartureTownId
WHERE PATINDEX('%inspection%', mr.Details) != 0
ORDER BY t.Id;

GO

-- =============================================================================
-- Problem 11: TOWNS WITH TRAINS
-- =============================================================================

USE SoftUni_RailwaysDB;
GO

CREATE FUNCTION udf_TownsWithTrains
(
    @name nvarchar(30)
)
RETURNS int
AS
BEGIN
    DECLARE @result int;

    SELECT @result = COUNT(*) FROM Trains
    JOIN Towns ON trains.DepartureTownId = towns.Id
    WHERE towns.Name = @name;

    SELECT @result += COUNT(*) FROM Trains
    JOIN Towns ON trains.ArrivalTownId = towns.Id
    WHERE towns.Name = @name;

    RETURN @result;
END

GO

-- =============================================================================
-- Problem 12: SEARCH PASSENGER TRAVELLING TO SPECIFIC TOWN
-- =============================================================================

USE SoftUni_RailwaysDB;
GO

CREATE PROCEDURE usp_SearchByTown
(
    @townName nvarchar(30)
)
AS
BEGIN
    SELECT
        passengers.Name AS PassengerName,
        tickets.DateOfDeparture,
        trains.HourOfDeparture
        FROM Passengers
    JOIN Tickets ON tickets.PassengerId = passengers.Id
    JOIN Trains ON tickets.TrainId = trains.Id
    JOIN Towns ON trains.ArrivalTownId = towns.Id
    WHERE towns.Name = @townName
    ORDER BY tickets.DateOfDeparture DESC, passengers.Name;
END

GO