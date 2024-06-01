# SQL

## RDBMS

Relational Database Management System is type of database management
system which stores the data using `tables`, `rows` (records) and `columns`
(fields). The tables can be related to each other using `foreign keys`.

### SQL

Structured Query Language is a programming language used to communicate with
RDBMS. SQL commands can be logically devided into four groups:

- `Data Definition` Describe the structure of our database (`CREATE`, `ALTER`).
- `Data Manipulation` Store and Retrieve data (`SELECT`, `INSERT`, `UPDATE`).
- `Data Control` Define who can access the data (`GRANT`, `REVOKE`).
- `Transaction Control` Bundle operations, allow rollback (`BEGIN`, `COMMIT`).

### Tables

The main building block of RDMBS.

- `Rows` Represent a record or entity.
- `Columns` Define data type, properties and constraints.
- `Cell` Actual data.

### Programmability

This section refers on how to customize database behavior.

- `Indices` Used to improve the speed of data retrieval on a table.
- `Functions` Take parameters perform operations and return result.
- `Procedures` Function that does not return value.
- `Triggers` Watch for activity in the database and react to it.

### Notes

- `SQL Server` is one type of RDBMS. It uses `Transact-SQL` for communication
which is extension of `SQL` and provides additional functionality to it.

## DATA DEFINITION

Describe the structure of the database.

### Data Types

`Numeric`
- `bit` Integer that can be 0, 1, or NULL.
- `int` 32 bit signed integer.
- `bigint` 64 bit signed integer.
- `decimal(p, s)` Fixed precision and scale numbers.
- `money` Monetary data.

`Strings`
- `char(size)` Fixed size string.
- `varchar(size)` Variable size string.
- `nvarchar(size)` Unicode variable size string.
- `text`, `ntext` Unlimited size string.

`Binary`
- `binary(size)` Fixed length sequence of bits.
- `varbinary(size)` Sequence of bits (1b - 2GB).

`Date and Time`
- `date` Date in range 0001-01-01 to 9999-12-31.
- `datetime2` Date and time with precision of 100 nanoseconds.
- `smalldatetime` Date and time with precision of 1 min.

### Custom Properties

`PRIMARY KEY` Indicates PK, unique by default.

`FOREIGN KEY` Indicates FK, which reference PK in another table.

`IDENTITY` Autoincrement.

`UNIQUE` No repeating values in entire table.

`DEFAULT` Sets default value (otherwise null).

`CHECK` Value constraint.

`NOT NULL` Required constraint.

### Basic Queries

```sql
-- Create database/table.
CREATE DATABASE Database;

CREATE TABLE Table
(
    Id int IDENTITY PRIMARY KEY,
    Name nvarchar(50) NOT NULL
);

-- Tables, columns, data types, constraints, relationships etc. can be altered.
ALTER TABLE Table
ADD Salary MONEY;

ALTER TABLE Table
ADD CONSTRAINT ConstraintName
CHECK (Column > 0);

-- Delete all entries in table.
TRUNCATE TABLE Table;

-- Delete database/table.
DROP DATABASE Database;

DROP TABLE Table;
```

### Notes

- Data types in SQL Server are lowercase.

## CRUD

`READ` (SELECT, AS, ORDER BY, WHERE)

`WRITE` (INSERT)

`UPDATE` (ALTER, SET, WHERE)

`DELETE` (DELETE, WHERE)

### Notes

`Projection` Specifying columns that should be selected.

`Selection` Specifying condition, which records should be selected.

`Join` Allow retrieving data from multiple tables which are related.

`INSERT` and `SELECT` can be combined to insert data from existing table.

## VIEWS

Views are named (saved) queries. `CREATE VIEW v_ViewName AS` etc...

## OPERATORS

`Comparison` >, <, >=, <=, =

`Logical` AND, OR, NOT

`Pattern matching` LIKE, IN, IS NULL, IS NOT NULL

`Other` BETWEEN

## FUNCTIONS

`AGGREGATE` (SUM, AVG, COUNT, MIN, MAX)

`STRING` (LEN, UPPER, LOWER, SUBSTRING, REPLACE, LTRIM, RTRIM, CONCAT, REVERSE)

`DATE AND TIME` (GETDATE, DATEADD, DATEDIFF, DATENAME, CONVERT, FORMAT)

`MATH` (ABS, CEILING, FLOOR, ROUND, POWER, SQRT)

`SYSTEM` (@@IDENTITY, @@ERROR, @@ROWCOUNT, @@SCOPE_IDENTITY)

`CONVERSION` (CAST, CONVERT)

`LOGICAL` (ISNULL, COALESCE)

`RANKING` (ROW_NUMBER, RANK, DENSE_RANK, NTILE)

`OTHER` (OFFSET, FETCH)

### Notes

Most of the functions (if not all of them) use 1 as start index.

## WILDCARDS

SQL Server wildcards are special characters used in the LIKE operator's pattern
matching.

`%` Zero, one, or more characters ('Jo%' matches John, Joe, Joanna).

`_` Single character ('J_n' matches Jan, Jen, Jon).

`[...]` Set or range of characters ([Jj] matches John, john).

`[^...]` Any character not in set or range.

`[a-c]` Any character in range ([a-c] matches a, b, c).

## QUERY EXECUTION ORDER

01. `FROM`

02. `ON`

03. `OUTER`

04. `WHERE`

05. `GROUP BY`

06. `HAVING` - Filter data on condition after grouping.

07. `SELECT`

08. `DISTINCT`

09. `ORDER BY`

10. `TOP/LIMIT`