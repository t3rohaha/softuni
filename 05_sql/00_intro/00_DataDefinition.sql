CREATE DATABASE Bank;

CREATE TABLE Clients (
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
);

CREATE TABLE AccountTypes (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Accounts (
    Id INT PRIMARY KEY IDENTITY,
    Balance DECIMAL(15, 2) NOT NULL DEFAULT(0),
    AccountTypeId INT FOREIGN KEY REFERENCES AccountTypes(Id),
    ClientId INT FOREIGN KEY REFERENCES Clients(Id)
);

CREATE TABLE Transactions (
    Id INT PRIMARY KEY IDENTITY,
    AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
    OldBalance DECIMAL(15, 2) NOT NULL,
    NewBalance DECIMAL(15, 2) NOT NULL,
    Amount AS NewBalance - OldBalance,
    CreatedAt DATETIME2
);

INSERT INTO Clients (FirstName, LastName) VALUES
('Frank', 'Lampard'),
('John', 'Terry'),
('Ashley', 'Cole'),
('Joe', 'Cole');

INSERT INTO AccountTypes (Name) VALUES
('Checking'),
('Saving');
    
INSERT INTO Accounts (Balance, AccountTypeId, ClientId) VALUES
(4000000.50, 1, 1),
(3000000.50, 1, 2),
(2000000.50, 2, 3),
(1000000.50, 2, 4);