using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.Models
{
    class LopHocPhan
    {
        string maHP;
        string tenHP;
        int soTinChi;
        int soTiet;
        string hoTenGV;
        string loaiHK;
        #region Field
        public string MaHP
        {
            get
            {
                return maHP;
            }

            set
            {
                maHP = value;
            }
        }

        public string TenHP
        {
            get
            {
                return tenHP;
            }

            set
            {
                tenHP = value;
            }
        }

        public int SoTinCHi
        {
            get
            {
                return soTinChi;
            }

            set
            {
                soTinChi = value;
            }
        }

        public int SoTiet
        {
            get
            {
                return soTiet;
            }

            set
            {
                soTiet = value;
            }
        }

        public string HoTenGV
        {
            get
            {
                return hoTenGV;
            }

            set
            {
                hoTenGV = value;
            }
        }

        public string LoaiHK
        {
            get
            {
                return loaiHK;
            }

            set
            {
                loaiHK = value;
            }
        }

        #endregion
        public LopHocPhan(string _maHP, string _tenHP, int _soTinChi,
            int _soTiet, string _hoTenGV, string _loaiHK)
        {
            maHP = _maHP;
            tenHP = _tenHP;
            soTinChi = _soTinChi;
            soTiet = _soTiet;
            hoTenGV = _hoTenGV;
            loaiHK = _loaiHK;
        }
        public LopHocPhan(string[] data)
        {
            //DateTime.f
            maHP = data[0];
            tenHP = data[1];
            soTinChi = Convert.ToInt32(data[2]);
            soTiet = Convert.ToInt32(data[3]);
            hoTenGV = data[4];
            loaiHK = data[5];
        }
        public int InsertLopHocPhan()
        {
            string[] paras = new string[6] { "@maHP", "@tenHP", "@sotinchi",
                "@sotiet", "@tenGV", "@loaiHK" };
            object[] values = new object[6] { maHP, tenHP, soTinChi, soTiet,
                hoTenGV, loaiHK };
            var i = Models.connection.ExcuteQuery("spInsertLopHocPhan",
                CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateLopHocPhan()
        {
            string[] paras = new string[6] { "@maHP", "@tenHP", "@sotinchi",
                "@sotiet", "@tenGV", "@loaiHK" };
            object[] values = new object[6] { maHP, tenHP, soTinChi, soTiet,
                hoTenGV, loaiHK };
            var i = Models.connection.ExcuteQuery("spUpdateLopHocPhan",
                CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteLopHocPhan()
        {
            var i = Models.connection.ExcuteQuery("spDeleteLopHocPhan",
                CommandType.StoredProcedure, new string[1] { "@MaHP" }, new object[1] { maHP });
            return i;
        }

        public static DataTable getTableLopHocPhan()
        {
            //Gọi thủ tục getLopHocPhan
            return Models.connection.getData("spgetTableLopHocPhan", CommandType.StoredProcedure);
        }
        //public static DataTable getTables

        public static LopHocPhan getLopHocPhan(string maLHP)
        {
            DataTable dt = new DataTable();
            dt = Models.connection.getData("spgetLopHocPhan", CommandType.StoredProcedure,
                new string[1] { "@MaHP" }, new object[1] { maLHP });
            var obj = dt.Rows[0].ItemArray;
            var data = obj.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();
            return new LopHocPhan(data);
        }
    }
}
