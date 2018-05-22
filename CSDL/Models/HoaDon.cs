using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.Models
{
    class HoaDon
    {
        string maHD;
        string tenHD;
        string ngayThu;
        int tongSoTien;
        string maSV;
        string maNV;
        #region Field
        public string MaHD
        {
            get
            {
                return maHD;
            }

            set
            {
                maHD = value;
            }
        }

        public string TenHD
        {
            get
            {
                return tenHD;
            }

            set
            {
                tenHD = value;
            }
        }

        public string NgayThu
        {
            get
            {
                return ngayThu;
            }

            set
            {
                ngayThu = value;
            }
        }

        public int TongSoTien
        {
            get
            {
                return tongSoTien;
            }

            set
            {
                tongSoTien = value;
            }
        }

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
        #endregion
        public HoaDon(string _maHD, string _tenHD, string _ngayThu,
           int _tongSoTien, string _maSV, string _maNV)
        {
            maHD = _maHD;
            tenHD = _tenHD;
            ngayThu = _ngayThu;
            tongSoTien = _tongSoTien;
            maSV = _maSV;
            maNV = _maNV;
        }
        public HoaDon(string[] data)
        {
            maHD = data[0];
            tenHD = data[1];
            ngayThu = data[2];
            tongSoTien = Convert.ToInt32( data[3]);
            maSV = data[4];
            maNV = data[5];
        }
        public int InsertHoaDon()
        {
            string[] paras = new string[6] { "@MAHD", "@TENHD", "@NGAYTHU",
                "@TONGSOTIEN", "@MASV", "@MANV"};
            object[] values = new object[6] { maHD, tenHD, ngayThu, tongSoTien,
                maSV, maNV};
            var i = Models.connection.ExcuteQuery("spInsertHoaDon",
                System.Data.CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateHoaDon()
        {
            string[] paras = new string[6] { "@MAHD", "@TENHD", "@NGAYTHU",
                "@TONGSOTIEN", "@MASV", "@MANV"};
            object[] values = new object[6] { maHD, tenHD, ngayThu, tongSoTien,
                maSV, maNV};
            var i = Models.connection.ExcuteQuery("spUpdateHoaDon",
                CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteHoaDon()
        {
            var i = Models.connection.ExcuteQuery("spDeleteHoaDon",
                CommandType.StoredProcedure, new string[1] { "@MAHD"}, new object[1] { maHD });
            return i;
        }

        public static DataTable getTableHoaDon()
        {
            //Gọi thủ tục getHoaDon
            return Models.connection.getData("spgetTableHoaDon", CommandType.StoredProcedure);
        }
        //public static DataTable getTables

        public static HoaDon getHoaDon(string maHD)
        {
            DataTable dt = new DataTable();
            dt = Models.connection.getData("spgetHoaDon", CommandType.StoredProcedure,
                 new string[1] { "@MAHD" }, new object[1] { maHD });
            var obj = dt.Rows[0].ItemArray;
            var data = obj.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();
            return new HoaDon(data);
        }
    }
}
