CREATE DATABASE CarRental;
GO

USE CarRental;
GO

CREATE TABLE Categories
(
    Id int IDENTITY,
    CategoryName nvarchar(50) NOT NULL,
    DailyRate smallint NOT NULL,
    WeeklyRate smallint NOT NULL,
    MonthlyRate smallint NOT NULL,
    WeekendRate smallint NOT NULL,
);
GO

CREATE TABLE Cars
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
GO

CREATE TABLE Employees
(
    Id int IDENTITY,
    FirstName varchar(50) NOT NULL,
    LastName varchar(50) NOT NULL,
    Title varchar(50),
    Notes varchar(400)
);
GO

CREATE TABLE Customers
(
    Id int IDENTITY,
    DriverLicenseNumber char(10) NOT NULL,
    FullName varchar(100) NOT NULL,
    Address varchar(200) NOT NULL,
    City varchar(100) NOT NULL,
    ZIP char(4) NOT NULL,
    Notes varchar(400)
);
GO

CREATE TABLE RentalOrders
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
GO

ALTER TABLE Categories ADD CONSTRAINT PK_Categories_Id PRIMARY KEY (Id);
ALTER TABLE Cars ADD CONSTRAINT PK_Cars_Id PRIMARY KEY (Id);
ALTER TABLE Employees ADD CONSTRAINT PK_Employees_Id PRIMARY KEY (Id);
ALTER TABLE Customers ADD CONSTRAINT PK_Customers_Id PRIMARY KEY (Id);
ALTER TABLE RentalOrders ADD CONSTRAINT PK_RentalOrders_Id PRIMARY KEY (Id);
GO

ALTER TABLE RentalOrders ADD CONSTRAINT FK_RentalOrder_EmployeeId
FOREIGN KEY (EmployeeId) REFERENCES Employees (Id);
ALTER TABLE RentalOrders ADD CONSTRAINT FK_RentalOrder_CustomerId
FOREIGN KEY (CustomerId) REFERENCES Customers (Id);
ALTER TABLE RentalOrders ADD CONSTRAINT FK_RentalOrder_CarId
FOREIGN KEY (CarId) REFERENCES Cars (Id);
GO

ALTER TABLE Cars ADD CONSTRAINT FK_Cars_CategoryId
FOREIGN KEY (CategoryId) REFERENCES Categories (Id);
GO

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate,
    WeekendRate)
VALUES
('Economy', 25, 150, 500, 60),
('Compact', 30, 180, 600, 70),
('Standard', 35, 210, 700, 80);
GO

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, Doors, Available,
    CategoryId)
VALUES
('CA1234AB', 'Toyota', 'Corolla', 2019, 4, 1, 2),
('VA5678CD', 'Honda', 'Civic', 2020, 4, 1, 2),
('PB9012EF', 'Ford', 'Focus', 2018, 4, 1, 2);
GO

INSERT INTO Employees (FirstName, LastName)
VALUES
('Frank', 'Lampard'),
('John', 'Terry'),
('Didier', 'Drogba');
GO

INSERT INTO Customers (DriverLicenseNumber, FullName, Address, City, ZIP)
VALUES
('AB123456CA', 'John Smith', '123 Main Street', 'Sofia', '1000'),
('CD789012DA', 'Alice Johnson', '456 Elm Avenue', 'Plovdiv', '4000'),
('EF345678EA', 'Michael Brown', '789 Oak Road', 'Varna', '9000'),
('GH901234FA', 'Emma Wilson', '101 Pine Street', 'Burgas', '8000'),
('IJ567890GA', 'David Garcia', '202 Maple Lane', 'Ruse', '7000');
GO

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel,
    KilometrageStart, StartDate, EndDate, TotalDays, RateApplied, TaxRate)
VALUES
(1, 1, 1, 75, 10000, '2024-05-01', '2024-05-05', 5, 30, 0.20),
(2, 2, 2, 80, 12000, '2024-05-02', '2024-05-06', 4, 40, 0.20),
(3, 3, 3, 70, 8000, '2024-05-03', '2024-05-07', 4, 35, 0.20);
GO