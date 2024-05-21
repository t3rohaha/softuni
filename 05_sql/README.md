# SQL

## RDBMS

`Database` Organized collection of information.

`RDBMS` Relational Database Management System is type of database management
system which stores the data using `tables`, `rows` (records) and `columns`
(fields).  The tables can be related to each other using `foreign keys`.

`SQL Server` One type of RDBMS. Uses `Transact-SQL` for communication.

`SQL` Structured Query Language is a programming language used to communicate
with RDBMS. SQL commands can be logically devided into four groups:
- `Data Definition` Describe the structure of our database (`CREATE`, `ALTER`)
- `Data Manipulation` Store and Retrieve data (`SELECT`, `INSERT`, `UPDATE`)
- `Data Control` Define who can access the data (`GRANT`, `REVOKE`).
- `Transaction Control` Bundle operations, allow rollback (`BEGIN`, `COMMIT`).

`Transact SQL` is extension of `SQL` and provides additional functionality
like `IF-ELSE`, `WHILE`, `TRY...CATCH`.

`Tables` The main building block of RDMBS. Contains:
- `Rows` Also called records or entities.
- `Columns` Also called fields. They define the data type of the data they
contain.
- `Cell` The actual data.

## Programmability

This section refers on how to customize database behavior.

`Indices` Used to improve the speed of data retrieval on a table.

`Procedures` One or more SQL Statements that are stored as a procedure. The
procedure then can be reused.

`Action` One or more SQL Statements that execute and return a result.

`Triggers` Watch for activity in the database and react to it.
