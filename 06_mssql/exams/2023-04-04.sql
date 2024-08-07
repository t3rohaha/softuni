-- =============================================================================
-- MSSQL EXAM 2023 AUG 04 MSSQL EXAM 2023 AUG 04 MSSQL EXAM 2023 AUG 04 MSSQL EX
-- =============================================================================

-- =============================================================================
-- ACCOUNTING ACCOUNTING ACCOUNTING ACCOUNTING ACCOUNTING ACCOUNTING ACCOUNTING
-- =============================================================================

-- =============================================================================
-- 01 DDL 01 DDL 01 DDL 01 DDL 01 DDL 01 DDL 01 DDL 01 DDL 01 DDL 01 DDL 01 DDL
-- =============================================================================

USE [master];
CREATE DATABASE [SoftUni_Accounting];
GO

USE [SoftUni_Accounting];

CREATE TABLE Countries
(
    Id int NOT NULL IDENTITY,
    [Name] varchar(10) NOT NULL,
    CONSTRAINT PK_Countries_Id PRIMARY KEY (Id)
);

CREATE TABLE Addresses
(
    Id int NOT NULL IDENTITY,
    StreetName nvarchar(20) NOT NULL,
    StreetNumber int NOT NULL,
    PostCode int NOT NULL,
    City varchar(25) NOT NULL,
    CountryId int NOT NULL,
    CONSTRAINT PK_Addresses_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Addresses_CountryId FOREIGN KEY (CountryId) REFERENCES Countries (Id)
);

CREATE TABLE Vendors
(
    Id int NOT NULL IDENTITY,
    [Name] nvarchar(25) NOT NULL,
    NumberVAT nvarchar(15) NOT NULL,
    AddressId int NOT NULL,
    CONSTRAINT PK_Vendors_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Vendors_AddressId FOREIGN KEY (AddressId) REFERENCES Addresses (Id)
);

CREATE TABLE Clients
(
    Id int NOT NULL IDENTITY,
    [Name] nvarchar(25) NOT NULL,
    NumberVAT nvarchar(15) NOT NULL,
    AddressId int NOT NULL,
    CONSTRAINT PK_Clients_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Clients_AddressId FOREIGN KEY (AddressId) REFERENCES Addresses (Id)
);

CREATE TABLE Categories
(
    Id int NOT NULL IDENTITY,
    [Name] varchar(10) NOT NULL,
    CONSTRAINT PK_Categories_Id PRIMARY KEY (Id)
);

CREATE TABLE Products
(
    Id int NOT NULL IDENTITY,
    [Name] nvarchar(35) NOT NULL,
    Price decimal(18, 2) NOT NULL,
    CategoryId int NOT NULL,
    VendorId int NOT NULL,
    CONSTRAINT PK_Products_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Products_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories (Id),
    CONSTRAINT FK_Products_VendorId FOREIGN KEY (VendorId) REFERENCES Vendors (Id),
);

CREATE TABLE Invoices
(
    Id int NOT NULL IDENTITY,
    [Number] int NOT NULL,
    IssueDate datetime2 NOT NULL,
    DueDate datetime2 NOT NULL,
    Amount decimal(18, 2) NOT NULL,
    Currency varchar(5) NOT NULL,
    ClientId int NOT NULL,
    CONSTRAINT PK_Invoices_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Invoices_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(Id),
    CONSTRAINT UQ_Invoices_Number UNIQUE ([Number])
);

CREATE TABLE ProductsClients
(
    ProductId int NOT NULL,
    ClientId int NOT NULL,
    CONSTRAINT PK_ProductsClients_Id PRIMARY KEY (ProductId, ClientId),
    CONSTRAINT FK_ProductsClients_ProductId FOREIGN KEY (ProductId) REFERENCES Products (Id),
    CONSTRAINT FK_ProductsClients_ClientId FOREIGN KEY (ClientId) REFERENCES Clients (Id)
);

GO

-- =============================================================================
-- 02 INSERT 02 INSERT 02 INSERT 02 INSERT 02 INSERT 02 INSERT 02 INSERT 02 INSE
-- =============================================================================

INSERT INTO Products
([Name], Price, CategoryId, VendorId) VALUES
('SCANIA Oil Filter XD01', 78.69, 1, 1),
('MAN Air Filter XD01', 97.38, 1, 5),
('DAF Light Bulb 05FG87', 55, 2, 13),
('ADR Shoes 47-47.5', 49.85, 3, 5),
('Anti-slip pads S', 5.87, 5, 7);

INSERT INTO Invoices
([Number], IssueDate, DueDate, Amount, Currency, ClientId) VALUES
('1219992181', '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
('1729252340', '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
('1950101013', '2023-02-17', '2023-04-18', 615.15, 'USD', 19);

GO

-- =============================================================================
-- 03 UPDATE 03 UPDATE 03 UPDATE 03 UPDATE 03 UPDATE 03 UPDATE 03 UPDATE 03 UPDA
-- =============================================================================

UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE DATEPART(YEAR, IssueDate) = 2022 AND DATEPART(MONTH, IssueDate) = 11;

UPDATE Clients
SET AddressId = 3
WHERE PATINDEX('%CO%', [Name]) != 0;

GO

-- =============================================================================
-- 04 DELETE 04 DELETE 04 DELETE 04 DELETE 04 DELETE 04 DELETE 04 DELETE 04 DELE
-- =============================================================================

DELETE FROM Invoices
WHERE ClientId = 11;

DELETE FROM ProductsClients
WHERE ClientId = 11;

DELETE FROM Clients
WHERE LEFT(NumberVAT, 2) = 'IT';

GO

-- =============================================================================
-- 05 ORDER 05 ORDER 05 ORDER 05 ORDER 05 ORDER 05 ORDER 05 ORDER 05 ORDER 05 OR
-- =============================================================================

select [number], currency from invoices
order by amount desc, duedate;
go

-- =============================================================================
-- 06 JOIN 06 JOIN 06 JOIN 06 JOIN 06 JOIN 06 JOIN 06 JOIN 06 JOIN 06 JOIN 06 JO
-- =============================================================================

select p.id, p.name, p.price, c.name from products p
join categories c on p.categoryId = c.Id
where c.name in ('ADR', 'Others')
order by p.price desc;
go

-- =============================================================================
-- 07 LEFT JOIN 07 LEFT JOIN 07 LEFT JOIN 07 LEFT JOIN 07 LEFT JOIN 07 LEFT JOIN
-- =============================================================================

select
    c.id,
    c.name as client,
    concat(a.streetName, ' ', a.streetNumber, ', ', a.city, ', ', a.postCode, ', ', co.name) as [address]
    from clients c
left join productsClients pc on pc.clientId = c.id
join addresses a on c.addressId = a.id
join countries co on a.countryId = co.id
where pc.productId is null
order by c.name;
go

-- =============================================================================
-- 08 WHERE 08 WHERE 08 WHERE 08 WHERE 08 WHERE 08 WHERE 08 WHERE 08 WHERE 08 WH
-- =============================================================================

select [number], amount, c.name from invoices i
join clients c on i.clientId = c.id
where
    (datepart(year, issueDate) < 2023 and currency = 'EUR') or
    (amount > 500 and left(c.numberVAT, 2) = 'DE')
order by i.number, i.amount desc;
go

-- =============================================================================
-- 09 AGGREGATE 09 AGGREGATE 09 AGGREGATE 09 AGGREGATE 09 AGGREGATE 09 AGGREGATE
-- =============================================================================

select c.name, max(p.price) as price, c.numbervat from clients c
join productsclients pc on pc.clientid = c.id
join products p on pc.productid = p.id
join vendors v on p.vendorid = v.id
where right(c.name, 2) != 'KG'
group by c.name, c.numbervat
order by max(p.price) desc;
go

-- =============================================================================
-- 10 AGGREGATE 10 AGGREGATE 10 AGGREGATE 10 AGGREGATE 10 AGGREGATE 10 AGGREGATE
-- =============================================================================

select c.name, floor(avg(p.price)) as [avg price] from clients c
join productsclients pc on pc.clientid = c.id
join products p on pc.productid = p.id
join vendors v on p.vendorid = v.id
where patindex('%FR%', v.numbervat) != 0
group by c.name
order by avg(p.price), c.name desc;
go

-- =============================================================================
-- 11 FUNCTIONS 11 FUNCTIONS 11 FUNCTIONS 11 FUNCTIONS 11 FUNCTIONS 11 FUNCTIONS
-- =============================================================================

create function udf_ProductWithClients
(
    @name nvarchar(35)
)
returns int
as
begin
    declare @count int;

    select @count = count(*) from products p
    join productsclients pc on pc.productid = p.id
    join clients c on pc.clientid = c.id
    where p.name = @name;

    return @count;
end
go

-- =============================================================================
-- 12 PROCEDURES 12 PROCEDURES 12 PROCEDURES 12 PROCEDURES 12 PROCEDURES 12 PROC
-- =============================================================================

create procedure usp_SearchByCountry
(
    @name varchar(10)
)
as
begin
    select
        v.name as vendor,
        v.numbervat as vat,
        concat(a.streetname, ' ', a.streetnumber) as [street info],
        concat(a.city, ' ', a.postcode) as [city info]
        from vendors v
    join addresses a on v.addressid = a.id
    join countries c on a.countryid = c.id
    where c.name = @name
    order by v.name, a.city;
end
go

