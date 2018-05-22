using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.Models
{
    class DangKy
    {
        string maSV;
        string maHD;
        string hocKy;
        string namHoc;
        string soTien;
        
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

        public string HocKy
        {
            get
            {
                return hocKy;
            }

            set
            {
                hocKy = value;
            }
        }

        public string NamHoc
        {
            get
            {
                return namHoc;
            }

            set
            {
                namHoc = value;
            }
        }

        public string SoTien
        {
            get
            {
                return soTien;
            }

            set
            {
                soTien = value;
            }
        }
        #endregion
        public DangKy(string _maSV, string _maHD, string _hocKy,
            string _namHoc, string _soTien )
        {
            maSV = _maSV;
            maHD = _maHD;
            hocKy = _hocKy;
            namHoc = _namHoc;
            soTien = _soTien;
        }
        public DangKy(string[] data)
        {
            //DateTime.f
            maSV = data[0];
            maHD = data[1];
            hocKy = data[2];
            namHoc = data[3];
            soTien = data[4];
        }
        public int InsertDangKy()
        {
            string[] paras = new string[5] { "@MASV", "@MAHD", "@HOCKY",
                "@NAMHOC", "@SOTIEN"};
            object[] values = new object[5] { maSV, maHD, hocKy, namHoc,
                soTien};
            var i = Models.connection.ExcuteQuery("spInsertDangKy",
                System.Data.CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateDangKy()
        {
            string[] paras = new string[5] { "@MASV", "@MAHD", "@HOCKY",
                "@NAMHOC", "@SOTIEN"};
            object[] values = new object[5] { maSV, maHD, hocKy, namHoc,
                soTien};
            var i = Models.connection.ExcuteQuery("spUpdateDangKy",
                CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteDangKy()
        {
            var i = Models.connection.ExcuteQuery("spDeleteDangKy",
                CommandType.StoredProcedure, new string[2] { "@MASV", "@MAHD" }, new object[2] { maSV, maHD });
            return i;
        }

        public static DataTable getTableDangKy()
        {
            //Gọi thủ tục getDangKy
            return Models.connection.getData("spgetTableDangKy", CommandType.StoredProcedure);
        }
        //public static DataTable getTables

        public static DangKy getDangKy(string maSV, string maHD)
        {
            DataTable dt = new DataTable();
            dt = Models.connection.getData("spgetDangKy", CommandType.StoredProcedure,
                new string[2] { "@MASV", "@MAHD" }, new object[2] { maSV, maHD });
            var obj = dt.Rows[0].ItemArray;
            var data = obj.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();
            return new DangKy(data);
        }
    }
}
