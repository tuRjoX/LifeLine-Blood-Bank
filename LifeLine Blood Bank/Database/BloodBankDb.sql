USE [BloodBankDb]
GO
ALTER TABLE [dbo].[UsersTbl] DROP CONSTRAINT [DF__UsersTbl__Create__0F2D40CE]
GO
ALTER TABLE [dbo].[RequestTbl] DROP CONSTRAINT [DF__tmp_ms_xx__Creat__17C286CF]
GO
ALTER TABLE [dbo].[PatientsTbl] DROP CONSTRAINT [DF__PatientsT__Creat__2EA5EC27]
GO
/****** Object:  Table [dbo].[UsersTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsersTbl]') AND type in (N'U'))
DROP TABLE [dbo].[UsersTbl]
GO
/****** Object:  Table [dbo].[TransferTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransferTbl]') AND type in (N'U'))
DROP TABLE [dbo].[TransferTbl]
GO
/****** Object:  Table [dbo].[RequestTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RequestTbl]') AND type in (N'U'))
DROP TABLE [dbo].[RequestTbl]
GO
/****** Object:  Table [dbo].[PatientsTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PatientsTbl]') AND type in (N'U'))
DROP TABLE [dbo].[PatientsTbl]
GO
/****** Object:  Table [dbo].[DonorTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DonorTbl]') AND type in (N'U'))
DROP TABLE [dbo].[DonorTbl]
GO
/****** Object:  Table [dbo].[BloodTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BloodTbl]') AND type in (N'U'))
DROP TABLE [dbo].[BloodTbl]
GO
/****** Object:  Table [dbo].[BloodTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodTbl](
	[BGroup] [varchar](50) NOT NULL,
	[BStock] [int] NOT NULL,
 CONSTRAINT [PK_BloodTbl] PRIMARY KEY CLUSTERED 
(
	[BGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonorTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonorTbl](
	[DNum] [int] IDENTITY(100,1) NOT NULL,
	[DName] [varchar](50) NOT NULL,
	[DAge] [int] NOT NULL,
	[DGender] [varchar](50) NOT NULL,
	[DPhone] [varchar](50) NOT NULL,
	[DAddress] [varchar](50) NOT NULL,
	[DBGroup] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientsTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientsTbl](
	[PNum] [int] IDENTITY(500,1) NOT NULL,
	[PName] [varchar](50) NOT NULL,
	[PAge] [int] NOT NULL,
	[PPhone] [varchar](50) NOT NULL,
	[PGender] [varchar](50) NOT NULL,
	[PBGroup] [varchar](50) NOT NULL,
	[PAdress] [varchar](50) NOT NULL,
	[PDList] [varchar](50) NOT NULL,
	[PWNo] [varchar](50) NOT NULL,
	[PBNo] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestTbl](
	[Id] [int] IDENTITY(500,1) NOT NULL,
	[RName] [varchar](50) NULL,
	[RPhone] [varchar](11) NULL,
	[REmail] [varchar](50) NULL,
	[RBGroup] [varchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferTbl](
	[TNum] [int] IDENTITY(1,1) NOT NULL,
	[PName] [varchar](50) NOT NULL,
	[BGroup] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersTbl]    Script Date: 28/09/2024 6:58:46 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersTbl](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[UName] [varchar](50) NULL,
	[UFullName] [varchar](50) NULL,
	[UPhone] [varchar](11) NULL,
	[UEmail] [varchar](50) NULL,
	[UPassword] [varchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PatientsTbl] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[RequestTbl] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UsersTbl] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
