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
    public partial class ThongTinNopPhi : UserControl
    {
        Models.SinhVien sv;

        public ThongTinNopPhi()
        {
            InitializeComponent();
            design();
            sv = Models.SinhVien.getSinhVien("SV0001");
           
        }
        int[] GetNamHoc()
        {
            var tmp = sv.KhoaHoc.Split('-');
            int count = int.Parse(tmp[tmp.Length - 1]) - int.Parse(tmp[0])+1;
            var result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = int.Parse(tmp[0]) + i;  
            }
            return result;
        }
        void loadCbbNamHoc()
        {
            var item = GetNamHoc();
            for (int i = 0; i < item.Length-1; i++)
            {
                cbNamHocThongTinNopPhi.Items.Add(item[i] + "-" + item[i+1]);
            }
        }
        void loadData(string MASV)
        {
            dataGridView1.DataSource = Models.DangKy.getMonHocDangKy("SV0001", "2015-2016", "HK1");
        }
        void design()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void tbnTaiLaiThongTinNopPhi_Click(object sender, EventArgs e)
        {

            loadCbbNamHoc();
            //loadData();
        }
    }
}
