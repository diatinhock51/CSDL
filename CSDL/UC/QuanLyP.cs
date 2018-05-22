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
        public QuanLy(string a)
        {
            InitializeComponent();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            //dgvLHP.CellClick += DgvLHP_CellClick;
        }

        //private void DgvLHP_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        //    {
        //        txtMaLHP.Text = Convert.ToString(DgvLHP.CurrentRow.Cells["MaHP"].Value);
        //        txtTenLHP.Text = Convert.ToString(dgvPhongBan.CurrentRow.Cells["TenPB"].Value);
        //        txtMaTP.Text = Convert.ToString(dgvPhongBan.CurrentRow.Cells["MaTP"].Value);
        //        txtNgayNC.Text = Convert.ToString(dgvPhongBan.CurrentRow.Cells["NgayNhanChuc"].Value);
        //    }
        //}

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

        }

       
    }
}
