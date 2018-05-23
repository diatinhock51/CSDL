USE CSDL
go
-- object spgetSinhVien
create procedure spgetSinhVien (@MASV char(10))
as
begin
	select * from SINHVIEN where MASV = @MASV;
end
GO

-- 
spgetSinhVien 'SV0001'
go
--spUpdateSinhVien
CREATE PROCEDURE spUpdateSinhVien
(
	@HoTenSV nvarchar(100),
	@NgaySinh	nvarchar(50),
    @MASV	char(10),
    @MaLQL	char(10),
    @KhoaHoc	nvarchar(50),
    @GioiTinh	nvarchar(10),
	@DiaChi	nvarchar(50),
	@Email	varchar(50),
	@MatKhau	char(10),
	@MaDT	char(10)
)
AS
BEGIN 
	UPDATE dbo.SinhVien
SET
	HoTenSV = @HoTenSV,
    NgaySinh = @NgaySinh ,
	MaSV = @MASV, 
	MaLQL= @MaLQL,
	KhoaHoc = @KhoaHoc,
	GioiTinh = @GioiTinh, 
	DiaChi = @DiaChi,
	Email = @Email ,
	MatKhau= @MatKhau,
	MaDT= @MaDT
	WHERE MaSV = @MASV
END	
go
--- spDeleteSinhVien 
CREATE PROCEDURE spDeleteSinhVien (@MASV char(10) )
AS
BEGIN 
	DELETE FROM dbo.SinhVien
	WHERE MaSV= @MASV
END
go
--spgetTableSinhVien

CREATE PROCEDURE spgetTableSinhVien 
AS
BEGIN 
	SELECT * FROM dbo.SinhVien
END
go
--InsertSinhVien
CREATE PROCEDURE InsertSinhVien 
(
	@HoTenSV nvarchar(100),
	@NgaySinh	nvarchar(50),
    @MASV	char(10),
    @MaLQL	char(10),
    @KhoaHoc	nvarchar(50),
    @GioiTinh	nvarchar(10),
	@DiaChi	nvarchar(50),
	@Email	varchar(50),
	@MatKhau	char(10),
	@MaDT	char(10)
)
AS 
BEGIN 
	INSERT INTO dbo.SinhVien
	        ( HoTenSV ,
	          NgaySinh ,
	          MaSV ,
	          MaLQL ,
	          KhoaHoc ,
	          GioiTinh ,
	          DiaChi ,
	          Email ,
	          MatKhau ,
	          MaDT
	        )
	VALUES  (@HoTenSV, @NgaySinh,@MASV, @MaLQL,@KhoaHoc, @GioiTinh,@DiaChi,@Email,@MatKhau,@MaDT
	        )
END
go
-- moi LOPQUANLY 

--procedure spgetLopQuanLy
CREATE procedure spgetLopQuanLy (@MALQL char(10))
as
begin
	select * from dbo.LopQuanLy where MaLQL=@MALQL;
end
GO

-- 
spgetLopQuanLy 'ANHTTT'
go
--spUpdateLopQuanLy
CREATE PROCEDURE spUpdateLopQuanLy
(
	@MALQL	char(10),	
	@TENLQL	nvarchar(50),	
	@KHOA	nvarchar(50)
)
AS
BEGIN 
	UPDATE dbo.LopQuanLy
SET
	MaLQL=@MALQL	,	
	TenLQL= @TENLQL	,	
	Khoa = @KHOA
	WHERE MaLQL=@MALQL
END	
GO 

--- spDeleteLopQuanLy
CREATE PROCEDURE spDeleteLopQuanLy (@MALQL CHAR(10) )
AS
BEGIN 
	DELETE FROM dbo.LopQuanLy
	WHERE MaLQL= @MALQL
END
GO
--spgetTableLopQuanLy

CREATE PROCEDURE spgetTableLopQuanLy
AS
BEGIN 
	SELECT * FROM dbo.LopQuanLy
END
go
--InsertLopQuanLy 
CREATE PROCEDURE spInsertLopQuanLy 
(
	@MALQL	char(10),	
	@TENLQL	nvarchar(50),	
	@KHOA	nvarchar(50)
)
AS 
BEGIN 
	INSERT INTO dbo.LopQuanLy
	        ( MaLQL, TenLQL, Khoa )
	VALUES  ( @MALQL,	@TENLQL	,	@KHOA	
	         )
END
GO
-- Nhan Vien 
--procedure spgetNhanVien
CREATE procedure spgetNhanVien (@MANV char(10))
as
begin
	select * from dbo.NhanVien WHERE MaNV= @MANV
end
GO

-- 
spgetNhanVien 'NV001'
go
--spUpdateNhanVien 
CREATE PROCEDURE spUpdateNhanVien
(
	@MANV	char(10),
	@TENNV	nvarchar(50),
	@SDT	char(15),
	@CHUCVU	nvarchar(20),
	@MATKHAU	char(10)
)
AS
BEGIN 
	UPDATE dbo.NhanVien
SET
	MaNV= @MANV,
	TenNV= @TENNV,
	SDT=@SDT,
	ChucVu=@CHUCVU,
	MatKhau=@MATKHAU
	WHERE MaNV=@MANV
END	
GO 

--- spDeleteNhanVien
CREATE PROCEDURE spDeleteNhanVien (@MANV CHAR(10) )
AS
BEGIN 
	DELETE FROM dbo.NhanVien
	WHERE MaNV= @MANV
END
GO
--spgetTableNhanVien

CREATE PROCEDURE spgetTableNhanVien
AS
BEGIN 
	SELECT * FROM dbo.NhanVien
END
GO 

--InsertNhanVien
CREATE PROCEDURE spInsertNhanVien
(
	@MANV	char(10),
	@TENNV	nvarchar(50),
	@SDT	char(15),
	@CHUCVU	nvarchar(20),
	@MATKHAU	char(10)
)
AS 
BEGIN 
	INSERT INTO dbo.NhanVien
	        ( MaNV, TenNV, SDT, ChucVu, MatKhau )
	VALUES  ( 
	          @MANV	, @TENNV	,@SDT	,@CHUCVU , @MATKHAU	
	         )
END
GO