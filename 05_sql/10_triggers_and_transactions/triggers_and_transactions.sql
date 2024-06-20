-- =============================================================================
-- TRIGGERS AND TRANSACTIONS TRIGGERS AND TRANSACTIONS TRIGGERS AND TRANSACTIONS
-- =============================================================================

-- =============================================================================
-- BANK DATABASE BANK DATABASE BANK DATABASE BANK DATABASE BANK DATABASE BANK DA
-- =============================================================================

USE Bank;
GO

-- Problem 01. Create table logs and add trigger to the Account table that
-- enters a new entry into the logs table everytime the balance on Account
-- changes.

CREATE TABLE Logs
(
    LogId int NOT NULL IDENTITY,
    AccountId int NOT NULL,
    OldSum money NOT NULL,
    NewSum money NOT NULL,
    CONSTRAINT PK_Logs_LogId PRIMARY KEY (LogId),
    CONSTRAINT FK_Logs_AccountId FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
    CONSTRAINT CHK_Logs_OldSum CHECK (OldSum > 0),
    CONSTRAINT CHK_Logs_NewSum CHECK (NewSum >= 0)
);
GO

CREATE TRIGGER tr_BalanceChange
ON Accounts
AFTER UPDATE
AS
BEGIN
    DECLARE @accountId int, @oldBalance money, @newBalance money;

    SELECT
        @accountId = i.Id,
        @oldBalance = d.Balance,
        @newBalance = i.Balance
    FROM deleted d
    JOIN inserted i
    ON d.Id = i.Id;

    INSERT INTO Logs
    (AccountId, OldSum, NewSum)
    VALUES
    (@accountId, @oldBalance, @newBalance);
END
GO

UPDATE Accounts
SET Balance += 1000
WHERE Id = 1;
GO

-- Problem 02. Create table NotificationEmails, add trigger to the Log table,
-- create new email when new record is inserted in Logs.

CREATE TABLE NotificationEmails
(
    Id int NOT NULL IDENTITY,
    Recipient int NOT NULL,
    Subject varchar(max) NOT NULL,
    Body varchar(max) NOT NULL,
    CONSTRAINT PK_NotificationEmails_Id PRIMARY KEY (Id),
    CONSTRAINT FK_NotificationEmails_Recipient FOREIGN KEY (Recipient) REFERENCES Accounts(Id)
); 
GO

CREATE TRIGGER tr_NewLog
ON Logs
AFTER INSERT
AS
BEGIN
    DECLARE @recipient int, @subject varchar(max), @body varchar(max);

    SELECT
        @recipient = i.AccountId,
        @subject = CONCAT('Balance change for account: ', i.AccountId),
        @body = CONCAT(
            'On ',
            GETDATE(),
            ' your balance was changed from ',
            i.OldSum,
            ' to ',
            i.NewSum,
            '.') 
    FROM inserted i;

    INSERT INTO NotificationEmails
    (Recipient, Subject, Body)
    VALUES
    (@recipient, @subject, @body);
END
GO

UPDATE Accounts
SET Balance += 1000
WHERE Id = 1;
GO

-- Problem 03. Add stored procedure usp_DepositMoney. It should validate that
-- the money deposited is positive number.

CREATE PROCEDURE usp_DepositMoney
(
    @AccountId int,
    @MoneyAmount decimal(10, 4)
)
AS
BEGIN
    IF (@MoneyAmount >= 0)
    BEGIN
        UPDATE Accounts
        SET Balance += @MoneyAmount
        WHERE Id = @AccountId;
    END
END
GO

EXECUTE usp_DepositMoney 1, 1000;
GO

-- Problem 04. Add stored procedure usp_WithdrawMoney. It should validate that
-- the money withdrawn is positive number.

CREATE PROCEDURE usp_WithdrawMoney
(
    @AccountId int,
    @MoneyAmount decimal(10, 4)
)
AS
BEGIN
    IF (@MoneyAmount >= 0)
    BEGIN
        UPDATE Accounts
        SET Balance -= @MoneyAmount
        WHERE Id = @AccountId;
    END
END
GO

EXECUTE usp_WithdrawMoney 1, 1000;
GO

-- Problem 05. Write stored procedure usp_TransferMoney. It should transfer
-- money from one account to another. Money should be positive. Use transaction
-- to make sure the whole precedure executes or fails as one.

CREATE PROCEDURE usp_TransferMoney
(
    @SenderId int,
    @ReceiverId int,
    @Amount decimal(10, 4)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF (@Amount <= 0)
        BEGIN
            RAISERROR('Amount should be greater than 0.', 16, 1);
        END

        EXECUTE usp_WithdrawMoney @SenderId, @Amount;

        EXECUTE usp_DepositMoney @ReceiverId, @Amount;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO

EXECUTE usp_TransferMoney 2, 1, 1000;
GO

-- =============================================================================
-- DIABLO DATABASE DIABLO DATABASE DIABLO DATABASE DIABLO DATABASE DIABLO DATABA
-- =============================================================================

USE Diablo;
GO

-- Problem 06. Create trigger that restricts users from buying items with
-- greater level than theirs.

CREATE TRIGGER tr_ValidateItemPurchase
ON UserGameItems
AFTER INSERT
AS
BEGIN
    DECLARE @ItemLvl int;
    DECLARE @UserLvl int;

    SELECT
        @ItemLvl = items.MinLevel,
        @UserLvl = ug.Level
    FROM inserted i
    JOIN Items items
    ON i.ItemId = items.Id
    JOIN UsersGames ug
    ON i.UserGameId = ug.Id;

    IF (@ItemLvl > @UserLvl)
    BEGIN
        RAISERROR('User level not enough.', 16, 1);
    END
END 
GO

CREATE PROCEDURE usp_AddBonus
(
    @Username nvarchar(50),
    @GameName nvarchar(50),
    @Cash money
)
AS
BEGIN
    DECLARE @GameId int, @UserId int;

    SELECT @GameId = Id
    FROM Games
    WHERE Name = @GameName;

    SELECT @UserId = Id
    FROM Users
    WHERE Username = @Username;

    UPDATE UsersGames
    SET Cash += @Cash
    WHERE GameId = @GameId AND UserId = @UserId;
END
GO

BEGIN TRY
    BEGIN TRANSACTION;
    EXECUTE usp_AddBonus 'baleremuda', 'Bali', 50000;
    EXECUTE usp_AddBonus 'loosenoise', 'Bali', 50000;
    EXECUTE usp_AddBonus 'inguinalself', 'Bali', 50000;
    EXECUTE usp_AddBonus 'buildingdeltoid', 'Bali', 50000;
    EXECUTE usp_AddBonus 'monoxidecos', 'Bali', 50000;
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH
GO

CREATE PROCEDURE usp_GetUserItems
(
    @GameName nvarchar(50)
)
AS
BEGIN
    SELECT
        u.Username,
        g.Name AS GameName,
        ug.Cash,
        i.Name AS ItemName
    FROM Games g
    JOIN UsersGames ug
    ON g.Id = ug.GameId
    JOIN Users u
    ON u.Id = ug.UserId
    JOIN UserGameItems ugi
    ON ug.Id = ugi.UserGameId
    JOIN Items i
    ON i.Id = ugi.ItemId
    WHERE g.Name = 'Bali' AND g.IsFinished = 0
    ORDER BY u.Username, i.Name;
END
GO

CREATE PROCEDURE usp_BuyItem
(
    @ItemId int,
    @Username varchar(50),
    @GameName varchar(50)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
            DECLARE @UserGameId int, @ItemPrice int;

            SELECT @UserGameId = ug.Id FROM UsersGames ug
            JOIN Users u ON u.Id = ug.UserId
            JOIN Games g ON g.Id = ug.GameId
            WHERE u.Username = @Username
                AND g.Name = @GameName
                AND g.IsFinished = 0;

            SELECT @ItemPrice = Price FROM Items
            WHERE Id = @ItemId;

            INSERT INTO UserGameItems
            (ItemId, UserGameId)
            VALUES
            (@ItemId, @UserGameId);

            UPDATE UsersGames
            SET Cash -= @ItemPrice
            WHERE Id = @UserGameId;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO

-- =============================================================================
-- SoftUni Database SoftUni Database SoftUni Database SoftUni Database SoftUni D
-- =============================================================================

USE SoftUni;
GO

-- Problem 08. Create procedure that assigns projects to employee. If employee
-- has more than 3 projects, throw exception.

CREATE PROCEDURE usp_AssignProject
(
    @employeeId int,
    @projectId int
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ProjectsCount int;

        SELECT @ProjectsCount = COUNT(*)
        FROM EmployeesProjects
        WHERE EmployeeId = @employeeId;

        IF (@ProjectsCount >= 3)
        BEGIN
            RAISERROR('The employee has too many projects!', 16, 1);
        END

        INSERT INTO EmployeesProjects
        (EmployeeID, ProjectID)
        VALUES
        (@employeeId, @projectId);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage nvarchar(max);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END