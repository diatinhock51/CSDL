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
    partial class QuanLy 
    {
        Models.LopHocPhan myLHP;
        Models.LopQuanLy myLQL;
        Models.DoiTuongMienGiam myDT;
        void Phuong()
        {
            /*Lop Hoc Phan*/
            var dataTable = Models.LopHocPhan.getTableLopHocPhan();
            dgvLHP.ReadOnly = true;
            dgvLHP.DataSource = dataTable;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
            dgvLHP.CellClick += DgvLHP_CellClick;
            tabPage1.Enter += TabPage1_Enter;

            /*Lop Quan Ly*/
            var dataTB = Models.LopQuanLy.getTableLopQuanLy();
            dgvLQL.ReadOnly = true;
            dgvLQL.DataSource = dataTB;
            btnThemLQL.Click += BtnThemLQL_Click;
            btnSuaLQL.Click += BtnSuaLQL_Click;
            btnXoaLQL.Click += BtnXoaLQL_Click;
            btnLuuLQL.Click += BtnLuuLQL_Click;
            btnHuyLQL.Click += BtnHuyLQL_Click;
            dgvLQL.CellClick += DgvLQL_CellClick;

            /*Doi Tuong Mien Giam*/
            var dataTableDT = Models.DoiTuongMienGiam.getTableDoiTuongMienGiam();
            dgvDTMG.ReadOnly = true;
            dgvDTMG.DataSource = dataTableDT;
            btnThemDTMG.Click += BtnThemDTMG_Click;
            btnSuaDTMG.Click += BtnSuaDTMG_Click;
            btnXoaDTMG.Click += BtnXoaDTMG_Click;
            btnLuuDTMG.Click += BtnLuuDTMG_Click;
            btnHuyDTMG.Click += BtnHuyDTMG_Click;
            dgvDTMG.CellClick += DgvDTMG_CellClick;
        }
/*He so mien giam*/
        private void DgvDTMG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaDT.Text = Convert.ToString(dgvDTMG.CurrentRow.Cells["CMaDT"].Value);
                txtTenDT.Text = Convert.ToString(dgvDTMG.CurrentRow.Cells["CLoaiDoiTuong"].Value);
                txtHSMG.Text = Convert.ToString(dgvDTMG.CurrentRow.Cells["CHeSoMG"].Value);
            }
        }

        private void BtnHuyDTMG_Click(object sender, EventArgs e)
        {
        
            if (btnHuyDTMG.Tag.ToString() == "ThemDT")
            {
                txtMaDT.Text = txtTenDT.Text = txtHSMG.Text = "";
            }
            if (btnHuyDTMG.Tag.ToString() == "SuaDT")
            {
                txtMaDT.Text = myDT.MaDT;
                txtTenDT.Text = myDT.LoaiDT;
                txtHSMG.Text = myDT.HeSoMG.ToString();
            }
            txtMaLQL.ReadOnly = txtTenLQL.ReadOnly = txtKhoa.ReadOnly = true;
            ReLoadBtnDTMG();
        }

        private void BtnLuuDTMG_Click(object sender, EventArgs e)
        {
            if (btnLuuDTMG.Tag.ToString() == "ThemDT")
            {
                myDT = new Models.DoiTuongMienGiam(txtMaDT.Text, txtTenDT.Text, float.Parse(txtHSMG.Text));
                myDT.InsertDoiTuongMienGiam();
                LoadDataDT();
            }
            if (btnLuuDTMG.Tag.ToString() == "SuaDT")
            {
                myDT = new Models.DoiTuongMienGiam(txtMaDT.Text, txtTenDT.Text, float.Parse(txtHSMG.Text));
                myDT.UpdateDoiTuongMienGiam();
                LoadDataDT();
            }
            txtMaDT.ReadOnly = txtTenDT.ReadOnly = txtHSMG.ReadOnly = true;
            ReLoadBtnDTMG();
        }

        public void LoadDataDT()
        {
            dgvDTMG.DataSource = Models.DoiTuongMienGiam.getTableDoiTuongMienGiam();
            dgvDTMG.Refresh();
        }
        private void BtnXoaDTMG_Click(object sender, EventArgs e)
        {
            myDT = new Models.DoiTuongMienGiam(txtMaDT.Text, txtTenDT.Text, float.Parse(txtHSMG.Text));
            myDT.DeleteDoiTuongMienGiam();
            LoadDataDT();
        }

        private void BtnSuaDTMG_Click(object sender, EventArgs e)
        {
            ReLoadBtnDTMG();
            myDT = new Models.DoiTuongMienGiam(txtMaDT.Text,txtTenDT.Text,float.Parse(txtHSMG.Text));
            txtMaDT.ReadOnly = txtTenDT.ReadOnly = txtHSMG.ReadOnly = false;
            btnLuuDTMG.Tag = "SuaDT";
            btnHuyDTMG.Tag = "SuaDT";
        }

        private void BtnThemDTMG_Click(object sender, EventArgs e)
        {
            txtMaDT.Text=txtTenDT.Text=txtHSMG.Text = "";
            txtMaDT.ReadOnly = txtTenDT.ReadOnly = txtHSMG.ReadOnly = false;
            btnLuuDTMG.Tag = "ThemDT";
            btnHuyDTMG.Tag = "ThemDT";
            ReLoadBtnDTMG();
        }

        void ReLoadBtnDTMG()
        {
            btnSuaDTMG.Visible = btnXoaDTMG.Visible =
                btnThemDTMG.Visible = !btnSuaDTMG.Visible;
            btnHuyDTMG.Visible = btnLuuDTMG.Visible = !btnLuuDTMG.Visible;
        }

/*Lop quan ly*/
        public void LoadDataLQL()
        {
            dgvLQL.DataSource = Models.LopQuanLy.getTableLopQuanLy();
            dgvLQL.Refresh();
        }
        private void DgvLQL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaLQL.Text = Convert.ToString(dgvLQL.CurrentRow.Cells["CMaLQL"].Value);
                txtTenLQL.Text = Convert.ToString(dgvLQL.CurrentRow.Cells["CTenLQL"].Value);
                txtKhoa.Text = Convert.ToString(dgvLQL.CurrentRow.Cells["CKhoa"].Value);
            }
        }

        private void BtnHuyLQL_Click(object sender, EventArgs e)
        {
            var aut = btnHuyLQL.Tag.ToString();
            if (btnHuyLQL.Tag.ToString() == "ThemLQL")
            {
                txtMaLQL.Text = txtTenLQL.Text = txtKhoa.Text = "";
            }
            if (btnHuyLQL.Tag.ToString() == "SuaLQL")
            {
                txtMaLQL.Text = myLQL.MaLQL;
                txtTenLQL.Text = myLQL.TenLQL;
                txtKhoa.Text = myLQL.Khoa;
            }
            txtMaLQL.ReadOnly = txtTenLQL.ReadOnly = txtKhoa.ReadOnly = true;
            ReLoadBtnLQL();
        }

        private void BtnLuuLQL_Click(object sender, EventArgs e)
        {
            if (btnLuuLQL.Tag.ToString() == "ThemLQL")
            {
                myLQL = new Models.LopQuanLy(txtMaLQL.Text, txtTenLQL.Text, txtKhoa.Text);
                myLQL.InsertLopQuanLy();
                LoadDataLQL();
            }
            if (btnLuuLQL.Tag.ToString() == "SuaLQL")
            {
                myLQL = new Models.LopQuanLy(txtMaLQL.Text, txtTenLQL.Text, txtKhoa.Text);
                myLQL.UpdateLopQuanLy();
                LoadDataLQL();
            }
            txtMaLQL.ReadOnly = txtTenLQL.ReadOnly = txtKhoa.ReadOnly = true;
            ReLoadBtnLQL();
        }

        private void BtnXoaLQL_Click(object sender, EventArgs e)
        {
            myLQL = new Models.LopQuanLy(txtMaLQL.Text, txtTenLQL.Text, txtKhoa.Text);
            myLQL.DeleteLopQuanLy();
            LoadDataLQL();
        }

        private void BtnSuaLQL_Click(object sender, EventArgs e)
        {
            ReLoadBtnLQL();
            myLQL = new Models.LopQuanLy(txtMaLQL.Text,txtTenLQL.Text,txtKhoa.Text);
            txtMaLQL.ReadOnly = txtTenLQL.ReadOnly = txtKhoa.ReadOnly = false;
            btnLuuLQL.Tag = "SuaLQL";
            btnHuyLQL.Tag = "SuaLQL";
        }

        private void BtnThemLQL_Click(object sender, EventArgs e)
        {
            txtMaLQL.Text=txtTenLQL.Text=txtKhoa.Text= "";
            txtMaLQL.ReadOnly = txtTenLQL.ReadOnly = txtKhoa.ReadOnly = false;
            btnLuuLQL.Tag = "ThemLQL";
            btnHuyLQL.Tag = "ThemLQL";
            ReLoadBtnLQL();
        }
        void ReLoadBtnLQL()
        {
            btnSuaLQL.Visible = btnXoaLQL.Visible =
                btnThemLQL.Visible = !btnSuaLQL.Visible;
            btnHuyLQL.Visible = btnLuuLQL.Visible = !btnLuuLQL.Visible;
        }

/*Lop Hoc Phan*/
        private void TabPage1_Enter(object sender, EventArgs e)
        {
            
        }
        
        void ReLoadBtn()
        {
            btnSua.Visible = btnXoa.Visible =
                btnThem.Visible = !btnSua.Visible;
            btnHuy.Visible = btnLuu.Visible = !btnLuu.Visible;
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            txtMaHP.Text = txtTenHP.Text = txtSoTinChi.Text =
            txtSoTiet.Text = txtTenGV.Text = txtLoaiHocKyLHP.Text = "";
            txtMaHP.ReadOnly = txtTenHP.ReadOnly = txtSoTinChi.ReadOnly = txtSoTiet.ReadOnly
            = txtTenGV.ReadOnly = txtLoaiHocKyLHP.ReadOnly = false;
            btnLuu.Tag = "Them";
            btnHuy.Tag = "Them";
            ReLoadBtn();
        }
        private void BtnSua_Click(object sender, EventArgs e)
        {
            ReLoadBtn();
            myLHP = new Models.LopHocPhan(txtMaHP.Text, txtTenHP.Text, int.Parse(txtSoTinChi.Text),
                   int.Parse(txtSoTiet.Text), txtTenGV.Text, txtLoaiHocKyLHP.Text);
            txtMaHP.ReadOnly = txtTenHP.ReadOnly = txtSoTinChi.ReadOnly = txtSoTiet.ReadOnly
            = txtTenGV.ReadOnly = txtLoaiHocKyLHP.ReadOnly = false;
            btnLuu.Tag = "Sua";
            btnHuy.Tag = "Sua";
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            myLHP = new Models.LopHocPhan(txtMaHP.Text, txtTenHP.Text, int.Parse(txtSoTinChi.Text),
                    int.Parse(txtSoTiet.Text), txtTenGV.Text, txtLoaiHocKyLHP.Text);
            myLHP.DeleteLopHocPhan();
            LoadDataLHP();
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (btnLuu.Tag.ToString()=="Them")
            {
                myLHP = new Models.LopHocPhan(txtMaHP.Text, txtTenHP.Text, int.Parse(txtSoTinChi.Text),
                        int.Parse(txtSoTiet.Text), txtTenGV.Text, txtLoaiHocKyLHP.Text);
                myLHP.InsertLopHocPhan();
                LoadDataLHP();
            }
            if (btnLuu.Tag.ToString() == "Sua")
            {
                myLHP = new Models.LopHocPhan(txtMaHP.Text, txtTenHP.Text, int.Parse(txtSoTinChi.Text),
                  int.Parse(txtSoTiet.Text), txtTenGV.Text, txtLoaiHocKyLHP.Text);
                myLHP.UpdateLopHocPhan();
                LoadDataLHP();
            }
            txtMaHP.ReadOnly = txtTenHP.ReadOnly = txtSoTinChi.ReadOnly = txtSoTiet.ReadOnly
            = txtTenGV.ReadOnly = txtLoaiHocKyLHP.ReadOnly = true;
            ReLoadBtn();
        }       
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            var au = btnHuy.Tag.ToString();
            if (btnHuy.Tag.ToString() == "Them")
            {
                //MessageBox.Show("Huy Them");
                txtMaHP.Text = txtTenHP.Text = txtSoTinChi.Text =
                txtSoTiet.Text = txtTenGV.Text = txtLoaiHocKyLHP.Text = "";
            }
            if (btnHuy.Tag.ToString() == "Sua")
            {
                //MessageBox.Show("Huy sua");
                txtMaHP.Text = myLHP.MaHP;
                txtTenHP.Text = myLHP.TenHP;
                txtSoTinChi.Text = myLHP.SoTinChi.ToString();
                txtSoTiet.Text = myLHP.SoTiet.ToString();
                txtTenGV.Text = myLHP.HoTenGV;
                txtLoaiHocKyLHP.Text = myLHP.LoaiHK;
            }
            txtMaHP.ReadOnly = txtTenHP.ReadOnly = txtSoTinChi.ReadOnly = txtSoTiet.ReadOnly
            = txtTenGV.ReadOnly = txtLoaiHocKyLHP.ReadOnly = true;
            ReLoadBtn();
        }
        public void LoadDataLHP()
        {
            dgvLHP.DataSource = Models.LopHocPhan.getTableLopHocPhan();
            dgvLHP.Refresh();
        }

      
        private void DgvLHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaHP.Text = Convert.ToString(dgvLHP.CurrentRow.Cells["MaHP"].Value);
                txtTenHP.Text = Convert.ToString(dgvLHP.CurrentRow.Cells["TenHP"].Value);
                txtSoTinChi.Text = Convert.ToString(dgvLHP.CurrentRow.Cells["SoTinChi"].Value);
                txtSoTiet.Text = Convert.ToString(dgvLHP.CurrentRow.Cells["SoTiet"].Value);
                txtTenGV.Text = Convert.ToString(dgvLHP.CurrentRow.Cells["TenGV"].Value);
                txtLoaiHocKyLHP.Text = Convert.ToString(dgvLHP.CurrentRow.Cells["LoaiHK"].Value);
            }
        }




        
    }
}
