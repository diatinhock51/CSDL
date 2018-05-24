using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CSDL.UC
{
    public partial class DangKyMonHoc : UserControl
    {
        string maSV;
        Models.DangKy myDK;
        Models.LopHocPhan myLHP;
        Models.SinhVien mySV;
        Models.LopQuanLy myLQL;
        public DangKyMonHoc(string _maSV)
        {
            InitializeComponent();
            maSV = _maSV;
            mySV = Models.SinhVien.getSinhVien(maSV);
            myLQL = Models.LopQuanLy.getLopQuanLy(mySV.MaLQL);
            showInfo();
            cbbNamHoc.Items.Clear();
            DangKy();
        }
        void LoadData()
        {
            dataGridView1.DataSource = Models.DangKy.getDangKymaSV(mySV.MaSV);
        }
         
        void showInfo()
        {
            txtHoTen.Text = mySV.Ten;
            txtKhoa.Text = myLQL.Khoa;
            txtLop.Text = myLQL.TenLQL;
            txtKhoaHoc.Text = mySV.KhoaHoc;
            txtHeSoMG.Text = mySV.MaDT;
        }
        int[] GetNamHoc()
        {
            var tmp = mySV.KhoaHoc.Split('-');
            int count = int.Parse(tmp[tmp.Length-1]) - int.Parse(tmp[0]);
            var result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = int.Parse(tmp[0]) + i;
            }
            return result;
        }
        void DangKy()
        {
            cbbNamHoc.Items.Clear();
            cbbNamHoc.Text = "-Chọn năm học-";
            var item = GetNamHoc();
            for (int i = 0; i <item.Length ; i++)
            {
                cbbNamHoc.Items.Add(item[i].ToString() + "-" + (item[i] + 1).ToString());
            }            
            cbbHocKy.SelectedValueChanged += CbbHocKy_SelectedValueChanged;
        }

        private void CbbHocKy_SelectedValueChanged(object sender, EventArgs e)
        {
            cbbMonHoc.Items.Clear();
            cbbMonHoc.Text = "-Chọn môn học-";
            var dataTen = Models.LopHocPhan.getTenLHP(cbbHocKy.SelectedItem.ToString());
            for (int i = 0; i < dataTen.Rows.Count; i++)
            {
                var val = dataTen.Rows[i][0].ToString();
                if (!cbbMonHoc.Items.Contains(val))
                {
                    cbbMonHoc.Items.Add(val);
                }
            }
            cbbMonHoc.SelectedValueChanged += CbbMonHoc_SelectedValueChanged;
        }

        private void CbbMonHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            cbbGV.Items.Clear();
            cbbGV.Text = "-Chọn giáo viên-";
            var dataGV = Models.LopHocPhan.getTenGV(cbbHocKy.SelectedItem.ToString(), cbbMonHoc.SelectedItem.ToString());
            for (int i = 0; i < dataGV.Rows.Count; i++)
            {
                var val = dataGV.Rows[i][0].ToString();
                if (!cbbGV.Items.Contains(val))
                {
                    cbbGV.Items.Add(val);
                }
            }
            cbbGV.SelectedValueChanged += CbbGV_SelectedValueChanged;
        }

        private void CbbGV_SelectedValueChanged(object sender, EventArgs e)
        {
            myLHP = Models.LopHocPhan.getLopHocPhan(cbbMonHoc.SelectedItem.ToString(),
                cbbGV.SelectedItem.ToString(), cbbHocKy.SelectedItem.ToString());
            txtTenMH.Text = myLHP.TenHP;
            txtHoTenGV.Text = myLHP.HoTenGV;
            txtSoTiet.Text = myLHP.SoTiet.ToString();
            txtSoTC.Text = myLHP.SoTinChi.ToString();
            txtMaLop.Text = myLHP.MaHP;

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            Int64 soTien = myLHP.SoTinChi * 25000;
            myDK = new Models.DangKy(mySV.MaSV, myLHP.MaHP, myLHP.LoaiHK,
                cbbNamHoc.SelectedItem.ToString(), soTien.ToString(),"Chưa nộp");
            myDK.InsertDangKy();
            LoadData();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //ReportParameter[] listPara = new ReportParameter[]{
            // new ReportParameter("MaHD",txtM),
            // new ReportParameter("DiaChi",db.THONGTINNHAHANGs.FirstOrDefault().DIACHI),
            // new ReportParameter("SoBan", db.BANANs.Where(p=>p.MABA == soban).FirstOrDefault().TENBA),
            // new ReportParameter("Ngay",DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
            // new ReportParameter("TongTien",TongTien.ToString()),
            // new ReportParameter("MaHD",MaHD.ToString())
            //};
            //fIn frmIn = new fIn(listPara);

        }
    }
}
