using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
namespace CSDL
{
    class TextBoxBottom : TextBox
    {
        public TextBoxBottom()
        {
            BorderStyle = BorderStyle.None;
            AutoSize = false;
            BackColor = Color.GhostWhite;
            
            this.Click += TextBoxBottom_Click;
        }

        private void TextBoxBottom_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.GhostWhite;
            TextBoxBottom obj = sender as TextBoxBottom;
            obj.BackColor = Color.Wheat;
            Controls.Add(new Label() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Red });
            //for (int i = 0; i < 5; i++)
            //{

            //    Thread.Sleep(10);
            //}

        }
    }
}
