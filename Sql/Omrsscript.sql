USE [master]
GO
/****** Object:  Database [OMRSDb]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE DATABASE [OMRSDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OMRSDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\OMRSDb.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OMRSDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\OMRSDb_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OMRSDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OMRSDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OMRSDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OMRSDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OMRSDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OMRSDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OMRSDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [OMRSDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OMRSDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [OMRSDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OMRSDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OMRSDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OMRSDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OMRSDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OMRSDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OMRSDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OMRSDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OMRSDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OMRSDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OMRSDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OMRSDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OMRSDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OMRSDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OMRSDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [OMRSDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OMRSDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OMRSDb] SET  MULTI_USER 
GO
ALTER DATABASE [OMRSDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OMRSDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OMRSDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OMRSDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [OMRSDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppConfigs]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppConfigs](
	[Key] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AppConfigs] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CallerTunes]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallerTunes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Singer] [nvarchar](max) NOT NULL,
	[Audio] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CallerTunes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerCareNumbers]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerCareNumbers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_CustomerCareNumbers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DNDCategories]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DNDCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DNDCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DNDModes]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DNDModes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DNDModes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DNDTransactions]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DNDTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DNDCategoryId] [int] NOT NULL,
	[DNDModeId] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DNDTransactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeedBacks]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBacks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FeedBacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModeInCategories]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModeInCategories](
	[CategoryId] [int] NOT NULL,
	[ModeId] [int] NOT NULL,
 CONSTRAINT [PK_ModeInCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[ModeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Offers]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[OperatorId] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Operators]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operators](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Logo] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Operators] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PBPTransactions]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PBPTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[CreatedDate] [int] NOT NULL,
 CONSTRAINT [PK_PBPTransactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Plans]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [int] NOT NULL,
	[OperatorId] [int] NOT NULL,
	[VASId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Validate] [nvarchar](max) NOT NULL,
	[Description] [int] NOT NULL,
 CONSTRAINT [PK_Plans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SimTypes]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SimTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SimTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OperatorId] [int] NOT NULL,
	[SimtypeId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[VASId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[PaymentCard] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInPlans]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInPlans](
	[UserId] [int] NOT NULL,
	[PlanId] [int] NOT NULL,
 CONSTRAINT [PK_UserInPlans] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[PlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VAS]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[OperatorId] [int] NOT NULL,
 CONSTRAINT [PK_VAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VASInOperators]    Script Date: 23/11/2020 6:39:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VASInOperators](
	[OperatorId] [int] NOT NULL,
	[VASId] [int] NOT NULL,
 CONSTRAINT [PK_VASInOperators] PRIMARY KEY CLUSTERED 
(
	[VASId] ASC,
	[OperatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201118180156_Init', N'5.0.0')
SET IDENTITY_INSERT [dbo].[AppUsers] ON 

INSERT [dbo].[AppUsers] ([Id], [FirstName], [LastName], [Username], [Password], [Role], [Token]) VALUES (1, N'tran', N'thuan', N'admin', N'admin', N'Admin', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2MDU4OTExNzYsImV4cCI6MTYwNjQ5NTk3NiwiaWF0IjoxNjA1ODkxMTc2fQ.AHsl-ry9ezwd62A_uBmF2Tv449SZlN0r9XobkS6diZg')
INSERT [dbo].[AppUsers] ([Id], [FirstName], [LastName], [Username], [Password], [Role], [Token]) VALUES (2, N'thuan', N'tran', N'user', N'user', N'User', NULL)
SET IDENTITY_INSERT [dbo].[AppUsers] OFF
/****** Object:  Index [IX_DNDTransactions_DNDCategoryId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_DNDTransactions_DNDCategoryId] ON [dbo].[DNDTransactions]
(
	[DNDCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DNDTransactions_DNDModeId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_DNDTransactions_DNDModeId] ON [dbo].[DNDTransactions]
(
	[DNDModeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DNDTransactions_UserId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_DNDTransactions_UserId] ON [dbo].[DNDTransactions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ModeInCategories_ModeId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_ModeInCategories_ModeId] ON [dbo].[ModeInCategories]
(
	[ModeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Offers_OperatorId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Offers_OperatorId] ON [dbo].[Offers]
(
	[OperatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Plans_OperatorId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Plans_OperatorId] ON [dbo].[Plans]
(
	[OperatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Plans_VASId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Plans_VASId] ON [dbo].[Plans]
(
	[VASId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_OperatorId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_OperatorId] ON [dbo].[Transactions]
(
	[OperatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_UserId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_UserId] ON [dbo].[Transactions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_VASId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_VASId] ON [dbo].[Transactions]
(
	[VASId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserInPlans_PlanId]    Script Date: 23/11/2020 6:39:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserInPlans_PlanId] ON [dbo].[UserInPlans]
(
	[PlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DNDCategories] ADD  DEFAULT (N'Active') FOR [Status]
GO
ALTER TABLE [dbo].[DNDModes] ADD  DEFAULT (N'Active') FOR [Status]
GO
ALTER TABLE [dbo].[Plans] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT ((0.0)) FOR [Price]
GO
ALTER TABLE [dbo].[DNDTransactions]  WITH CHECK ADD  CONSTRAINT [FK_DNDTransactions_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DNDTransactions] CHECK CONSTRAINT [FK_DNDTransactions_AppUsers_UserId]
GO
ALTER TABLE [dbo].[DNDTransactions]  WITH CHECK ADD  CONSTRAINT [FK_DNDTransactions_DNDCategories_DNDCategoryId] FOREIGN KEY([DNDCategoryId])
REFERENCES [dbo].[DNDCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DNDTransactions] CHECK CONSTRAINT [FK_DNDTransactions_DNDCategories_DNDCategoryId]
GO
ALTER TABLE [dbo].[DNDTransactions]  WITH CHECK ADD  CONSTRAINT [FK_DNDTransactions_DNDModes_DNDModeId] FOREIGN KEY([DNDModeId])
REFERENCES [dbo].[DNDModes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DNDTransactions] CHECK CONSTRAINT [FK_DNDTransactions_DNDModes_DNDModeId]
GO
ALTER TABLE [dbo].[ModeInCategories]  WITH CHECK ADD  CONSTRAINT [FK_ModeInCategories_DNDCategories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[DNDCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModeInCategories] CHECK CONSTRAINT [FK_ModeInCategories_DNDCategories_CategoryId]
GO
ALTER TABLE [dbo].[ModeInCategories]  WITH CHECK ADD  CONSTRAINT [FK_ModeInCategories_DNDModes_ModeId] FOREIGN KEY([ModeId])
REFERENCES [dbo].[DNDModes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModeInCategories] CHECK CONSTRAINT [FK_ModeInCategories_DNDModes_ModeId]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offers_Operators_OperatorId] FOREIGN KEY([OperatorId])
REFERENCES [dbo].[Operators] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offers_Operators_OperatorId]
GO
ALTER TABLE [dbo].[Plans]  WITH CHECK ADD  CONSTRAINT [FK_Plans_Operators_OperatorId] FOREIGN KEY([OperatorId])
REFERENCES [dbo].[Operators] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Plans] CHECK CONSTRAINT [FK_Plans_Operators_OperatorId]
GO
ALTER TABLE [dbo].[Plans]  WITH CHECK ADD  CONSTRAINT [FK_Plans_VAS_VASId] FOREIGN KEY([VASId])
REFERENCES [dbo].[VAS] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Plans] CHECK CONSTRAINT [FK_Plans_VAS_VASId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_AppUsers_UserId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Operators_OperatorId] FOREIGN KEY([OperatorId])
REFERENCES [dbo].[Operators] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Operators_OperatorId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_VAS_VASId] FOREIGN KEY([VASId])
REFERENCES [dbo].[VAS] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_VAS_VASId]
GO
ALTER TABLE [dbo].[UserInPlans]  WITH CHECK ADD  CONSTRAINT [FK_UserInPlans_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInPlans] CHECK CONSTRAINT [FK_UserInPlans_AppUsers_UserId]
GO
ALTER TABLE [dbo].[UserInPlans]  WITH CHECK ADD  CONSTRAINT [FK_UserInPlans_Plans_PlanId] FOREIGN KEY([PlanId])
REFERENCES [dbo].[Plans] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInPlans] CHECK CONSTRAINT [FK_UserInPlans_Plans_PlanId]
GO
ALTER TABLE [dbo].[VASInOperators]  WITH CHECK ADD  CONSTRAINT [FK_VASInOperators_Operators_VASId] FOREIGN KEY([VASId])
REFERENCES [dbo].[Operators] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VASInOperators] CHECK CONSTRAINT [FK_VASInOperators_Operators_VASId]
GO
ALTER TABLE [dbo].[VASInOperators]  WITH CHECK ADD  CONSTRAINT [FK_VASInOperators_VAS_VASId] FOREIGN KEY([VASId])
REFERENCES [dbo].[VAS] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VASInOperators] CHECK CONSTRAINT [FK_VASInOperators_VAS_VASId]
GO
USE [master]
GO
ALTER DATABASE [OMRSDb] SET  READ_WRITE 
GO
