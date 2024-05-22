USE Minions;

CREATE TABLE People
(
    Id int PRIMARY KEY IDENTITY,
    Name nvarchar(200) NOT NULL,
    Picture varbinary(MAX),
    Height decimal(3, 2),
    Weight decimal(5, 2),
    Gender char(1) NOT NULL,
    Birthdate date NOT NULL,
    Biography varchar(MAX)
);

ALTER TABLE People
ADD CONSTRAINT CHK_People_Picture_2MB CHECK (DATALENGTH(Picture) <= 2097152);

ALTER TABLE People
ADD CONSTRAINT CHK_People_Gender_Values CHECK (Gender IN ('m', 'f'));

INSERT INTO People (Name, Gender, Birthdate)
VALUES
('Frank Lampard', 'm', '1978/06/20'),
('Ashley Cole', 'm', '1980/12/20'),
('Joe Cole', 'm', '1981/11/08'),
('Cole Palmer', 'm', '2002/04/18'),
('John Terry', 'm', '1980/12/07');