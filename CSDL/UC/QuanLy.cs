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
            setMaLQL();
            setKhoaHoc();
        }/// <summary>
        /// //
        /// </summary>
        #region Method
        public void HienThiDanhSachSV()
        {
            var dataTable = Models.SinhVien.getTableSinhVien();
            dgvSV.ReadOnly = true;
            dgvSV.DataSource = dataTable;
            Binding();
            //MessageBox.Show(dgvSV.Rows.Count + "");
        }/// <summary>
        /// /
        /// </summary>
        public void Binding()
        {
            txtMaSV.DataBindings.Clear();
            txtMaSV.DataBindings.Add("Text", dgvSV.DataSource, "MaSV", true);
            txtHoTenSV.DataBindings.Clear();
            txtHoTenSV.DataBindings.Add("Text", dgvSV.DataSource, "HoTenSV", true);
            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Text", dgvSV.DataSource, "NgaySinh", true);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvSV.DataSource, "DiaChi", true);
            cbxGioiTinh.DataBindings.Clear();
            cbxGioiTinh.DataBindings.Add("Text", dgvSV.DataSource, "GioiTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvSV.DataSource, "Email", true);
            cbxKhoaHoc.DataBindings.Clear();
            cbxKhoaHoc.DataBindings.Add("Text", dgvSV.DataSource, "KhoaHoc", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", dgvSV.DataSource, "MatKhau", true);
            cbxMaLQL.DataBindings.Clear();
            cbxMaLQL.DataBindings.Add("Text", dgvSV.DataSource, "MaLQL", true, DataSourceUpdateMode.OnPropertyChanged);
            cbxMaDT.DataBindings.Clear();
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
            dtpNgaySinh.Refresh();
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtMatKhau.Text = "";
            cbxGioiTinh.Text = "-Chọn giới tính-";
            cbxKhoaHoc.Text = "-Chọn khóa học-";
            cbxMaLQL.Text = "-Chọn Mã LQL-";
            cbxMaDT.Text = "-Chọn Mã ĐT-";
        }
        void btnReload()
        {
            btnSVSua.Visible = btnSVXoa.Visible =
                btnSVThem.Visible = !btnSVSua.Visible;
            btnSVHuy.Visible = btnSVLuu.Visible = !btnSVLuu.Visible;
        }
        #endregion
        #region Events
        void setKhoaHoc()
        {
            cbNamHocSV.Items.Clear();
            cbxKhoaHoc.Items.Clear();
            string[] itemsKH = GetKhoaHoc();
            for (int i = 0; i < itemsKH.Length; i++)
            {
                if (!cbxKhoaHoc.Items.Contains(itemsKH[i]))
                {
                    cbNamHocSV.Items.Add(itemsKH[i]);
                    cbxKhoaHoc.Items.Add(itemsKH[i]);
                }

            }
        }
        void setGioiTinh()
        {
            cbxGioiTinh.Items.Clear();
            string[] itemsGT = GetGioiTinh();
            for (int i = 0; i < itemsGT.Length; i++)
            {
                if (!cbxGioiTinh.Items.Contains(itemsGT[i]))
                {
                    //cbxGioiTinh.Items.Clear();
                    cbxGioiTinh.Items.Add(itemsGT[i]);
                }

            }
        }
        void setMaLQL()
        {
            cbxMaLQL.Items.Clear();
            cbLopSV.Items.Clear();
            string[] itemsLQL = GetMaLQL();
            for (int i = 0; i < itemsLQL.Length; i++)
            {
                if (!cbxMaLQL.Items.Contains(itemsLQL[i]))
                {
                    cbLopSV.Items.Add(itemsLQL[i]);
                    cbxMaLQL.Items.Add(itemsLQL[i]);
                }

            }
        }
        void setMaDT()
        {
            cbxMaDT.Items.Clear();
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
            tlpSinhVien.Enabled = true;
            txtMaSV.Text = "SV" + dgvSV.Rows.Count.ToString("0000");
            btnSVLuu.Tag = "Them";
            btnSVHuy.Tag = "Them";
            btnReload();
        }
        private void btnSVSua_Click(object sender, EventArgs e)
        {
            btnReload();
            flag = 1;
            tlpSinhVien.Enabled = true;
            setGioiTinh();
            setKhoaHoc();
            setMaLQL();
            setMaDT();
            btnSVLuu.Tag = "Sua";
            btnSVHuy.Tag = "Sua";
        }
        string convertToDateSQL(string dateC)
        {
            string result;
            string date = dateC.Split(' ')[0];
            var X = date.Split('/');
            result = X[2] + "-" + X[1] + "-" + X[0];
            return result;
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
                string ngaySinh = convertToDateSQL(dtpNgaySinh.Value.ToString("dd/MM/yyy"));
                mySV = new Models.SinhVien(txtMaSV.Text, txtHoTenSV.Text, ngaySinh, txtDiaChi.Text
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

            //string _NgaySinh = "";
            string _NgaySinh = convertToDateSQL(dtpNgaySinh.Value.ToString("dd/MM/yyy"));

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
            if (btnSVLuu.Tag.ToString() == "Them")
            {
                string ngaySinh = convertToDateSQL(dtpNgaySinh.Value.ToString("dd/MM/yyy"));
                mySV = new Models.SinhVien(txtMaSV.Text, txtHoTenSV.Text, ngaySinh, txtDiaChi.Text
                    , cbxGioiTinh.Text, txtEmail.Text, cbxKhoaHoc.Text,
                    txtMatKhau.Text, cbxMaLQL.Text, cbxMaDT.Text);
                //HienThiDanhSachSV();
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
            if (btnSVLuu.Tag.ToString() == "Sua")
            {
                string ngaySinh = convertToDateSQL(dtpNgaySinh.Value.ToString("dd/MM/yyy"));
                mySV = new Models.SinhVien(txtMaSV.Text, txtHoTenSV.Text, ngaySinh, txtDiaChi.Text
                    , cbxGioiTinh.Text, txtEmail.Text, cbxKhoaHoc.Text,
                    txtMatKhau.Text, cbxMaLQL.Text, cbxMaDT.Text);
                var i = mySV.UpdateSinhVien();
                if (i == 0)
                {
                    MessageBox.Show("Sửa thất bại !");
                }
                else
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachSV();
                    Dis_End(false);
                }
            }
        }
        private void tabPage3_Enter(object sender, EventArgs e)
        {
            txtMaSV.Enabled = false;
            HienThiDanhSachSV();            
            Dis_End(false);
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

        private void cbLopSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            dgvSV.DataSource = Models.SinhVien.Filter_MaLQL(cbb.Text);
        }

        private void cbNamHocSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbLopSV.Text);
            if (cbLopSV.Text == "-Chọn lớp-")
            {
                
                ComboBox cbb = sender as ComboBox;
                dgvSV.DataSource = Models.SinhVien.Filter_KhoaHoc(cbb.Text);
            }
            else
            {
                ComboBox cbb = sender as ComboBox;
                dgvSV.DataSource = Models.SinhVien.Filter_Both(cbLopSV.Text,cbb.Text);
            }
            
        }

        private void btnSVHuy_Click(object sender, EventArgs e)
        {
            var au = btnSVHuy.Tag.ToString();
            if (btnSVHuy.Tag.ToString() == "Them")
            {
                //MessageBox.Show("Huy Them");
                txtMaSV.Text = txtHoTenSV.Text = txtDiaChi.Text =
                txtEmail.Text = txtMatKhau.Text = "";
                dtpNgaySinh.Refresh();
                cbxGioiTinh.Text = "-Chọn giới tính-";
                cbxKhoaHoc.Text = "-Chọn khóa học-";
                cbxMaLQL.Text = "-Chọn mã LQL-";
                cbxMaDT.Text = "-Chọn mã ĐT-";
            }
            if (btnSVHuy.Tag.ToString() == "Sua")
            {
                //MessageBox.Show("Huy sua");
                txtMaSV.Text = mySV.MaSV;
                txtHoTenSV.Text = mySV.Ten;
                txtDiaChi.Text = mySV.DiaChi;
                txtEmail.Text = mySV.Email;
                txtMatKhau.Text = mySV.MatKhau;
                dtpNgaySinh.Text = mySV.NgaySinh;
                cbxGioiTinh.Text = mySV.GioiTinh;
                cbxKhoaHoc.Text = mySV.KhoaHoc;
                cbxMaLQL.Text = mySV.MaLQL;
                cbxMaDT.Text = mySV.MaDT;
            }
            btnReload();
        }
    }
}
