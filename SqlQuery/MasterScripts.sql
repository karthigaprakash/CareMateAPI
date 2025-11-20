Use CareMates

CREATE DATABASE CareMates 

CREATE TABLE [User] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [UserName] VARCHAR(50),
    [Email] VARCHAR(50),
    [Password] VARCHAR(50),
    [MobileNumber] VARCHAR(20),
    [CreatedDate] DATETIME NOT NULL,
    [ModifiedDate] DATETIME NULL
);

CREATE TABLE [Role] (
    [RoleId] INT PRIMARY KEY IDENTITY(1,1),
    [RoleName] VARCHAR(50),
    [Description] VARCHAR(200),
    [IsDelete] BIT DEFAULT 0,
    [CreatedDate] DATETIME NOT NULL,
    [ModifiedDate] DATETIME NULL
);

CREATE TABLE [UserRole] (
    [UserRoleId] INT PRIMARY KEY IDENTITY(1,1),
    [UserId] INT,
    [RoleId] INT,
    [IsDelete] BIT DEFAULT 0,
    [CreatedDate] DATETIME NOT NULL,
    [ModifiedDate] DATETIME NULL,
    FOREIGN KEY (UserId) REFERENCES [User](Id),
    FOREIGN KEY (RoleId) REFERENCES [Role](RoleId)
);