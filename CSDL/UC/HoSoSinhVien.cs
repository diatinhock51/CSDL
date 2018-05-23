using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL.UC
{
    public partial class HoSoSinhVien : UserControl
    {
        Models.SinhVien sv;
        string MaSV;
        public HoSoSinhVien()
        {
            InitializeComponent();
            getHoSoSinhVien("SV0001");
            getDoiTuong("SV0001");
            getLQL("SV0001");
        }
        void getHoSoSinhVien(string MaSV)
        {
            sv = Models.SinhVien.getSinhVien(MaSV);
            txtTenSVHoSo.Text = sv.Ten;
            txtMaSVHoSo.Text = sv.MaSV;
            txtNgaySinhHoSo.Text = sv.NgaySinh;
            txtGioiTinhHoSo.Text = sv.GioiTinh;
            txtDiaChiHoSo.Text = sv.DiaChi;
            txtEmailHoSo.Text = sv.Email;
            txtKhoaHocSV.Text = sv.KhoaHoc;
        }
        void getDoiTuong( string MaSV)
        {
            sv = Models.SinhVien.getSinhVien(MaSV);
            Models.DoiTuongMienGiam dt = Models.DoiTuongMienGiam.getDoiTuongMienGiam(sv.MaDT);
            txtDoiTuongHoSo.Text = dt.LoaiDT;
        }
        void getLQL(string MaSV)
        {
            sv = Models.SinhVien.getSinhVien(MaSV);
            Models.LopQuanLy lql = Models.LopQuanLy.getLopQuanLy(sv.MaLQL);
            txtLopHoSo.Text = lql.TenLQL;
            txtKhoaHoSo.Text = lql.Khoa;
        }
    }
}
