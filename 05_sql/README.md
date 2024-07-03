# SQL Server

## Table of Contents

1. [RDBMS and SQL OVERVIEW](#rdbms-and-sql-overview)
2. [DDL](#ddl-and-data-types)
    1. [DATA TYPES](#data-types)
    2. [CONSTRAINTS](#constraints)
    3. [RELATIONS](#relations)
    4. [STEPS IN DATABASE DESIGN](#steps-in-database-design)
3. [DML](#dml)
    1. [QUERY EXECUTION ORDER](#query-execution-order)
    2. [OPERATORS](#operators)
    3. [BUILT-IN FUNCTIONS](#built-in-functions)
    4. [RANKING](#ranking)
4. [PROGRAMMABILITY](#programmability)
    1. [CTE](#cte)
    2. [FUNCTIONS](#functions)
    3. [PROCEDURES](#procedures)
    4. [TRIGGERS](#triggers)
    5. [TRANSACTIONS](#transactions)

## RDBMS and SQL OVERVIEW

**RDBMS** Relational Database Management System is a type of database management
system which stores the data using tables, rows, columns. The tables can be
related to each other using primary and foreign keys. 

**TABLES** The main building block of the database, it contains rows, columns and
cells.

**ROWS** Represent a record or entity.

**COLUMNS** Define data type, properties and constraints.

**CELLS** Actual data.

**SQL** Structured Query Language is a programming language used to communicate
with RDBMS. SQL commands can be logically devided into four groups.

**DATA DEFINITION** Create and update the database (`CREATE`, `ALTER`, `DROP`).

**DATA MANIPULATION** Add, update, retrieve data (`SELECT`, `INSERT`, `UPDATE`).

**DATA CONTROL** Define who can access the data (`GRANT`, `REVOKE`).

**TRANSACTION CONTROL** Bundle operations, allow rollback (`BEGIN`, `COMMIT`).

**NB!** SQL Server is one type of RDBMS. It uses T-SQL for communication which is
extension of SQL and provides additional functionality to it.

## DDL and DATA TYPES

**DDL** Data Definition Language is a group of functionality used to create and
modify a database.

**DATABASE OBJECTS** Entities used to store, organize and manipulate data.
Examples of database objects are tables, views, stored procedures, functions,
triggers and more.

**CREATE** Used to create database objects.

**ALTER** Used to modify the structure of an existing database object.

**DROP** Used to delete existing database objects.

**CONSTRAINT** Used to add rules to the database.

### DATA TYPES

**DATA TYPES** Used to describe the nature of the data being stored in a column.

**TYPE CONVERSION** SQL Server allows implicit and explicit type conversion.

**PRECISION** The total number of digits in a number.

**SCALE** The number of digits to the right of the decimal point.

**BIT** Integer that can be 0 or 1.

**INT** 32-bit signed integer.

**BIGINT** 64-bit signed integer.

**DECIMAL(precision, scale)** Fixed precision and scale numbers.

**MONEY** Monetary data values.

**CHAR(size)** Fixed size string.

**VARCHAR(size)** Variable size string.

**NVARCHAR(size)** Unicode variable size string.

**BINARY(size)** Fixed length sequence of bytes.

**VARBINARY(size)** Variable length sequence of bytes.

**DATE** Date in range 0001-01-01 to 9999-12-31.

**DATETIME2** Date and time in format YYYY-MM-DD hh:mm:ss

**XML** Allows storing xml in a structured format.

**JSON** Allows storing json in a structured format.

**NB!** By default all data types allow NULL unless specified otherwise with the
NOT NULL constraint.

### CONSTRAINTS

**PRIMARY KEY** Indicates PK, unique by default.

**FOREIGN KEY** Indicates FK, which reference PK in another table.

**IDENTITY** Autoincrement.

**UNIQUE** No repeating values in entire table.

**DEFAULT** Sets default value (otherwise null).

**CHECK** Value constraint.

**NOT NULL** Required constraint.

### RELATIONS

**ONE TO MANY** e.g. one country has many towns, one town has one country.

**MANY TO MANY** e.g. one student has many courses, one course has many
students. Uses `join/mapping table` which references both primary keys.

**ONE TO ONE** e.g. one country has one capital. 

### STEPS IN DATABASE DESIGN

01. **TABLES** Represent the objects we want to store in the database.

02. **COLUMNS** Represent the data that define the object and we want to store.

03. **PRIMARY KEYS** Constraints that meke each row unique.

04. **RELATIONSHIPS** Constraints that specify how tables relate to each other.

05. **CONSTRAINTS** Rules and restrictions on the data in a table.

06. **SEED** Initial values used for auto-incrementing primary keys (not
adding initial data to the database).

```sql
CREATE DATABASE [UniversityDB];
GO

USE [UniversityDB];
GO

CREATE TABLE [Students] (
    Id INT IDENTITY,
    FullName NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_Students_Id PRIMARY KEY (Id)
);

CREATE TABLE [Courses] (
    Id INT IDENTITY,
    CourseName NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_Courses_Id PRIMARY KEY (Id)
);

CREATE TABLE [Enrollments] (
    Id INT IDENTITY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    CONSTRAINT PK_Enrollments_Id PRIMARY KEY (StudentId, CourseId),
    CONSTRAINT FK_Enrollments_StudentId FOREIGN KEY (StudentId) REFERENCES [Students] (Id)
    CONSTRAINT FK_Enrollments_CourseId FOREIGN KEY (CourseId) REFERENCES [Courses] (Id)
);

-- Alter table to add new column.
ALTER TABLE [Students]
ADD Age int NOT NULL;

-- Add constraint to the new column.
ALTER TABLE [Students]
ADD CONSTRAINT CHK_Age
CHECK (Age > 0);

-- Delete table.
DROP TABLE [Students];

-- Use master.
USE master;
GO

-- Delete database.
DROP DATABASE [University];
```

## DML

**DML** Data Manipulation Language is a group of functionality that allows CRUD
operations on the data.

**INSERT** Adds new rows of data into a table.

**UPDATE** Modifies existing data within one or more rows in a table.

**DELETE** Deletes one or more rows in a table.

**SELECT** Retrieves data from one or more tables.

**RESULT SET** The set of rows returned by query after it has been executed
against the database.

```sql
INSERT INTO [Students]
(FullName)
VALUES
('Frank Lampard'),
('John Terry'),
('Didier Drogba');

INSERT INTO [Courses]
(CourseName)
VALUES
('Defending 101'),
('Passing 101'),
('Scoring 101');

INSERT INTO [Enrollments]
(StudentId, CourseId)
VALUES
(1, 2),
(2, 1),
(3, 3);

-- Get data.
SELECT * FROM [Students];

-- Update data.
UPDATE [Students]
SET FullName += ' updated'
WHERE FullName = 'Frank Lampard';
GO

-- Delete all entries in a table.
TRUNCATE TABLE [Students];
GO
```

### QUERY EXECUTION ORDER

1. **FROM** Specifies the tables or views from which the data is retrieved.

2. **ON** Adds criteria for a JOIN (e.g. Matching IDs).

3. **OUTER** LEFT/RIGHT/FULL JOIN Retrieves rows that meet and don't meet the
JOIN criteria.

4. **WHERE** Adds criteria for the rows retrieved.

5. **GROUP BY** Groups rows by columns with same values into summary rows.

6. **HAVING** Add criteria after grouping.

7. **SELECT** Retrieves column or expression from result set.

8. **DISTINCT** Removes duplicate rows from result set.

9. **ORDER BY** Orders the result set by specified column or expression.

10. **TOP/LIMIT** Limits the the rows returned in a result set.

### OPERATORS

**COMPARISON** (>, <, >=, <=, =)

**LOGICAL** (AND, OR, NOT)

**PATTERN MATCHING** (LIKE, IN, IS NULL, IS NOT NULL)

**OTHER** (BETWEEN)

### BUILT-IN FUNCTIONS

**AGGREGATE** (SUM, AVG, COUNT, MIN, MAX)

**STRING** (LEN, UPPER, LOWER, SUBSTRING, REPLACE, LTRIM, RTRIM, CONCAT, REVERSE)

**DATE AND TIME** (GETDATE, DATEADD, DATEDIFF, DATENAME, CONVERT, FORMAT)

**MATH** (ABS, CEILING, FLOOR, ROUND, POWER, SQRT)

**SYSTEM** (@@IDENTITY, @@ERROR, @@ROWCOUNT, @@SCOPE_IDENTITY)

**CONVERSION** (CAST, CONVERT)

**LOGICAL** (ISNULL, COALESCE)

**RANKING** (ROW_NUMBER, RANK, DENSE_RANK, NTILE)

**OTHER** (OFFSET, FETCH)

### RANKING

A ranking function is a function that assigns a number/rank to each row within a
partition of a result set.

**OVER** Used with ranking functions to define the set of rows on which the
function operates.

**ORDER BY** It is mandatory after OVER because ranking functions require
specific order.

**PARTITION BY** Optional clause to devide the result set into partitions.

```sql
SELECT
    FullName,
    JobTitle,
    ROW_NUMBER() OVER (PARTITION BY JobTitle ORDER BY JobTitle) AS Rank
FROM Employees;
```

### WILDCARDS

SQL Server wildcards are special characters used in the LIKE operator's pattern
matching.

**%** Zero, one, or more characters ('Jo%' matches John, Joe, Joanna).

**_** Single character ('J_n' matches Jan, Jen, Jon).

**[...]** Set or range of characters ([Jj] matches John, john).

**[^...]** Any character not in set or range.

**[a-c]** Any character in range ([a-c] matches a, b, c).

### JOIN

With `JOIN` statement we can get data from two tables simultaneously.

**INNER JOIN** Takes all rows that are not null in both tables.

**LEFT OUTER JOIN** Take all rows from LEFT, and fill nulls to RIGHT.

**RIGHT OUTER JOIN** Take all rows from RIGHT, and fill nulls to LEFT.

**FULL OUTER JOIN**

**CROSS JOIN**

## PROGRAMMABILITY

This section refers on how to customize database behavior.

- `Indices` Used to improve the speed of data retrieval on a table.
- `Functions` Take parameters perform operations and return result.
- `Procedures` Series of operations, including querying and modifying the db.
- `Triggers` Watch for activity in the database and react to it.

### CTE

Common Table Expression is a named temporary result set that can be referenced
within the scope of a single SELECT, INSERT, UPDATE or DELETE statement. CTEs
enhance readability and simplify complex queries by breaking them down to
smaller, more manageable parts.

```sql
WITH CTE_AvgDepartmentSalary (DepartmentId, AvgSalary)
AS
(
    SELECT DepartmentId, AVG(Salary) AS AvgSalary
    FROM [Employees]
    GROUP BY DepartmentId;
)
SELECT
    DepartmentId,
    MIN(AvgSalary) AS MinAvgSalary
FROM CTE_AvgDepartmentSalary;

WITH CTE_LowSalaryEmployees (EmployeeId)
AS
(
    SELECT EmployeeId
    FROM [Employees]
    WHERE DepartmentId = 1 AND Salary < 50000;
)
DELETE FROM [Employeees]
WHERE EmployeeId IN (SELECT EmployeeId FROM CTE_LowSalaryEmployees);
```

### FUNCTIONS

Functions encapsulate logic to perform specific task. Usually they recieve
input (parameters) and return output. Scalar Functions return scalar value and
Table-Valued Functions return result set.

```sql
CREATE FUNCTION fn_GetAge
(
    @dob date
)
RETURNS int
AS
BEGIN
    RETURN DATEDIFF(YEAR, @dob, GETDATE());
END
```

### STORED PROCEDURES

Precompiled, reusable SQL. Can include data retrieval and modification.

```sql
CREATE PROCEDURE usp_UpdateEmployeeSalary
(
    @EmployeeId int,
    @NewSalary decimal(10,2)
)
AS
BEGIN
    UPDATE Employees
    SET Salary = @NewSalary
    WHERE Id = @EmployeeId;
END
```

### TRIGGERS

Triggers are special types of stored procedures that automatically execute
in response to certain events (INSERT, UPDATE, DELETE, CREATE, ALTER, DROP) on a
table or view. The data after performing the operation is not saved before the
trigger executes.

**AFTER TRIGGER** Executed after INSERT, UPDATE, DELETE. Can access updated or
deleted rows.

**INSTEAD OF TRIGGER** Executed instead of the triggering operation, which
allows overriding the default behavior of INSERT, UPDATE, DELETE.

```sql
CREATE TRIGGER tr_TriggerName
ON TableName
AFTER UPDATE
AS
BEGIN
    SELECT *
    FROM inserted i
    JOIN deleted d ON d.Id = i.Id;
END
```

### TRANSACTIONS

Transactions are a set of database operations executed as a whole. If one
operation fail, the whole transaction is cancelled and a `ROLLBACK` is made
to the starting point of the transaction. After `COMMIT` transaction becomes
persistent. `ACID` is an acronym that describes the main properties of
transactions. `Atomicity` means that either all of the operations succeed or
none of them do. `Consistency` means that transactions cannot break rules
already created for the database data. `Isolation` means that every transaction
is executed independently from one another. `Durability` means that once
committed, a transaction cannot be undone.

```sql
BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE Accouts
    SET Balance = Balance - @withdrawAmount
    WHERE Id = @accountId;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH
```

## Notes

**Cartesian product** All possible combinations between the elemets of two sets.
This is the result when data from multiple tables are taken without a valid
JOIN.