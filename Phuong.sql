/*Thủ tục thêm Lớp Học Phần */
CREATE PROC spInsertLopHocPhan(@maHP char(10),@tenHP nvarchar(50), @sotinchi INT, @sotiet INT, 
                               @tenGV nvarchar(50), @loaiHK char(10))
AS BEGIN
   	INSERT INTO dbo.LopHocPhan
   	        (MaHP,TenHP,SoTinChi,SoTiet,TenGV,LoaiHK)
   	VALUES  (@maHP,@tenHP,@sotinchi,@sotiet,@tenGV,@loaiHK)
   END

/*Thủ tục sửa Lớp Học Phần theo mãHP*/
go
CREATE PROC spUpdateLopHocPhan(@maHP char(10),@tenHP nvarchar(50), @sotinchi INT, @sotiet INT, 
                               @tenGV nvarchar(50), @loaiHK char(10))
AS 
BEGIN
	UPDATE dbo.LopHocPhan 
	SET TenHP=@tenHP,SoTinChi=@sotinchi,SoTiet=@sotiet,
	    TenGV=@tenGV,LoaiHK=@loaiHK 
	WHERE MaHP=@maHP
END

/*Thủ tục xoá Lớp Học Phần theo mãHP*/
GO
CREATE PROC spDeleteLopHocPhan(@maHP char(10))
AS
BEGIN
	DELETE FROM dbo.LopHocPhan WHERE MaHP=@maHP
END

/*Thủ tục lấy ra danh sách Lớp Học Phần theo mãHP*/
GO
CREATE PROC spgetLopHocPhan(@maHP char(10))
AS 
BEGIN
	SELECT *FROM dbo.LopHocPhan WHERE MaHP=@maHP
END

/*Thủ tục lấy ra tất cả danh sách Lớp Học Phần */
GO
CREATE PROC spgetTableLopHocPhan
AS
BEGIN
	SELECT *FROM dbo.LopHocPhan
END