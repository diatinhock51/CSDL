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
            var dataTable = Models.LopHocPhan.getTableLopHocPhan();
            dgvLHP.DataSource = dataTable;
            //var dataTable = Models.LopHocPhan.getTableLopHocPhan();
        }
    }
}
