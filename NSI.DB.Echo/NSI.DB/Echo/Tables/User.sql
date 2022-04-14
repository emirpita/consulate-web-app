CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [DateCreated] DATETIME NOT NULL DEFAULT getdate(), 
    [FirstName] NVARCHAR(255) NOT NULL, 
    [LastName] NVARCHAR(255) NOT NULL, 
    [Gender] NVARCHAR(50) NOT NULL CHECK ([Gender] IN ('Male', 'Female')), 
    [Email] NVARCHAR(255) NOT NULL UNIQUE, 
    [Username] NVARCHAR(255) NOT NULL UNIQUE, 
    [Password] NVARCHAR(255) NOT NULL, 
    [PlaceOfBirth] NVARCHAR(255) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1,
    [SysStartTime] DATETIME2(7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime] DATETIME2(7) GENERATED ALWAYS AS ROW END NOT NULL,
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[UserHistory], DATA_CONSISTENCY_CHECK=ON));

GO

CREATE INDEX [IX_User_Username] ON [dbo].[User] ([Username])

GO

CREATE INDEX [IX_User_Email] ON [dbo].[User] ([Email])
