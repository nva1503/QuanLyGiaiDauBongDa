USE [master]
GO
/****** Object:  Database [QuanLyGiaiDauBongDa]    Script Date: 24-Feb-22 9:04:27 PM ******/
CREATE DATABASE [QuanLyGiaiDauBongDa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyGiaiDauBongDa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyGiaiDauBongDa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyGiaiDauBongDa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyGiaiDauBongDa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyGiaiDauBongDa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET QUERY_STORE = OFF
GO
USE [QuanLyGiaiDauBongDa]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account_id] [int] NOT NULL,
	[full_name] [nvarchar](100) NULL,
	[username] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[email] [nvarchar](50) NULL,
	[dob] [date] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[player_id] [int] NOT NULL,
	[match_id] [int] NOT NULL,
	[card_time] [int] NOT NULL,
	[card_type] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Club]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Club](
	[club_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[year_created] [date] NOT NULL,
	[country_id] [int] NOT NULL,
	[city] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[stadium_id] [int] NOT NULL,
 CONSTRAINT [PK_Club] PRIMARY KEY CLUSTERED 
(
	[club_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[country_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[short_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[country_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goal]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goal](
	[goal_id] [int] NOT NULL,
	[match_id] [int] NOT NULL,
	[player_id] [int] NOT NULL,
	[goal_time] [int] NOT NULL,
 CONSTRAINT [PK_Goal] PRIMARY KEY CLUSTERED 
(
	[goal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[match_id] [int] NOT NULL,
	[play_date] [date] NOT NULL,
	[host_id] [int] NOT NULL,
	[guest_id] [int] NOT NULL,
	[referee_id] [int] NOT NULL,
	[tourseason_id] [int] NOT NULL,
	[play_stage] [nvarchar](50) NOT NULL,
	[venue_id] [int] NOT NULL,
 CONSTRAINT [PK_Match_1] PRIMARY KEY CLUSTERED 
(
	[match_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match_Result]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match_Result](
	[match_id] [int] NOT NULL,
	[play_stage] [nvarchar](50) NULL,
	[club_id] [int] NULL,
	[win_lose] [nvarchar](50) NULL,
	[goal_score] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[player_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[dob] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
	[position_id] [int] NOT NULL,
	[height] [nvarchar](50) NOT NULL,
	[weight] [nvarchar](50) NOT NULL,
	[image] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[player_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playing_Position]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playing_Position](
	[position_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Playing_Position] PRIMARY KEY CLUSTERED 
(
	[position_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Referee]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Referee](
	[referee_id] [int] NOT NULL,
	[referee_name] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Referee] PRIMARY KEY CLUSTERED 
(
	[referee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] NOT NULL,
	[role_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role_Account]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_Account](
	[role_id] [int] NULL,
	[account_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stadiun]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stadiun](
	[stadium_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Stadiun] PRIMARY KEY CLUSTERED 
(
	[stadium_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[club_id] [int] NULL,
	[player_id] [int] NULL,
	[match_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venue]    Script Date: 24-Feb-22 9:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venue](
	[venue_id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[audience_capacity] [int] NULL,
 CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED 
(
	[venue_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_Match] FOREIGN KEY([match_id])
REFERENCES [dbo].[Match] ([match_id])
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_Match]
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_Player] FOREIGN KEY([player_id])
REFERENCES [dbo].[Player] ([player_id])
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_Player]
GO
ALTER TABLE [dbo].[Club]  WITH CHECK ADD  CONSTRAINT [FK_Club_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([country_id])
GO
ALTER TABLE [dbo].[Club] CHECK CONSTRAINT [FK_Club_Country]
GO
ALTER TABLE [dbo].[Club]  WITH CHECK ADD  CONSTRAINT [FK_Club_Stadiun] FOREIGN KEY([stadium_id])
REFERENCES [dbo].[Stadiun] ([stadium_id])
GO
ALTER TABLE [dbo].[Club] CHECK CONSTRAINT [FK_Club_Stadiun]
GO
ALTER TABLE [dbo].[Goal]  WITH CHECK ADD  CONSTRAINT [FK_Goal_Match] FOREIGN KEY([match_id])
REFERENCES [dbo].[Match] ([match_id])
GO
ALTER TABLE [dbo].[Goal] CHECK CONSTRAINT [FK_Goal_Match]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Club] FOREIGN KEY([host_id])
REFERENCES [dbo].[Club] ([club_id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Club]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Club1] FOREIGN KEY([guest_id])
REFERENCES [dbo].[Club] ([club_id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Club1]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Referee] FOREIGN KEY([referee_id])
REFERENCES [dbo].[Referee] ([referee_id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Referee]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Venue] FOREIGN KEY([venue_id])
REFERENCES [dbo].[Venue] ([venue_id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Venue]
GO
ALTER TABLE [dbo].[Match_Result]  WITH CHECK ADD  CONSTRAINT [FK_Match_Result_Club] FOREIGN KEY([club_id])
REFERENCES [dbo].[Club] ([club_id])
GO
ALTER TABLE [dbo].[Match_Result] CHECK CONSTRAINT [FK_Match_Result_Club]
GO
ALTER TABLE [dbo].[Match_Result]  WITH CHECK ADD  CONSTRAINT [FK_Match_Result_Match] FOREIGN KEY([match_id])
REFERENCES [dbo].[Match] ([match_id])
GO
ALTER TABLE [dbo].[Match_Result] CHECK CONSTRAINT [FK_Match_Result_Match]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([country_id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Country]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Playing_Position] FOREIGN KEY([position_id])
REFERENCES [dbo].[Playing_Position] ([position_id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Playing_Position]
GO
ALTER TABLE [dbo].[Referee]  WITH CHECK ADD  CONSTRAINT [FK_Referee_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([country_id])
GO
ALTER TABLE [dbo].[Referee] CHECK CONSTRAINT [FK_Referee_Country]
GO
ALTER TABLE [dbo].[Role_Account]  WITH CHECK ADD  CONSTRAINT [FK_Role_Account_Account] FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([account_id])
GO
ALTER TABLE [dbo].[Role_Account] CHECK CONSTRAINT [FK_Role_Account_Account]
GO
ALTER TABLE [dbo].[Role_Account]  WITH CHECK ADD  CONSTRAINT [FK_Role_Account_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Role_Account] CHECK CONSTRAINT [FK_Role_Account_Role]
GO
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Club] FOREIGN KEY([club_id])
REFERENCES [dbo].[Club] ([club_id])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Club]
GO
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Match] FOREIGN KEY([match_id])
REFERENCES [dbo].[Match] ([match_id])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Match]
GO
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Player] FOREIGN KEY([player_id])
REFERENCES [dbo].[Player] ([player_id])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Player]
GO
USE [master]
GO
ALTER DATABASE [QuanLyGiaiDauBongDa] SET  READ_WRITE 
GO
