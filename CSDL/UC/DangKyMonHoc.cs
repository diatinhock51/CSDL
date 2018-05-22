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
    public partial class DangKyMonHoc : UserControl
    {
        string maSV;
        Models.SinhVien mySV;
        Models.LopQuanLy myLQL;
        public DangKyMonHoc(string _maSV)
        {
            InitializeComponent();
            maSV = _maSV;
            mySV = Models.SinhVien.getSinhVien(maSV);
            myLQL = Models.LopQuanLy.getLopQuanLy(mySV.MaLQL);
            showInfo();
            DangKy();
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
            var item = GetNamHoc();
            for (int i = 0; i <item.Length ; i++)
            {
                cbbNamHoc.Items.Add(item[i]);
            }
        }
    }
}
