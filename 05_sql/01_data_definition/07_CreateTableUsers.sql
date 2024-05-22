USE Minions;

CREATE TABLE Users
(
    Id int PRIMARY KEY IDENTITY,
    Username varchar(30) NOT NULL UNIQUE,
    Password varchar(26) NOT NULL,
    ProfilePicture varbinary(MAX),
    LastLogin datetime2,
    IsDeleted bit DEFAULT(0) NOT NULL
);

ALTER TABLE Users
ADD CONSTRAINT CHK_Users_ProfilePicture_900kb
CHECK (DATALENGTH(ProfilePicture) <= 921600);

INSERT INTO Users
(Username, Password)
VALUES
('John_Terry', '12345'),
('Frank_Lampard', '12345'),
('Didier_Drogba', '12345'),
('Diego_Costa', '12345'),
('Cole_Palmer', '12345');

TRUNCATE TABLE Users;