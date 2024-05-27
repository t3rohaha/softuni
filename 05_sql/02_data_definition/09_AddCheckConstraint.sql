USE Minions;

ALTER TABLE Users
ADD CONSTRAINT CHK_Users_Password_MinLength CHECK (DATALENGTH(Password) > 4);