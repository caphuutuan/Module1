USE [QLNB]
GO
/****** Object:  Table [dbo].[BaiBao]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiBao](
	[MaBB] [int] IDENTITY(1,1) NOT NULL,
	[MaTL] [int] NULL,
	[UserID] [int] NULL,
	[TenBB] [nvarchar](50) NULL,
	[NgayViet] [datetime] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[NgayChinhSua] [datetime] NULL,
	[DanhGia] [nvarchar](50) NULL,
	[Status] [int] NOT NULL,
	[MaLV] [int] NULL,
	[Thumb] [nvarchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_BaiBao] PRIMARY KEY CLUSTERED 
(
	[MaBB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTDH]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDH](
	[MaCTDH] [int] IDENTITY(1,1) NOT NULL,
	[MaDH] [int] NULL,
	[MaBB] [int] NULL,
	[Gia] [int] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_CTDH] PRIMARY KEY CLUSTERED 
(
	[MaCTDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoanhThu]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoanhThu](
	[MaDT] [int] IDENTITY(1,1) NOT NULL,
	[Ngay] [date] NULL,
	[Money] [float] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_DoanhThu] PRIMARY KEY CLUSTERED 
(
	[MaDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocGia](
	[MaDG] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[TenDG] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[DiaChi] [varchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[RoleID] [int] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_DocGia] PRIMARY KEY CLUSTERED 
(
	[MaDG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoiTac]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoiTac](
	[MaDT] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[SDT] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[Email] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_DoiTac] PRIMARY KEY CLUSTERED 
(
	[MaDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[NgayDat] [datetime] NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LinhVucNB]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinhVucNB](
	[MaLinhVuc] [int] IDENTITY(1,1) NOT NULL,
	[TenLinhVuc] [nvarchar](50) NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_LinhVucNB] PRIMARY KEY CLUSTERED 
(
	[MaLinhVuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaBao]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaBao](
	[MaNB] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaBao] PRIMARY KEY CLUSTERED 
(
	[MaNB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuangCao]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuangCao](
	[MaQC] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nchar](100) NULL,
	[MoTa] [nchar](100) NULL,
	[HinhAnh] [nchar](10) NULL,
	[Link] [nchar](100) NULL,
	[Status] [nchar](100) NULL,
 CONSTRAINT [PK_QuangCao] PRIMARY KEY CLUSTERED 
(
	[MaQC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoaiBaiBao]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoaiBaiBao](
	[MaTL] [int] IDENTITY(1,1) NOT NULL,
	[TenTL] [nvarchar](50) NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_TheLoaiBaiBao] PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/10/2023 1:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[Email] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaiBao] ON 

INSERT [dbo].[BaiBao] ([MaBB], [MaTL], [UserID], [TenBB], [NgayViet], [NoiDung], [NgayChinhSua], [DanhGia], [Status], [MaLV], [Thumb], [Active]) VALUES (1, 2, 1, N'Tin chính trị mới nhất 11/09/2023', NULL, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[BaiBao] ([MaBB], [MaTL], [UserID], [TenBB], [NgayViet], [NoiDung], [NgayChinhSua], [DanhGia], [Status], [MaLV], [Thumb], [Active]) VALUES (2, 3, 2, N'Bài báo 1', NULL, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[BaiBao] ([MaBB], [MaTL], [UserID], [TenBB], [NgayViet], [NoiDung], [NgayChinhSua], [DanhGia], [Status], [MaLV], [Thumb], [Active]) VALUES (3, 3, 2, N'Bài báo 2', NULL, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', NULL, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[BaiBao] ([MaBB], [MaTL], [UserID], [TenBB], [NgayViet], [NoiDung], [NgayChinhSua], [DanhGia], [Status], [MaLV], [Thumb], [Active]) VALUES (4, 4, 3, N'Bài báo 3', NULL, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', NULL, NULL, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[BaiBao] OFF
GO
SET IDENTITY_INSERT [dbo].[LinhVucNB] ON 

INSERT [dbo].[LinhVucNB] ([MaLinhVuc], [TenLinhVuc], [Description]) VALUES (1, N'Công nghệ', NULL)
INSERT [dbo].[LinhVucNB] ([MaLinhVuc], [TenLinhVuc], [Description]) VALUES (2, N'Chính trị', NULL)
INSERT [dbo].[LinhVucNB] ([MaLinhVuc], [TenLinhVuc], [Description]) VALUES (3, N'Kinh tế', NULL)
INSERT [dbo].[LinhVucNB] ([MaLinhVuc], [TenLinhVuc], [Description]) VALUES (4, N'Xã hội', NULL)
INSERT [dbo].[LinhVucNB] ([MaLinhVuc], [TenLinhVuc], [Description]) VALUES (5, N'Thể thao', NULL)
INSERT [dbo].[LinhVucNB] ([MaLinhVuc], [TenLinhVuc], [Description]) VALUES (6, N'Y tế', NULL)
SET IDENTITY_INSERT [dbo].[LinhVucNB] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [Name], [Description]) VALUES (1, N'Admin', N'Quản trị viên')
INSERT [dbo].[Role] ([RoleID], [Name], [Description]) VALUES (2, N'Staff', N'Nhân viên')
INSERT [dbo].[Role] ([RoleID], [Name], [Description]) VALUES (3, N'Journalist', N'Nhà báo')
INSERT [dbo].[Role] ([RoleID], [Name], [Description]) VALUES (4, N'Editor', N'Biên tập viên')
INSERT [dbo].[Role] ([RoleID], [Name], [Description]) VALUES (5, N'Customer', N'Khách hàng')
INSERT [dbo].[Role] ([RoleID], [Name], [Description]) VALUES (6, N'Reader', N'Độc giả')
INSERT [dbo].[Role] ([RoleID], [Name], [Description]) VALUES (7, N'Partner', N'Đối tác')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[TheLoaiBaiBao] ON 

INSERT [dbo].[TheLoaiBaiBao] ([MaTL], [TenTL], [Description]) VALUES (1, N'Đời sống', NULL)
INSERT [dbo].[TheLoaiBaiBao] ([MaTL], [TenTL], [Description]) VALUES (2, N'Bản tin chính trị', NULL)
INSERT [dbo].[TheLoaiBaiBao] ([MaTL], [TenTL], [Description]) VALUES (3, N'Văn hoá', NULL)
INSERT [dbo].[TheLoaiBaiBao] ([MaTL], [TenTL], [Description]) VALUES (4, N'Nghệ thuật', NULL)
INSERT [dbo].[TheLoaiBaiBao] ([MaTL], [TenTL], [Description]) VALUES (5, N'Phỏng vấn chính trị gia', NULL)
INSERT [dbo].[TheLoaiBaiBao] ([MaTL], [TenTL], [Description]) VALUES (6, N'Phân tích chính trị', NULL)
INSERT [dbo].[TheLoaiBaiBao] ([MaTL], [TenTL], [Description]) VALUES (7, N'Phân tích thị trường', NULL)
INSERT [dbo].[TheLoaiBaiBao] ([MaTL], [TenTL], [Description]) VALUES (8, N'Phân tích thể thao', NULL)
INSERT [dbo].[TheLoaiBaiBao] ([MaTL], [TenTL], [Description]) VALUES (9, N'Đời sống & sức khoẻ', NULL)
SET IDENTITY_INSERT [dbo].[TheLoaiBaiBao] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [Ten], [SDT], [DiaChi], [NgaySinh], [Email], [RoleID], [Status]) VALUES (1, N'Tuấn 1', N'0123456789', NULL, CAST(N'2002-03-25' AS Date), NULL, 3, 1)
INSERT [dbo].[User] ([UserID], [Ten], [SDT], [DiaChi], [NgaySinh], [Email], [RoleID], [Status]) VALUES (2, N'Tuấn 2', N'0123456789', NULL, CAST(N'2002-03-25' AS Date), NULL, 3, 1)
INSERT [dbo].[User] ([UserID], [Ten], [SDT], [DiaChi], [NgaySinh], [Email], [RoleID], [Status]) VALUES (3, N'Tuấn 3', N'0123456789', NULL, CAST(N'2002-03-25' AS Date), NULL, 3, 1)
INSERT [dbo].[User] ([UserID], [Ten], [SDT], [DiaChi], [NgaySinh], [Email], [RoleID], [Status]) VALUES (4, N'A 1', N'0123456789', NULL, CAST(N'2023-11-09' AS Date), NULL, 7, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[BaiBao]  WITH CHECK ADD  CONSTRAINT [FK_BaiBao_LinhVucNB] FOREIGN KEY([MaLV])
REFERENCES [dbo].[LinhVucNB] ([MaLinhVuc])
GO
ALTER TABLE [dbo].[BaiBao] CHECK CONSTRAINT [FK_BaiBao_LinhVucNB]
GO
ALTER TABLE [dbo].[BaiBao]  WITH CHECK ADD  CONSTRAINT [FK_BaiBao_TheLoaiBaiBao] FOREIGN KEY([MaTL])
REFERENCES [dbo].[TheLoaiBaiBao] ([MaTL])
GO
ALTER TABLE [dbo].[BaiBao] CHECK CONSTRAINT [FK_BaiBao_TheLoaiBaiBao]
GO
ALTER TABLE [dbo].[BaiBao]  WITH CHECK ADD  CONSTRAINT [FK_BaiBao_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[BaiBao] CHECK CONSTRAINT [FK_BaiBao_User]
GO
ALTER TABLE [dbo].[CTDH]  WITH CHECK ADD  CONSTRAINT [FK_CTDH_BaiBao] FOREIGN KEY([MaDH])
REFERENCES [dbo].[BaiBao] ([MaBB])
GO
ALTER TABLE [dbo].[CTDH] CHECK CONSTRAINT [FK_CTDH_BaiBao]
GO
ALTER TABLE [dbo].[CTDH]  WITH CHECK ADD  CONSTRAINT [FK_CTDH_DonHang] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO
ALTER TABLE [dbo].[CTDH] CHECK CONSTRAINT [FK_CTDH_DonHang]
GO
ALTER TABLE [dbo].[DocGia]  WITH CHECK ADD  CONSTRAINT [FK_DocGia_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[DocGia] CHECK CONSTRAINT [FK_DocGia_Role]
GO
ALTER TABLE [dbo].[DoiTac]  WITH CHECK ADD  CONSTRAINT [FK_DoiTac_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[DoiTac] CHECK CONSTRAINT [FK_DoiTac_Role]
GO
ALTER TABLE [dbo].[NhaBao]  WITH CHECK ADD  CONSTRAINT [FK_NhaBao_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[NhaBao] CHECK CONSTRAINT [FK_NhaBao_Role]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
