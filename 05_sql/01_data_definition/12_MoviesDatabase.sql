-- CREATE DATABASE.

CREATE DATABASE Movies;

USE Movies;

-- CREATE TABLES.

CREATE TABLE Directors
(
    Id int IDENTITY, 
    Name nvarchar(50) NOT NULL,
    Notes nvarchar(4000)
);

CREATE TABLE Genres
(
    Id int IDENTITY,
    Name nvarchar(50) NOT NULL,
    Notes nvarchar(4000)
);

CREATE TABLE Categories
(
    Id int IDENTITY,
    Name nvarchar(50) NOT NULL,
    Notes nvarchar(4000)
);

CREATE TABLE Movies
(
    Id int IDENTITY,
    Title nvarchar(100) NOT NULL,
    CopyrightYear date NOT NULL,
    Length time NOT NULL,
    DirectorId int NOT NULL,
    GenreId int NOT NULL,
    CategoryId int NOT NULL,
    Rating tinyint,
    Notes nvarchar(4000)
);

-- ADD CONSTRAINTS.

ALTER TABLE Directors ADD CONSTRAINT PK_Directors_Id PRIMARY KEY (Id);

ALTER TABLE Genres ADD CONSTRAINT PK_Genres_Id PRIMARY KEY (Id);

ALTER TABLE Categories ADD CONSTRAINT PK_Categories_Id PRIMARY KEY (Id);

ALTER TABLE Movies ADD CONSTRAINT PK_Movies_Id PRIMARY KEY (Id);

ALTER TABLE Movies ADD CONSTRAINT FK_MovieDirector
FOREIGN KEY (DirectorId) REFERENCES Directors (Id);

ALTER TABLE Movies ADD CONSTRAINT FK_MovieGenre
FOREIGN KEY (GenreId) REFERENCES Genres (Id);

ALTER TABLE Movies ADD CONSTRAINT FK_MovieCategory
FOREIGN KEY (CategoryId) REFERENCES Categories (Id);

ALTER TABLE Movies ADD CONSTRAINT DF_Movies_Rating_0 DEFAULT 0 FOR Rating;

-- INSERT DATA.

INSERT INTO Directors (Name) VALUES 
('Steven Spielberg'),
('Alfred Hitchcock'),
('Martin Scorsese'),
('Stanley Kubrick'),
('Quentin Tarantino');

INSERT INTO Genres (Name) VALUES
('Adventure'),
('Thriller'),
('Crime'),
('Science Fiction'),
('Action');

INSERT INTO Categories (Name) VALUES
('Music'),
('Sport'),
('Art'),
('Science'),
('History');

INSERT INTO Movies
(Title, CopyrightYear, Length, DirectorId, GenreId, CategoryId) VALUES
('Jurassic Park', '1993', '02:07:00', 1, 4, 3),
('Psycho', '1960', '01:49:00', 2, 2, 3),
('Goodfellas', '1990', '02:26:00', 3, 3, 5),
('2001: A Space Odyssey', '1968', '02:29:00', 4, 4, 3),
('Pulp Fiction', '1994', '02:34:00', 5, 3, 3);