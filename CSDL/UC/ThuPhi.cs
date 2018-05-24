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
    public partial class ThuPhi : UserControl
    {
        public ThuPhi()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            TextBox maSV = sender as TextBox;
            try
            {
                Models.SinhVien sv = Models.SinhVien.getSinhVien(maSV.Text);
                //MessageBox.Show(sv.DiaChi);
                txtMaSVView.Text = maSV.Text;
                txtTenSVView.Text = sv.Ten;
                // Lấy ra tên lớp quản lý
                Models.LopQuanLy lopQuanLy = Models.LopQuanLy.getLopQuanLy(sv.MaLQL);
                txtLopView.Text = lopQuanLy.TenLQL;
                txtDiaChiView.Text = sv.DiaChi;
                txtEmailView.Text = sv.Email;
                txtKhoaHoc.Text = sv.KhoaHoc;
                cbHocKy.Enabled = true;
                cbNamHoc.Enabled = true;
                cbTenHD.Enabled = true;
                loadCbbNamHoc(sv);
            }
            catch (Exception)
            {
                cbHocKy.Enabled = false;
                cbNamHoc.Enabled = false;
                cbTenHD.Enabled = false;
                txtMaSVView.Text = "";
                txtTenSVView.Text = "";
                // Lấy ra tên lớp quản lý
                //Models.LopQuanLy lopQuanLy = Models.LopQuanLy.getLopQuanLy(sv.MaLQL);
                txtLopView.Text = "";
                txtDiaChiView.Text = "";
                txtEmailView.Text = "";
                txtKhoaHoc.Text = "";
            }


        }
        int[] GetNamHoc(Models.SinhVien sv)
        {
            var tmp = sv.KhoaHoc.Split('-');
            int count = int.Parse(tmp[tmp.Length - 1]) - int.Parse(tmp[0]) + 1;
            var result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = int.Parse(tmp[0]) + i;
            }
            return result;
        }
        void loadCbbNamHoc(Models.SinhVien sv)
        {
            var item = GetNamHoc(sv);
            for (int i = 0; i < item.Length - 1; i++)
            {
                cbNamHoc.Items.Add(item[i] + "-" + item[i + 1]);
            }
        }
        private void ThuPhi_Load(object sender, EventArgs e)
        {
            string maNV = "NV001";
            Models.NhanVien nv = Models.NhanVien.getNhanVien(maNV);
            txtMaNVView.Text = maNV;
            txtTenNVView.Text = nv.TenNV;
            txtSDTNVView.Text = nv.SoDT;
            sinhMaHDTuDong();

        }
        void loadData(string mASV,string namHoc,string hocKy)
        {
            dgvMonHoc.DataSource = Models.DangKy.getMonHocDangKy(mASV, namHoc, hocKy);
            int sumM = 0;
            for (int i = 0; i < dgvMonHoc.Rows.Count-1; i++)
            {
                sumM += int.Parse(dgvMonHoc.Rows[i].Cells[5].FormattedValue.ToString());
            }
            txtSoTien.Text = sumM.ToString();
        }
        void sinhMaHDTuDong()
        {
            DataTable hd = Models.HoaDon.getTableHoaDon();
            List<string> maHD = new List<string>();
            for (int i = 0; i < hd.Rows.Count; i++)
            {
                maHD.Add(hd.Rows[i][0]+"");
            }
            List<int> ma = new List<int>();
            for (int i = 0; i < maHD.Count; i++)
            {
                maHD[i] = maHD[i].Replace("HD", "");
                ma.Add(int.Parse(maHD[i]));
            }
            int max = 0;
            foreach (var item in ma)
            {
                if (max < item)
                {
                    max = item;
                }
            }
            txtMaHD.Text = "HD" + (max + 1).ToString("0000");
        }

        private void cbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadData(txtMaSV.Text,cbNamHoc.Text,cbHocKy.Text);

        }
            catch (Exception)
            {
                
                MessageBox.Show("Chưa chọn năm học hoặc học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            txtMaHDView.Text = txtMaHD.Text;
            txtTenHDView.Text = cbTenHD.Text;
            txtSoTienView.Text = txtSoTien.Text;
            DateTime today= DateTime.Today;
            var date = today.ToString("dd/MM/yyyy");
            txtNgayThuView.Text = date.ToString().Replace('/','-');

            txtHocKyView.Text = cbHocKy.Text;
            txtNamHocView.Text = cbNamHoc.Text;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var day = txtNgayThuView.Text.Split('-');
            string date = day[day.Length - 1] + "-" + day[1] + "-" + day[0];
            MessageBox.Show(date);
            Models.HoaDon hoaDon = new Models.HoaDon(txtMaHDView.Text, txtTenHDView.Text, 
                date, int.Parse(txtSoTienView.Text), txtMaSVView.Text, txtMaNVView.Text);
            hoaDon.InsertHoaDon();
            Models.DangKy dangKy;
            for (int i = 0; i < dgvMonHoc.Rows.Count; i++)
            {
                dangKy = new Models.DangKy(txtMaSV.Text,dgvMonHoc.Rows[i].Cells[1].FormattedValue.ToString(), 
                    dgvMonHoc.Rows[i].Cells[3].FormattedValue.ToString(), dgvMonHoc.Rows[i].Cells[4].FormattedValue.ToString(),
                    dgvMonHoc.Rows[i].Cells[5].FormattedValue.ToString(),
                    dgvMonHoc.Rows[i].Cells[6].FormattedValue.ToString());
                dangKy.UpdateDangKy();
            }
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
