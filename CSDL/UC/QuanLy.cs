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
    public partial class QuanLy : UserControl
    {

        public QuanLy()
        {
            InitializeComponent();
            Phuong();
            
            var dataTable = Models.SinhVien.getTableSinhVien();
            dgvSV.DataSource = dataTable;

        }

        //private void btnThem_Click(object sender, EventArgs e)
        //{

        //}
    }
}
