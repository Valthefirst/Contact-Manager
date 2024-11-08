USE [master]
GO
/****** Object:  Database [ContactManager]    Script Date: 2024-11-04 10:19:10 PM ******/
CREATE DATABASE [ContactManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContactManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContactManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContactManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ContactManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContactManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContactManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContactManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContactManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContactManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContactManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContactManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContactManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContactManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContactManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContactManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContactManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContactManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContactManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContactManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ContactManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContactManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContactManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContactManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContactManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContactManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContactManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContactManager] SET RECOVERY FULL 
GO
ALTER DATABASE [ContactManager] SET  MULTI_USER 
GO
ALTER DATABASE [ContactManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContactManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContactManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContactManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContactManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ContactManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContactManager', N'ON'
GO
ALTER DATABASE [ContactManager] SET QUERY_STORE = OFF
GO
USE [ContactManager]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2024-11-04 10:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[Type_Code] [char](1) NOT NULL,
	[CreationDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
	[Number] [int] NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[PostalCode] [char](6) NOT NULL,
	[Country] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2024-11-04 10:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](20) NULL,
	[CreationDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 2024-11-04 10:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[Type_Code] [char](1) NOT NULL,
	[CreationDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 2024-11-04 10:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[Type_Code] [char](1) NOT NULL,
	[PhoneNumber] [nvarchar](10) NOT NULL,
	[CreationDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 2024-11-04 10:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[Code] [char](1) NOT NULL,
	[Description] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Contact] FOREIGN KEY([Contact_Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Contact]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Type]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Contact] FOREIGN KEY([Contact_Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Contact]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Type]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Contact] FOREIGN KEY([Contact_Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Contact]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Type]
GO
USE [master]
GO
ALTER DATABASE [ContactManager] SET  READ_WRITE 
GO
