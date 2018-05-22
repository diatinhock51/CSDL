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
            dgvLHP.CellClick += DgvLHP_CellClick;
            txtLoaiHocKyLHP.Click += TxtSoTinChi_Click;
        }

        private void TxtSoTinChi_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("aaa");
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

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            myLHP = new Models.LopHocPhan(txtMaHP.Text, txtTenHP.Text, int.Parse(txtSoTinChi.Text),
                    int.Parse(txtSoTiet.Text), txtTenGV.Text, txtLoaiHocKyLHP.Text);
            myLHP.DeleteLopHocPhan();
            LoadDataLHP();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            myLHP = new Models.LopHocPhan(txtMaHP.Text, txtTenHP.Text, int.Parse(txtSoTinChi.Text),
                   int.Parse(txtSoTiet.Text), txtTenGV.Text, txtLoaiHocKyLHP.Text);
            myLHP.UpdateLopHocPhan();
            LoadDataLHP();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            myLHP = new Models.LopHocPhan(txtMaHP.Text, txtTenHP.Text, int.Parse(txtSoTinChi.Text),
                    int.Parse(txtSoTiet.Text), txtTenGV.Text, txtLoaiHocKyLHP.Text);
            myLHP.InsertLopHocPhan();
            LoadDataLHP();
            
        }

       
    }
}
