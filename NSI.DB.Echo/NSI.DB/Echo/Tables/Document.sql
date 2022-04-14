CREATE TABLE [dbo].[Document]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [RequestId] UNIQUEIDENTIFIER NOT NULL, 
    [TypeId] UNIQUEIDENTIFIER NOT NULL, 
    [DateCreated] DATETIME NOT NULL DEFAULT getdate(), 
    [DateOfExpiration] DATETIME NULL, 
    [Url] NVARCHAR(255) NOT NULL UNIQUE, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [Title] NVARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_Document_ToRequest] FOREIGN KEY ([RequestId]) REFERENCES [Request]([Id]), 
    CONSTRAINT [FK_Document_ToDocumentType] FOREIGN KEY ([TypeId]) REFERENCES [DocumentType]([Id])
)

GO

CREATE INDEX [IX_Document_Url] ON [dbo].[Document] ([Url])
