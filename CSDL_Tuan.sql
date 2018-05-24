-- Tao Proc CSDL- Tuan
USE CSDL
CREATE PROCEDURE [dbo].[spgetTableHoaDon]
AS
BEGIN 
	SELECT * FROM dbo.HoaDon
END

GO
//-------------------------------------
CREATE PROCEDURE [dbo].[spInsertHoaDon]
(
	@MAHD	char(10),
	@TENHD	nvarchar(50),
	@NGAYTHU	DATE,
	@TONGSOTIEN	BIGINT,
	@MASV	char(10),
	@MANV	char(10)
)
AS 
BEGIN 
	INSERT INTO dbo.HoaDon
	        ( MaHD ,
	          TenHD ,
	          NgayThu ,
	          TongSoTien ,
	          MaSV ,
	          MaNV
	        )
	VALUES  ( @MAHD , -- MaHD - char(10)
	          @TENHD , -- TenHD - nvarchar(50)
	          @NGAYTHU , -- NgayThu - date
	          @TONGSOTIEN , -- TongSoTien - bigint
	          @MASV , -- MaSV - char(10)
	          @MANV  -- MaNV - char(10)
	        )
	
END

GO
--spInsertHoaDon 'HD0002', 'Thu phí kỳ 1','1998-10-10',60000,'sv0001','nv001'





-- Update hoa don

CREATE PROCEDURE [dbo].[spUpdateDangKy]
(
	@MASV	varchar(10),
	@MAHP	varchar(10),
	@LOAIHK	varchar(10),
	@NAMHOC	varchar(10),
	@SOTIEN bigint,
	@TRANGTHAINOP nvarchar(15)	
)
AS
BEGIN 
	UPDATE dbo.DangKy
SET
	TrangThaiNop=N'Đã Nộp'
	WHERE MaSV=@MASV AND MaHP=@MAHP AND NamHoc=@NAMHOC AND LoaiHK=@LOAIHK
END	

GO


--SELECT * FROM DangKy

-- Lấy ra danh sách sinh viên nộp phí từ ngày A đến ngày B

go
CREATE PROCEDURE [dbo].[spgetSinhVienNopPhi] (@NGAYBATDAU DATE, @NGAYKETTHUC date)
AS
BEGIN
	SELECT SV.MaSV, SV.HoTenSV,HD.TongSoTien,HD.NgayThu,NV.TenNV  
	FROM Sinhvien AS SV, dbo.HoaDon AS HD,dbo.NhanVien AS NV
	WHERE SV.MaSV=HD.MaSV AND NV.MaNV=HD.MaNV
	AND HD.NgayThu>@NGAYBATDAU AND HD.NgayThu<@NGAYKETTHUC
END

GO

go
CREATE PROCEDURE [dbo].[spgetSinhVienNopPhiTrongNgay] (@NGAY DATE)
AS
BEGIN
	SELECT SV.MaSV, SV.HoTenSV,HD.TongSoTien,NV.TenNV  
	FROM Sinhvien AS SV, dbo.HoaDon AS HD,dbo.NhanVien AS NV
	WHERE SV.MaSV=HD.MaSV AND NV.MaNV=HD.MaNV
	AND HD.NgayThu=@NGAY
END

GO


--dbo.spgetSinhVienNopPhiTrongNgay @NGAY = '2018-05-23' -- date





--dbo.spgetSinhVienNopPhi @NGAYBATDAU = '2018-05-22', -- date
--    @NGAYKETTHUC = '2018-05-25' -- date


--SELECT * FROM dbo.HoaDon

-- Lấy ra danh sách sinh viên chưa nộp phí của một học kỳ thuộc một năm học nào đáy
go
CREATE PROCEDURE [dbo].[spgetSinhVienChuaNopPhi] (@LOAIHK varchar(10),@NAMHOC varchar(10) )
AS
BEGIN
	SELECT SV.MaSV, SV.HoTenSV,SV.NgaySinh, SV.DiaChi,COUNT(DK.MaHP) AS SoMonHoc,SUM(DK.SoTien) AS SoTienNo
	FROM Sinhvien AS SV, dbo.DangKy AS DK
	WHERE SV.MaSV=DK.MaSV
	AND DK.LoaiHK=@LOAIHK AND DK.NamHoc=@NAMHOC AND DK.TrangThaiNop='Chưa nộp'
	GROUP BY
	SV.MaSV, SV.HoTenSV,SV.NgaySinh, SV.DiaChi
END

GO
 --DROP PROCEDURE dbo.spgetSinhVienChuaNopPhi
--dbo.spgetSinhVienChuaNopPhi @LOAIHK = 'HK1', -- varchar(10)
--    @NAMHOC = '2015-2016' -- varchar(10)
