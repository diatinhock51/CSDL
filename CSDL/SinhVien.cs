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
    public partial class fSinhVien : Form
    {
        Models.SinhVien mySV;
        public fSinhVien(string maSV)
        {
            mySV = Models.SinhVien.getSinhVien(maSV);
            InitializeComponent();
           
        }

        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            btnHoSoSV.BackColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(26)))), ((int)(((byte)(153)))));
            btnDangKi.BackColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(26)))), ((int)(((byte)(153)))));
            btnThongTinNopPhi.BackColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(26)))), ((int)(((byte)(153)))));
            btnInfoApp.BackColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(26)))), ((int)(((byte)(153)))));

            Button obj = sender as Button;
            if (obj == btnHoSoSV)
            {
                generalHoSoSinhVien();
            }
            else if (obj == btnDangKi)
            {
                generalDangKyMonHoc();
            }
            else if (obj == btnThongTinNopPhi)
            {
                generalThongTinNopPhi();
            }
            else
            {
                generalInfo();
            }
        }
        void generalHoSoSinhVien()
        {
            UC.HoSoSinhVien hoSo = new UC.HoSoSinhVien();
            hoSo.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(hoSo);
        }
        void generalDangKyMonHoc()
        {
            UC.DangKyMonHoc dangKy = new UC.DangKyMonHoc(mySV.MaSV);
            dangKy.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(dangKy);
        }
        void generalThongTinNopPhi()
        {
            UC.ThongTinNopPhi ttNopPhi = new UC.ThongTinNopPhi();
            ttNopPhi.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(ttNopPhi);
        }

        void generalInfo()
        {
            UC.ThongTin thongTin = new UC.ThongTin();
            thongTin.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(thongTin);
        }
        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
        }

        private void splitContainer1_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown)
            {
                mouseX = MousePosition.X - 600;
                mouseY = MousePosition.Y - 35;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void splitContainer1_Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            this.Height = 800;
            this.Width = 1200;
            lblName.Text = mySV.Ten;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
