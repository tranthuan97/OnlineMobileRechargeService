-- -------------------------------------------------------------
-- TablePlus 3.12.0(354)
--
-- https://tableplus.com/
--
-- Database: OMRSDb
-- Generation Time: 2020-12-14 09:58:56.1280
-- -------------------------------------------------------------


-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId] nvarchar(150),
    [ProductVersion] nvarchar(32),
    PRIMARY KEY ([MigrationId])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[AppConfigs] (
    [Key] nvarchar(450),
    [Value] nvarchar(MAX),
    PRIMARY KEY ([Key])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[AppUsers] (
    [Id] int IDENTITY,
    [FirstName] nvarchar(MAX),
    [LastName] nvarchar(MAX),
    [Username] nvarchar(MAX),
    [Password] nvarchar(MAX),
    [Email] nvarchar(MAX),
    [Address] nvarchar(MAX),
    [VerifyCode] nvarchar(MAX),
    [Role] nvarchar(MAX),
    [Token] nvarchar(MAX),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[CallerTunes] (
    [Id] int IDENTITY,
    [Name] nvarchar(MAX),
    [Singer] nvarchar(MAX),
    [Audio] nvarchar(MAX),
    [Image] nvarchar(MAX),
    [Price] decimal(18,2),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[ContactUs] (
    [Id] int IDENTITY,
    [Name] nvarchar(MAX),
    [Address] nvarchar(MAX),
    [PhoneNumber] nvarchar(MAX),
    [Email] nvarchar(MAX),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[CustomerCareNumbers] (
    [Id] int IDENTITY,
    [PhoneNumber] nvarchar(MAX),
    [Description] nvarchar(MAX),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[DNDCategories] (
    [Id] int IDENTITY,
    [Name] nvarchar(MAX),
    [Type] nvarchar(MAX),
    [Status] nvarchar(MAX) DEFAULT (N'Active'),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[DNDModes] (
    [Id] int IDENTITY,
    [Name] nvarchar(MAX),
    [Type] nvarchar(MAX),
    [Status] nvarchar(MAX) DEFAULT (N'Active'),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[DNDTransactions] (
    [Id] int IDENTITY,
    [UserId] int,
    [DNDCategoryId] int,
    [DNDModeId] int,
    [StartDate] datetime2(7),
    [EndDate] datetime2(7),
    [CreatedDate] datetime2(7),
    [Status] nvarchar(MAX),
    [Description] nvarchar(MAX),
    CONSTRAINT [FK_DNDTransactions_DNDModes_DNDModeId] FOREIGN KEY ([DNDModeId]) REFERENCES [dbo].[DNDModes]([Id]) ON DELETE 1,
    CONSTRAINT [FK_DNDTransactions_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AppUsers]([Id]) ON DELETE 1,
    CONSTRAINT [FK_DNDTransactions_DNDCategories_DNDCategoryId] FOREIGN KEY ([DNDCategoryId]) REFERENCES [dbo].[DNDCategories]([Id]) ON DELETE 1,
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[FeedBacks] (
    [Id] int IDENTITY,
    [FullName] nvarchar(MAX),
    [Content] nvarchar(MAX),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[GuestTransactions] (
    [Id] int IDENTITY,
    [PlanId] int,
    [FirstName] nvarchar(MAX),
    [LastName] nvarchar(MAX),
    [PhoneNumber] nvarchar(MAX),
    [PaymentCard] nvarchar(MAX),
    [CreatedDate] datetime2(7),
    [Simtype] nvarchar(MAX),
    CONSTRAINT [FK_GuestTransactions_Plans_PlanId] FOREIGN KEY ([PlanId]) REFERENCES [dbo].[Plans]([Id]) ON DELETE 1,
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[ModeInCategories] (
    [CategoryId] int,
    [ModeId] int,
    CONSTRAINT [FK_ModeInCategories_DNDCategories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[DNDCategories]([Id]) ON DELETE 1,
    CONSTRAINT [FK_ModeInCategories_DNDModes_ModeId] FOREIGN KEY ([ModeId]) REFERENCES [dbo].[DNDModes]([Id]) ON DELETE 1,
    PRIMARY KEY ([CategoryId],[ModeId])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Offers] (
    [Id] int IDENTITY,
    [Name] nvarchar(MAX),
    [ProviderId] int,
    [Image] nvarchar(MAX),
    [CreatedDate] datetime2(7),
    [Description] nvarchar(MAX),
    CONSTRAINT [FK_Offers_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[Providers]([Id]) ON DELETE 1,
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[PBPTransactions] (
    [Id] int IDENTITY,
    [PhoneNumber] int,
    [Price] decimal(18,2),
    [CreatedDate] datetime2(7),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Plans] (
    [Id] int IDENTITY,
    [Name] nvarchar(MAX),
    [ProviderId] int,
    [VASId] int,
    [Amount] int DEFAULT ((0)),
    [Price] decimal(18,2),
    [Validate] nvarchar(MAX),
    [Description] nvarchar(MAX),
    CONSTRAINT [FK_Plans_VAS_VASId] FOREIGN KEY ([VASId]) REFERENCES [dbo].[VAS]([Id]) ON DELETE 1,
    CONSTRAINT [FK_Plans_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[Providers]([Id]) ON DELETE 1,
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Providers] (
    [Id] int IDENTITY,
    [Name] nvarchar(MAX),
    [Logo] nvarchar(MAX),
    [Description] nvarchar(MAX),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Transactions] (
    [Id] int IDENTITY,
    [ProviderId] int,
    [UserId] int,
    [VASId] int,
    [Price] decimal(18,2) DEFAULT ((0.0)),
    [PaymentCard] nvarchar(MAX),
    [CreatedDate] datetime2(7),
    [Simtype] nvarchar(MAX),
    CONSTRAINT [FK_Transactions_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[Providers]([Id]) ON DELETE 1,
    CONSTRAINT [FK_Transactions_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AppUsers]([Id]) ON DELETE 1,
    CONSTRAINT [FK_Transactions_VAS_VASId] FOREIGN KEY ([VASId]) REFERENCES [dbo].[VAS]([Id]) ON DELETE 1,
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[UserInPlans] (
    [UserId] int,
    [PlanId] int,
    CONSTRAINT [FK_UserInPlans_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AppUsers]([Id]) ON DELETE 1,
    CONSTRAINT [FK_UserInPlans_Plans_PlanId] FOREIGN KEY ([PlanId]) REFERENCES [dbo].[Plans]([Id]) ON DELETE 1,
    PRIMARY KEY ([UserId],[PlanId])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[VAS] (
    [Id] int IDENTITY,
    [Name] nvarchar(MAX),
    PRIMARY KEY ([Id])
);

-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[VASInProviders] (
    [ProviderId] int,
    [VASId] int,
    CONSTRAINT [FK_VASInProviders_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[Providers]([Id]) ON DELETE 1,
    CONSTRAINT [FK_VASInProviders_VAS_VASId] FOREIGN KEY ([VASId]) REFERENCES [dbo].[VAS]([Id]) ON DELETE 1,
    PRIMARY KEY ([VASId],[ProviderId])
);

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES
(N'20201209121847_InitialCreate', N'5.0.0'),
(N'20201210043457_UpdateMigration', N'5.0.0'),
(N'20201210160826_Table-GuestTransactions', N'5.0.0'),
(N'20201211023845_edit_entities', N'5.0.0');

INSERT INTO [dbo].[AppUsers] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Address], [VerifyCode], [Role], [Token]) VALUES
('4', N'Lam', N'Phan', N'lampn', N'101193D7181CC88340AE5B2B17BBA8A1', N'lampn@gmail.com', N'Da Nang, Viet Nam', NULL, N'User', NULL),
('5', N'Lam', N'Phan', N'lampn9397', N'4297F44B13955235245B2497399D7A93', N'davidbull931997@gmail.com', N'Da Nang, Viet Nam', NULL, N'User', NULL),
('6', N'user', N'user', N'user', N'EE11CBB19052E40B07AAC0CA060C23EE', N'user', N'user', NULL, N'User', NULL),
('7', N'123123', N'123123', N'0776266985', N'4297F44B13955235245B2497399D7A93', N'lampn@gmail.com', N'123123', NULL, N'User', NULL),
('8', N'Lam', N'Phan', N'0776266986', N'4297F44B13955235245B2497399D7A93', N'davidbull931997@gmail.com', N'Da Nang, Viet Nam', NULL, N'User', NULL),
('9', N'Lam', N'Phan', N'0776266987', N'4297F44B13955235245B2497399D7A93', N'davidbull931997@gmail.com', N'Da Nang, Viet Nam', NULL, N'User', NULL);

INSERT INTO [dbo].[FeedBacks] ([Id], [FullName], [Content]) VALUES
('1', N'Lam Phan', N'My Feedback'),
('2', N'123123', N'123123'),
('3', N'123123123', N'123123123132'),
('4', N'123123', N'123123'),
('5', N'123123123', N'123123123');

INSERT INTO [dbo].[GuestTransactions] ([Id], [PlanId], [FirstName], [LastName], [PhoneNumber], [PaymentCard], [CreatedDate], [Simtype]) VALUES
('1', '2', N'Lam', N'Phan', N'0776266985', N'201769663', '2020-12-11 15:55:58.1403110', N'Prepay'),
('2', '2', N'Lam', N'Phan', N'0776266985', N'123123123123', '2020-12-11 16:02:11.2257160', N'Prepay'),
('3', '2', N'123123', N'123123', N'123123', N'123123', '2020-12-11 16:04:37.4317980', N'Prepay'),
('4', '2', N'123123', N'123123', N'123123', N'123123', '2020-12-11 16:11:21.7488010', N'Prepay'),
('5', '2', N'addsasad', N'dsaads', N'adsadssadasd', N'asddsasad', '2020-12-11 16:16:39.9594750', N'Prepay'),
('6', '2', N'Lam', N'Phan', N'0776266985', N'123123', '2020-12-11 16:28:18.8523890', N'Prepay'),
('7', '2', N'123123', N'123123', N'123123', N'123123123', '2020-12-11 16:29:52.2823510', N'Prepay');

INSERT INTO [dbo].[Plans] ([Id], [Name], [ProviderId], [VASId], [Amount], [Price], [Validate], [Description]) VALUES
('2', N'3G 5GB', '7', '5', '5', '120000.00', N'30 days', N'Lướt web thả ga với gói 3G 5GB của nhà mạng Mobifone');

INSERT INTO [dbo].[Providers] ([Id], [Name], [Logo], [Description]) VALUES
('7', N'Mobifone', N'/mobifone_vietnam.jpg', N'Mobifone description');

INSERT INTO [dbo].[Transactions] ([Id], [ProviderId], [UserId], [VASId], [Price], [PaymentCard], [CreatedDate], [Simtype]) VALUES
('11', '7', '4', '6', '50000.00', N'201769663', '2020-12-09 13:38:15.6866667', NULL),
('12', '7', '5', '5', '120000.00', N'201769663', '2020-12-11 11:55:31.1516680', N'Postpaid'),
('13', '7', '5', '5', '120000.00', N'12312312312312', '2020-12-11 16:42:25.1911060', N'Postpaid'),
('14', '7', '5', '5', '120000.00', N'123123', '2020-12-11 17:10:54.5616600', N'Postpaid'),
('15', '7', '5', '5', '120000.00', N'qweqweqwe', '2020-12-11 17:11:17.3891800', N'Postpaid'),
('16', '7', '5', '5', '120000.00', N'asdasdasd', '2020-12-11 17:12:01.4998930', N'Postpaid'),
('17', '7', '5', '5', '120000.00', N'123123123', '2020-12-11 17:12:48.2915120', N'Prepay'),
('18', '7', '5', '5', '120000.00', N'123123123123', '2020-12-11 17:18:04.8246150', N'Prepaid'),
('19', '7', '5', '5', '120000.00', N'asdasdasd', '2020-12-11 17:20:17.4848240', N'Prepaid'),
('20', '7', '5', '5', '120000.00', N'asdasdasd', '2020-12-11 17:21:35.3385070', N'Prepaid');

INSERT INTO [dbo].[VAS] ([Id], [Name]) VALUES
('5', N'3G'),
('6', N'4G');

