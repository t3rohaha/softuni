-- =============================================================================
-- MSSQL Server Exam 16 Jun 2024 MSSQL Server Exam 16 Jun 2024 MSSQL Server Exam 
-- =============================================================================

-- =============================================================================
-- LIBRARY LIBRARY LIBRARY LIBRARY LIBRARY LIBRARY LIBRARY LIBRARY LIBRARY LIBRA
-- =============================================================================

-- =============================================================================
-- Problem 01: DDL
-- =============================================================================

PRINT 'CREATING DATABASE...';

CREATE DATABASE LibraryDb;
GO

USE LibraryDb;

CREATE TABLE Genres
(
    Id int IDENTITY,
    [Name] nvarchar(30) NOT NULL,
    CONSTRAINT PK_Genres_Id PRIMARY KEY (Id)
);

CREATE TABLE Contacts
(
    Id int IDENTITY,
    Email nvarchar(100),
    PhoneNumber nvarchar(20),
    PostAddress nvarchar(200),
    WebSite nvarchar(50),
    CONSTRAINT PK_Contacts_Id PRIMARY KEY (Id)
);

CREATE TABLE Authors
(
    Id int IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    ContactId int NOT NULL,
    CONSTRAINT PK_Authors_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Authors_ContactId FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE Books
(
    Id int IDENTITY,
    Title nvarchar(100) NOT NULL,
    YearPublished int NOT NULL,
    ISBN nvarchar(13) NOT NULL,
    AuthorId int NOT NULL,
    GenreId int NOT NULL,
    CONSTRAINT PK_Books_Id PRIMARY KEY (Id),
    CONSTRAINT UQ_Books_ISBN UNIQUE (ISBN),
    CONSTRAINT FK_Books_AuthorId FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
    CONSTRAINT FK_Books_GenreId FOREIGN KEY (GenreId) REFERENCES Genres(Id)
);

CREATE TABLE Libraries
(
    Id int IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    ContactId int NOT NULL,
    CONSTRAINT PK_Libraries_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Libraries_ContactId FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE LibrariesBooks
(
    LibraryId int,
    BookId int NOT NULL,
    CONSTRAINT PK_LibrariesBooks PRIMARY KEY (LibraryId, BookId),
    CONSTRAINT FK_LibrariesBooks_LibraryId FOREIGN KEY (LibraryId) REFERENCES Libraries(Id),
    CONSTRAINT FK_LibrariesBooks_BookId FOREIGN KEY (BookId) REFERENCES Books(Id)
);

GO

-- =============================================================================
-- DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML DML D
-- =============================================================================

-- =============================================================================
-- Problem 02: Insert
-- =============================================================================

PRINT 'INSERTING DATA...';

INSERT INTO Contacts
(Email, PhoneNumber, PostAddress, Website)
VALUES
(NULL, NULL, NULL, NULL),
(NULL, NULL, NULL, NULL),
('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com');

INSERT INTO Authors
([Name], ContactId)
VALUES
('George Orwell', 21),
('Aldous Huxley', 22),
('Stephen King', 23),
('Suzanne Collins', 24);

INSERT INTO Books
(Title, YearPublished, ISBN, AuthorId, GenreId)
VALUES
('1984', 1949, '9780451524935', 16, 2),
('Animal Farm', 1945, '9780451526342', 16, 2),
('Brave New World', 1932, '9780060850524', 17, 2),
('The Doors of Perception', 1954, '9780060850531', 17, 2),
('The Shining', 1977, '9780307743657', 18, 9),
('It', 1986, '9781501142970', 18, 9),
('The Hunger Games', 2008, '9780439023481', 19, 7),
('Catching Fire', 2009, '9780439023498', 19, 7),
('Mockingjay', 2010, '9780439023511', 19, 7);

INSERT INTO LibrariesBooks
(LibraryId, BookId)
VALUES
(1, 36),
(1, 37),
(2, 38),
(2, 39),
(3, 40),
(3, 41),
(4, 42),
(4, 43),
(5, 44);

GO

-- =============================================================================
-- Problem 03: Update
-- =============================================================================

UPDATE Contacts
SET Website = CONCAT('www.', REPLACE(LOWER(a.Name), ' ', ''), '.com')
FROM Authors a
JOIN Contacts c
ON a.ContactId = c.Id
WHERE c.Website IS NULL;

GO

-- =============================================================================
-- Problem 04: Delete
-- =============================================================================

BEGIN TRY
    BEGIN TRANSACTION;
    DELETE lb FROM LibrariesBooks lb
    JOIN Books b ON lb.BookId = b.Id
    JOIN Authors a ON b.AuthorId = a.Id
    WHERE a.Name = 'Alex Michaelides';

    DELETE b FROM Books b
    JOIN Authors a ON b.AuthorId = a.Id
    WHERE a.Name = 'Alex Michaelides';

    DELETE FROM Authors
    WHERE [Name] = 'Alex Michaelides';
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'An Error occured when trying to delete author.'
END CATCH

GO

-- =============================================================================
-- QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERYING QUERY
-- =============================================================================

-- =============================================================================
-- Problem 05: Books by Year of Publication
-- =============================================================================

SELECT
    Title AS [Book Title],
    ISBN,
    YearPublished AS YearReleased
FROM Books
ORDER BY YearPublished DESC, Title;

GO

-- =============================================================================
-- Problem 06: Books by Genre
-- =============================================================================

SELECT 
    b.Id,
    b.Title,
    b.ISBN,
    g.Name
FROM Books b
JOIN Genres g ON b.GenreId = g.Id
WHERE g.Name IN ('Biography', 'Historical Fiction')
ORDER BY g.Name, b.Title;

GO

-- =============================================================================
-- Problem 07: Libraries Missing Specific Genre
-- =============================================================================

WITH cte_LibrariesContainingMysteryBooks (LibraryId)
AS
(
    SELECT DISTINCT lb.LibraryId
    FROM Books b
        JOIN LibrariesBooks lb ON lb.BookId = b.Id
        JOIN Genres g ON b.GenreId = g.Id
    WHERE g.Name = 'Mystery'
)
SELECT
    l.Name AS Library, 
    c.Email
FROM Libraries l
JOIN Contacts c ON l.ContactId = c.Id
WHERE l.Id NOT IN (SELECT * FROM cte_LibrariesContainingMysteryBooks)
ORDER BY Library;

GO

-- =============================================================================
-- Problem 08: First 3 Books
-- =============================================================================

SELECT TOP(3)
    b.Title,
    b.YearPublished AS [Year],
    g.Name AS Genre
FROM Books b
JOIN Genres g ON b.GenreId = g.Id
WHERE (b.YearPublished > 2000 AND CHARINDEX('a', b.Title, 0) != 0)
OR (b.YearPublished < 1950 AND PATINDEX('Fantasy', g.Name) != 0)
ORDER BY b.Title, b.YearPublished DESC;

GO

-- =============================================================================
-- Problem 09: Authors from the UK
-- =============================================================================

SELECT
    a.Name AS Author,
    c.Email,
    c.PostAddress AS Address
FROM Authors a
    JOIN Contacts c ON a.ContactId = c.Id
WHERE PATINDEX('%UK%', c.PostAddress) != 0
ORDER BY a.Name;

GO

-- =============================================================================
-- Problem 10: Fictions in Denver
-- =============================================================================

WITH cte_FictionBooks (Id, Title, AuthorId, LibraryId)
AS
(
    SELECT b.Id, b.Title, b.AuthorId, lb.LibraryId FROM Books b
    JOIN Genres g ON b.GenreId = g.Id
    JOIN LibrariesBooks lb ON lb.BookId = b.Id
    WHERE g.Name = 'Fiction'
)
SELECT a.Name, b.Title, l.Name, c.PostAddress FROM cte_FictionBooks b
JOIN Authors a ON b.AuthorId = a.Id
JOIN Libraries l ON b.LibraryId = l.Id
JOIN Contacts c ON l.ContactId = c.Id
WHERE PATINDEX('%Denver%', c.PostAddress) != 0
ORDER BY b.Title;

select * from libraries l
join contacts c on l.contactId = c.Id;

GO

-- =============================================================================
-- Problem 11: Authors with Books
-- =============================================================================

CREATE FUNCTION udf_AuthorsWithBooks
(
    @name nvarchar(100)
)
RETURNS int
AS
BEGIN
    DECLARE @booksCount int;

    SELECT @booksCount = COUNT(*) FROM Books b
    JOIN Authors a ON b.AuthorId = a.Id
    WHERE a.Name = @name;

    RETURN @booksCount;
END

GO

-- =============================================================================
-- Problem 12: Search for Books from a Specific Genre
-- =============================================================================

CREATE PROCEDURE usp_SearchByGenre
(
    @genreName nvarchar(30)
)
AS
BEGIN
    SELECT 
        b.Title,
        b.YearPublished AS [Year],
        b.ISBN,
        a.Name AS Author,
        g.Name AS Genre
    FROM Books b
    JOIN Genres g ON b.GenreId = g.Id
    JOIN Authors a ON b.AuthorId = a.Id
    WHERE g.Name = @genreName
    ORDER BY b.Title;
END

GO