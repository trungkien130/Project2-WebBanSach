USE [ThucTapChuyenDe1]
GO
/****** Object:  User [ltk2210900034]    Script Date: 31/10/2024 2:44:39 CH ******/
CREATE USER [ltk2210900034] FOR LOGIN [ltk2210900034] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 31/10/2024 2:44:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] NOT NULL,
	[TaiKhoan] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 31/10/2024 2:44:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSach] [int] NULL,
	[Img] [varchar](250) NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[Tong] [decimal](18, 0) NULL,
	[IdKH] [int] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSach]    Script Date: 31/10/2024 2:44:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSach](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_DanhMucSach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 31/10/2024 2:44:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](70) NULL,
	[Email] [char](100) NOT NULL,
	[SDT] [char](10) NULL,
	[Password] [varchar](250) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[NgayDangKy] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 31/10/2024 2:44:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [int] NOT NULL,
	[TenSach] [nvarchar](250) NULL,
	[IdDM] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[Img] [varchar](250) NULL,
	[TacGia] [nvarchar](250) NULL,
	[MoTa] [nvarchar](250) NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 31/10/2024 2:44:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [int] NOT NULL,
	[Img] [varchar](250) NULL,
	[Title] [nvarchar](250) NULL,
 CONSTRAINT [PK_Silde] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([Id], [IdSach], [Img], [SoLuong], [DonGia], [Tong], [IdKH]) VALUES (1004, 7, NULL, 8, CAST(100000 AS Decimal(18, 0)), CAST(800000 AS Decimal(18, 0)), 126)
INSERT [dbo].[Cart] ([Id], [IdSach], [Img], [SoLuong], [DonGia], [Tong], [IdKH]) VALUES (1005, 4, NULL, 1, CAST(100000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), 126)
INSERT [dbo].[Cart] ([Id], [IdSach], [Img], [SoLuong], [DonGia], [Tong], [IdKH]) VALUES (1006, 1, NULL, 5, CAST(100000 AS Decimal(18, 0)), CAST(500000 AS Decimal(18, 0)), 126)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMucSach] ON 

INSERT [dbo].[DanhMucSach] ([Id], [TenDanhMuc], [TrangThai]) VALUES (1, N'Ngôn tình', 1)
INSERT [dbo].[DanhMucSach] ([Id], [TenDanhMuc], [TrangThai]) VALUES (3, N'Thiếu nhi', 1)
INSERT [dbo].[DanhMucSach] ([Id], [TenDanhMuc], [TrangThai]) VALUES (4, N'Tình cảm', 1)
INSERT [dbo].[DanhMucSach] ([Id], [TenDanhMuc], [TrangThai]) VALUES (5, N'Tiểu Thuyến', 1)
INSERT [dbo].[DanhMucSach] ([Id], [TenDanhMuc], [TrangThai]) VALUES (6, N'Comic', 1)
SET IDENTITY_INSERT [dbo].[DanhMucSach] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [Email], [SDT], [Password], [DiaChi], [NgaySinh], [NgayDangKy], [TrangThai]) VALUES (126, N'Lê Trung Kiên', N'kienlee14@gmail.com                                                                                 ', N'0913088169', N'123456', N'ha dong ', CAST(N'2004-02-13' AS Date), CAST(N'2024-10-19' AS Date), 1)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [Email], [SDT], [Password], [DiaChi], [NgaySinh], [NgayDangKy], [TrangThai]) VALUES (129, N'Lê Trung Kiên', N'kienlee14@gmail.com                                                                                 ', N'123123    ', N'2234234', N'ha dong', CAST(N'2004-02-13' AS Date), CAST(N'2024-10-19' AS Date), 1)
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [Email], [SDT], [Password], [DiaChi], [NgaySinh], [NgayDangKy], [TrangThai]) VALUES (130, N'Lê Trung Kiên', N'kienlee14@gmail.com                                                                                 ', N'0913088167', N'123456', NULL, CAST(N'2004-02-13' AS Date), CAST(N'2024-10-22' AS Date), 1)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach], [IdDM], [SoLuong], [DonGia], [Img], [TacGia], [MoTa]) VALUES (1, N'NĂM THÁNG ĐẰNG ĐẴNG, CHẲNG CÓ NGÀY NÀO THÍCH HỢP ĐI LÀM', 3, 5, CAST(100000 AS Decimal(18, 0)), N'bookImg1.jpg', N'me', N'chua co')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [IdDM], [SoLuong], [DonGia], [Img], [TacGia], [MoTa]) VALUES (2, N'Bay qua hồ gươm', 3, 2, CAST(100000 AS Decimal(18, 0)), N'bay-qua-ho-guom.jpg', N'v', N'chua co')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [IdDM], [SoLuong], [DonGia], [Img], [TacGia], [MoTa]) VALUES (3, N'Hà Nội thời cận đại', 5, 1, CAST(100000 AS Decimal(18, 0)), N'ha-noi-thoi-can-dai-01.jpg', N'z', N'chua co')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [IdDM], [SoLuong], [DonGia], [Img], [TacGia], [MoTa]) VALUES (4, N'Một thử nghiệm phê bình', 5, 1, CAST(100000 AS Decimal(18, 0)), N'mot-thu-nghiem-phe-binh-01.jpg', N'test', N'chua co')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [IdDM], [SoLuong], [DonGia], [Img], [TacGia], [MoTa]) VALUES (5, N'Quốc văn giáo khoa thư', 5, 1, CAST(100000 AS Decimal(18, 0)), N'quoc-van-giao-khoa-thu-.jpg', N'z', N'chua co')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [IdDM], [SoLuong], [DonGia], [Img], [TacGia], [MoTa]) VALUES (6, N'NĂM THÁNG ĐẰNG ĐẴNG, CHẲNG CÓ NGÀY NÀO THÍCH HỢP ĐI LÀM', 3, 1, CAST(100000 AS Decimal(18, 0)), N'bookImg1.jpg', N'1', N'chua co')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [IdDM], [SoLuong], [DonGia], [Img], [TacGia], [MoTa]) VALUES (7, N'Luận lý giáo khoa thư', 5, 1, CAST(100000 AS Decimal(18, 0)), N'luan-ly-giao-khoa-thu-01.jpg', N'test', N'chua co')
GO
INSERT [dbo].[Slide] ([ID], [Img], [Title]) VALUES (1, N'slide1.jpg', N'Sự kiện - Tiếng nói của tư liệu: Hà Nội thời cận đại từ góc nhìn hôm nay')
INSERT [dbo].[Slide] ([ID], [Img], [Title]) VALUES (2, N'slide2.jpg', N'Toạ đàm: Lối vào thế giới văn chương của Italo Calvino')
INSERT [dbo].[Slide] ([ID], [Img], [Title]) VALUES (3, N'slide3.jpg', N'SÁCH MỚI NỔI BẬT THÁNG 8')
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_KhachHang] FOREIGN KEY([IdKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_KhachHang]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Sach] FOREIGN KEY([IdSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Sach]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_DanhMucSach] FOREIGN KEY([IdDM])
REFERENCES [dbo].[DanhMucSach] ([Id])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_DanhMucSach]
GO
