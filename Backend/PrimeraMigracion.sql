IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [dsEmployees] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [RFC] nvarchar(max) NOT NULL,
    [BornDate] datetime2 NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_dsEmployees] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230419175543_PrimeraMigracion', N'7.0.5');
GO

COMMIT;
GO

