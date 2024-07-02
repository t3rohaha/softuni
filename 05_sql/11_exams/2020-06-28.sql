-- =============================================================================
-- MSSQL Server Exam 28 Jun 2020 MSSQL Server Exam 28 Jun 2020 MSSQL Server Exam 
-- =============================================================================

-- =============================================================================
-- COLONIAL JOURNEY COLONIAL JOURNEY COLONIAL JOURNEY COLONIAL JOURNEY COLONIAL 
-- =============================================================================

-- =============================================================================
-- Problem 01: DDL
-- =============================================================================

PRINT('CREATING COLONIAL JOURNEY DATABASE');

CREATE DATABASE ColonialJourneyDB;
GO

USE ColonialJourneyDB;

CREATE TABLE Planets (
    Id int NOT NULL IDENTITY,
    [Name] varchar(30) NOT NULL,
    CONSTRAINT PK_Planets_Id PRIMARY KEY (Id)
);

CREATE TABLE Spaceports (
    Id int NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    PlanetId int NOT NULL,
    CONSTRAINT PK_Spaceports_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Spaceports_PlanetId FOREIGN KEY (PlanetId) REFERENCES Planets (Id)
);

CREATE TABLE Spaceships (
    Id int NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    Manufacturer varchar(30) NOT NULL,
    LightSpeedRate int NOT NULL DEFAULT 0,
    CONSTRAINT PK_Spaceships_Id PRIMARY KEY (Id)
);

CREATE TABLE Colonists (
    Id int NOT NULL IDENTITY,
    FirstName varchar(20) NOT NULL,
    LastName varchar(20) NOT NULL,
    Ucn varchar(10) NOT NULL,
    BirthDate date NOT NULL,
    CONSTRAINT PK_Colonists_Id PRIMARY KEY (Id),
    CONSTRAINT UQ_Colonists_Ucn UNIQUE (Ucn)
);

CREATE TABLE Journeys (
    Id int NOT NULL IDENTITY,
    JourneyStart datetime NOT NULL,
    JourneyEnd datetime NOT NULL,
    Purpose varchar(11),
    DestinationSpaceportId int NOT NULL,
    SpaceshipId int NOT NULL,
    CONSTRAINT PK_Journeys_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Journeys_DestinationSpaceportId FOREIGN KEY (DestinationSpaceportId) REFERENCES Spaceports (Id),
    CONSTRAINT FK_Journeys_SpaceshipId FOREIGN KEY (SpaceshipId) REFERENCES Spaceships (Id),
    CONSTRAINT CHK_Journeys_Purpose CHECK (Purpose IN ('Medical', 'Technical', 'Educational', 'Military'))
);

CREATE TABLE TravelCards (
    Id int NOT NULL IDENTITY,
    CardNumber varchar(10) NOT NULL,
    JobDuringJourney varchar(8),
    ColonistId int NOT NULL,
    JourneyId int NOT NULL,
    CONSTRAINT PK_TravelCards_Id PRIMARY KEY (Id),
    CONSTRAINT FK_TravelCards_ColonistId FOREIGN KEY (ColonistId) REFERENCES Colonists (Id),
    CONSTRAINT FK_TravelCards_JourneyId FOREIGN KEY (JourneyId) REFERENCES Journeys (Id),
    CONSTRAINT CHK_TravelCards_CardNumber CHECK (LEN(CardNumber) = 10),
    CONSTRAINT UQ_TravelCards_CardNumber UNIQUE (CardNumber),
    CONSTRAINT CHK_TravelCards_JobDuringJourney CHECK (JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook'))
);

GO

-- =============================================================================
-- DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML D
-- =============================================================================

-- =============================================================================
-- Problem 02: INSERT
-- =============================================================================

PRINT('INSERTING DATA INTO COLONIAL JOURNEY DATABASE');

INSERT INTO Planets
([Name])
VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn');

INSERT INTO Spaceships
([Name], Manufacturer, LightSpeedRate)
VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda', 4),
('Falcon9', 'SpaceX', 1),
('Bed', 'Vidolov', 6);

GO

-- =============================================================================
-- Problem 03: UPDATE
-- =============================================================================

PRINT('UPDATING SPACESHIPS');

UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12;

GO

-- =============================================================================
-- Problem 04: DELETE
-- =============================================================================

PRINT('DELETING JOURNEYS');

DELETE
FROM TravelCards
WHERE JourneyId IN (SELECT TOP(3) Id FROM Journeys);

DELETE TOP(3)
FROM Journeys;

GO

-- =============================================================================
-- QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERY
-- =============================================================================

-- =============================================================================
-- Problem 05: SELECT ALL MILITARY JOURNEYS
-- =============================================================================

PRINT('SELECTING ALL MILITARY JOURNEYS');

SELECT Id, JourneyStart, JourneyEnd
FROM Journeys;

-- =============================================================================
-- Problem 06: SELECT ALL PILOTS
-- =============================================================================

PRINT('SELECTING ALL PILOTS');

SELECT
    c.Id,
    CONCAT(FirstName, ' ', LastName) AS full_name
FROM Colonists c
JOIN TravelCards tc
ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY Id;

-- =============================================================================
-- Problem 07: COUNT COLONISTS ON TECHNICAL JOURNEY
-- =============================================================================

PRINT('COUNTING COLONISTS ON TECHNICAL JOURNEY');

SELECT COUNT(*) AS count
FROM Colonists c
JOIN TravelCards tc
ON c.Id = tc.ColonistId
JOIN Journeys j
ON tc.JourneyId = j.Id
WHERE j.Purpose = 'Technical';

-- =============================================================================
-- Problem 08: SELECT SPACESHIPS WITH PILOTS YOUNGER THAN 30
-- =============================================================================

PRINT('SELECTING SPACESHIPS WITH PILOTS YOUNGER THAT 30')

SELECT
    [Name],
    Manufacturer
FROM Spaceships s
JOIN Journeys j
ON j.SpaceshipId = s.Id
JOIN TravelCards tc
ON tc.JourneyId = j.Id
JOIN Colonists c
ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
    AND DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
ORDER BY s.Name;

-- =============================================================================
-- Problem 09: SELECT PLANETS AND THEIR JOURNEY COUNT
-- =============================================================================

PRINT('SELECTING PLANETS AND THEIR JOURNEY COUNT');

SELECT
    p.Name,
    COUNT(*) AS JourneysCount
FROM Journeys j
JOIN Spaceports sp
ON j.DestinationSpaceportId = sp.Id
JOIN Planets p
ON sp.PlanetId = p.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC, p.Name;

-- =============================================================================
-- Problem 10: SELECT SECOND OLDEST IMPORTANT COLONIST
-- =============================================================================