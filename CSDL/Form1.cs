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
    public partial class Form1 : Form
    {
        bool hide = true;
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;
        public Form1()
        {
            InitializeComponent();
            UC.QuanLy quanLy = new UC.QuanLy();
            quanLy.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(quanLy);
            //splitContainer1.Panel1.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pcbOff.BackColor = Color.DarkRed;
            Application.Exit();
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            btnThuPhi.BackColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(26)))), ((int)(((byte)(153)))));
            btnQuanLy.BackColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(26)))), ((int)(((byte)(153)))));
            btnThongKe.BackColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(26)))), ((int)(((byte)(153)))));
            btn3.BackColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(26)))), ((int)(((byte)(153)))));
            //btn4.BackColor = Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(26)))), ((int)(((byte)(153)))));
            //Button btn = sender as Button;
            //btn.BackColor = Color.DimGray;
            //Messenger.messengerBox box = new Messenger.messengerBox();
            //box.Show();
            //Accsount tmp = new Accsount();
            //splitContainer1.Panel2.Controls.Add(tmp);
            Button obj = sender as Button;
            //MessageBox.Show(obj.Text);
            if (obj == btnThuPhi)
            {
                //MessageBox.Show(obj.Text);
                generalThuPhi();
            }
            else if (obj == btnThongKe)
            {
                //MessageBox.Show(obj.Text);
                generalThongKe();
            }
            else if (obj == btnQuanLy)
            {
                //MessageBox.Show(obj.Text);
                generalQuanLy();
            }
            else if (obj == btnInfoApp)
            {
                //MessageBox.Show(obj.Text);
                generalThongTin();
            }
        }
        void generalThuPhi()
        {
            UC.ThuPhi thuphi = new UC.ThuPhi();
            thuphi.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(thuphi);
        }
        void generalThongKe()
        {
            UC.ThongKe thongKe = new UC.ThongKe();
            thongKe.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(thongKe);
        }
        void generalQuanLy()
        {
            UC.QuanLy quanLy = new UC.QuanLy();
            quanLy.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(quanLy);
        }

        void generalThongTin() 
        {
            UC.ThongTin thongTin = new UC.ThongTin();
            thongTin.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(thongTin);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.hide == true)
            {
                splitContainer1.Panel1.Show();
                this.hide = false;
            }
            else
            {
                splitContainer1.Panel1.Hide();
                this.hide = true;
            }
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown)
            {
                mouseX = MousePosition.X - 400;
                mouseY = MousePosition.Y - 35;
                this.SetDesktopLocation(mouseX, mouseY);
            }
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = 800;
            this.Width = 1200;
        }
    }
}
