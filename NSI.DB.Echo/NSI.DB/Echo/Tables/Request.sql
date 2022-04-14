CREATE TABLE [dbo].[Request]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL, 
    [DateCreated] DATETIME NOT NULL DEFAULT getdate(), 
    [Reason] NVARCHAR(255) NOT NULL, 
    [Type] NVARCHAR(50) NOT NULL CHECK ([Type] IN ('Passport', 'Visa')), 
    [State] NVARCHAR(50) NOT NULL CHECK ([State] IN ('Pending', 'Approved', 'Rejected')), 
    CONSTRAINT [FK_Request_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Request_ToEmployee] FOREIGN KEY ([EmployeeId]) REFERENCES [User]([Id]),
)
