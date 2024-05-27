USE Hotel;
GO

-- Get Tax rate before decrease.
SELECT Id, TaxRate FROM Payments
ORDER BY TaxRate DESC;
GO

-- The operation is not applied as expected because of TaxRate data type
-- precision.
UPDATE Payments SET TaxRate = TaxRate - (TaxRate * 0.03);
GO

-- Get Tax rate after decrease.
SELECT Id, TaxRate FROM Payments
ORDER BY TaxRate DESC;
GO