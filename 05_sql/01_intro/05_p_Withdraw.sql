CREATE PROC p_Withdraw
    @AccountId INT,
    @Amount DECIMAL(15, 2)
AS
BEGIN
    DECLARE @Balance decimal(15, 2) = (
        SELECT Balance
        FROM Accounts
        WHERE Id = @AccountId)
    IF (@Balance - @Amount >= 0)
    BEGIN
        UPDATE Accounts
        SET Balance -= @Amount
        WHERE Id = @AccountId
    END
    ELSE
    BEGIN
        RAISERROR('Insufficient funds', 10, 1)
    END
END