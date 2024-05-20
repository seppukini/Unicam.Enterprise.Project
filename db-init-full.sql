USE [master]

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ParadigmiProject')
BEGIN
    CREATE DATABASE [ParadigmiProject];
END
GO

USE [ParadigmiProject];

GO
ALTER DATABASE [ParadigmiProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ParadigmiProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ParadigmiProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ParadigmiProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ParadigmiProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ParadigmiProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ParadigmiProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [ParadigmiProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ParadigmiProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ParadigmiProject] SET AUTO_UPDATE_STATISTICS OFF 
GO
ALTER DATABASE [ParadigmiProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ParadigmiProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ParadigmiProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ParadigmiProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ParadigmiProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ParadigmiProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ParadigmiProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ParadigmiProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ParadigmiProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ParadigmiProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ParadigmiProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ParadigmiProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ParadigmiProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ParadigmiProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ParadigmiProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ParadigmiProject] SET  MULTI_USER 
GO
ALTER DATABASE [ParadigmiProject] SET PAGE_VERIFY TORN_PAGE_DETECTION  
GO
ALTER DATABASE [ParadigmiProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ParadigmiProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ParadigmiProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ParadigmiProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ParadigmiProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ParadigmiProject', N'ON'
GO
ALTER DATABASE [ParadigmiProject] SET QUERY_STORE = OFF
GO
USE [ParadigmiProject]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 18/05/2024 16:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](100) NOT NULL,
    [Price] [decimal](18, 0) NOT NULL,
    [Type] [int] NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[OrderCourses]    Script Date: 18/05/2024 16:47:20 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[OrderCourses](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [OrdersId] [int] NOT NULL,
    [CoursesId] [int] NOT NULL,
    CONSTRAINT [PK_OrderCourses] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Orders]    Script Date: 18/05/2024 16:47:20 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Orders](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Date] [datetime] NOT NULL,
    [Street] [varchar](100) NOT NULL,
    [City] [varchar](100) NOT NULL,
    [ZipCode] [varchar](100) NOT NULL,
    [UserId] [int] NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/05/2024 16:47:20 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Users](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](100) NOT NULL,
    [Surname] [varchar](100) NOT NULL,
    [Email] [varchar](100) NOT NULL,
    [Password] [varchar](100) NOT NULL,
    [Role] [int] NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET IDENTITY_INSERT [dbo].[Courses] ON
    GO
    INSERT [dbo].[Courses] ([Id], [Name], [Price], [Type]) VALUES (1, N'Tortellini alla norcina', CAST(10 AS Decimal(18, 0)), 0)
    GO
    INSERT [dbo].[Courses] ([Id], [Name], [Price], [Type]) VALUES (2, N'Tonnarelli cacio e pepe', CAST(9 AS Decimal(18, 0)), 0)
    GO
    INSERT [dbo].[Courses] ([Id], [Name], [Price], [Type]) VALUES (3, N'Petto di pollo ai ferri', CAST(11 AS Decimal(18, 0)), 1)
    GO
    INSERT [dbo].[Courses] ([Id], [Name], [Price], [Type]) VALUES (4, N'Grigliata mista', CAST(15 AS Decimal(18, 0)), 1)
    GO
    INSERT [dbo].[Courses] ([Id], [Name], [Price], [Type]) VALUES (5, N'Patate fritte', CAST(4 AS Decimal(18, 0)), 2)
    GO
    INSERT [dbo].[Courses] ([Id], [Name], [Price], [Type]) VALUES (6, N'Patate arrosto', CAST(4 AS Decimal(18, 0)), 2)
    GO
    INSERT [dbo].[Courses] ([Id], [Name], [Price], [Type]) VALUES (7, N'Verdure di stagione grigliate', CAST(4 AS Decimal(18, 0)), 2)
    GO
    INSERT [dbo].[Courses] ([Id], [Name], [Price], [Type]) VALUES (8, N'Tiramisu', CAST(5 AS Decimal(18, 0)), 3)
    GO
    INSERT [dbo].[Courses] ([Id], [Name], [Price], [Type]) VALUES (9, N'Panna cotta', CAST(5 AS Decimal(18, 0)), 3)
    GO
    SET IDENTITY_INSERT [dbo].[Courses] OFF
    GO
    SET IDENTITY_INSERT [dbo].[OrderCourses] ON
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (33, 5, 1)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (34, 5, 2)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (35, 5, 3)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (36, 5, 4)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (37, 5, 5)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (38, 5, 6)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (39, 5, 7)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (40, 5, 8)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (41, 5, 9)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (42, 6, 1)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (43, 6, 4)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (44, 7, 1)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (45, 7, 2)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (46, 7, 3)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (47, 7, 5)
    GO
    INSERT [dbo].[OrderCourses] ([Id], [OrdersId], [CoursesId]) VALUES (48, 7, 8)
    GO
    SET IDENTITY_INSERT [dbo].[OrderCourses] OFF
    GO
    SET IDENTITY_INSERT [dbo].[Orders] ON
    GO
    INSERT [dbo].[Orders] ([Id], [Date], [Street], [City], [ZipCode], [UserId]) VALUES (5, CAST(N'2024-04-15T14:27:23.093' AS DateTime), N'Via Pappagalli, 12', N'Jesi', N'60035', 2)
    GO
    INSERT [dbo].[Orders] ([Id], [Date], [Street], [City], [ZipCode], [UserId]) VALUES (6, CAST(N'2024-05-10T14:27:47.377' AS DateTime), N'Via Roma, 21', N'Ancona', N'60121', 2)
    GO
    INSERT [dbo].[Orders] ([Id], [Date], [Street], [City], [ZipCode], [UserId]) VALUES (7, CAST(N'2024-05-18T14:28:19.820' AS DateTime), N'Via Pappagalli, 12', N'Jesi', N'60035', 2)
    GO
    SET IDENTITY_INSERT [dbo].[Orders] OFF
    GO
    SET IDENTITY_INSERT [dbo].[Users] ON
    GO
    INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [Role]) VALUES (1, N'Admin', N'Admin', N'admin@email.it', N'admin', 1)
    GO
    INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [Role]) VALUES (2, N'Mario', N'Rossi', N'mario.rossi@email.it', N'Mario1234.', 0)
    GO
    SET IDENTITY_INSERT [dbo].[Users] OFF
    GO
ALTER TABLE [dbo].[OrderCourses]  WITH CHECK ADD  CONSTRAINT [FK_OrderCourses_Courses] FOREIGN KEY([CoursesId])
    REFERENCES [dbo].[Courses] ([Id])
    ON UPDATE CASCADE
       ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderCourses] CHECK CONSTRAINT [FK_OrderCourses_Courses]
    GO
ALTER TABLE [dbo].[OrderCourses]  WITH CHECK ADD  CONSTRAINT [FK_OrderCourses_Orders] FOREIGN KEY([OrdersId])
    REFERENCES [dbo].[Orders] ([Id])
    ON UPDATE CASCADE
       ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderCourses] CHECK CONSTRAINT [FK_OrderCourses_Orders]
    GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
    REFERENCES [dbo].[Users] ([Id])
    ON UPDATE CASCADE
       ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
    GO
    USE [master]
    GO
ALTER DATABASE [ParadigmiProject] SET  READ_WRITE 
GO
