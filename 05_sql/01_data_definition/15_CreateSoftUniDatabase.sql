CREATE DATABASE SoftUni;
GO
USE SoftUni;
GO

CREATE TABLE Towns
(
    Id int IDENTITY,
    Name varchar(50) NOT NULL,
    CONSTRAINT PK_Towns_Id PRIMARY KEY (Id)
);
GO

CREATE TABLE Addresses
(
    Id int IDENTITY,
    TownId int NOT NULL,
    AddressText varchar(200) NOT NULL,
    CONSTRAINT PK_Addresses_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Addresses_TownId FOREIGN KEY (TownId) REFERENCES Towns (Id)
);
GO

CREATE TABLE Departments
(
    Id int IDENTITY,
    Name varchar(100) NOT NULL,
    CONSTRAINT PK_Departments_Id PRIMARY KEY (Id)
);
GO

CREATE TABLE Employees
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
    CONSTRAINT FK_Employees_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Departments (Id),
    CONSTRAINT FK_Employees_AddressId FOREIGN KEY (AddressId) REFERENCES Addresses (Id)
);
GO