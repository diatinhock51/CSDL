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
        string MK;
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
            this.MK = sv.MatKhau;
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2(sv);
            fr2.Show();
        }
    }
}
