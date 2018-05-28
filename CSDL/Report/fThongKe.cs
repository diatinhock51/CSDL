using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL.Report
{
    public partial class fThongKe : Form
    {
        DataTable myDt;
        public fThongKe()
        {
            InitializeComponent();
        }

        private void fThongKe_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "";
            //rds.Value= myDt
            //reportViewer1
            this.reportViewer1.RefreshReport();
        }
    }
}
