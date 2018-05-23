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
