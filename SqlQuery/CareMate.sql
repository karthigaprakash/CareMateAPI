USE CareMates

-- 12/11/2025 --

Select * from [User]
Select * from [UserRole]
Select * from [Role]

ALTER TABLE [User]
ADD [IsDelete] BIT NOT NULL DEFAULT 0;

-- Insert Role
INSERT INTO [Role] (RoleName, Description, IsDelete, CreatedDate,ModifiedDate)
VALUES ('Admin', 'System Admin', 0, GETDATE(),NULL);

-- Link User to Role
INSERT INTO [UserRole] (UserId, RoleId, IsDelete, CreatedDate, ModifiedDate)
VALUES (1, 1, 0, GETDATE(), NULL);

