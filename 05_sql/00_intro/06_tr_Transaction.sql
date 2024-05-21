CREATE TRIGGER tr_Transaction ON Accounts
AFTER UPDATE
AS
BEGIN
    INSERT INTO Transactions (AccountId, OldBalance, NewBalance, CreatedAt)
    SELECT inserted.Id, deleted.Balance, inserted.Balance, GETDATE()
    FROM inserted
        JOIN deleted ON inserted.Id = deleted.Id;
END