-- 01: ONE-TO-ONE RELATIONSHIP EXAMPLE.
-- 01: ONE-TO-ONE RELATIONSHIP EXAMPLE.
-- 01: ONE-TO-ONE RELATIONSHIP EXAMPLE.

USE master;
GO

CREATE DATABASE SoftUni_Relations;
GO

USE SoftUni_Relations;
GO

PRINT '01. ONE-TO-ONE Example';

CREATE TABLE Passports
(
    PassportID int NOT NULL,
    PassportNumber varchar(8) NOT NULL,
    CONSTRAINT PK_Passports_PassportID PRIMARY KEY (PassportID),
    CONSTRAINT UQ_PassportNumber UNIQUE (PassportNumber),
    CONSTRAINT CHK__PassportNumber CHECK (LEN(PassportNumber) = 8)
);

INSERT INTO Passports (PassportID, PassportNumber) VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2');

CREATE TABLE People
(
    PersonID int NOT NULL,
    FirstName varchar(25) NOT NULL,
    Salary decimal(8, 2) NOT NULL,
    PassportID int NOT NULL,
    CONSTRAINT PK_Persons_PersonID PRIMARY KEY (PersonID),
    CONSTRAINT UQ_People_PassportID UNIQUE (PassportID),
    CONSTRAINT FK_People_PassportID FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)
);

INSERT INTO People (PersonID, FirstName, Salary, PassportID) VALUES
(1, 'Roberto', 43300, 102),
(2, 'Tom', 56100, 103),
(3, 'Yana', 60200, 101);

GO

-- 02: ONE-TO-MANY RELATIONSHIP EXAMPLE.
-- 02: ONE-TO-MANY RELATIONSHIP EXAMPLE.
-- 02: ONE-TO-MANY RELATIONSHIP EXAMPLE.

PRINT '02. ONE-TO-MANY Example';

CREATE TABLE Manufacturers
(
    ManufacturerID int NOT NULL,
    Name varchar(25) NOT NULL,
    EstablishedOn date NOT NULL,
    CONSTRAINT PK_Manufacturers_ManufacturerID PRIMARY KEY (ManufacturerID)
);

INSERT INTO Manufacturers (ManufacturerID, Name, EstablishedOn) VALUES
(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '03/05/1966');

CREATE TABLE Models
(
    ModelID int NOT NULL,
    Name varchar(25) NOT NULL,
    ManufacturerID int NOT NULL,
    CONSTRAINT PK_Models_ModelID PRIMARY KEY (ModelID),
    CONSTRAINT FK_Models_ManufacturerID FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
);

INSERT INTO Models (ModelID, Name, ManufacturerID) VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3);

GO

-- 03: MANY-TO-MANY RELATIONSHIP EXAMPLE.
-- 03: MANY-TO-MANY RELATIONSHIP EXAMPLE.
-- 03: MANY-TO-MANY RELATIONSHIP EXAMPLE.

PRINT '03. MANY-TO-MANY Example';

CREATE TABLE Students
(
    StudentID int NOT NULL,
    Name varchar(50) NOT NULL,
    CONSTRAINT PK_Students_StudentID PRIMARY KEY (StudentID)
);

INSERT INTO Students (StudentID, Name) VALUES 
(1, 'Mila'),
(2, 'Toni'),
(3, 'Ron');

CREATE TABLE Exams
(
    ExamID int NOT NULL,
    Name varchar(50) NOT NULL,
    CONSTRAINT PK_Exams_ExamID PRIMARY KEY (ExamID)
);

INSERT INTO Exams (ExamID, Name) VALUES
(101, 'SpringMVC'),
(102, 'SpringMVC'),
(103, 'SpringMVC');

CREATE TABLE StudentsExams
(
    StudentID int NOT NULL,
    ExamID int NOT NULL,
    CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID),
    CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);

INSERT INTO StudentsExams (StudentID, ExamID) VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103);

GO

-- 04: SELF-REFERENCE EXAMPLE.
-- 04: SELF-REFERENCE EXAMPLE.
-- 04: SELF-REFERENCE EXAMPLE.

PRINT '04. SELF-REFERENCE Example';

CREATE TABLE Teachers
(
    TeacherID int NOT NULL,
    Name varchar(50) NOT NULL,
    ManagerID int,
    CONSTRAINT PK_Teachers_TeacherID PRIMARY KEY (TeacherID),
    CONSTRAINT FK_Teachers_ManagerID FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
);

INSERT INTO Teachers (TeacherID, Name, ManagerID) VALUES
(101, 'John', NULL), 
(102, 'Maya', 106), 
(103, 'Silvia', 106), 
(104, 'Ted', 105), 
(105, 'Mark', 101), 
(106, 'Greta', 101); 

GO

-- 05: ONLINE STORE database.
-- 05: ONLINE STORE database.
-- 05: ONLINE STORE database.

PRINT '05. ONLINE STORE Database';

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'OnlineStoreDB')
BEGIN
    DROP DATABASE OnlineStoreDB;
END
GO

CREATE DATABASE OnlineStoreDB;
GO

USE OnlineStoreDB;
GO

CREATE TABLE Cities
(
    CityID int NOT NULL,
    Name varchar(50) NOT NULL,
    CONSTRAINT PK_Cities_CityID PRIMARY KEY (CityID)
);

INSERT INTO Cities (CityID, Name) VALUES
(1, 'London'),
(2, 'Manchester'),
(3, 'Liverpool');

CREATE TABLE Customers
(
    CustomerID int NOT NULL, 
    Name varchar(50) NOT NULL,
    Birthday date NOT NULL,
    CityID int NOT NULL,
    CONSTRAINT PK_Customers_CustomerID PRIMARY KEY (CustomerID),
    CONSTRAINT FK_Customers_CityID FOREIGN KEY (CityID) REFERENCES Cities(CityID)
);

INSERT INTO Customers (CustomerID, Name, Birthday, CityID) VALUES
(1, 'Frank Lampard', '1978-06-20', 1),
(2, 'Wayne Rooney', '1986-10-24', 2),
(3, 'Steven Gerrard', '1980-05-30', 3);

CREATE TABLE Orders
(
    OrderID int NOT NULL,
    CustomerID int NOT NULL,
    CONSTRAINT PK_Orders_OrderID PRIMARY KEY (OrderID),
    CONSTRAINT FK_Orders_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

INSERT INTO Orders (OrderID, CustomerID) VALUES
(1, 1),
(2, 2),
(3, 3);

CREATE TABLE ItemTypes
(
    ItemTypeID int NOT NULL,
    Name varchar(50) NOT NULL,
    CONSTRAINT PK_ItemTypes_ItemTypeID PRIMARY KEY (ItemTypeID)
);

INSERT INTO ItemTypes (ItemTypeID, Name) VALUES
(1, 'Games'),
(2, 'Clothing'),
(3, 'Electronics');

CREATE TABLE Items
(
    ItemID int NOT NULL,
    Name varchar(50) NOT NULL,
    ItemTypeID int NOT NULL,
    CONSTRAINT PK_Items_ItemID PRIMARY KEY (ItemID),
    CONSTRAINT FK_Items_ItemTypeID FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
);

INSERT INTO Items (ItemID, Name, ItemTypeID) VALUES
(1, 'RDR2', 1),
(2, 'Gucci Shirt', 2),
(3, 'IPhone 15', 3);

CREATE TABLE OrderItems
(
    OrderID int NOT NULL,
    ItemID int NOT NULL,
    CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID),
    CONSTRAINT FK_OrderItems_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_OrderItems_ItemID FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
);

INSERT INTO OrderItems (OrderID, ItemID) VALUES
(1, 1),
(2, 2),
(3, 3);

GO

-- 06: University Database.
-- 06: University Database.
-- 06: University Database.

PRINT('06. University Database')

USE master;

IF EXISTS(SELECT Name FROM sys.Databases WHERE Name = 'UniversityDB')
BEGIN
    DROP DATABASE UniversityDB;
END

CREATE DATABASE UniversityDB;
GO

USE UniversityDB;
GO

CREATE TABLE Majors
(
    MajorID int NOT NULL,
    Name varchar(50) NOT NULL,
    CONSTRAINT PK_Majors_MajorID PRIMARY KEY (MajorID)
);

INSERT INTO Majors
(MajorID, Name) VALUES
(1, 'Carlo Ancelotti'),
(2, 'Jose Mourinho'),
(3, 'Thomas Tuchel');

CREATE TABLE Students
(
    StudentID int NOT NULL,
    StudentNumber char(8) NOT NULL,
    StudentName varchar(50) NOT NULL,
    MajorID int NOT NULL,
    CONSTRAINT PK_Students_StudentID PRIMARY KEY (StudentID),
    CONSTRAINT FK_Students_MajorID FOREIGN KEY (MajorID) REFERENCES Majors(MajorID),
    CONSTRAINT UQ_Students_StudentNumber UNIQUE (StudentNumber),
    CONSTRAINT CHK_Students_StudentNumber CHECK (LEN(StudentNumber) = 8)
);

INSERT INTO Students
(StudentID, StudentNumber, StudentName, MajorID) VALUES
(1, '02345678', 'Frank Lampard', 1),
(2, '12345678', 'John Terry', 2),
(3, '22345678', 'Didier Drogba', 3);

CREATE TABLE Payments
(
    PaymentID int NOT NULL,
    PaymentDate date NOT NULL,
    PaymentAmount decimal(9, 2) NOT NULL,
    StudentID int NOT NULL,
    CONSTRAINT PK_Payments_PaymentID PRIMARY KEY (PaymentID),
    CONSTRAINT FK_Payments_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT CHK_Payments_PaymentAmount CHECK (PaymentAmount > 0)
);

INSERT INTO Payments
(PaymentID, PaymentDate, PaymentAmount, StudentID) VALUES
(1, '2024-06-01', 100000.00, 1),
(2, '2024-06-02', 200000.00, 2),
(3, '2024-06-03', 300000.00, 3)

CREATE TABLE Subjects
(
    SubjectID int NOT NULL,
    SubjectName varchar(50) NOT NULL,
    CONSTRAINT PK_Subjects_SubjectID PRIMARY KEY (SubjectID)
);

INSERT INTO Subjects
(SubjectID, SubjectName) VALUES
(1, 'Football'),
(2, 'Basketball'),
(3, 'Snooker');

CREATE TABLE Agenda
(
    StudentID int NOT NULL, 
    SubjectID int NOT NULL,
    CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID),
    CONSTRAINT FK_Agenda_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_Agenda_SubjectID FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);

INSERT INTO Agenda
(StudentID, SubjectID) VALUES
(1, 1),
(1, 2),
(2, 2),
(2, 3),
(3, 3)

GO