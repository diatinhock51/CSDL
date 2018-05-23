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
        string MASV="SV0001";
        string NAMHOC;
        string HOCKY;
        public ThongTinNopPhi()
        {
            InitializeComponent();
            design();  
            sv = Models.SinhVien.getSinhVien("SV0001");
            loadCbbNamHoc();
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
        void loadData(string MASV, string NAMHOC , string HOCKY )
        {
            dataGridView1.DataSource = Models.DangKy.getMonHocDangKy(MASV, NAMHOC,HOCKY);
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

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        void design1()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight  ;
            for (int i = 3; i <= 5; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void tbnTaiLaiThongTinNopPhi_Click(object sender, EventArgs e)
        {
            NAMHOC = cbNamHocThongTinNopPhi.Text;
            HOCKY = cbHocKyThongTinNopPhi.Text;
            if (HOCKY == "-Chọn học kỳ-" & NAMHOC != "-Chọn năm học-")
            {
                MessageBox.Show("Mời bạn chọn hoc kỳ ");
            }
            else if (HOCKY != "-Chọn học kỳ-" && NAMHOC == "-Chọn năm học-")
            {
                MessageBox.Show("Mời bạn chọn năm học ");
            }
            else
            {
                loadData(MASV, NAMHOC, HOCKY);
                if (Models.DangKy.getMonHocDangKy(MASV, NAMHOC, HOCKY) != null)
                {
                    design1();
                    MessageBox.Show("aaa");
                }
            }
        }
    }
}
