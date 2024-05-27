CREATE DATABASE Hotel;
GO
USE Hotel;
GO

CREATE TABLE Employees
(
    Id int IDENTITY,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    Title nvarchar(100) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_Employees_Id PRIMARY KEY (Id)
);
GO

CREATE TABLE Customers
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
GO

CREATE TABLE RoomStatus
(
    RoomStatus nvarchar(50) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_RoomStatus_RoomStatus PRIMARY KEY (RoomStatus)
);
GO

CREATE TABLE RoomTypes
(
    RoomType nvarchar(50) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_RoomTypes_RoomType PRIMARY KEY (RoomType)
);
GO

CREATE TABLE BedTypes
(
    BedType nvarchar(50) NOT NULL,
    Notes nvarchar(500),
    CONSTRAINT PK_BedTypes_BedType PRIMARY KEY (BedType)
);
GO

CREATE TABLE Rooms
(
    RoomNumber char(3) NOT NULL,
    RoomType nvarchar(50) NOT NULL,
    BedType nvarchar(50) NOT NULL,
    RoomStatus nvarchar(50) NOT NULL,
    Rate decimal(10, 2) NOT NULL,
    Notes nvarchar(500)
    CONSTRAINT PK_Rooms_RoomNumber PRIMARY KEY (RoomNumber),
    CONSTRAINT FK_Rooms_RoomType FOREIGN KEY (RoomType) REFERENCES RoomTypes (RoomType),
    CONSTRAINT FK_Rooms_BedType FOREIGN KEY (BedType) REFERENCES BedTypes (BedType),
    CONSTRAINT FK_Rooms_RoomStatus FOREIGN KEY (RoomStatus) REFERENCES RoomStatus (RoomStatus),
);
GO

CREATE TABLE Payments
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
    CONSTRAINT FK_Payments_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
    CONSTRAINT FK_Payments_AccountNumber FOREIGN KEY (AccountNumber) REFERENCES Customers (AccountNumber),
    CONSTRAINT CHK_Payments_TaxRate_Range CHECK (TaxRate BETWEEN 0.00 AND 0.99)
);
GO

CREATE TABLE Occupancies
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
    CONSTRAINT FK_Occupancies_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
    CONSTRAINT FK_Occupancies_AccountNumber FOREIGN KEY (AccountNumber) REFERENCES Customers (AccountNumber),
    CONSTRAINT FK_Occupancies_RoomNumber FOREIGN KEY (RoomNumber) REFERENCES Rooms (RoomNumber),
);
GO

INSERT INTO Employees (FirstName, LastName, Title, Notes) 
VALUES 
('John', 'Doe', 'Manager', 'Experienced in hotel management'),
('Alice', 'Smith', 'Receptionist', 'Friendly and efficient'),
('David', 'Johnson', 'Housekeeper', 'Detail-oriented and reliable');
GO

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) 
VALUES 
('100001', 'Michael', 'Brown', '1234567890', 'Sarah Brown', '0987654321', 'Frequent guest, loyalty program member'),
('100002', 'Emma', 'Wilson', '2345678901', 'John Wilson', '9876543210', 'Allergic to peanuts'),
('100003', 'Sophia', 'Jones', '3456789012', 'Robert Jones', '8765432109', 'Requires wheelchair-accessible room');
GO

INSERT INTO RoomStatus (RoomStatus, Notes) 
VALUES 
('Available', 'Ready for occupancy'),
('Occupied', 'Currently occupied by guest'),
('Under Maintenance', 'Room is undergoing maintenance');
GO

INSERT INTO RoomTypes (RoomType, Notes) 
VALUES 
('Standard', 'Basic room with standard amenities'),
('Suite', 'Luxurious suite with extra space and amenities'),
('Deluxe', 'High-end room with premium amenities');
GO

INSERT INTO BedTypes (BedType, Notes) 
VALUES 
('Single', 'One single bed'),
('Double', 'One double bed'),
('King', 'One king-size bed');
GO

INSERT INTO Rooms (RoomNumber, RoomType, BedType, RoomStatus, Rate, Notes) 
VALUES 
('101', 'Standard', 'Double', 'Available', 120.00, 'Sea view, non-smoking'),
('102', 'Suite', 'King', 'Occupied', 250.00, 'Mountain view, non-smoking'),
('103', 'Deluxe', 'King', 'Available', 200.00, 'Includes living area and kitchenette');
GO

INSERT INTO Payments (EmployeeId, AccountNumber, PaymentDate, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) 
VALUES 
(1, '100001', '2024-05-20', '2024-05-17', '2024-05-20', 3, 360.00, 0.10, 36.00, 396.00, 'Room payment for 3 nights'),
(2, '100002', '2024-05-21', '2024-05-18', '2024-05-22', 4, 500.00, 0.10, 50.00, 550.00, 'Room payment for 4 nights'),
(3, '100003', '2024-05-22', '2024-05-19', '2024-05-23', 3, 600.00, 0.10, 60.00, 660.00, 'Room payment for 3 nights');
GO

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber, RateApplied, DateOccupied, PhoneCharge, Notes) 
VALUES 
(1, '100001', '101', 120.00, '2024-05-17', 10.00, 'Guest made local calls'),
(2, '100002', '102', 250.00, '2024-05-18', 20.00, 'Guest made international calls'),
(3, '100003', '103', 200.00, '2024-05-19', 0.00, 'No phone usage');
GO

SELECT * FROM Occupancies;