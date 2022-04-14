CREATE TABLE [dbo].[RolePermission]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [RoleId] UNIQUEIDENTIFIER NOT NULL, 
    [PermissionId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_RolePermission_ToRole] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id]),
    CONSTRAINT [FK_RolePermission_ToPermission] FOREIGN KEY ([PermissionId]) REFERENCES [Permission]([Id])
)
