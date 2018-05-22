using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.Models
{
    class SinhVien
    {
        string maSV;
        string ten;
        DateTime ngaySinh;
        string diaChi;
        string gioiTinh;
        string email;
        string khoaHoc;
        string matKhau;
        string maLHP;
        string maDT;
        #region Field
        public string MaSV
        {
            get
            {
                return maSV;
            }

            set
            {
                maSV = value;
            }
        }

        public string Ten
        {
            get
            {
                return ten;
            }

            set
            {
                ten = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return matKhau;
            }

            set
            {
                matKhau = value;
            }
        }

        public string KhoaHoc
        {
            get
            {
                return khoaHoc;
            }

            set
            {
                khoaHoc = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        public string MaDT
        {
            get
            {
                return maDT;
            }

            set
            {
                maDT = value;
            }
        }

        public string MaLHP
        {
            get
            {
                return maLHP;
            }

            set
            {
                maLHP = value;
            }
        }
        #endregion
        public SinhVien(string _maSV, string _ten, DateTime _ngaySinh,
            string _diaChi, string _gioiTinh, string _email, string _khoaHoc,
            string _matKhau, string _maLHP, string _maDT)
        {
            maSV = _maSV;
            ten = _ten;
            ngaySinh = _ngaySinh;
            diaChi = _diaChi;
            gioiTinh = _gioiTinh;
            email = _email;
            khoaHoc = _khoaHoc;
            matKhau = _matKhau;
            maLHP = _maLHP;
            maDT = _maDT;
        }
        public SinhVien(string[] data)
        {
            //DateTime.f
            maSV = data[0];
            ten = data[1];
            ngaySinh = DateTime.ParseExact(data[2], "yy/MM/dd h:mm:ss tt", 
            System.Globalization.CultureInfo.InvariantCulture); 
            diaChi = data[3];
            gioiTinh = data[4];
            email = data[5];
            khoaHoc = data[6];
            matKhau = data[7];
            maLHP = data[8];
            maDT = data[9];
        }
        public int InsertSinhVien()
        {            
            string[] paras = new string[10] { "@MASV", "@TENSV", "@NGAYSINH",
                "@GIOITINH", "@DIACHI", "@EMAIL", "@KHOAHOC", "@MATKHAU", "@MALHP", "@MADT"};
            object[] values = new object[10] { maSV, ten, ngaySinh, gioiTinh,
                diaChi, email, khoaHoc, matKhau, maLHP, maDT };
            var i = Models.connection.ExcuteQuery("spInsertSinhVien", 
                CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateSinhVien()
        {
            string[] paras = new string[10] { "@MASV", "@TENSV", "@NGAYSINH",
                "@GIOITINH", "@DIACHI", "@EMAIL", "@KHOAHOC", "@MATKHAU", "@MALHP", "@MADT"};
            object[] values = new object[10] { maSV, ten, ngaySinh, gioiTinh,
                diaChi, email, khoaHoc, matKhau, maLHP, maDT };
            var i = Models.connection.ExcuteQuery("spUpdateSinhVien", 
                CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteSinhVien()
        {
            var i = Models.connection.ExcuteQuery("spDeleteSinhVien",
                CommandType.StoredProcedure, new string[1] { "@MASV" }, new object[1] { maSV });
            return i;
        }

        public static DataTable getTableSinhVien()
        {
            //Gọi thủ tục getSinhVien
            return Models.connection.getData("spgetSinhVien", CommandType.StoredProcedure);            
        }
        //public static DataTable getTables

        public static SinhVien getSinhVien(string maSV)
        {
            DataTable dt = new DataTable();
            dt = Models.connection.getData("spgetSinhVienByMaSV", CommandType.StoredProcedure, 
                new string[1] { "@MASV" }, new object[1] { maSV });
            var obj = dt.Rows[0].ItemArray;
            var data= obj.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();
            return new SinhVien(data);            
        }
        
    }
}
