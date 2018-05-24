use CSDL
go
create procedure spgetTenLHP (@LOAIHK char(10))
as
begin
	select TenHP from LopHocPhan where LoaiHK = @LOAIHK;
end
GO
create procedure spgetTenGV 
(
@LOAIHK char(10),
@TENHP nvarchar(50)
)
as
begin
	select TenGV from LopHocPhan where LoaiHK = @LOAIHK AND TenHP=@TENHP;
end
GO
select * from LopHocPhan where LoaiHK = 'HK1'  AND SoTinChi='3'
go
create PROC [dbo].[spgetLopHocPhanWithOutKey]
(
@tenHP nvarchar(50),
@tenGV nvarchar(50),
@loaiHK char(10)
)
AS 
BEGIN
	SELECT *FROM dbo.LopHocPhan 
	WHERE 
	TenHP=@tenHP
	AND TenGV=@tenGV
	AND LoaiHK=@loaiHK
END
go
create PROCEDURE [dbo].[spInsertDangKy] 
(
	@MASV nvarchar(10),
	@MAHP	nvarchar(10),
	@HOCKY	nvarchar(10),
	@NAMHOC varchar(10),
	@SOTIEN	bigint,
	@TRANGTHAINNOP	nvarchar(15)
)
AS 
BEGIN 
	INSERT INTO dbo.DangKy
	(	
	MaSV ,
	MaHP ,
	NamHoc ,
	SoTien ,
	LoaiHK ,
	TrangThaiNop 
	)
	VALUES  
	(
	@MASV, 
	@MAHP, 
	@NAMHOC,
	@SOTIEN,
	@HOCKY,
	@TRANGTHAINNOP
	)
END
go
create procedure spgetDangKymaSV (@MASV varchar(10))
as
begin
	Select LHP.MaHP,TenHP,SoTinChi,SoTiet,TenGV,LHP.LoaiHK, TrangThaiNop 
	from 
	DangKy as DK,
	LopHocPhan as LHP
	where 
	DK.MaHP=LHP.MaHP and DK.LoaiHK=LHP.LoaiHK and MaSV=@MASV
end
GO

