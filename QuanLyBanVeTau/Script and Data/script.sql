USE [QUANLYBANVETAU]
GO
/****** Object:  StoredProcedure [dbo].[CheckTaiKhoanHanhKhach]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckTaiKhoanHanhKhach]
	@TaiKhoan varchar(100)
as
	select * from HANHKHACH where TAIKHOAN = @TaiKhoan


GO
/****** Object:  StoredProcedure [dbo].[DangNhapHanhKhach]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DangNhapHanhKhach]
	@TaiKhoan varchar(100),
	@MatKhau varchar(50)
as
	select * from HANHKHACH where TAIKHOAN = @TaiKhoan and MATKHAU = @MatKhau


GO
/****** Object:  StoredProcedure [dbo].[DangNhapNhanVien]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DangNhapNhanVien]
	@TaiKhoan varchar(100),
	@MatKhau varchar(50)
as
	select * from NHANVIEN where TAIKHOAN = @TaiKhoan and MATKHAU = @MatKhau


GO
/****** Object:  StoredProcedure [dbo].[GetDatVe]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDatVe]
	@MaDatVe varchar(50)
as
	select * from DATVE where MADATVE = @MaDatVe

GO
/****** Object:  StoredProcedure [dbo].[GetDSCTDV]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSCTDV]
as
	select A.*,B.SOGHE, C.MATOA, C.SOTOA, D.TENDT from CTDV as A, GHE as B, TOATAU as C, DTGIAMGIA as D where A.MAGHE = B.MAGHE and B.MATOA = C.MATOA and A.MADT = D.MADT

GO
/****** Object:  StoredProcedure [dbo].[GetDSCTDVTheoMaDatVe]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSCTDVTheoMaDatVe]
	@MaDatVe varchar(50)
as
	select A.*,B.SOGHE, C.MATOA, C.SOTOA, D.TENDT from CTDV as A, GHE as B, TOATAU as C, DTGIAMGIA as D where MADATVE = @MaDatVe and A.MAGHE = B.MAGHE and B.MATOA = C.MATOA and A.MADT = D.MADT

GO
/****** Object:  StoredProcedure [dbo].[GetDSDatVe]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSDatVe]
as
	select * from DATVE


GO
/****** Object:  StoredProcedure [dbo].[GetDSDoanTau]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetDSDoanTau]
as
select A.*, B.TENGA as TENGACUOI from (select DOANTAU.*, GATAU.TENGA as TENGADAU from DOANTAU, GATAU where DOANTAU.MAGADAU = GATAU.MAGA) as A, GATAU as B where A.MAGACUOI = B.MAGA
GO
/****** Object:  StoredProcedure [dbo].[GetDSDTGiamGia]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSDTGiamGia]
as
	select * from DTGIAMGIA


GO
/****** Object:  StoredProcedure [dbo].[GetDSGaTau]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSGaTau]
as
	select * from GATAU


GO
/****** Object:  StoredProcedure [dbo].[GetDSGhe]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSGhe]
	@MaToa varchar(10),
	@MaLoaiGhe varchar(10)
as
	select * from GHE where MAGHE not in (select MAGHE from CTDV) and MATOA = @MaToa and MALOAIGHE = @MaLoaiGhe


GO
/****** Object:  StoredProcedure [dbo].[GetDSGiaVe]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSGiaVe]
as
	select * from GIAVE


GO
/****** Object:  StoredProcedure [dbo].[GetDSHoaDon]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSHoaDon]
as
	select * from HOADON

GO
/****** Object:  StoredProcedure [dbo].[GetDSLichTrinh]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSLichTrinh]
as
	select * from LICHTRINH


GO
/****** Object:  StoredProcedure [dbo].[GetDSLichTrinhTheoYeuCau]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDSLichTrinhTheoYeuCau]
	@MaGaDi varchar(10),
	@MaGaden varchar(10),
	@MaTau varchar(10),
	@TuNgay datetime,
	@DenNgay datetime
AS
	SELECT * FROM LICHTRINH where MAGADI=@MaGaDi and MAGADEN=@MaGaden and MATAU=@MaTau and (NGAYKHOIHANH between @TuNgay and @DenNgay)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[GetDSLoaiGhe]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSLoaiGhe]
as
	select * from LOAIGHE


GO
/****** Object:  StoredProcedure [dbo].[GetDSLoaiGheTrongToa]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSLoaiGheTrongToa]
	@MaToa varchar(10)
as
	select distinct MALOAIGHE from GHE where MATOA = @MaToa


GO
/****** Object:  StoredProcedure [dbo].[GetDSToaTauTheoMaTau]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDSToaTauTheoMaTau]
	@MaTau varchar(10)
as
	select * from TOATAU where MATAU = @MaTau


GO
/****** Object:  StoredProcedure [dbo].[GetDTauTheoMaTau]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDTauTheoMaTau]
	@MaTau varchar(10)
AS
	SELECT * from (select A.*, B.TENGA as TENGACUOI from (select DOANTAU.*, GATAU.TENGA as TENGADAU from DOANTAU, GATAU where DOANTAU.MAGADAU = GATAU.MAGA) as A, GATAU as B where A.MAGACUOI = B.MAGA) as C where C.MATAU=@MaTau
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[GetDTTheoMaDT]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDTTheoMaDT]
	@MaDT int
as
	select * from DTGIAMGIA where MADT = @MaDT


GO
/****** Object:  StoredProcedure [dbo].[GetGiaVeTheoMaGiaVe]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetGiaVeTheoMaGiaVe]
	@MaGiaVe varchar(50)
as
	select * from GIAVE where MAGIAVE = @MaGiaVe


GO
/****** Object:  StoredProcedure [dbo].[GetGTTheoMaGa]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetGTTheoMaGa]
	@MaGa varchar(10)
as
	select * from GATAU where MAGA = @MaGa


GO
/****** Object:  StoredProcedure [dbo].[GetHDTheoMaDatVe]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetHDTheoMaDatVe]
	@MaDatVe varchar(50)
as
	select * from HOADON where MADATVE =@MaDatVe

GO
/****** Object:  StoredProcedure [dbo].[GetHDTheoMaHD]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetHDTheoMaHD]
	@MaHD varchar(50)
as
	select * from HOADON where MAHD = @MaHD

GO
/****** Object:  StoredProcedure [dbo].[GetLTTheoMaLT]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetLTTheoMaLT]
	@MaLichTrinh varchar(20)
as
	select * from LICHTRINH where MALICHTRINH = @MaLichTrinh


GO
/****** Object:  Table [dbo].[CTDV]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTDV](
	[MADATVE] [varchar](50) NULL,
	[TENHK] [nvarchar](100) NULL,
	[MADT] [int] NULL,
	[CMND] [varchar](10) NULL,
	[MAGHE] [varchar](10) NULL,
	[MAGIAVE] [varchar](50) NULL,
	[GIA] [money] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DATVE]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DATVE](
	[MADATVE] [varchar](50) NOT NULL,
	[MALICHTRINH] [varchar](20) NULL,
	[MAHK] [varchar](10) NULL,
	[TONGGIA] [money] NULL,
	[NGAYHETHAN] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MADATVE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DOANTAU]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DOANTAU](
	[MATAU] [varchar](10) NOT NULL,
	[MAGADAU] [varchar](10) NULL,
	[MAGACUOI] [varchar](10) NULL,
	[TONGSOTOA] [smallint] NULL,
	[GHICHU] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MATAU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DTGIAMGIA]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DTGIAMGIA](
	[MADT] [int] IDENTITY(1,1) NOT NULL,
	[TENDT] [nvarchar](20) NULL,
	[HESO] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MADT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GATAU]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GATAU](
	[MAGA] [varchar](10) NOT NULL,
	[TENGA] [nvarchar](20) NULL,
	[DIACHI] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAGA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GHE]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GHE](
	[MAGHE] [varchar](10) NOT NULL,
	[MATOA] [varchar](10) NULL,
	[SOGHE] [smallint] NULL,
	[MALOAIGHE] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAGHE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GIAVE]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GIAVE](
	[MAGIAVE] [varchar](50) NOT NULL,
	[GADI] [varchar](10) NULL,
	[GADEN] [varchar](10) NULL,
	[MATAU] [varchar](10) NULL,
	[MALOAIGHE] [varchar](10) NULL,
	[DONGIA] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MAGIAVE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HANHKHACH]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HANHKHACH](
	[MAHK] [varchar](10) NOT NULL,
	[HOTEN] [nvarchar](100) NULL,
	[GIOITINH] [nvarchar](10) NULL,
	[NGAYSINH] [datetime] NULL,
	[DIACHI] [nvarchar](100) NULL,
	[CMND] [varchar](10) NULL,
	[SDT] [varchar](15) NULL,
	[EMAIL] [varchar](50) NULL,
	[TAIKHOAN] [varchar](100) NULL,
	[MATKHAU] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHD] [varchar](50) NOT NULL,
	[NGAYLAP] [datetime] NULL,
	[MADATVE] [varchar](50) NULL,
	[MANV] [varchar](10) NULL,
	[THANHTOAN] [money] NULL,
	[THOILAI] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LICHTRINH]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LICHTRINH](
	[MALICHTRINH] [varchar](20) NOT NULL,
	[MATAU] [varchar](10) NULL,
	[MAGADI] [varchar](10) NULL,
	[MAGADEN] [varchar](10) NULL,
	[NGAYKHOIHANH] [datetime] NULL,
	[GIOKHOIHANH] [time](7) NULL,
	[NGAYDEN] [datetime] NULL,
	[GIODEN] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[MALICHTRINH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAIGHE]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAIGHE](
	[MALOAIGHE] [varchar](10) NOT NULL,
	[TENGHE] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MALOAIGHE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [varchar](10) NOT NULL,
	[HOTEN] [nvarchar](100) NULL,
	[GIOITINH] [nvarchar](10) NULL,
	[NGAYSINH] [datetime] NULL,
	[NGAYVAOLAM] [datetime] NULL,
	[CMND] [varchar](50) NULL,
	[DIACHI] [nvarchar](200) NULL,
	[SDT] [varchar](20) NULL,
	[EMAIL] [varchar](50) NULL,
	[MAPB] [varchar](10) NULL,
	[TAIKHOAN] [varchar](100) NULL,
	[MATKHAU] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHONGBAN]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHONGBAN](
	[MAPB] [varchar](10) NOT NULL,
	[TENPB] [nvarchar](100) NULL,
	[MATRUONGPHONG] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TOATAU]    Script Date: 3/19/2015 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TOATAU](
	[MATOA] [varchar](10) NOT NULL,
	[MATAU] [varchar](10) NULL,
	[SOTOA] [smallint] NULL,
	[SOLUONGGHE] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[MATOA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CTDV]  WITH CHECK ADD FOREIGN KEY([MADATVE])
REFERENCES [dbo].[DATVE] ([MADATVE])
GO
ALTER TABLE [dbo].[CTDV]  WITH CHECK ADD FOREIGN KEY([MADT])
REFERENCES [dbo].[DTGIAMGIA] ([MADT])
GO
ALTER TABLE [dbo].[CTDV]  WITH CHECK ADD FOREIGN KEY([MAGHE])
REFERENCES [dbo].[GHE] ([MAGHE])
GO
ALTER TABLE [dbo].[CTDV]  WITH CHECK ADD FOREIGN KEY([MAGIAVE])
REFERENCES [dbo].[GIAVE] ([MAGIAVE])
GO
ALTER TABLE [dbo].[DATVE]  WITH CHECK ADD FOREIGN KEY([MAHK])
REFERENCES [dbo].[HANHKHACH] ([MAHK])
GO
ALTER TABLE [dbo].[DATVE]  WITH CHECK ADD FOREIGN KEY([MALICHTRINH])
REFERENCES [dbo].[LICHTRINH] ([MALICHTRINH])
GO
ALTER TABLE [dbo].[DOANTAU]  WITH CHECK ADD FOREIGN KEY([MAGACUOI])
REFERENCES [dbo].[GATAU] ([MAGA])
GO
ALTER TABLE [dbo].[DOANTAU]  WITH CHECK ADD FOREIGN KEY([MAGADAU])
REFERENCES [dbo].[GATAU] ([MAGA])
GO
ALTER TABLE [dbo].[GHE]  WITH CHECK ADD FOREIGN KEY([MALOAIGHE])
REFERENCES [dbo].[LOAIGHE] ([MALOAIGHE])
GO
ALTER TABLE [dbo].[GHE]  WITH CHECK ADD FOREIGN KEY([MATOA])
REFERENCES [dbo].[TOATAU] ([MATOA])
GO
ALTER TABLE [dbo].[GIAVE]  WITH CHECK ADD FOREIGN KEY([GADEN])
REFERENCES [dbo].[GATAU] ([MAGA])
GO
ALTER TABLE [dbo].[GIAVE]  WITH CHECK ADD FOREIGN KEY([GADI])
REFERENCES [dbo].[GATAU] ([MAGA])
GO
ALTER TABLE [dbo].[GIAVE]  WITH CHECK ADD FOREIGN KEY([MALOAIGHE])
REFERENCES [dbo].[LOAIGHE] ([MALOAIGHE])
GO
ALTER TABLE [dbo].[GIAVE]  WITH CHECK ADD FOREIGN KEY([MATAU])
REFERENCES [dbo].[DOANTAU] ([MATAU])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MADATVE])
REFERENCES [dbo].[DATVE] ([MADATVE])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[LICHTRINH]  WITH CHECK ADD FOREIGN KEY([MAGADI])
REFERENCES [dbo].[GATAU] ([MAGA])
GO
ALTER TABLE [dbo].[LICHTRINH]  WITH CHECK ADD FOREIGN KEY([MAGADEN])
REFERENCES [dbo].[GATAU] ([MAGA])
GO
ALTER TABLE [dbo].[LICHTRINH]  WITH CHECK ADD FOREIGN KEY([MATAU])
REFERENCES [dbo].[DOANTAU] ([MATAU])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_MAPB] FOREIGN KEY([MAPB])
REFERENCES [dbo].[PHONGBAN] ([MAPB])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_MAPB]
GO
ALTER TABLE [dbo].[PHONGBAN]  WITH CHECK ADD FOREIGN KEY([MATRUONGPHONG])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[TOATAU]  WITH CHECK ADD FOREIGN KEY([MATAU])
REFERENCES [dbo].[DOANTAU] ([MATAU])
GO
