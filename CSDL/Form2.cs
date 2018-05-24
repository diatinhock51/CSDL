using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSDL.Models;
namespace CSDL
{
    public partial class Form2 : Form
    {
        Models.SinhVien mySV;
        public Form2 ( Models.SinhVien sv)
        {
            mySV = sv;
            InitializeComponent();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txtMatKhauCu.Text = "";
        }

        private void txtMatKhauMoi_Click(object sender, EventArgs e)
        {
            txtMatKhauMoi.Text = "";
        }

        private void txtNhapLai_Click(object sender, EventArgs e)
        {
            txtNhapLai.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(mySV.MatKhau+"/");
            //MessageBox.Show(txtMatKhauCu.Text);
            if (txtMatKhauCu.Text != mySV.MatKhau.Trim())
            {
                //MessageBox.Show(txtMatKhauCu.Text.Trim());
                MessageBox.Show("Mật khẩu cũ không đúng");
                txtMatKhauCu.Text = "";
            }
            else if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu mới");
                txtMatKhauMoi.Text = "";
                txtNhapLai.Text = "";
            }
            else
            {
                //MatKhauMoi = 
                mySV.MatKhau = txtMatKhauMoi.Text;
                mySV.UpdateMKSinhVien();
                MessageBox.Show("Xác nhận đổi mật khẩu ");
                this.Close();
            }
        }
    }
}
