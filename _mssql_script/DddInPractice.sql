USE [master]
GO
/****** Object:  Database [DddInPractice]    Script Date: 1.05.2022 18:57:56 ******/
CREATE DATABASE [DddInPractice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DddInPractice', FILENAME = N'F:\xxx\DddInPractice.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DddInPractice_log', FILENAME = N'F:\xxx\DddInPractice_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DddInPractice] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DddInPractice].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DddInPractice] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DddInPractice] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DddInPractice] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DddInPractice] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DddInPractice] SET ARITHABORT OFF 
GO
ALTER DATABASE [DddInPractice] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DddInPractice] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DddInPractice] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DddInPractice] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DddInPractice] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DddInPractice] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DddInPractice] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DddInPractice] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DddInPractice] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DddInPractice] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DddInPractice] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DddInPractice] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DddInPractice] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DddInPractice] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DddInPractice] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DddInPractice] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DddInPractice] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DddInPractice] SET RECOVERY FULL 
GO
ALTER DATABASE [DddInPractice] SET  MULTI_USER 
GO
ALTER DATABASE [DddInPractice] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DddInPractice] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DddInPractice] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DddInPractice] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DddInPractice] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DddInPractice] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DddInPractice', N'ON'
GO
ALTER DATABASE [DddInPractice] SET QUERY_STORE = OFF
GO
USE [DddInPractice]
GO
/****** Object:  Table [dbo].[Atm]    Script Date: 1.05.2022 18:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atm](
	[AtmID] [bigint] NOT NULL,
	[MoneyCharged] [decimal](18, 2) NOT NULL,
	[OneCentCount] [int] NOT NULL,
	[TenCentCount] [int] NOT NULL,
	[QuarterCount] [int] NOT NULL,
	[OneDollarCount] [int] NOT NULL,
	[FiveDollarCount] [int] NOT NULL,
	[TwentyDollarCount] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeadOffice]    Script Date: 1.05.2022 18:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeadOffice](
	[HeadOfficeID] [bigint] NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[OneCentCount] [int] NOT NULL,
	[TenCentCount] [int] NOT NULL,
	[QuarterCount] [int] NOT NULL,
	[OneDollarCount] [int] NOT NULL,
	[FiveDollarCount] [int] NOT NULL,
	[TwentyDollarCount] [int] NOT NULL,
 CONSTRAINT [PK_HeadOffice] PRIMARY KEY CLUSTERED 
(
	[HeadOfficeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ids]    Script Date: 1.05.2022 18:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ids](
	[EntityName] [varchar](50) NOT NULL,
	[NextHigh] [int] NULL,
 CONSTRAINT [PK_Ids] PRIMARY KEY CLUSTERED 
(
	[EntityName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slot]    Script Date: 1.05.2022 18:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slot](
	[SlotID] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[SnackMachineID] [int] NOT NULL,
	[SnackID] [int] NOT NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_Slot] PRIMARY KEY CLUSTERED 
(
	[SlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Snack]    Script Date: 1.05.2022 18:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Snack](
	[SnackID] [bigint] NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Snack] PRIMARY KEY CLUSTERED 
(
	[SnackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SnackMachine]    Script Date: 1.05.2022 18:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnackMachine](
	[SnackMachineID] [bigint] NOT NULL,
	[OneCentCount] [int] NOT NULL,
	[TenCentCount] [int] NOT NULL,
	[QuarterCount] [int] NOT NULL,
	[OneDollarCount] [int] NOT NULL,
	[FiveDollarCount] [int] NOT NULL,
	[TwentyDollarCount] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Atm] ADD  CONSTRAINT [DF_Atm_OneCentCount]  DEFAULT ((0)) FOR [OneCentCount]
GO
ALTER TABLE [dbo].[Atm] ADD  CONSTRAINT [DF_Atm_1_OneCentCount1]  DEFAULT ((0)) FOR [TenCentCount]
GO
ALTER TABLE [dbo].[Atm] ADD  CONSTRAINT [DF_Atm_1_OneCentCount2]  DEFAULT ((0)) FOR [QuarterCount]
GO
ALTER TABLE [dbo].[Atm] ADD  CONSTRAINT [DF_Atm_1_OneCentCount3]  DEFAULT ((0)) FOR [OneDollarCount]
GO
ALTER TABLE [dbo].[Atm] ADD  CONSTRAINT [DF_Atm_1_OneCentCount4]  DEFAULT ((0)) FOR [FiveDollarCount]
GO
ALTER TABLE [dbo].[Atm] ADD  CONSTRAINT [DF_Atm_1_OneCentCount5]  DEFAULT ((0)) FOR [TwentyDollarCount]
GO
ALTER TABLE [dbo].[HeadOffice] ADD  CONSTRAINT [DF_HeadOffice_OneCentCount]  DEFAULT ((0)) FOR [OneCentCount]
GO
ALTER TABLE [dbo].[HeadOffice] ADD  CONSTRAINT [DF_HeadOffice_TenCentCount]  DEFAULT ((0)) FOR [TenCentCount]
GO
ALTER TABLE [dbo].[HeadOffice] ADD  CONSTRAINT [DF_HeadOffice_QuarterCount]  DEFAULT ((0)) FOR [QuarterCount]
GO
ALTER TABLE [dbo].[HeadOffice] ADD  CONSTRAINT [DF_HeadOffice_OneDollarCount]  DEFAULT ((0)) FOR [OneDollarCount]
GO
ALTER TABLE [dbo].[HeadOffice] ADD  CONSTRAINT [DF_HeadOffice_FiveDollarCount]  DEFAULT ((0)) FOR [FiveDollarCount]
GO
ALTER TABLE [dbo].[HeadOffice] ADD  CONSTRAINT [DF_HeadOffice_TwentyDollarCount]  DEFAULT ((0)) FOR [TwentyDollarCount]
GO
ALTER TABLE [dbo].[SnackMachine] ADD  CONSTRAINT [DF_SnackMachine_OneCentCount]  DEFAULT ((0)) FOR [OneCentCount]
GO
ALTER TABLE [dbo].[SnackMachine] ADD  CONSTRAINT [DF_Table_1_OneCentCount1]  DEFAULT ((0)) FOR [TenCentCount]
GO
ALTER TABLE [dbo].[SnackMachine] ADD  CONSTRAINT [DF_Table_1_OneCentCount2]  DEFAULT ((0)) FOR [QuarterCount]
GO
ALTER TABLE [dbo].[SnackMachine] ADD  CONSTRAINT [DF_Table_1_OneCentCount3]  DEFAULT ((0)) FOR [OneDollarCount]
GO
ALTER TABLE [dbo].[SnackMachine] ADD  CONSTRAINT [DF_Table_1_OneCentCount4]  DEFAULT ((0)) FOR [FiveDollarCount]
GO
ALTER TABLE [dbo].[SnackMachine] ADD  CONSTRAINT [DF_Table_1_OneCentCount5]  DEFAULT ((0)) FOR [TwentyDollarCount]
GO
USE [master]
GO
ALTER DATABASE [DddInPractice] SET  READ_WRITE 
GO
