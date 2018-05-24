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
        void Phuong()
        {
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
        }
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
            CSDL.Controls.PdfCtrl.ExportToPdf((DataTable)dgvLHP.DataSource);
            //txtMaHP.Text = txtTenHP.Text = txtSoTinChi.Text =
            //txtSoTiet.Text = txtTenGV.Text = txtLoaiHocKyLHP.Text = "";
            //txtMaHP.ReadOnly = txtTenHP.ReadOnly = txtSoTinChi.ReadOnly = txtSoTiet.ReadOnly
            //= txtTenGV.ReadOnly = txtLoaiHocKyLHP.ReadOnly = false;
            //btnLuu.Tag = "Them";
            //btnHuy.Tag = "Them";
            //ReLoadBtn();
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
                txtSoTinChi.Text = myLHP.SoTinCHi.ToString();
                txtSoTiet.Text = myLHP.SoTiet.ToString();
                txtTenGV.Text = myLHP.HoTenGV;
                txtLoaiHocKyLHP.Text = myLHP.LoaiHK;
            }
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
