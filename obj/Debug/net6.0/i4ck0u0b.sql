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

CREATE TABLE [UserViewModel] (
    [AuthZeroId] nvarchar(450) NOT NULL,
    [UserNickname] nvarchar(max) NULL,
    [UserEmail] nvarchar(max) NULL,
    [UserRole] nvarchar(max) NULL,
    [AdminViewModelAuthZeroId1] nvarchar(450) NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [AdminViewModelAuthZeroId] nvarchar(450) NULL,
    CONSTRAINT [PK_UserViewModel] PRIMARY KEY ([AuthZeroId]),
    CONSTRAINT [FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId] FOREIGN KEY ([AdminViewModelAuthZeroId]) REFERENCES [UserViewModel] ([AuthZeroId]),
    CONSTRAINT [FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId1] FOREIGN KEY ([AdminViewModelAuthZeroId1]) REFERENCES [UserViewModel] ([AuthZeroId])
);
GO

CREATE TABLE [IssueViewModel] (
    [Id] int NOT NULL IDENTITY,
    [IssueName] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastUpdateDate] datetime2 NOT NULL,
    [CurrentSeverity] int NULL,
    [CurrentStatus] int NOT NULL,
    [ReportedByUserId] nvarchar(max) NULL,
    [AssignedToUserId] nvarchar(max) NULL,
    [UserViewModelAuthZeroId] nvarchar(450) NULL,
    CONSTRAINT [PK_IssueViewModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IssueViewModel_UserViewModel_UserViewModelAuthZeroId] FOREIGN KEY ([UserViewModelAuthZeroId]) REFERENCES [UserViewModel] ([AuthZeroId])
);
GO

CREATE TABLE [NotificationViewModels] (
    [Id] int NOT NULL IDENTITY,
    [UserViewModelAuthZeroId] nvarchar(450) NULL,
    CONSTRAINT [PK_NotificationViewModels] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_NotificationViewModels_UserViewModel_UserViewModelAuthZeroId] FOREIGN KEY ([UserViewModelAuthZeroId]) REFERENCES [UserViewModel] ([AuthZeroId])
);
GO

CREATE TABLE [ProjectViewModel] (
    [Id] int NOT NULL IDENTITY,
    [ProjectName] nvarchar(max) NULL,
    [ProjectAdminAuthZeroId] nvarchar(450) NULL,
    CONSTRAINT [PK_ProjectViewModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProjectViewModel_UserViewModel_ProjectAdminAuthZeroId] FOREIGN KEY ([ProjectAdminAuthZeroId]) REFERENCES [UserViewModel] ([AuthZeroId])
);
GO

CREATE TABLE [MessageViewModel] (
    [Id] int NOT NULL IDENTITY,
    [ParentMassageId] int NOT NULL,
    [CreatedTime] datetime2 NULL,
    [SenderUserId] nvarchar(max) NOT NULL,
    [ReceiverUserId] nvarchar(max) NULL,
    [Message] nvarchar(max) NULL,
    [Viewed] bit NOT NULL,
    [IssueViewModelId] int NULL,
    [UserViewModelAuthZeroId] nvarchar(450) NULL,
    CONSTRAINT [PK_MessageViewModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MessageViewModel_IssueViewModel_IssueViewModelId] FOREIGN KEY ([IssueViewModelId]) REFERENCES [IssueViewModel] ([Id]),
    CONSTRAINT [FK_MessageViewModel_UserViewModel_UserViewModelAuthZeroId] FOREIGN KEY ([UserViewModelAuthZeroId]) REFERENCES [UserViewModel] ([AuthZeroId])
);
GO

CREATE INDEX [IX_IssueViewModel_UserViewModelAuthZeroId] ON [IssueViewModel] ([UserViewModelAuthZeroId]);
GO

CREATE INDEX [IX_MessageViewModel_IssueViewModelId] ON [MessageViewModel] ([IssueViewModelId]);
GO

CREATE INDEX [IX_MessageViewModel_UserViewModelAuthZeroId] ON [MessageViewModel] ([UserViewModelAuthZeroId]);
GO

CREATE INDEX [IX_NotificationViewModels_UserViewModelAuthZeroId] ON [NotificationViewModels] ([UserViewModelAuthZeroId]);
GO

CREATE INDEX [IX_ProjectViewModel_ProjectAdminAuthZeroId] ON [ProjectViewModel] ([ProjectAdminAuthZeroId]);
GO

CREATE INDEX [IX_UserViewModel_AdminViewModelAuthZeroId] ON [UserViewModel] ([AdminViewModelAuthZeroId]);
GO

CREATE INDEX [IX_UserViewModel_AdminViewModelAuthZeroId1] ON [UserViewModel] ([AdminViewModelAuthZeroId1]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220812162556_Initial_create', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [IssueViewModel] DROP CONSTRAINT [FK_IssueViewModel_UserViewModel_UserViewModelAuthZeroId];
GO

ALTER TABLE [MessageViewModel] DROP CONSTRAINT [FK_MessageViewModel_UserViewModel_UserViewModelAuthZeroId];
GO

ALTER TABLE [NotificationViewModels] DROP CONSTRAINT [FK_NotificationViewModels_UserViewModel_UserViewModelAuthZeroId];
GO

ALTER TABLE [ProjectViewModel] DROP CONSTRAINT [FK_ProjectViewModel_UserViewModel_ProjectAdminAuthZeroId];
GO

ALTER TABLE [UserViewModel] DROP CONSTRAINT [FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId];
GO

ALTER TABLE [UserViewModel] DROP CONSTRAINT [FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId1];
GO

ALTER TABLE [UserViewModel] DROP CONSTRAINT [PK_UserViewModel];
GO

DROP INDEX [IX_UserViewModel_AdminViewModelAuthZeroId] ON [UserViewModel];
GO

DROP INDEX [IX_UserViewModel_AdminViewModelAuthZeroId1] ON [UserViewModel];
GO

DROP INDEX [IX_ProjectViewModel_ProjectAdminAuthZeroId] ON [ProjectViewModel];
GO

DROP INDEX [IX_NotificationViewModels_UserViewModelAuthZeroId] ON [NotificationViewModels];
GO

DROP INDEX [IX_MessageViewModel_UserViewModelAuthZeroId] ON [MessageViewModel];
GO

DROP INDEX [IX_IssueViewModel_UserViewModelAuthZeroId] ON [IssueViewModel];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserViewModel]') AND [c].[name] = N'AdminViewModelAuthZeroId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [UserViewModel] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [UserViewModel] DROP COLUMN [AdminViewModelAuthZeroId];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserViewModel]') AND [c].[name] = N'AdminViewModelAuthZeroId1');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [UserViewModel] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [UserViewModel] DROP COLUMN [AdminViewModelAuthZeroId1];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserViewModel]') AND [c].[name] = N'Discriminator');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [UserViewModel] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [UserViewModel] DROP COLUMN [Discriminator];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProjectViewModel]') AND [c].[name] = N'ProjectAdminAuthZeroId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ProjectViewModel] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [ProjectViewModel] DROP COLUMN [ProjectAdminAuthZeroId];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[NotificationViewModels]') AND [c].[name] = N'UserViewModelAuthZeroId');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [NotificationViewModels] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [NotificationViewModels] DROP COLUMN [UserViewModelAuthZeroId];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MessageViewModel]') AND [c].[name] = N'UserViewModelAuthZeroId');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [MessageViewModel] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [MessageViewModel] DROP COLUMN [UserViewModelAuthZeroId];
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'UserViewModelAuthZeroId');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [IssueViewModel] DROP COLUMN [UserViewModelAuthZeroId];
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserViewModel]') AND [c].[name] = N'AuthZeroId');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [UserViewModel] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [UserViewModel] ALTER COLUMN [AuthZeroId] nvarchar(max) NULL;
GO

ALTER TABLE [UserViewModel] ADD [Id] int NOT NULL IDENTITY;
GO

ALTER TABLE [UserViewModel] ADD [AdminViewModelId] int NULL;
GO

ALTER TABLE [ProjectViewModel] ADD [ProjectAdminId] int NULL;
GO

ALTER TABLE [NotificationViewModels] ADD [UserViewModelId] int NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MessageViewModel]') AND [c].[name] = N'SenderUserId');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [MessageViewModel] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [MessageViewModel] ALTER COLUMN [SenderUserId] int NULL;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MessageViewModel]') AND [c].[name] = N'ReceiverUserId');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [MessageViewModel] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [MessageViewModel] ALTER COLUMN [ReceiverUserId] int NULL;
GO

ALTER TABLE [MessageViewModel] ADD [UserViewModelId] int NULL;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'ReportedByUserId');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [IssueViewModel] ALTER COLUMN [ReportedByUserId] int NULL;
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'IssueName');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [IssueViewModel] ALTER COLUMN [IssueName] nvarchar(max) NULL;
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'CurrentStatus');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [IssueViewModel] ALTER COLUMN [CurrentStatus] int NULL;
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'AssignedToUserId');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [IssueViewModel] ALTER COLUMN [AssignedToUserId] int NULL;
GO

ALTER TABLE [IssueViewModel] ADD [UserViewModelId] int NULL;
GO

ALTER TABLE [UserViewModel] ADD CONSTRAINT [PK_UserViewModel] PRIMARY KEY ([Id]);
GO

CREATE TABLE [AdminViewModel] (
    [Id] int NOT NULL IDENTITY,
    [ParentId] int NULL,
    CONSTRAINT [PK_AdminViewModel] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_UserViewModel_AdminViewModelId] ON [UserViewModel] ([AdminViewModelId]);
GO

CREATE INDEX [IX_ProjectViewModel_ProjectAdminId] ON [ProjectViewModel] ([ProjectAdminId]);
GO

CREATE INDEX [IX_NotificationViewModels_UserViewModelId] ON [NotificationViewModels] ([UserViewModelId]);
GO

CREATE INDEX [IX_MessageViewModel_UserViewModelId] ON [MessageViewModel] ([UserViewModelId]);
GO

CREATE INDEX [IX_IssueViewModel_UserViewModelId] ON [IssueViewModel] ([UserViewModelId]);
GO

ALTER TABLE [IssueViewModel] ADD CONSTRAINT [FK_IssueViewModel_UserViewModel_UserViewModelId] FOREIGN KEY ([UserViewModelId]) REFERENCES [UserViewModel] ([Id]);
GO

ALTER TABLE [MessageViewModel] ADD CONSTRAINT [FK_MessageViewModel_UserViewModel_UserViewModelId] FOREIGN KEY ([UserViewModelId]) REFERENCES [UserViewModel] ([Id]);
GO

ALTER TABLE [NotificationViewModels] ADD CONSTRAINT [FK_NotificationViewModels_UserViewModel_UserViewModelId] FOREIGN KEY ([UserViewModelId]) REFERENCES [UserViewModel] ([Id]);
GO

ALTER TABLE [ProjectViewModel] ADD CONSTRAINT [FK_ProjectViewModel_AdminViewModel_ProjectAdminId] FOREIGN KEY ([ProjectAdminId]) REFERENCES [AdminViewModel] ([Id]);
GO

ALTER TABLE [UserViewModel] ADD CONSTRAINT [FK_UserViewModel_AdminViewModel_AdminViewModelId] FOREIGN KEY ([AdminViewModelId]) REFERENCES [AdminViewModel] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220815072623_Updated_Tables', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MessageViewModel]') AND [c].[name] = N'ParentMassageId');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [MessageViewModel] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [MessageViewModel] DROP COLUMN [ParentMassageId];
GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'ReportedByUserId');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [IssueViewModel] DROP COLUMN [ReportedByUserId];
GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserViewModel]') AND [c].[name] = N'UserRole');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [UserViewModel] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [UserViewModel] ALTER COLUMN [UserRole] int NULL;
ALTER TABLE [UserViewModel] ADD DEFAULT 0 FOR [UserRole];
GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserViewModel]') AND [c].[name] = N'AuthZeroId');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [UserViewModel] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [UserViewModel] ALTER COLUMN [AuthZeroId] nvarchar(max) NOT NULL;
ALTER TABLE [UserViewModel] ADD DEFAULT N'' FOR [AuthZeroId];
GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MessageViewModel]') AND [c].[name] = N'SenderUserId');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [MessageViewModel] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [MessageViewModel] ALTER COLUMN [SenderUserId] int NOT NULL;
ALTER TABLE [MessageViewModel] ADD DEFAULT 0 FOR [SenderUserId];
GO

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MessageViewModel]') AND [c].[name] = N'ReceiverUserId');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [MessageViewModel] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [MessageViewModel] ALTER COLUMN [ReceiverUserId] int NOT NULL;
ALTER TABLE [MessageViewModel] ADD DEFAULT 0 FOR [ReceiverUserId];
GO

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MessageViewModel]') AND [c].[name] = N'CreatedTime');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [MessageViewModel] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [MessageViewModel] ALTER COLUMN [CreatedTime] datetime2 NOT NULL;
ALTER TABLE [MessageViewModel] ADD DEFAULT '0001-01-01T00:00:00.0000000' FOR [CreatedTime];
GO

DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'CurrentStatus');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [IssueViewModel] ALTER COLUMN [CurrentStatus] int NOT NULL;
ALTER TABLE [IssueViewModel] ADD DEFAULT 0 FOR [CurrentStatus];
GO

DECLARE @var22 sysname;
SELECT @var22 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'CurrentSeverity');
IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var22 + '];');
ALTER TABLE [IssueViewModel] ALTER COLUMN [CurrentSeverity] int NOT NULL;
ALTER TABLE [IssueViewModel] ADD DEFAULT 0 FOR [CurrentSeverity];
GO

DECLARE @var23 sysname;
SELECT @var23 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'AssignedToUserId');
IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var23 + '];');
ALTER TABLE [IssueViewModel] ALTER COLUMN [AssignedToUserId] int NOT NULL;
ALTER TABLE [IssueViewModel] ADD DEFAULT 0 FOR [AssignedToUserId];
GO

ALTER TABLE [AdminViewModel] ADD [AuthZeroId] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221206120053_from-scratch', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [MessageViewModel] DROP CONSTRAINT [FK_MessageViewModel_UserViewModel_UserViewModelId];
GO

ALTER TABLE [ProjectViewModel] DROP CONSTRAINT [FK_ProjectViewModel_AdminViewModel_ProjectAdminId];
GO

ALTER TABLE [UserViewModel] DROP CONSTRAINT [FK_UserViewModel_AdminViewModel_AdminViewModelId];
GO

DROP TABLE [AdminViewModel];
GO

DROP TABLE [NotificationViewModels];
GO

DROP INDEX [IX_UserViewModel_AdminViewModelId] ON [UserViewModel];
GO

DROP INDEX [IX_ProjectViewModel_ProjectAdminId] ON [ProjectViewModel];
GO

DROP INDEX [IX_MessageViewModel_UserViewModelId] ON [MessageViewModel];
GO

DECLARE @var24 sysname;
SELECT @var24 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserViewModel]') AND [c].[name] = N'AdminViewModelId');
IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [UserViewModel] DROP CONSTRAINT [' + @var24 + '];');
ALTER TABLE [UserViewModel] DROP COLUMN [AdminViewModelId];
GO

DECLARE @var25 sysname;
SELECT @var25 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProjectViewModel]') AND [c].[name] = N'ProjectAdminId');
IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [ProjectViewModel] DROP CONSTRAINT [' + @var25 + '];');
ALTER TABLE [ProjectViewModel] DROP COLUMN [ProjectAdminId];
GO

DECLARE @var26 sysname;
SELECT @var26 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MessageViewModel]') AND [c].[name] = N'ReceiverUserId');
IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [MessageViewModel] DROP CONSTRAINT [' + @var26 + '];');
ALTER TABLE [MessageViewModel] DROP COLUMN [ReceiverUserId];
GO

DECLARE @var27 sysname;
SELECT @var27 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MessageViewModel]') AND [c].[name] = N'UserViewModelId');
IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [MessageViewModel] DROP CONSTRAINT [' + @var27 + '];');
ALTER TABLE [MessageViewModel] DROP COLUMN [UserViewModelId];
GO

EXEC sp_rename N'[MessageViewModel].[SenderUserId]', N'CreatedByUserId', N'COLUMN';
GO

ALTER TABLE [ProjectViewModel] ADD [ProjectManagerId] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208075840_made_lots_of_changes', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208091947_list_to_collections', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208105642_add_virtual', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var28 sysname;
SELECT @var28 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IssueViewModel]') AND [c].[name] = N'AssignedToUserId');
IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [IssueViewModel] DROP CONSTRAINT [' + @var28 + '];');
ALTER TABLE [IssueViewModel] DROP COLUMN [AssignedToUserId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208113939_remove_assignedtouserid', N'6.0.8');
GO

COMMIT;
GO

