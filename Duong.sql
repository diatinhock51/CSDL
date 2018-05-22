use CSDL
go
create procedure spgetTenLHP (@LOAIHK char(10))
as
begin
	select * from LopHocPhan where LoaiHK = @LOAIHK;
end
GO