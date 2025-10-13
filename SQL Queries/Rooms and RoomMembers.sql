CREATE TABLE Rooms
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(MAX) NOT NULL,
	[Description] NVARCHAR(MAX),
	[Capacity] INT DEFAULT(2),
	[CreatedBy] INT NOT NULL,
	[CreatedOn] DATETIME DEFAULT(GETDATE()),
	[EventOn] DATETIME NOT NULL,
	[TotalCollection] INT NOT NULL,
	[CollectedTillNow] INT DEFAULT(0),
	CONSTRAINT FK_Rooms_Users_CreatedBy FOREIGN KEY([CreatedBy]) REFERENCES Users([EmployeeId]) 
);
CREATE TABLE RoomMembers
(
    [RoomId] INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    CONSTRAINT PK_RoomMembers PRIMARY KEY ([RoomId], [EmployeeId]),
    CONSTRAINT FK_RoomMembers_Rooms FOREIGN KEY ([RoomId]) REFERENCES Rooms([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_RoomMembers_Users FOREIGN KEY ([EmployeeId]) REFERENCES Users([EmployeeId])
);

SELECT * FROM Rooms
SELECT * FROM RoomMembers
DROP TABLE Rooms
DROP TABLE RoomMembers
DELETE FROM Rooms WHERE Name = 'test'
DBCC CHECKIDENT ('Rooms', RESEED, 1);