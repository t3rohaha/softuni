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
- `Procedures` Series of operations, including querying and modifying the db.
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

### Constraints

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

## STEPS IN DATABASE DESIGN

01. `Entities`

02. `Columns`

03. `Primary keys`

04. `Relationships`

05. `Constraints`

06. `Seed`

## TABLE RELATIONS

`One-to-many` - e.g. one country has many towns, one town has one country.

`Many-to-many` - e.g. one student has many courses, one course has many
students. Uses `join/mapping table` which references both primary keys.

`One-to-one` - e.g. one country has one capital. 

```sql
CONSTRAINT FK_Country_Capital FOREIGN KEY (CapitalID) REFERENCES Cities(Id);
```

## JOIN

With `JOIN` statement we can get data from two tables simultaneously.

`INNER JOIN` - Takes all rows that are not null in both tables.

`LEFT OUTER JOIN` - Take all rows from LEFT, and fill nulls to RIGHT.

`RIGHT OUTER JOIN` - Take all rows from RIGHT, and fill nulls to LEFT.

`FULL OUTER JOIN`

`CROSS JOIN`

### Notes

`Cartesian product` - All possible combinations between the elemets of two sets.
This is the result when data from multiple tables are taken without a valid
JOIN.

## CTE

Common table expression is a query which result can be used as source for
another query. It can be considered as a named subquery. To write CTE we begin
with `WITH` then `CTE_Name` followed by `AS ()` which contains the subquery.