CREATE TABLE [dbo].[Attachment]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [RequestId] UNIQUEIDENTIFIER NOT NULL, 
    [TypeId] UNIQUEIDENTIFIER NOT NULL, 
    [Url] NVARCHAR(255) NOT NULL UNIQUE, 
    CONSTRAINT [FK_Attachment_ToRequest] FOREIGN KEY ([RequestId]) REFERENCES [Request]([Id]), 
    CONSTRAINT [FK_Attachment_ToDocumentType] FOREIGN KEY ([TypeId]) REFERENCES [DocumentType]([Id]) 
)

GO

CREATE INDEX [IX_Attachment_Url] ON [dbo].[Attachment] ([Url])
