USE [BloodBankDb]
GO
ALTER TABLE [dbo].[UsersTbl] DROP CONSTRAINT [DF__UsersTbl__Create__0F2D40CE]
GO
ALTER TABLE [dbo].[RequestTbl] DROP CONSTRAINT [DF__tmp_ms_xx__Creat__17C286CF]
GO
ALTER TABLE [dbo].[PatientsTbl] DROP CONSTRAINT [DF__PatientsT__Creat__2EA5EC27]
GO
/****** Object:  Table [dbo].[UsersTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsersTbl]') AND type in (N'U'))
DROP TABLE [dbo].[UsersTbl]
GO
/****** Object:  Table [dbo].[TransferTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransferTbl]') AND type in (N'U'))
DROP TABLE [dbo].[TransferTbl]
GO
/****** Object:  Table [dbo].[RequestTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RequestTbl]') AND type in (N'U'))
DROP TABLE [dbo].[RequestTbl]
GO
/****** Object:  Table [dbo].[PatientsTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PatientsTbl]') AND type in (N'U'))
DROP TABLE [dbo].[PatientsTbl]
GO
/****** Object:  Table [dbo].[DonorTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DonorTbl]') AND type in (N'U'))
DROP TABLE [dbo].[DonorTbl]
GO
/****** Object:  Table [dbo].[BloodTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BloodTbl]') AND type in (N'U'))
DROP TABLE [dbo].[BloodTbl]
GO
/****** Object:  Table [dbo].[BloodTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
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
/****** Object:  Table [dbo].[DonorTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
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
/****** Object:  Table [dbo].[PatientsTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
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
/****** Object:  Table [dbo].[RequestTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
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
/****** Object:  Table [dbo].[TransferTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
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
/****** Object:  Table [dbo].[UsersTbl]    Script Date: 28/09/2024 6:50:48 pm ******/
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
INSERT [dbo].[BloodTbl] ([BGroup], [BStock]) VALUES (N'A+', 2)
INSERT [dbo].[BloodTbl] ([BGroup], [BStock]) VALUES (N'A-', 0)
INSERT [dbo].[BloodTbl] ([BGroup], [BStock]) VALUES (N'AB+', 2)
INSERT [dbo].[BloodTbl] ([BGroup], [BStock]) VALUES (N'AB-', 1)
INSERT [dbo].[BloodTbl] ([BGroup], [BStock]) VALUES (N'B+', 0)
INSERT [dbo].[BloodTbl] ([BGroup], [BStock]) VALUES (N'B-', 6)
INSERT [dbo].[BloodTbl] ([BGroup], [BStock]) VALUES (N'O+', 0)
INSERT [dbo].[BloodTbl] ([BGroup], [BStock]) VALUES (N'O-', -1)
GO
SET IDENTITY_INSERT [dbo].[DonorTbl] ON 

INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (102, N'Turjo', 18, N'Male', N'01857048383', N'Dhaka', N'O+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (103, N'Shaily', 18, N'Female', N'01764554447', N'Dhaka', N'B-')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (104, N'Saif', 18, N'Male', N'01733833088', N'Dhaka', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1108, N'Mehedi', 19, N'Male', N'01234567890', N'Dhaka', N'A-')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1114, N'Turjo', 22, N'Male', N'01857048383', N'Diasf', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1115, N'Turjo Das Dip', 22, N'Male', N'01857048383', N'Dhaka', N'O+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1116, N'Turjo Das Dip', 18, N'Male', N'01857048383', N'Dhaka', N'A-')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1117, N'Jaya', 18, N'Male', N'01857048383', N'Dhaka', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1118, N'Turjo Das Dip', 5, N'Male', N'01857048383', N'Barisal', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1119, N'Turjo Das Dip', 18, N'Male', N'01857048383', N'Dhaka', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1120, N'Turjo Das Dip', 18, N'Male', N'01857048383', N'Dhaka', N'A-')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1121, N'Turjo', 17, N'Male', N'01857048383', N'Dhaka', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1122, N'fdsfds', 18, N'Male', N'01857048383', N'Dhaka', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1123, N'Turjo', 18, N'Male', N'01710160491', N'111', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1124, N'Shaily Saha', 18, N'Male', N'01716204874', N'Dhaka', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1125, N'Turjo Das Dip', 18, N'Male', N'01857048383', N'Barisal', N'A-')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1126, N'Shaily Saha', 18, N'Female', N'01716204874', N'Dhaka', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1127, N'Jaya', 20, N'Male', N'01716204874', N'Dhaka', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1128, N'Sadia', 18, N'Male', N'01857048383', N'Dhaka', N'B+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1129, N'Turjo Das Dip', 18, N'Male', N'01857048383', N'Dhaka', N'B+')
INSERT [dbo].[DonorTbl] ([DNum], [DName], [DAge], [DGender], [DPhone], [DAddress], [DBGroup]) VALUES (1130, N'Turjo Das Dip', 18, N'Male', N'01857048383', N'Dhaka', N'A+')
SET IDENTITY_INSERT [dbo].[DonorTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientsTbl] ON 

INSERT [dbo].[PatientsTbl] ([PNum], [PName], [PAge], [PPhone], [PGender], [PBGroup], [PAdress], [PDList], [PWNo], [PBNo], [CreatedDate]) VALUES (500, N'Turjo Das Dip', 18, N'01857048383', N'Male', N'O+', N'Dhaka', N'Cardiothoracic and Vascular Surgery', N'M1-M20', N'F-6', CAST(N'2024-09-26T21:08:50.910' AS DateTime))
SET IDENTITY_INSERT [dbo].[PatientsTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[RequestTbl] ON 

INSERT [dbo].[RequestTbl] ([Id], [RName], [RPhone], [REmail], [RBGroup], [CreatedDate]) VALUES (501, N'Turjo Das Dip', N'01857048383', NULL, N'A-', CAST(N'2024-09-25T17:50:48.273' AS DateTime))
INSERT [dbo].[RequestTbl] ([Id], [RName], [RPhone], [REmail], [RBGroup], [CreatedDate]) VALUES (502, N'Turjo Das Dip', N'01857048383', NULL, N'A+', CAST(N'2024-09-25T17:51:22.370' AS DateTime))
INSERT [dbo].[RequestTbl] ([Id], [RName], [RPhone], [REmail], [RBGroup], [CreatedDate]) VALUES (503, N'Turjo Das Dip', N'01857048383', NULL, N'A-', CAST(N'2024-09-25T17:58:21.910' AS DateTime))
INSERT [dbo].[RequestTbl] ([Id], [RName], [RPhone], [REmail], [RBGroup], [CreatedDate]) VALUES (504, N'Turjo Das Dip', N'01857048383', NULL, N'A+', CAST(N'2024-09-25T19:50:15.927' AS DateTime))
INSERT [dbo].[RequestTbl] ([Id], [RName], [RPhone], [REmail], [RBGroup], [CreatedDate]) VALUES (505, N'Turjo Das Dip', N'01857048383', NULL, N'A+', CAST(N'2024-09-25T19:53:34.360' AS DateTime))
INSERT [dbo].[RequestTbl] ([Id], [RName], [RPhone], [REmail], [RBGroup], [CreatedDate]) VALUES (506, N'Turjo Das Dip', N'01857048383', NULL, N'A-', CAST(N'2024-09-25T19:57:43.047' AS DateTime))
INSERT [dbo].[RequestTbl] ([Id], [RName], [RPhone], [REmail], [RBGroup], [CreatedDate]) VALUES (507, N'Turjo Das Dip', N'01857048383', NULL, N'A+', CAST(N'2024-09-25T19:59:20.597' AS DateTime))
INSERT [dbo].[RequestTbl] ([Id], [RName], [RPhone], [REmail], [RBGroup], [CreatedDate]) VALUES (510, N'Turjo Das Dip', N'01857048383', N'hilawov619@aiworldx.com', N'A-', CAST(N'2024-09-26T00:34:26.130' AS DateTime))
INSERT [dbo].[RequestTbl] ([Id], [RName], [RPhone], [REmail], [RBGroup], [CreatedDate]) VALUES (514, N'Turjo Das Dip', N'01857048383', N'tdas41380@gmail.com', N'B+', CAST(N'2024-09-26T01:40:41.140' AS DateTime))
SET IDENTITY_INSERT [dbo].[RequestTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[TransferTbl] ON 

INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (1, N'Shaily', N'O-')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (2, N'Turjo', N'O+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (3, N'Turjo', N'O+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (4, N'Turjo Das Dip', N'A+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (5, N'Turjo Das Dip', N'A+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (6, N'Turjo Das Dip', N'AB+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (7, N'Turjo Das Dip', N'A+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (8, N'Shaily Saha', N'A+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (9, N'Shaily Saha', N'A+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (10, N'Shaily Saha', N'A+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (11, N'Turjo Das Dip', N'B+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (12, N'Turjo Das Dip', N'O+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (13, N'Turjo Das Dip', N'O+')
INSERT [dbo].[TransferTbl] ([TNum], [PName], [BGroup]) VALUES (14, N'Shaily Saha', N'A+')
SET IDENTITY_INSERT [dbo].[TransferTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[UsersTbl] ON 

INSERT [dbo].[UsersTbl] ([Id], [UName], [UFullName], [UPhone], [UEmail], [UPassword], [CreatedDate]) VALUES (101, N'shaily1', N'Shaily Saha', N'01716204874', N'shailysaha3@gmail.com', N'shaily3', CAST(N'2024-09-25T21:45:56.987' AS DateTime))
INSERT [dbo].[UsersTbl] ([Id], [UName], [UFullName], [UPhone], [UEmail], [UPassword], [CreatedDate]) VALUES (102, N'tdas', N'Turjo Das Dip', N'01857048383', N'hilawov619@aiworldx.com', N'tdas12', CAST(N'2024-09-26T00:33:07.313' AS DateTime))
INSERT [dbo].[UsersTbl] ([Id], [UName], [UFullName], [UPhone], [UEmail], [UPassword], [CreatedDate]) VALUES (103, N'turjo', N'Turjo Das Dip', N'01857048383', N'phlxe504vd@qacmjeq.com', N'123456', CAST(N'2024-09-26T21:56:33.357' AS DateTime))
INSERT [dbo].[UsersTbl] ([Id], [UName], [UFullName], [UPhone], [UEmail], [UPassword], [CreatedDate]) VALUES (106, N'turj', N'Turjo Das Dip', N'01857048383', N'turjodasdip1@gmail.com', N'123456', CAST(N'2024-09-26T22:13:09.580' AS DateTime))
INSERT [dbo].[UsersTbl] ([Id], [UName], [UFullName], [UPhone], [UEmail], [UPassword], [CreatedDate]) VALUES (107, N'turjo1', N'Turjo Das Dip', N'01857048383', N'tdas41380@gmail.com', N'Dip.12', CAST(N'2024-09-26T22:17:30.067' AS DateTime))
SET IDENTITY_INSERT [dbo].[UsersTbl] OFF
GO
ALTER TABLE [dbo].[PatientsTbl] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[RequestTbl] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UsersTbl] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
