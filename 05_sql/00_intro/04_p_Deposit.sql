CREATE PROC p_Deposit (@AccountId INT, @Amount DECIMAL(15, 2))
AS
BEGIN
    UPDATE Accounts
    SET Balance += @Amount
    WHERE Id = @AccountId
END