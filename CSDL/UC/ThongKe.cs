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
    public partial class ThongKe : UserControl
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void btnTaiLai1_Click(object sender, EventArgs e)
        { 
            string ngayTruoc=convertToDateSQL(dtpTruoc.Value.ToString("dd/MM/yyy"));
            string ngaySau = convertToDateSQL(dtpSau.Value.ToString("dd/MM/yyy"));
           dgvNopPhi.DataSource= Models.HoaDon.getSinhVienNopPhi(ngayTruoc, ngaySau);

        }


        string convertToDateSQL(string dateC)
        {
            string result;
            string date = dateC.Split(' ')[0];
            var X = date.Split('/');
            result = X[2] + "-" + X[1] + "-" + X[0];
            return result;
        }

        private void btnTaiLaiDay_Click(object sender, EventArgs e)
        {
            string date = convertToDateSQL(dtpToday.Value.ToString("dd/MM/yyy"));
            dgvNopPhiToday.DataSource = Models.HoaDon.getSinhVienNopPhiNgay(date);

        }

        private void cbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbHocKy.Text == "HK1" || cbHocKy.Text == "HK2" || cbHocKy.Text == "HKP")
            {
                string hocKy = cbHocKy.Text;
                string namHoc = cbNamHoc.Text;
                dgvNoPhi.DataSource = Models.DangKy.getSinhVienChuaNopPhi(namHoc, hocKy);

            }
            else
            {
                MessageBox.Show(cbHocKy.Text);
                MessageBox.Show("Chưa chọn học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
