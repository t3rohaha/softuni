-- =============================================================================
-- DATA DEFINITION DATA DEFINITION DATA DEFINITION DATA DEFINITION DATA DEFINITI
-- =============================================================================

-- =============================================================================
-- MINIONS DATABASE MINIONS DATABASE MINIONS DATABASE MINIONS DATABASE MINIONS D
-- =============================================================================

-- =============================================================================
-- Problem 01: CREATE DATABASE.
-- =============================================================================

CREATE DATABASE Minions;
GO

USE Minions;

-- =============================================================================
-- Problem 02: CREATE TABLES.
-- =============================================================================

CREATE TABLE [Minions]
(
    Id int PRIMARY KEY,
    Name nvarchar,
    Age int
);

CREATE TABLE [Towns]
(
    Id int PRIMARY KEY,
    Name nvarchar
);

-- =============================================================================
-- Problem 03: ALTER.
-- =============================================================================

ALTER TABLE [Minions]
ADD TownId int FOREIGN KEY REFERENCES Towns(Id);

ALTER TABLE [Minions]
ALTER COLUMN Name nvarchar(20);

ALTER TABLE [Towns]
ALTER COLUMN Name nvarchar(20);

-- =============================================================================
-- Problem 04: INSERT.
-- =============================================================================

INSERT INTO [Minions]
(Id, Name, Age, TownId)
VALUES
(1, 'Frank', 23, 1),
(2, 'John', 24, 1),
(3, 'Ashley', 22, 2),
(4, 'Joe', 22, 2);

INSERT INTO [Towns]
(Id, Name)
VALUES
(1, 'London'),
(2, 'Manchester');

-- =============================================================================
-- Problem 05: TRUNCATE.
-- =============================================================================

TRUNCATE TABLE [Minions];

-- =============================================================================
-- Problem 06: DROP.
-- =============================================================================

DROP TABLE [Minions];

DROP TABLE [Towns];

-- =============================================================================
-- Problem 07: CREATE, ALTER, INSERT.
-- =============================================================================

CREATE TABLE [People]
(
    Id int PRIMARY KEY IDENTITY,
    Name nvarchar(200) NOT NULL,
    Picture varbinary(MAX),
    Height decimal(3, 2),
    Weight decimal(5, 2),
    Gender char(1) NOT NULL,
    Birthdate date NOT NULL,
    Biography varchar(MAX)
);

ALTER TABLE [People]
ADD CONSTRAINT CHK_People_Picture_2MB CHECK (DATALENGTH(Picture) <= 2097152);

ALTER TABLE [People]
ADD CONSTRAINT CHK_People_Gender_Values CHECK (Gender IN ('m', 'f'));

INSERT INTO [People]
(Name, Gender, Birthdate)
VALUES
('Frank Lampard', 'm', '1978/06/20'),
('Ashley Cole', 'm', '1980/12/20'),
('Joe Cole', 'm', '1981/11/08'),
('Cole Palmer', 'm', '2002/04/18'),
('John Terry', 'm', '1980/12/07');

-- =============================================================================
-- Problem 08: CREATE.
-- =============================================================================

CREATE TABLE [Users]
(
    Id int PRIMARY KEY IDENTITY,
    Username varchar(30) NOT NULL UNIQUE,
    Password varchar(26) NOT NULL,
    ProfilePicture varbinary(MAX),
    LastLogin datetime2,
    IsDeleted bit DEFAULT(0) NOT NULL
);

ALTER TABLE [Users]
ADD CONSTRAINT CHK_Users_ProfilePicture_900kb
CHECK (DATALENGTH(ProfilePicture) <= 921600);

INSERT INTO [Users]
(Username, Password)
VALUES
('John_Terry', '12345'),
('Frank_Lampard', '12345'),
('Didier_Drogba', '12345'),
('Diego_Costa', '12345'),
('Cole_Palmer', '12345');

TRUNCATE TABLE [Users];

-- =============================================================================
-- Problem 09: ALTER PK.
-- =============================================================================

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC07DBE3395A; 

ALTER TABLE [Users]
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username);

-- =============================================================================
-- Problem 10: CHECK CONSTRAINT.
-- =============================================================================

ALTER TABLE [Users]
ADD CONSTRAINT CHK_Users_Password_MinLength CHECK (DATALENGTH(Password) > 4);

-- =============================================================================
-- Problem 11: DEFAULT VALUE.
-- =============================================================================

ALTER TABLE [Users]
DROP CONSTRAINT DF__Users__IsDeleted__4D94879B;

ALTER TABLE [Users]
ADD CONSTRAINT DF_Users_IsDeleted_False DEFAULT 0 FOR IsDeleted;

ALTER TABLE [Users]
ADD CONSTRAINT DF_Users_LastLogin_CURRENT_TIMESTAMP
DEFAULT CURRENT_TIMESTAMP FOR LastLogin;

-- =============================================================================
-- Problem 12: UNIQUE CONSTRAINT.
-- =============================================================================

ALTER TABLE [Users]
DROP CONSTRAINT PK_Users;

ALTER TABLE [Users]
ADD CONSTRAINT PK_Users_Id PRIMARY KEY (Id);

ALTER TABLE [Users]
DROP CONSTRAINT UQ__Users__536C85E496D7177D;

ALTER TABLE [Users]
ADD CONSTRAINT UQ_Users_Username UNIQUE (Username);

-- =============================================================================
-- MOVIES DATABASE MOVIES DATABASE MOVIES DATABASE MOVIES DATABASE MOVIES DATABA
-- =============================================================================

CREATE DATABASE [Movies];
GO

USE [Movies];
GO

CREATE TABLE [Directors]
(
    Id int IDENTITY, 
    Name nvarchar(50) NOT NULL,
    Notes nvarchar(4000)
);

CREATE TABLE [Genres]
(
    Id int IDENTITY,
    Name nvarchar(50) NOT NULL,
    Notes nvarchar(4000)
);

CREATE TABLE [Categories]
(
    Id int IDENTITY,
    Name nvarchar(50) NOT NULL,
    Notes nvarchar(4000)
);

CREATE TABLE [Movies]
(
    Id int IDENTITY,
    Title nvarchar(100) NOT NULL,
    CopyrightYear date NOT NULL,
    Length time NOT NULL,
    DirectorId int NOT NULL,
    GenreId int NOT NULL,
    CategoryId int NOT NULL,
    Rating tinyint,
    Notes nvarchar(4000)
);

ALTER TABLE [Directors] ADD CONSTRAINT PK_Directors_Id PRIMARY KEY (Id);
ALTER TABLE [Genres] ADD CONSTRAINT PK_Genres_Id PRIMARY KEY (Id);
ALTER TABLE [Categories] ADD CONSTRAINT PK_Categories_Id PRIMARY KEY (Id);
ALTER TABLE [Movies] ADD CONSTRAINT PK_Movies_Id PRIMARY KEY (Id);

ALTER TABLE [Movies] ADD CONSTRAINT FK_MovieDirector
FOREIGN KEY (DirectorId) REFERENCES [Directors] (Id);
ALTER TABLE [Movies] ADD CONSTRAINT FK_MovieGenre
FOREIGN KEY (GenreId) REFERENCES [Genres] (Id);
ALTER TABLE [Movies] ADD CONSTRAINT FK_MovieCategory
FOREIGN KEY (CategoryId) REFERENCES [Categories] (Id);

ALTER TABLE [Movies] ADD CONSTRAINT DF_Movies_Rating_0 DEFAULT 0 FOR Rating;

INSERT INTO [Directors]
(Name)
VALUES 
('Steven Spielberg'),
('Alfred Hitchcock'),
('Martin Scorsese'),
('Stanley Kubrick'),
('Quentin Tarantino');

INSERT INTO [Genres]
(Name)
VALUES
('Adventure'),
('Thriller'),
('Crime'),
('Science Fiction'),
('Action');

INSERT INTO [Categories]
(Name)
VALUES
('Music'),
('Sport'),
('Art'),
('Science'),
('History');

INSERT INTO [Movies]
(Title, CopyrightYear, Length, DirectorId, GenreId, CategoryId)
VALUES
('Jurassic Park', '1993', '02:07:00', 1, 4, 3),
('Psycho', '1960', '01:49:00', 2, 2, 3),
('Goodfellas', '1990', '02:26:00', 3, 3, 5),
('2001: A Space Odyssey', '1968', '02:29:00', 4, 4, 3),
('Pulp Fiction', '1994', '02:34:00', 5, 3, 3);

-- =============================================================================
-- CAR RENTAL DATABASE CAR RENTAL DATABASE CAR RENTAL DATABASE CAR RENTAL DATABA
-- =============================================================================

CREATE DATABASE [CarRental];
GO

USE [CarRental];

CREATE TABLE [Categories]
(
    Id int IDENTITY,
    CategoryName nvarchar(50) NOT NULL,
    DailyRate smallint NOT NULL,
    WeeklyRate smallint NOT NULL,
    MonthlyRate smallint NOT NULL,
    WeekendRate smallint NOT NULL,
);

CREATE TABLE [Cars]
(
    Id int IDENTITY,
    PlateNumber char(8) NOT NULL,
    Manufacturer varchar(50) NOT NULL,
    Model varchar(50) NOT NULL,
    CarYear char(4) NOT NULL,
    Doors tinyint NOT NULL,
    Available bit NOT NULL,
    CategoryId int NOT NULL,
    Picture varbinary(max),
    Condition varchar(50)
);

CREATE TABLE [Employees]
(
    Id int IDENTITY,
    FirstName varchar(50) NOT NULL,
    LastName varchar(50) NOT NULL,
    Title varchar(50),
    Notes varchar(400)
);

CREATE TABLE [Customers]
(
    Id int IDENTITY,
    DriverLicenseNumber char(10) NOT NULL,
    FullName varchar(100) NOT NULL,
    Address varchar(200) NOT NULL,
    City varchar(100) NOT NULL,
    ZIP char(4) NOT NULL,
    Notes varchar(400)
);

CREATE TABLE [RentalOrders]
(
    Id int IDENTITY,
    EmployeeId int NOT NULL,
    CustomerId int NOT NULL,
    CarId int NOT NULL,
    TankLevel tinyint NOT NULL,
    KilometrageStart int NOT NULL,
    KilometrageEnd int,
    TotalKilomentrage int,
    StartDate date NOT NULL,
    EndDate date NOT NULL,
    TotalDays tinyint NOT NULL,
    RateApplied smallint NOT NULL,
    TaxRate smallint NOT NULL,
    OrderStatus varchar(50),
    Notes varchar(400)
);

ALTER TABLE [Categories] ADD CONSTRAINT PK_Categories_Id PRIMARY KEY (Id);
ALTER TABLE [Cars] ADD CONSTRAINT PK_Cars_Id PRIMARY KEY (Id);
ALTER TABLE [Employees] ADD CONSTRAINT PK_Employees_Id PRIMARY KEY (Id);
ALTER TABLE [Customers] ADD CONSTRAINT PK_Customers_Id PRIMARY KEY (Id);
ALTER TABLE [RentalOrders] ADD CONSTRAINT PK_RentalOrders_Id PRIMARY KEY (Id);

ALTER TABLE [RentalOrders] ADD CONSTRAINT FK_RentalOrder_EmployeeId
FOREIGN KEY (EmployeeId) REFERENCES [Employees] (Id);
ALTER TABLE [RentalOrders] ADD CONSTRAINT FK_RentalOrder_CustomerId
FOREIGN KEY (CustomerId) REFERENCES [Customers] (Id);
ALTER TABLE [RentalOrders] ADD CONSTRAINT FK_RentalOrder_CarId
FOREIGN KEY (CarId) REFERENCES [Cars] (Id);
ALTER TABLE [Cars] ADD CONSTRAINT FK_Cars_CategoryId
FOREIGN KEY (CategoryId) REFERENCES [Categories] (Id);

INSERT INTO [Categories]
(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Economy', 25, 150, 500, 60),
('Compact', 30, 180, 600, 70),
('Standard', 35, 210, 700, 80);

INSERT INTO [Cars]
(PlateNumber, Manufacturer, Model, CarYear, Doors, Available, CategoryId)
VALUES
('CA1234AB', 'Toyota', 'Corolla', 2019, 4, 1, 2),
('VA5678CD', 'Honda', 'Civic', 2020, 4, 1, 2),
('PB9012EF', 'Ford', 'Focus', 2018, 4, 1, 2);

INSERT INTO [Employees]
(FirstName, LastName)
VALUES
('Frank', 'Lampard'),
('John', 'Terry'),
('Didier', 'Drogba');

INSERT INTO [Customers]
(DriverLicenseNumber, FullName, Address, City, ZIP)
VALUES
('AB123456CA', 'John Smith', '123 Main Street', 'Sofia', '1000'),
('CD789012DA', 'Alice Johnson', '456 Elm Avenue', 'Plovdiv', '4000'),
('EF345678EA', 'Michael Brown', '789 Oak Road', 'Varna', '9000'),
('GH901234FA', 'Emma Wilson', '101 Pine Street', 'Burgas', '8000'),
('IJ567890GA', 'David Garcia', '202 Maple Lane', 'Ruse', '7000');

INSERT INTO [RentalOrders]
(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, StartDate, EndDate, TotalDays, RateApplied, TaxRate)
VALUES
(1, 1, 1, 75, 10000, '2024-05-01', '2024-05-05', 5, 30, 0.20),
(2, 2, 2, 80, 12000, '2024-05-02', '2024-05-06', 4, 40, 0.20),
(3, 3, 3, 70, 8000, '2024-05-03', '2024-05-07', 4, 35, 0.20);

-- =============================================================================
-- HOTEL DATABASE HOTEL DATABASE HOTEL DATABASE HOTEL DATABASE HOTEL DATABASE HO
-- =============================================================================

CREATE DATABASE Hotel;
GO

USE Hotel;

CREATE TABLE [Employees]
(
    Id int IDENTITY,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    Title nvarchar(100) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_Employees_Id PRIMARY KEY (Id)
);

CREATE TABLE [Customers]
(
    AccountNumber char(10) NOT NULL,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    PhoneNumber char(13) NOT NULL,
    EmergencyName nvarchar(100) NOT NULL,
    EmergencyNumber char(13) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_Customers_AccountNumber PRIMARY KEY (AccountNumber)
);

CREATE TABLE [RoomStatus]
(
    RoomStatus nvarchar(50) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_RoomStatus_RoomStatus PRIMARY KEY (RoomStatus)
);

CREATE TABLE [RoomTypes]
(
    RoomType nvarchar(50) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_RoomTypes_RoomType PRIMARY KEY (RoomType)
);

CREATE TABLE [BedTypes]
(
    BedType nvarchar(50) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_BedTypes_BedType PRIMARY KEY (BedType)
);

CREATE TABLE [Rooms]
(
    RoomNumber char(3) NOT NULL,
    RoomType nvarchar(50) NOT NULL,
    BedType nvarchar(50) NOT NULL,
    RoomStatus nvarchar(50) NOT NULL,
    Rate decimal(10, 2) NOT NULL,
    Notes nvarchar(500)
    CONSTRAINT PK_Rooms_RoomNumber PRIMARY KEY (RoomNumber),
    CONSTRAINT FK_Rooms_RoomType FOREIGN KEY (RoomType) REFERENCES [RoomTypes] (RoomType),
    CONSTRAINT FK_Rooms_BedType FOREIGN KEY (BedType) REFERENCES [BedTypes] (BedType),
    CONSTRAINT FK_Rooms_RoomStatus FOREIGN KEY (RoomStatus) REFERENCES [RoomStatus] (RoomStatus),
);

CREATE TABLE [Payments]
(
    Id int IDENTITY,
    EmployeeId int NOT NULL,
    AccountNumber char(10) NOT NULL,
    PaymentDate date NOT NULL,
    FirstDateOccupied date NOT NULL,
    LastDateOccupied date NOT NULL,
    TotalDays tinyint NOT NULL,
    AmountCharged decimal(10, 2) NOT NULL,
    TaxRate decimal(3, 2) NOT NULL,
    TaxAmount decimal(10, 2) NOT NULL,
    PaymentTotal decimal(10, 2) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_Payments_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Payments_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES [Employees] (Id),
    CONSTRAINT FK_Payments_AccountNumber FOREIGN KEY (AccountNumber) REFERENCES [Customers] (AccountNumber),
    CONSTRAINT CHK_Payments_TaxRate_Range CHECK (TaxRate BETWEEN 0.00 AND 0.99)
);

CREATE TABLE [Occupancies]
(
    Id int IDENTITY,
    EmployeeId int NOT NULL,
    AccountNumber char(10) NOT NULL,
    RoomNumber char(3) NOT NULL,
    RateApplied decimal(10, 2) NOT NULL,
    DateOccupied date NOT NULL,
    PhoneCharge decimal(10, 2) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_Occupancies_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Occupancies_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES [Employees] (Id),
    CONSTRAINT FK_Occupancies_AccountNumber FOREIGN KEY (AccountNumber) REFERENCES [Customers] (AccountNumber),
    CONSTRAINT FK_Occupancies_RoomNumber FOREIGN KEY (RoomNumber) REFERENCES [Rooms] (RoomNumber),
);

INSERT INTO [Employees]
(FirstName, LastName, Title, Notes) 
VALUES 
('John', 'Doe', 'Manager', 'Experienced in hotel management'),
('Alice', 'Smith', 'Receptionist', 'Friendly and efficient'),
('David', 'Johnson', 'Housekeeper', 'Detail-oriented and reliable');

INSERT INTO [Customers]
(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) 
VALUES 
('100001', 'Michael', 'Brown', '1234567890', 'Sarah Brown', '0987654321', 'Frequent guest, loyalty program member'),
('100002', 'Emma', 'Wilson', '2345678901', 'John Wilson', '9876543210', 'Allergic to peanuts'),
('100003', 'Sophia', 'Jones', '3456789012', 'Robert Jones', '8765432109', 'Requires wheelchair-accessible room');

INSERT INTO [RoomStatus]
(RoomStatus, Notes) 
VALUES 
('Available', 'Ready for occupancy'),
('Occupied', 'Currently occupied by guest'),
('Under Maintenance', 'Room is undergoing maintenance');

INSERT INTO [RoomTypes]
(RoomType, Notes) 
VALUES 
('Standard', 'Basic room with standard amenities'),
('Suite', 'Luxurious suite with extra space and amenities'),
('Deluxe', 'High-end room with premium amenities');

INSERT INTO [BedTypes]
(BedType, Notes) 
VALUES 
('Single', 'One single bed'),
('Double', 'One double bed'),
('King', 'One king-size bed');

INSERT INTO [Rooms]
(RoomNumber, RoomType, BedType, RoomStatus, Rate, Notes) 
VALUES 
('101', 'Standard', 'Double', 'Available', 120.00, 'Sea view, non-smoking'),
('102', 'Suite', 'King', 'Occupied', 250.00, 'Mountain view, non-smoking'),
('103', 'Deluxe', 'King', 'Available', 200.00, 'Includes living area and kitchenette');

INSERT INTO [Payments]
(EmployeeId, AccountNumber, PaymentDate, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) 
VALUES 
(1, '100001', '2024-05-20', '2024-05-17', '2024-05-20', 3, 360.00, 0.10, 36.00, 396.00, 'Room payment for 3 nights'),
(2, '100002', '2024-05-21', '2024-05-18', '2024-05-22', 4, 500.00, 0.10, 50.00, 550.00, 'Room payment for 4 nights'),
(3, '100003', '2024-05-22', '2024-05-19', '2024-05-23', 3, 600.00, 0.10, 60.00, 660.00, 'Room payment for 3 nights');

INSERT INTO [Occupancies]
(EmployeeId, AccountNumber, RoomNumber, RateApplied, DateOccupied, PhoneCharge, Notes) 
VALUES 
(1, '100001', '101', 120.00, '2024-05-17', 10.00, 'Guest made local calls'),
(2, '100002', '102', 250.00, '2024-05-18', 20.00, 'Guest made international calls'),
(3, '100003', '103', 200.00, '2024-05-19', 0.00, 'No phone usage');

SELECT * FROM [Occupancies];

-- =============================================================================
-- SOFTUNI DATABASE SOFTUNI DATABASE SOFTUNI DATABASE SOFTUNI DATABASE SOFTUNI D
-- =============================================================================

CREATE DATABASE [SoftUni];
GO

USE [SoftUni];

CREATE TABLE [Towns]
(
    Id int IDENTITY,
    Name varchar(50) NOT NULL,
    CONSTRAINT PK_Towns_Id PRIMARY KEY (Id)
);

CREATE TABLE [Addresses]
(
    Id int IDENTITY,
    TownId int NOT NULL,
    AddressText varchar(200) NOT NULL,
    CONSTRAINT PK_Addresses_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Addresses_TownId FOREIGN KEY (TownId) REFERENCES [Towns] (Id)
);

CREATE TABLE [Departments]
(
    Id int IDENTITY,
    Name varchar(100) NOT NULL,
    CONSTRAINT PK_Departments_Id PRIMARY KEY (Id)
);

CREATE TABLE [Employees]
(
    Id int IDENTITY,
    FirstName varchar(50) NOT NULL,
    MiddleName varchar(50),
    LastName varchar(50) NOT NULL,
    JobTitle varchar(100) NOT NULL,
    HireDate date NOT NULL,
    Salary decimal(10, 2) NOT NULL,
    DepartmentId int NOT NULL,
    AddressId int NOT NULL,
    CONSTRAINT PK_Employees_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Employees_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES [Departments] (Id),
    CONSTRAINT FK_Employees_AddressId FOREIGN KEY (AddressId) REFERENCES [Addresses] (Id)
);

-- =============================================================================
-- Problem 17: BACKUP DATABASE
-- =============================================================================

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

-- =============================================================================
-- SOFTUNI DATABASE SOFTUNI DATABASE SOFTUNI DATABASE SOFTUNI DATABASE SOFTUNI D
-- =============================================================================

-- =============================================================================
-- Problem 18: INSERT
-- =============================================================================

USE [SoftUni];

INSERT INTO [Towns]
(Name)
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas'),
('Ruse');

INSERT INTO [Addresses]
(TownId, AddressText)
VALUES
(1, '123 Main Street'),
(2, '456 Elm Avenue'),
(3, '789 Oak Road'),
(4, '101 Pine Street'),
(5, '202 Maple Lane');

INSERT INTO [Departments]
(Name)
VALUES
('Software Development'),
('Engineering'),
('Quality Assurance'),
('Sales'),
('Marketing');

INSERT INTO [Employees]
(FirstName, MiddleName, LastName, JobTitle, HireDate, Salary, DepartmentId, AddressId)
VALUES
('Frank', NULL, 'Lampard', '.NET Developer', '2020-01-15', 60000.00, 1, 1),
('John', NULL, 'Terry', 'Senior Engineer', '2021-03-20', 45000.00, 2, 2),
('Didier', NULL, 'Drogba', 'Intern', '2019-07-10', 55000.00, 3, 3),
('Joe', NULL, 'Cole', 'CEO', '2020-11-05', 50000.00, 4, 4),
('Ashley', NULL, 'Cole', 'Intern', '2022-02-28', 60000.00, 5, 5);

-- =============================================================================
-- Problem 19: SELECT
-- =============================================================================

SELECT * FROM [Towns];

SELECT * FROM [Departments];

SELECT * FROM [Employees];

-- =============================================================================
-- Problem 20: ORDER
-- =============================================================================

SELECT * FROM [Towns]
ORDER BY Name;

SELECT * FROM [Departments]
ORDER BY Name;

SELECT * FROM [Employees]
ORDER BY Salary DESC;

-- =============================================================================
-- Problem 21: SELECT
-- =============================================================================

SELECT Name FROM [Towns]
ORDER BY Name;

SELECT Name FROM [Departments]
ORDER BY Name;

SELECT FirstName, LastName, JobTitle, Salary FROM [Employees]
ORDER BY Salary DESC;

-- =============================================================================
-- Problem 21: UPDATE
-- =============================================================================

-- View Salary before increase.
SELECT FirstName, LastName, Salary FROM [Employees];

-- Increase Salary by 10%.
UPDATE [Employees] SET Salary = Salary * 1.1;

-- View Salary after increase.
SELECT FirstName, LastName, Salary FROM [Employees];

-- =============================================================================
-- HOTEL DATABASE HOTEL DATABASE HOTEL DATABASE HOTEL DATABASE HOTEL DATABASE HO
-- =============================================================================

USE [Hotel];

-- =============================================================================
-- Problem 23: UPDATE
-- =============================================================================

-- Get Tax rate before decrease.
SELECT Id, TaxRate FROM [Payments]
ORDER BY TaxRate DESC;

-- The operation is not applied as expected because of TaxRate data type
-- precision.
UPDATE [Payments] SET TaxRate = TaxRate - (TaxRate * 0.03);

-- Get Tax rate after decrease.
SELECT Id, TaxRate FROM [Payments]
ORDER BY TaxRate DESC;

-- =============================================================================
-- Problem 24: TRUNCATE
-- =============================================================================

-- View before truncate.
SELECT * FROM Occupancies;

TRUNCATE TABLE Occupancies;

-- View after truncate.
SELECT * FROM Occupancies;