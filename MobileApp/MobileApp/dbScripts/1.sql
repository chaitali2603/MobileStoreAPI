USE [master]
GO
/****** Object:  Database [MobileStore]    Script Date: 31-05-2022 12.37.56 PM ******/
CREATE DATABASE [MobileStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MobileStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MobileStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MobileStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MobileStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MobileStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MobileStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MobileStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MobileStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MobileStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MobileStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MobileStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [MobileStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MobileStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MobileStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MobileStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MobileStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MobileStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MobileStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MobileStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MobileStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MobileStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MobileStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MobileStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MobileStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MobileStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MobileStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MobileStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MobileStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MobileStore] SET RECOVERY FULL 
GO
ALTER DATABASE [MobileStore] SET  MULTI_USER 
GO
ALTER DATABASE [MobileStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MobileStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MobileStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MobileStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MobileStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MobileStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MobileStore', N'ON'
GO
ALTER DATABASE [MobileStore] SET QUERY_STORE = OFF
GO
USE [MobileStore]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 31-05-2022 12.37.56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Pincode] [decimal](18, 0) NULL,
	[State] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[IsDated] [bit] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 31-05-2022 12.37.56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LasttName] [nvarchar](max) NULL,
	[DOB] [date] NULL,
	[Password] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 31-05-2022 12.37.56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [uniqueidentifier] NOT NULL,
	[userId] [uniqueidentifier] NULL,
	[Address] [nvarchar](max) NULL,
	[OrderDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 31-05-2022 12.37.56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[Price] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[IsDated] [bit] NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 31-05-2022 12.37.56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[Disscount] [decimal](18, 2) NULL,
	[Brand] [nvarchar](max) NULL,
	[Storage] [nvarchar](max) NULL,
	[OS] [nvarchar](max) NULL,
	[Battery] [nvarchar](max) NULL,
	[RAM] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [MobileStore] SET  READ_WRITE 
GO
