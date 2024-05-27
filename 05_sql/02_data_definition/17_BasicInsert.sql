USE SoftUni;
GO

INSERT INTO Towns (Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas'),
('Ruse');
GO

INSERT INTO Addresses (TownId, AddressText) VALUES
(1, '123 Main Street'),
(2, '456 Elm Avenue'),
(3, '789 Oak Road'),
(4, '101 Pine Street'),
(5, '202 Maple Lane');
GO

INSERT INTO Departments (Name) VALUES
('Software Development'),
('Engineering'),
('Quality Assurance'),
('Sales'),
('Marketing');
GO

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, HireDate, Salary, DepartmentId, AddressId) VALUES
('Frank', NULL, 'Lampard', '.NET Developer', '2020-01-15', 60000.00, 1, 1),
('John', NULL, 'Terry', 'Senior Engineer', '2021-03-20', 45000.00, 2, 2),
('Didier', NULL, 'Drogba', 'Intern', '2019-07-10', 55000.00, 3, 3),
('Joe', NULL, 'Cole', 'CEO', '2020-11-05', 50000.00, 4, 4),
('Ashley', NULL, 'Cole', 'Intern', '2022-02-28', 60000.00, 5, 5);
GO