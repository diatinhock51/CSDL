using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.Models
{
    class NhanVien
    {
        string maNV;
        string tenNV;
        string soDT;
        string chucVu;
        string matKhau;
        #region Field
        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }

        public string TenNV
        {
            get
            {
                return tenNV;
            }

            set
            {
                tenNV = value;
            }
        }

        public string SoDT
        {
            get
            {
                return soDT;
            }

            set
            {
                soDT = value;
            }
        }

        public string ChucVu
        {
            get
            {
                return chucVu;
            }

            set
            {
                chucVu = value;
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

        #endregion
        public NhanVien(string _maNV, string _tenNV, string _soDT, string _chucVu, string _matKhau)
        {
            maNV = _maNV;
            tenNV = _tenNV;
            soDT = _soDT;
            chucVu = _chucVu;
            matKhau = _matKhau;
        }
        public NhanVien(string[] data)
        {
            maNV = data[0];
            tenNV = data[1];
            soDT = data[2];
            chucVu = data[3];
            matKhau = data[4];
        }
        public int InsertNhanVien()
        {
            string[] paras = new string[5] { "@MANV", "@TENNV", "@SODT", "@CHUCVU", "@MATKHAU" };
            object[] values = new object[5] { maNV, tenNV, soDT, chucVu, matKhau };
            var i = Models.connection.ExcuteQuery("spInsertNhanVien",
                CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateNhanVien()
        {
            string[] paras = new string[5] { "@MANV", "@TENNV", "@SODT", "@CHUCVU", "@MATKHAU" };
            object[] values = new object[5] { maNV, tenNV, soDT, chucVu, matKhau };
            var i = Models.connection.ExcuteQuery("spUpdateNhanVien",
                CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteNhanVien()
        {
            var i = Models.connection.ExcuteQuery("spDeleteNhanVien",
                CommandType.StoredProcedure, new string[1] { "@MANV" }, new object[1] { maNV });
            return i;
        }

        public static DataTable getTableNhanVien()
        {
            //Gọi thủ tục getNhanVien
            return Models.connection.getData("spgetTableNhanVien", CommandType.StoredProcedure);
        }
        //public static DataTable getTables

        public static NhanVien getNhanVien(string maNV)
        {
            DataTable dt = new DataTable();
            dt = Models.connection.getData("spgetNhanVien", CommandType.StoredProcedure,
                new string[1] { "@MANV" }, new object[1] { maNV });
            var obj = dt.Rows[0].ItemArray;
            var data = obj.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();
            return new NhanVien(data);
        }
        public static List<List<string>> getMaNV()
        {
            List<List<string>> re = new List<List<string>>();
            List<string> maNV = new List<string>();
            List<string> matKhau = new List<string>();
            DataTable dt = new DataTable();
            dt = Models.connection.getData("Select MaNV,MatKhau from NhanVien", CommandType.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                maNV.Add(dt.Rows[i][0].ToString().Trim());
                matKhau.Add(dt.Rows[i][1].ToString().Trim());
            }
            re.Add(maNV);
            re.Add(matKhau);
            Console.Write(matKhau.Count);
            return re;
        }
    }
}
