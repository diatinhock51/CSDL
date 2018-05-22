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
        public DangKyMonHoc(string _maSV)
        {
            InitializeComponent();
            maSV = _maSV;
            mySV = Models.SinhVien.getSinhVien(maSV);
            showInfo();
        }
        void showInfo()
        {
            txtHoTen.Text = mySV.Ten;
            txtKhoa.Text = mySV.KhoaHoc;
            txtKhoaHoc.Text = mySV.KhoaHoc;
            txtHeSoMG.Text = mySV.MaDT;
        }
    }
}
