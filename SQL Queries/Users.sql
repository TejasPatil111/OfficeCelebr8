CREATE TABLE Users
(
	[Id] NVARCHAR(100) PRIMARY KEY,
	[EmployeeId] INT UNIQUE,
	[Name] NVARCHAR(MAX) NOT NULL,
	[Email] NVARCHAR(100) UNIQUE NOT NULL,
	[Password] NVARCHAR(15) NOT NULL,
	[Designation] NVARCHAR(100) NOT NULL,
	[Role] INT NOT NULL
);

SELECT * FROM Users
DROP TABLE Users
INSERT INTO Users(Id, EmployeeId, Name, Email, Password, Designation, Role)
Values('36ba7d88-39c9-4f8a-805e-6dbd740332f4', 13566, 'Tejas Patil', 'tejas@gmail.com', 'Tejas@123', 'Software Engineer', 2);
INSERT INTO Users(Id, EmployeeId, Name, Email, Password, Designation, Role)
Values('DBF79803-E7C7-4779-BC94-3A6B6232128E', 0, 'Admin', 'admin@officecelebr8.com', 'Admin@123', 'Software Engineer', 1);

