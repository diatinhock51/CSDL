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
    public partial class QuanLy : UserControl
    {
        Models.SinhVien mySV;
        int flag = 0;
        public QuanLy()
        {
            InitializeComponent();
            Phuong();
            HienThiDanhSachSV();
        }
        #region Method
        public void HienThiDanhSachSV()
        {
            var dataTable = Models.SinhVien.getTableSinhVien();
            dgvSV.ReadOnly = true;
            dgvSV.DataSource = dataTable;
        }
        public void Binding()
        {
            txtMaSV.DataBindings.Clear();
            txtMaSV.DataBindings.Add("Text", dgvSV.DataSource, "MaSV", true);
            txtHoTenSV.DataBindings.Clear();
            txtHoTenSV.DataBindings.Add("Text", dgvSV.DataSource, "HoTenSV", true);
            txtNgaySinh.DataBindings.Clear();
            txtNgaySinh.DataBindings.Add("Text", dgvSV.DataSource, "NgaySinh", true);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvSV.DataSource, "DiaChi", true);
            cbxGioiTinh.DataBindings.Add("Text", dgvSV.DataSource, "GioiTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvSV.DataSource, "Email", true);
            cbxKhoaHoc.DataBindings.Add("Text", dgvSV.DataSource, "KhoaHoc", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", dgvSV.DataSource, "MatKhau", true);
            cbxMaLQL.DataBindings.Add("Text", dgvSV.DataSource, "MaLQL", true, DataSourceUpdateMode.OnPropertyChanged);
            cbxMaDT.DataBindings.Add("Text", dgvSV.DataSource, "MaDT", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void Dis_End(bool e)
        {
            tlpSinhVien.Enabled = e;
            btnSVThem.Enabled = !e;
            btnSVXoa.Enabled = !e;
            btnSVSua.Enabled = !e;
            btnSVLuu.Enabled = !e;
        }
        private void clearData()
        {
            txtMaSV.Text = "";
            txtHoTenSV.Text = "";
            txtNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtMatKhau.Text = "";
            cbxGioiTinh.Text = "-Chọn giới tính-";
            cbxKhoaHoc.Text = "-Chọn khóa học-";
            cbxMaLQL.Text = "-Chọn Mã LQL-";
            cbxMaDT.Text = "-Chọn Mã ĐT-";
        }

        #endregion
        #region Events
        void setKhoaHoc()
        {
            string[] itemsKH = GetKhoaHoc();
            for (int i = 0; i < itemsKH.Length; i++)
            {
                if (!cbxKhoaHoc.Items.Contains(itemsKH[i]))
                {
                    cbxKhoaHoc.Items.Add(itemsKH[i]);
                }

            }
        }
        void setGioiTinh()
        {
            string[] itemsGT = GetGioiTinh();
            for (int i = 0; i < itemsGT.Length; i++)
            {
                if (!cbxGioiTinh.Items.Contains(itemsGT[i]))
                {
                    cbxGioiTinh.Items.Add(itemsGT[i]);
                }

            }
        }
        void setMaLQL()
        {
            string[] itemsLQL = GetMaLQL();
            for (int i = 0; i < itemsLQL.Length; i++)
            {
                if (!cbxMaLQL.Items.Contains(itemsLQL[i]))
                {
                    cbxMaLQL.Items.Add(itemsLQL[i]);
                }

            }
        }
        void setMaDT()
        {
            string[] itemsDT = GetMaDT();
            for (int i = 0; i < itemsDT.Length; i++)
            {
                if (!cbxMaDT.Items.Contains(itemsDT[i]))
                {
                    cbxMaDT.Items.Add(itemsDT[i]);
                }

            }
        }
        private void btnSVThem_Click(object sender, EventArgs e)
        {
            setGioiTinh();
            setKhoaHoc();
            setMaLQL();
            setMaDT();
            flag = 0;
            clearData();
            Dis_End(true);
        }
        private void btnSVSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            tlpSinhVien.Enabled = true;
            setGioiTinh();
            setKhoaHoc();
            setMaLQL();
            setMaDT();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            txtMaSV.Enabled = false;
            HienThiDanhSachSV();
            Binding();
            Dis_End(false);
        }

        private void btnSVXoa_Click(object sender, EventArgs e)
        {
            string _MaSV = "";
            try
            {
                _MaSV = txtMaSV.Text;
                MessageBox.Show(_MaSV);
            }
            catch { }
            DialogResult dr = MessageBox.Show(" Bạn có chắc chắn xóa ?", "Xác nhận ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                mySV = new Models.SinhVien(txtMaSV.Text, txtHoTenSV.Text, txtNgaySinh.Text, txtDiaChi.Text
                    , cbxGioiTinh.Text, txtEmail.Text, cbxKhoaHoc.Text,
                    txtMatKhau.Text, cbxMaLQL.Text, cbxMaDT.Text);
                var i = mySV.DeleteSinhVien();
                if (i > 0)
                {
                    MessageBox.Show("Xóa Thành Công !");
                    
                }
                else
                    MessageBox.Show("Xóa Không thành công");
            }
            HienThiDanhSachSV();
        }


        private void btnSVLuu_Click(object sender, EventArgs e)
        {
            string _MaSV = txtMaSV.Text;
            string _HoTenSV = "";
            try
            {
                _HoTenSV = txtHoTenSV.Text;
            }
            catch { }

            string _NgaySinh = "";
            try
            {
                _NgaySinh = txtNgaySinh.Text;
            }
            catch { }
            string _DiaChi = "";
            try
            {
                _DiaChi = txtDiaChi.Text;
            }
            catch { }
            string _GioiTinh = "";
            try
            {
                _GioiTinh = cbxGioiTinh.Text;
            }
            catch { }
            string _Email = "";
            try
            {
                _Email = txtEmail.Text;
            }
            catch { }
            string _KhoaHoc = "";
            try
            {
                _KhoaHoc = cbxKhoaHoc.Text;
            }
            catch { }
            string _MatKhau = "";
            try
            {
                _MatKhau = txtMatKhau.Text;
            }
            catch { }
            string _MaLQL = "";
            try
            {
                _MaLQL = cbxMaLQL.Text;
            }
            catch { }
            string _MaDT = "";
            try
            {
                _MaDT = cbxMaDT.Text;
            }
            catch { }
            if (flag == 0)
            {
                mySV = new Models.SinhVien(txtMaSV.Text, txtHoTenSV.Text, txtNgaySinh.Text, txtDiaChi.Text
                    , cbxGioiTinh.Text, txtEmail.Text, cbxKhoaHoc.Text,
                    txtMatKhau.Text, cbxMaLQL.Text, cbxMaDT.Text);
                var i = mySV.InsertSinhVien();
                if (i == 0)
                {
                    MessageBox.Show("Thêm mới thất bại !");
                }
                else
                {
                    MessageBox.Show("Thêm mới thành công !");
                    HienThiDanhSachSV();
                    Dis_End(false);
                }
            }
            else
            {
                mySV = new Models.SinhVien(txtMaSV.Text, txtHoTenSV.Text, txtNgaySinh.Text, txtDiaChi.Text
                    , cbxGioiTinh.Text, txtEmail.Text, cbxKhoaHoc.Text,
                    txtMatKhau.Text, cbxMaLQL.Text, cbxMaDT.Text);
                var i = mySV.InsertSinhVien();
                if (i == 0)
                {
                    MessageBox.Show("Sửa thất bại !");
                }
                else
                {
                    MessageBox.Show("Sửa thành công !");
                    Dis_End(false);
                }
            }
        }
        #endregion
        string[] GetKhoaHoc()
        {
            string[] resultKH = new string[dgvSV.Rows.Count-1];
            for (int i = 0; i < dgvSV.Rows.Count-1 ; i++)
            {
                
                resultKH[i]= dgvSV.Rows[i].Cells["KhoaHoc"].Value.ToString();
            }
           
            return resultKH;
        }
        string[] GetMaLQL()
        {
            string[] resultMaLQL = new string[dgvSV.Rows.Count - 1];
            for (int i = 0; i < dgvSV.Rows.Count - 1; i++)
            {

                resultMaLQL[i] = dgvSV.Rows[i].Cells["MaLQL"].Value.ToString();
            }

            return resultMaLQL;
        }
        string[] GetMaDT()
        {
            string[] resultMaDT = new string[dgvSV.Rows.Count - 1];
            for (int i = 0; i < dgvSV.Rows.Count - 1; i++)
            {

                resultMaDT[i] = dgvSV.Rows[i].Cells["MaDT"].Value.ToString();
            }

            return resultMaDT;
        }
        string[] GetGioiTinh()
        {
            string[] resultGT = new string[dgvSV.Rows.Count - 1];
            for (int i = 0; i < dgvSV.Rows.Count - 1; i++)
            {
                resultGT[i] = dgvSV.Rows[i].Cells["GioiTinh"].Value.ToString();
            }
            return resultGT;
        }

       
    }
}
