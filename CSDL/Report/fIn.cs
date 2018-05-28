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


namespace CSDL.UC
{
    public partial class fIn : Form
    {
        ReportParameter[] mylistPara;
        DataTable myDt;
        public fIn(ReportParameter[] listPara)
        {
            InitializeComponent();
            mylistPara = listPara;
        }

        private void fIn_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "";
            rds.Value = myDt;
            this.rpInHoaDon.LocalReport.DataSources.Add()
            this.rpInHoaDon.LocalReport.SetParameters(mylistPara);
            this.rpInHoaDon.LocalReport.Refresh();
            this.rpInHoaDon.RefreshReport();            
        }
    }
}
