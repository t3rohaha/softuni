CREATE PROC p_AddAccount (@ClientId INT, @AccountTypeId INT)
AS
BEGIN
    INSERT INTO Accounts (ClientId, AccountTypeId)
    VALUES (@ClientId, @AccountTypeId)
END