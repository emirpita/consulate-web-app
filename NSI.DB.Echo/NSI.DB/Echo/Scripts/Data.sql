/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Default document types
INSERT INTO DocumentType(Name)
VALUES
('Passport'),
('Visa'),
('PersonalIdentity'), -- licna karta
('CitizenIdentity'), -- cips
('CitizenshipCetificate'), -- drzavljanstvo
('Image'),
('Other');

-- Default roles
INSERT INTO Role(Name)
VALUES
('Admin'),
('Employee'),
('User');

INSERT INTO Permission(Name)
VALUES
('role:modify'),
('permission:modify'),
('employee:create'),
('employee:delete'),
('employee:update'),
('user:delete'),
('document:create'),
('document:view'),
('request:view'),
('request:create'),
('profile:view');

-- Admin permissions
INSERT INTO RolePermission(RoleId, PermissionId)
SELECT r.Id, p.Id FROM Role r, Permission p WHERE r.Name = 'Admin' AND p.Name IN (
    'role:modify',
    'permission:modify',
    'employee:create',
    'employee:delete',
    'employee:update',
    'user:delete'
);

-- Employee permissions
INSERT INTO RolePermission(RoleId, PermissionId)
SELECT r.Id, p.Id FROM Role r, Permission p WHERE r.Name = 'Employee' AND p.Name IN (
    'document:create',
    'document:view',
    'request:view'
);

-- User permissions
INSERT INTO RolePermission(RoleId, PermissionId)
SELECT r.Id, p.Id FROM Role r, Permission p WHERE r.Name = 'User' AND p.Name IN (
    'profile:view',
    'request:create',
    'document:view'
);
