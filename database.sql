USE [master]
GO
/****** Object:  Database [Kurzusok]    Script Date: 2021. 11. 28. 17:22:20 ******/
CREATE DATABASE [Kurzusok]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kurzusok', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kurzusok.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kurzusok_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kurzusok_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Kurzusok] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kurzusok].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kurzusok] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kurzusok] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kurzusok] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kurzusok] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kurzusok] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kurzusok] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Kurzusok] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kurzusok] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kurzusok] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kurzusok] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kurzusok] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kurzusok] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kurzusok] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kurzusok] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kurzusok] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Kurzusok] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kurzusok] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kurzusok] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kurzusok] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kurzusok] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kurzusok] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kurzusok] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kurzusok] SET RECOVERY FULL 
GO
ALTER DATABASE [Kurzusok] SET  MULTI_USER 
GO
ALTER DATABASE [Kurzusok] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kurzusok] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kurzusok] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kurzusok] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Kurzusok] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Kurzusok] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Kurzusok', N'ON'
GO
ALTER DATABASE [Kurzusok] SET QUERY_STORE = OFF
GO
USE [Kurzusok]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2021. 11. 28. 17:22:20 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[course_id] [int] IDENTITY(1,1) NOT NULL,
	[subject_id] [int] NOT NULL,
	[course_type] [varchar](100) NOT NULL,
	[members] [int] NOT NULL,
	[classroom] [varchar](100) NULL,
	[comment] [varchar](max) NULL,
	[neptun_ok] [bit] NOT NULL,
	[software] [varchar](100) NULL,
	[hours] [int] NULL,
	[course_code] [int] NOT NULL,
 CONSTRAINT [PK_COURSES] PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[courses_teachers]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses_teachers](
	[course_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[loads] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgrammeDetails]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgrammeDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[programme_id] [int] NOT NULL,
	[subject_code] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[e_hours] [int] NULL,
	[gy_hours] [int] NULL,
	[lab_hours] [int] NULL,
	[correspond_hours] [int] NULL,
	[credit] [int] NOT NULL,
	[recommended_semester] [int] NULL,
	[obligatory] [bit] NOT NULL,
 CONSTRAINT [PK_ProgrammeDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Programmes]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Programmes](
	[programme_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[training] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SZAKOK] PRIMARY KEY CLUSTERED 
(
	[programme_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [varchar](100) NOT NULL,
	[weeks] [int] NOT NULL,
 CONSTRAINT [PK_SEMESTER] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subject_programmes]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subject_programmes](
	[subject_id] [int] NOT NULL,
	[programme_id] [int] NOT NULL,
	[obligatory] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[subject_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[e_hours] [int] NULL,
	[gy_hours] [int] NULL,
	[subject_code] [varchar](100) NOT NULL,
	[semester_id] [int] NOT NULL,
	[education_type] [varchar](50) NOT NULL,
	[l_hours] [int] NULL,
	[correspond_hours] [int] NULL,
 CONSTRAINT [PK_SUBJECTS] PRIMARY KEY CLUSTERED 
(
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 2021. 11. 28. 17:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[teacher_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[hoursperweek] [int] NOT NULL,
	[position] [varchar](100) NOT NULL,
	[is_working] [bit] NOT NULL,
 CONSTRAINT [PK_TEACHERS] PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.18')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210927131452_initialsetup', N'3.1.18')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'27f39d9f-91dd-4d30-b278-05469b9286e9', N'Admin', N'ADMIN', N'a67cc832-e099-454a-8a4e-5392d477bed6')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'aab1615a-a81f-467d-9c7d-d37b00398195', N'Felhasználó', N'FELHASZNÁLÓ', N'39def2c3-e7e9-4660-952b-3b8508070299')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'047609da-2f26-494e-bdb8-f7a9f916a2fd', N'27f39d9f-91dd-4d30-b278-05469b9286e9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'047609da-2f26-494e-bdb8-f7a9f916a2fd', N'Szabolcsoló Varga', N'SZABOLCSOLÓ VARGA', N'varga2szabolcs2@gmail.com', N'VARGA2SZABOLCS2@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEC9noMzmV8EtMBEsdTtcyqmPgQUNUVFvKHCcqp86vQ2AnBLbXwf4WY73lFew5rm9Ww==', N'HHNWUWY4775MEMGBSYO2IYKA64OONY45', N'9af9e8e0-8a69-4ace-a043-a35c1478d9d8', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b23a79b4-d794-454b-b5c9-14610a4ee233', N'Zöllei Alex', N'ZÖLLEI ALEX', N'zolleialex@gmail.com', N'ZOLLEIALEX@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEKN4SCQteGs0//0imBdSeNUwgFB/6hjL/1xRoV7IHQRZjdeM0Si8fqXj09mG+Ia72A==', N'WSAQKVOVJMC6B76X6E5QX3PXWBGUXDGL', N'36cf5a6e-3fe9-4c74-8648-da2c2aa5f6b9', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([course_id], [subject_id], [course_type], [members], [classroom], [comment], [neptun_ok], [software], [hours], [course_code]) VALUES (2, 8, N'Csak Vizsga', 423, N'b3', NULL, 1, NULL, 2, 2)
INSERT [dbo].[Courses] ([course_id], [subject_id], [course_type], [members], [classroom], [comment], [neptun_ok], [software], [hours], [course_code]) VALUES (3, 11, N'E-learning', 312, N'b4', N'[[$Szabolcsoló Varga$]]mindenki készüljön fel jól :)', 1, N'321', NULL, 1)
INSERT [dbo].[Courses] ([course_id], [subject_id], [course_type], [members], [classroom], [comment], [neptun_ok], [software], [hours], [course_code]) VALUES (4, 13, N'Egyéni felkészülés', 4, N'd1', N'[[$Szabolcsoló Varga$]]mindenki készüljön fel jól :)', 0, N'visual studio pls', 2, 4)
INSERT [dbo].[Courses] ([course_id], [subject_id], [course_type], [members], [classroom], [comment], [neptun_ok], [software], [hours], [course_code]) VALUES (10, 13, N'Elmélet', 5, NULL, NULL, 0, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
INSERT [dbo].[courses_teachers] ([course_id], [teacher_id], [loads]) VALUES (3, 1, 100)
INSERT [dbo].[courses_teachers] ([course_id], [teacher_id], [loads]) VALUES (2, 1, 100)
INSERT [dbo].[courses_teachers] ([course_id], [teacher_id], [loads]) VALUES (4, 1, 50)
INSERT [dbo].[courses_teachers] ([course_id], [teacher_id], [loads]) VALUES (4, 2, 50)
INSERT [dbo].[courses_teachers] ([course_id], [teacher_id], [loads]) VALUES (10, 1, 100)
GO
SET IDENTITY_INSERT [dbo].[ProgrammeDetails] ON 

INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (278, 3, N'GKNB_INTM012', N'Számítógépek működése', 3, 2, 0, NULL, 8, 1, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (279, 3, N'GKNB_INTM001', N'Rendszer és irányítás', 2, 0, 0, NULL, 3, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (280, 3, N'GKNB_INTM018', N'Számítógép-hálózatok', 3, 1, 0, NULL, 6, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (281, 3, N'GKNB_INTM021', N'Programozás', 2, 2, 0, NULL, 6, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (282, 3, N'GKNB_INTM022', N'Projektmunka és szoftvertechnológia', 1, 2, 0, NULL, 6, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (283, 3, N'GKNB_INTM020', N'Mikroelektromechanikai rendszerek', 0, 2, 0, NULL, 3, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (284, 3, N'GKNB_INTM024', N'OO programozás és adatbázis-kezelés', 1, 4, 0, NULL, 7, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (285, 3, N'GKNB_INTM025', N'Rendszerüzemeltetés és biztonság', 2, 0, 0, NULL, 3, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (286, 3, N'GKNB_INTM002', N'Mesterséges intelligencia', 2, 2, 0, NULL, 6, 4, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (287, 3, N'GKNB_INTM003', N'Kiberfizikai rendszerek', 2, 2, 0, NULL, 6, 4, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (288, 3, N'GKNB_INTM004', N'Projektmunka 1.', 0, 0, 0, NULL, 6, 4, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (289, 3, N'GKNB_INTM005', N'Projektmunka 2.', 0, 0, 0, NULL, 6, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (290, 3, N'GKNB_INTM006', N'Modern szoftverfejlesztési eszközök', 0, 2, 0, NULL, 3, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (291, 3, N'GKNB_INTM007', N'Vállalati információs rendszerek', 2, 0, 0, NULL, 3, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (292, 3, N'GKNB_INTM019', N'Modellezés és optimalizálás a gyakorlatban', 2, 2, 0, NULL, 6, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (293, 3, N'GKNB_INTM009', N'Korszerű hálózati alkalmazások', 4, 0, 0, NULL, 6, 6, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (294, 3, N'GKNB_INTM096', N'Szakdolgozati konzultáció I.', 0, 0, 0, NULL, 7, 6, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (295, 3, N'GKNB_INTM008', N'IT-szolgáltatások', 2, 0, 0, NULL, 3, 7, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (296, 3, N'GKNB_INTM097', N'Szakdolgozati konzultáció II.', 0, 0, 0, NULL, 8, 7, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (297, 3, N'GKNB_INTM010', N'Adatbázisok', 2, 1, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (298, 3, N'GKNB_INTM011', N'Rendszerfejlesztés', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (299, 3, N'GKNB_INTM013', N'Üzleti célú rendszerek', 2, 1, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (300, 3, N'GKNB_INTM026', N'C++', 1, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (301, 3, N'GKNB_INTM027', N'Emberközpontú infokommunikáció', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (302, 3, N'GKNB_INTM028', N'Felhasználói interfészek tervezése (Sw ergonómia)', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (303, 3, N'GKNB_INTM029', N'Funkcionális programozás', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (304, 3, N'GKNB_INTM030', N'Gyakorlatorientált sw-technológia', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (305, 3, N'GKNB_INTM031', N'Humanoid informatika', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (306, 3, N'GKNB_INTM032', N'Humanoid robotok irányítása', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (307, 3, N'GKNB_INTM033', N'Információ modellezés', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (308, 3, N'GKNB_INTM034', N'Interaktív multimédia alkalmazások', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (309, 3, N'GKNB_INTM035', N'IT a járműgyártásban', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (310, 3, N'GKNB_INTM036', N'IT-változásmenedzsment', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (311, 3, N'GKNB_INTM037', N'Java programozás', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (312, 3, N'GKNB_INTM038', N'Gépi látás', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (313, 3, N'GKNB_INTM039', N'Kiterjesztett kollaboráció a jövő Internetén', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (314, 3, N'GKNB_INTM040', N'Mobilalkalmazás-fejlesztés', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (315, 3, N'GKNB_INTM041', N'PHP', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (316, 3, N'GKNB_INTM042', N'Portálfejlesztés .NET-ben', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (317, 3, N'GKNB_INTM043', N'Programozás.Net-ben', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (318, 3, N'GKNB_INTM044', N'Adatintenzív adatbázis-kezelő alkalmazások', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (319, 3, N'GKNB_INTM045', N'Számítógépes adatbiztonság', 2, 1, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (320, 3, N'GKNB_INTM047', N'IT-beruházások megtérülése I', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (321, 3, N'GKNB_INTM048', N'IT-beruházások megtérülése II', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (322, 3, N'GKNB_INTM049', N'WEB technológia', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (323, 3, N'GKNB_INTM050', N'Ágazati információrendszerek I.', 2, 0, 0, NULL, 3, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (324, 3, N'GKNB_INTM051', N'Ágazati információrendszerek II.', 2, 0, 0, NULL, 3, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (325, 3, N'GKNB_INTM052', N'Banki Informatika', 2, 0, 0, NULL, 3, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (326, 3, N'GKNB_INTM053', N'Beágyazott rendszerek (IoT)', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (327, 3, N'GKNB_INTM054', N'C#', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (444, 2, N'GKLB_INTM012', N'Számítógépek működése', NULL, NULL, NULL, 24, 8, 1, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (445, 2, N'GKLB_INTM001', N'Rendszer és irányítás', NULL, NULL, NULL, 9, 3, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (446, 2, N'GKLB_INTM018', N'Számítógép-hálózatok', NULL, NULL, NULL, 18, 6, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (447, 2, N'GKLB_INTM021', N'Programozás', NULL, NULL, NULL, 18, 6, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (448, 2, N'GKLB_INTM022', N'Projektmunka és szoftvertechnológia', NULL, NULL, NULL, 18, 6, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (449, 2, N'GKLB_INTM020', N'Mikroelektromechanikai rendszerek', NULL, NULL, NULL, 9, 3, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (450, 2, N'GKLB_INTM024', N'OO programozás és adatbázis-kezelés', NULL, NULL, NULL, 21, 7, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (451, 2, N'GKLB_INTM025', N'Rendszerüzemeltetés és biztonság', NULL, NULL, NULL, 9, 3, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (452, 2, N'GKLB_INTM002', N'Mesterséges intelligencia', NULL, NULL, NULL, 18, 6, 4, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (453, 2, N'GKLB_INTM003', N'Kiberfizikai rendszerek', NULL, NULL, NULL, 18, 6, 4, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (454, 2, N'GKLB_INTM004', N'Projektmunka 1.', NULL, NULL, NULL, 0, 6, 4, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (455, 2, N'GKLB_INTM005', N'Projektmunka 2.', NULL, NULL, NULL, 0, 6, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (456, 2, N'GKLB_INTM006', N'Modern szoftverfejlesztési eszközök', NULL, NULL, NULL, 9, 3, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (457, 2, N'GKLB_INTM007', N'Vállalati információs rendszerek', NULL, NULL, NULL, 9, 3, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (458, 2, N'GKLB_INTM019', N'Modellezés és optimalizálás a gyakorlatban', NULL, NULL, NULL, 18, 6, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (459, 2, N'GKLB_INTM009', N'Korszerű hálózati alkalmazások', NULL, NULL, NULL, 18, 6, 6, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (460, 2, N'GKLB_INTM096', N'Szakdolgozati konzultáció I.', NULL, NULL, NULL, 0, 7, 6, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (461, 2, N'GKLB_INTM008', N'IT-szolgáltatások', NULL, NULL, NULL, 9, 3, 7, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (462, 2, N'GKLB_INTM097', N'Szakdolgozati konzultáció II.', NULL, NULL, NULL, 0, 8, 7, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (463, 2, N'GKLB_INTM010', N'Adatbázisok', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (464, 2, N'GKLB_INTM011', N'Rendszerfejlesztés', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (465, 2, N'GKLB_INTM013', N'Üzleti célú rendszerek', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (466, 2, N'GKLB_INTM026', N'C++', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (467, 2, N'GKLB_INTM027', N'Emberközpontú infokommunikáció', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (468, 2, N'GKLB_INTM028', N'Felhasználói interfészek tervezése (Sw ergonómia)', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (469, 2, N'GKLB_INTM029', N'Funkcionális programozás', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (470, 2, N'GKLB_INTM030', N'Gyakorlatorientált sw-technológia', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (471, 2, N'GKLB_INTM031', N'Humanoid informatika', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (472, 2, N'GKLB_INTM032', N'Humanoid robotok irányítása', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (473, 2, N'GKLB_INTM033', N'Információ modellezés', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (474, 2, N'GKLB_INTM034', N'Interaktív multimédia alkalmazások', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (475, 2, N'GKLB_INTM036', N'IT-változásmenedzsment', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (476, 2, N'GKLB_INTM037', N'Java programozás', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (477, 2, N'GKLB_INTM038', N'Gépi látás', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (478, 2, N'GKLB_INTM039', N'Kiterjesztett kollaboráció a jövő Internetén', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (479, 2, N'GKLB_INTM040', N'Mobilalkalmazás-fejlesztés', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (480, 2, N'GKLB_INTM041', N'PHP', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (481, 2, N'GKLB_INTM042', N'Portálfejlesztés .NET-ben', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (482, 2, N'GKLB_INTM043', N'Programozás .Net-ben', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (483, 2, N'GKLB_INTM044', N'Adatintenzív adatbázis-kezelő alkalmazások', NULL, NULL, NULL, 3, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (484, 2, N'GKLB_INTM045', N'Számítógépes adatbiztonság', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (485, 2, N'GKLB_INTM047', N'IT-beruházások megtérülése I', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (486, 2, N'GKLB_INTM048', N'IT-beruházások megtérülése II', NULL, NULL, NULL, 15, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (487, 2, N'GKLB_INTM049', N'WEB technológia', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (488, 2, N'GKLB_INTM050', N'Ágazati információrendszerek I.', NULL, NULL, NULL, 9, 3, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (489, 2, N'GKLB_INTM051', N'Ágazati információrendszerek II.', NULL, NULL, NULL, 9, 3, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (490, 2, N'GKLB_INTM052', N'Banki Informatika', NULL, NULL, NULL, 9, 3, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (491, 2, N'GKLB_INTM053', N'Beágyazott rendszerek (IoT)', NULL, NULL, NULL, 18, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (492, 2, N'GKLB_INTM054', N'C#', NULL, NULL, NULL, 18, 6, NULL, 0)
GO
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (493, 1, N'GKNB_INTM012', N'Számítógépek működése', 3, 2, 0, NULL, 8, 1, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (494, 1, N'GKNB_INTM001', N'Rendszer és irányítás', 2, 0, 0, NULL, 3, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (495, 1, N'GKNB_INTM018', N'Számítógép-hálózatok', 3, 1, 0, NULL, 6, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (496, 1, N'GKNB_INTM021', N'Programozás', 2, 2, 0, NULL, 6, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (497, 1, N'GKNB_INTM022', N'Projektmunka és szoftvertechnológia', 1, 2, 0, NULL, 6, 2, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (498, 1, N'GKNB_INTM020', N'Mikroelektromechanikai rendszerek', 0, 2, 0, NULL, 3, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (499, 1, N'GKNB_INTM025', N'Rendszerüzemeltetés és biztonság', 2, 0, 0, NULL, 3, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (500, 1, N'GKNB_INTM085', N'OO programozás', 1, 3, 0, NULL, 6, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (501, 1, N'GKNB_INTM086', N'Adatbázis-kezelés', 1, 2, 0, NULL, 4, 3, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (502, 1, N'GKNB_INTM002', N'Mesterséges intelligencia', 2, 2, 0, NULL, 6, 4, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (503, 1, N'GKNB_INTM004', N'Projektmunka 1.', 0, 0, 0, NULL, 6, 4, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (504, 1, N'GKNB_INTM087', N'Ipar 4.0 technológiák', 2, 0, 0, NULL, 3, 4, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (505, 1, N'GKNB_INTM005', N'Projektmunka 2.', 0, 0, 0, NULL, 6, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (506, 1, N'GKNB_INTM006', N'Modern szoftverfejlesztési eszközök', 0, 2, 0, NULL, 3, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (507, 1, N'GKNB_INTM007', N'Vállalati információs rendszerek', 2, 0, 0, NULL, 3, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (508, 1, N'GKNB_INTM019', N'Modellezés és optimalizálás a gyakorlatban', 2, 2, 0, NULL, 6, 5, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (509, 1, N'GKNB_INTM009', N'Korszerű hálózati alkalmazások', 4, 0, 0, NULL, 6, 6, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (510, 1, N'GKNB_INTM096', N'Szakdolgozati konzultáció I.', 0, 0, 0, NULL, 7, 6, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (511, 1, N'GKNB_INTM008', N'IT-szolgáltatások', 2, 0, 0, NULL, 3, 7, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (512, 1, N'GKNB_INTM097', N'Szakdolgozati konzultáció II.', 0, 0, 0, NULL, 8, 7, 1)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (513, 1, N'GKNB_INTM011', N'Rendszerfejlesztés', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (514, 1, N'GKNB_INTM013', N'Üzleti célú rendszerek', 2, 1, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (515, 1, N'GKNB_INTM026', N'C++', 1, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (516, 1, N'GKNB_INTM028', N'Felhasználói interfészek tervezése (Sw ergonómia)', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (517, 1, N'GKNB_INTM029', N'Funkcionális programozás', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (518, 1, N'GKNB_INTM030', N'Gyakorlatorientált sw-technológia', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (519, 1, N'GKNB_INTM032', N'Humanoid robotok irányítása', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (520, 1, N'GKNB_INTM033', N'Információ modellezés', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (521, 1, N'GKNB_INTM034', N'Interaktív multimédia alkalmazások', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (522, 1, N'GKNB_INTM035', N'IT a járműgyártásban', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (523, 1, N'GKNB_INTM036', N'IT-változásmenedzsment', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (524, 1, N'GKNB_INTM037', N'Java programozás', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (525, 1, N'GKNB_INTM038', N'Gépi látás', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (526, 1, N'GKNB_INTM039', N'Kiterjesztett kollaboráció a jövő Internetén', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (527, 1, N'GKNB_INTM040', N'Mobilalkalmazás-fejlesztés', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (528, 1, N'GKNB_INTM041', N'PHP', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (529, 1, N'GKNB_INTM042', N'Portálfejlesztés .NET-ben', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (530, 1, N'GKNB_INTM043', N'Programozás.Net-ben', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (531, 1, N'GKNB_INTM044', N'Adatintenzív adatbázis-kezelő alkalmazások', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (532, 1, N'GKNB_INTM045', N'Számítógépes adatbiztonság', 2, 1, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (533, 1, N'GKNB_INTM047', N'IT-beruházások megtérülése I', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (534, 1, N'GKNB_INTM048', N'IT-beruházások megtérülése II', 3, 0, 0, NULL, 5, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (535, 1, N'GKNB_INTM049', N'WEB technológia', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (536, 1, N'GKNB_INTM050', N'Ágazati információrendszerek I.', 2, 0, 0, NULL, 3, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (537, 1, N'GKNB_INTM051', N'Ágazati információrendszerek II.', 2, 0, 0, NULL, 3, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (538, 1, N'GKNB_INTM052', N'Banki Informatika', 2, 0, 0, NULL, 3, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (539, 1, N'GKNB_INTM053', N'Beágyazott rendszerek (IoT)', 2, 2, 0, NULL, 6, NULL, 0)
INSERT [dbo].[ProgrammeDetails] ([id], [programme_id], [subject_code], [name], [e_hours], [gy_hours], [lab_hours], [correspond_hours], [credit], [recommended_semester], [obligatory]) VALUES (540, 1, N'GKNB_INTM054', N'C#', 2, 2, 0, NULL, 6, NULL, 0)
SET IDENTITY_INSERT [dbo].[ProgrammeDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Programmes] ON 

INSERT [dbo].[Programmes] ([programme_id], [name], [training]) VALUES (1, N'2017 MI bsc', N'nappali')
INSERT [dbo].[Programmes] ([programme_id], [name], [training]) VALUES (2, N'2020 GI bsc', N'levelezős')
INSERT [dbo].[Programmes] ([programme_id], [name], [training]) VALUES (3, N'1996 MI msc', N'nappali')
SET IDENTITY_INSERT [dbo].[Programmes] OFF
GO
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([id], [date], [weeks]) VALUES (1, N'2020/21/1', 13)
INSERT [dbo].[Semester] ([id], [date], [weeks]) VALUES (2, N'2020/21/2', 14)
INSERT [dbo].[Semester] ([id], [date], [weeks]) VALUES (3, N'2021/22/1', 14)
SET IDENTITY_INSERT [dbo].[Semester] OFF
GO
INSERT [dbo].[subject_programmes] ([subject_id], [programme_id], [obligatory]) VALUES (11, 2, 1)
INSERT [dbo].[subject_programmes] ([subject_id], [programme_id], [obligatory]) VALUES (8, 1, 1)
INSERT [dbo].[subject_programmes] ([subject_id], [programme_id], [obligatory]) VALUES (9, 1, 1)
INSERT [dbo].[subject_programmes] ([subject_id], [programme_id], [obligatory]) VALUES (10, 1, 1)
INSERT [dbo].[subject_programmes] ([subject_id], [programme_id], [obligatory]) VALUES (12, 2, 1)
INSERT [dbo].[subject_programmes] ([subject_id], [programme_id], [obligatory]) VALUES (13, 1, 1)
INSERT [dbo].[subject_programmes] ([subject_id], [programme_id], [obligatory]) VALUES (22, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([subject_id], [name], [e_hours], [gy_hours], [subject_code], [semester_id], [education_type], [l_hours], [correspond_hours]) VALUES (8, N'asd', 2, 2, N'asd', 3, N'async', 4, NULL)
INSERT [dbo].[Subjects] ([subject_id], [name], [e_hours], [gy_hours], [subject_code], [semester_id], [education_type], [l_hours], [correspond_hours]) VALUES (9, N'asd2', 1, 1, N'asd2', 3, N'traditional', 1, NULL)
INSERT [dbo].[Subjects] ([subject_id], [name], [e_hours], [gy_hours], [subject_code], [semester_id], [education_type], [l_hours], [correspond_hours]) VALUES (10, N'asd3', 4, 4, N'asd3', 3, N'traditional', 4, NULL)
INSERT [dbo].[Subjects] ([subject_id], [name], [e_hours], [gy_hours], [subject_code], [semester_id], [education_type], [l_hours], [correspond_hours]) VALUES (11, N'asd', NULL, NULL, N'asd', 3, N'traditional', NULL, 5)
INSERT [dbo].[Subjects] ([subject_id], [name], [e_hours], [gy_hours], [subject_code], [semester_id], [education_type], [l_hours], [correspond_hours]) VALUES (12, N'asd4', 1, 1, N'asd4', 3, N'traditional', 1, NULL)
INSERT [dbo].[Subjects] ([subject_id], [name], [e_hours], [gy_hours], [subject_code], [semester_id], [education_type], [l_hours], [correspond_hours]) VALUES (13, N'Programozás', 3, 2, N'GKNB_INTM021', 1, N'traditional', 2, NULL)
INSERT [dbo].[Subjects] ([subject_id], [name], [e_hours], [gy_hours], [subject_code], [semester_id], [education_type], [l_hours], [correspond_hours]) VALUES (22, N'Projektmunka 1.', 1, 1, N'GKNB_INTM004', 1, N'traditional', 1, NULL)
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([teacher_id], [name], [hoursperweek], [position], [is_working]) VALUES (1, N'Zöld Alex', 0, N'Adjunktus, tanársegéd, mesteroktató', 0)
INSERT [dbo].[Teachers] ([teacher_id], [name], [hoursperweek], [position], [is_working]) VALUES (2, N'Szabolcsoló Varga', 0, N'Adjunktus, tanársegéd, mesteroktató', 1)
INSERT [dbo].[Teachers] ([teacher_id], [name], [hoursperweek], [position], [is_working]) VALUES (3, N'Bogzos Ádám', 0, N'Tanszéki mérnök', 1)
INSERT [dbo].[Teachers] ([teacher_id], [name], [hoursperweek], [position], [is_working]) VALUES (4, N'Senki', 1, N'Tanári munkakörök', 0)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2021. 11. 28. 17:22:20 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2021. 11. 28. 17:22:20 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2021. 11. 28. 17:22:20 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2021. 11. 28. 17:22:20 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2021. 11. 28. 17:22:20 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2021. 11. 28. 17:22:20 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2021. 11. 28. 17:22:20 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Courses_members]  DEFAULT ((0)) FOR [members]
GO
ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [DF__Teachers__hoursp__24927208]  DEFAULT ('0') FOR [hoursperweek]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [Courses_fk0] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subjects] ([subject_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [Courses_fk0]
GO
ALTER TABLE [dbo].[courses_teachers]  WITH CHECK ADD  CONSTRAINT [courses_teachers_fk0] FOREIGN KEY([course_id])
REFERENCES [dbo].[Courses] ([course_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[courses_teachers] CHECK CONSTRAINT [courses_teachers_fk0]
GO
ALTER TABLE [dbo].[courses_teachers]  WITH CHECK ADD  CONSTRAINT [courses_teachers_fk1] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teachers] ([teacher_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[courses_teachers] CHECK CONSTRAINT [courses_teachers_fk1]
GO
ALTER TABLE [dbo].[ProgrammeDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProgrammeDetails_Programmes] FOREIGN KEY([programme_id])
REFERENCES [dbo].[Programmes] ([programme_id])
GO
ALTER TABLE [dbo].[ProgrammeDetails] CHECK CONSTRAINT [FK_ProgrammeDetails_Programmes]
GO
ALTER TABLE [dbo].[subject_programmes]  WITH CHECK ADD  CONSTRAINT [subject_szakok_fk0] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subjects] ([subject_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[subject_programmes] CHECK CONSTRAINT [subject_szakok_fk0]
GO
ALTER TABLE [dbo].[subject_programmes]  WITH CHECK ADD  CONSTRAINT [subject_szakok_fk1] FOREIGN KEY([programme_id])
REFERENCES [dbo].[Programmes] ([programme_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[subject_programmes] CHECK CONSTRAINT [subject_szakok_fk1]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [Subjects_fk0] FOREIGN KEY([semester_id])
REFERENCES [dbo].[Semester] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [Subjects_fk0]
GO
USE [master]
GO
ALTER DATABASE [Kurzusok] SET  READ_WRITE 
GO
