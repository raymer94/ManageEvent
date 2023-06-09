USE [master]
GO
/****** Object:  Database [EventManage]    Script Date: 4/28/2023 4:27:50 AM ******/
CREATE DATABASE [EventManage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EventManage', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EventManage.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EventManage_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EventManage_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EventManage] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EventManage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EventManage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EventManage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EventManage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EventManage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EventManage] SET ARITHABORT OFF 
GO
ALTER DATABASE [EventManage] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EventManage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EventManage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EventManage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EventManage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EventManage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EventManage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EventManage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EventManage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EventManage] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EventManage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EventManage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EventManage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EventManage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EventManage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EventManage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EventManage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EventManage] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EventManage] SET  MULTI_USER 
GO
ALTER DATABASE [EventManage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EventManage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EventManage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EventManage] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EventManage] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EventManage] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EventManage] SET QUERY_STORE = ON
GO
ALTER DATABASE [EventManage] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EventManage]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 4/28/2023 4:27:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[age] [int] NOT NULL,
	[status_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 4/28/2023 4:27:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Furnitures]    Script Date: 4/28/2023 4:27:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Furnitures](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 4/28/2023 4:27:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client_id] [int] NOT NULL,
	[event_id] [int] NOT NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NOT NULL,
	[status_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations_furnitures]    Script Date: 4/28/2023 4:27:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations_furnitures](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[reservation_id] [int] NOT NULL,
	[furniture_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 4/28/2023 4:27:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([id], [name], [age], [status_id]) VALUES (1, N'Manuel', 22, 1)
INSERT [dbo].[Clients] ([id], [name], [age], [status_id]) VALUES (2, N'Raymer', 15, 1)
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([id], [name], [description]) VALUES (1, N'Birthday', N'Celebration of a birthday')
INSERT [dbo].[Events] ([id], [name], [description]) VALUES (2, N'Wedding', N'Celebration of a wedding')
INSERT [dbo].[Events] ([id], [name], [description]) VALUES (3, N'Conference', N'Professional conference')
INSERT [dbo].[Events] ([id], [name], [description]) VALUES (4, N'Training', N'casual training')
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Furnitures] ON 

INSERT [dbo].[Furnitures] ([id], [name], [description]) VALUES (1, N'Sofa', N'A comfortable sofa')
INSERT [dbo].[Furnitures] ([id], [name], [description]) VALUES (2, N'chair', N'A comfortable chair')
SET IDENTITY_INSERT [dbo].[Furnitures] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([id], [client_id], [event_id], [start_time], [end_time], [status_id]) VALUES (1, 1, 2, CAST(N'2023-05-01T10:00:00.000' AS DateTime), CAST(N'2023-05-01T12:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservations_furnitures] ON 

INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (1, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (2, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (3, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (4, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (5, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (6, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (7, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (8, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (9, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (10, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (11, 1, 1)
INSERT [dbo].[Reservations_furnitures] ([id], [reservation_id], [furniture_id]) VALUES (12, 1, 1)
SET IDENTITY_INSERT [dbo].[Reservations_furnitures] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([id], [description]) VALUES (1, N'AVAILABLE')
INSERT [dbo].[Status] ([id], [description]) VALUES (2, N'CANCELED')
INSERT [dbo].[Status] ([id], [description]) VALUES (3, N'DUE')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[Clients] ([id])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([event_id])
REFERENCES [dbo].[Events] ([id])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[Reservations_furnitures]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_furnitures_Furnitures] FOREIGN KEY([furniture_id])
REFERENCES [dbo].[Furnitures] ([id])
GO
ALTER TABLE [dbo].[Reservations_furnitures] CHECK CONSTRAINT [FK_Reservations_furnitures_Furnitures]
GO
ALTER TABLE [dbo].[Reservations_furnitures]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_furnitures_Reservations] FOREIGN KEY([reservation_id])
REFERENCES [dbo].[Reservations] ([id])
GO
ALTER TABLE [dbo].[Reservations_furnitures] CHECK CONSTRAINT [FK_Reservations_furnitures_Reservations]
GO
USE [master]
GO
ALTER DATABASE [EventManage] SET  READ_WRITE 
GO
