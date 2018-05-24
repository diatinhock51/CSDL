using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL
{
    public partial class Login : Form
    {

        //bool hide = true;
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;
        public Login()
        {
            InitializeComponent();
        }
        //void generate()
        //{
        //    TextBoxBottom txt = new TextBoxBottom();
        //    txt.Location = new Point(10, 10);
        //    this.Controls.Add(txt);
        //}
        /// <summary>
        /// Sự kiện kiểm soát trạng thái khi nhập 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtName.BackColor = Color.GhostWhite;
            txtPass.BackColor = Color.GhostWhite;
            txtName.Controls.Clear();
            txtPass.Controls.Clear();
            //TextBoxBottom obj = sender as TextBoxBottom;
            //obj.BackColor = Color.Wheat;
        }
        /// <summary>
        /// Sự kiện đóng Form 
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Sự kiện kiểm soát move Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
            //MessageBox.Show("ssssss");
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown)
            {
                mouseX = MousePosition.X - 90;
                mouseY = MousePosition.Y - 15;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Button login = sender as Button;
            List<List<string>> SV = Models.SinhVien.getMaSV();
            List<List<string>> NV = Models.NhanVien.getMaNV();
            string maDN = txtName.Text;
            string matKhau = txtPass.Text;
            if (SV[0].Contains(maDN.ToUpper()) && SV[1][SV[0].IndexOf(maDN.ToUpper())]==matKhau)
            {
                SinhVien(maDN);
            }
            else if (NV[0].Contains(maDN.ToUpper()) && NV[1][NV[0].IndexOf(maDN.ToUpper())] == matKhau)
            {
                NhanVien(maDN);
            }
            else
            {
                //MessageBox.Show(maDN+"/"+matKhau);
                //MessageBox.Show(SV[0][0] + "");

                MessageBox.Show("Sai tên đăng nhập hoặc tài khoản","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        void SinhVien(string maDN)
        {
            CSDL.fSinhVien sv = new CSDL.fSinhVien(maDN);
            this.Hide();
            sv.Show();
        }

        void NhanVien(string maNV)
        {
            CSDL.Form1 nv = new CSDL.Form1(maNV);
            this.Hide();
            nv.Show();
        }
        private void btnLogin_MouseMove(object sender, MouseEventArgs e)
        {
            Button login = sender as Button;
            login.BackColor = Color.ForestGreen;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            Button login = sender as Button;
            login.BackColor = Color.Peru;
        }


    }
}
