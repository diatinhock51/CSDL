using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.Models
{
    class LopQuanLy
    {
        string maLHP;
        string tenLHP;
        string khoa;
        #region Field
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

        public string TenLHP
        {
            get
            {
                return tenLHP;
            }

            set
            {
                tenLHP = value;
            }
        }

        public string Khoa
        {
            get
            {
                return khoa;
            }

            set
            {
                khoa = value;
            }
        }

        #endregion
        public LopQuanLy(string _maLHP, string _tenLHP, string _khoa)
        {
            maLHP = _maLHP;
            tenLHP = _tenLHP;
            khoa = _khoa;
        }
        public LopQuanLy(string[] data)
        {
            //DateTime.f
            maLHP = data[0];
            tenLHP = data[1];
            khoa = data[2];
        }
        public int InsertLopQuanLy()
        {
            string[] paras = new string[3] { "@MALHP", "@TENLHP", "@KHOA"};
            object[] values = new object[3] { maLHP, tenLHP, khoa };
            var i = Models.connection.ExcuteQuery("spInsertLopQuanLy",
                CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateLopQuanLy()
        {
            string[] paras = new string[3] { "@MALHP", "@TENLHP", "@KHOA" };
            object[] values = new object[3] { maLHP, tenLHP, khoa };
            var i = Models.connection.ExcuteQuery("spUpdateLopQuanLy",
                CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteLopQuanLy()
        {
            var i = Models.connection.ExcuteQuery("spDeleteLopQuanLy",
                CommandType.StoredProcedure, new string[1] { "@MALHP" }, new object[1] { maLHP });
            return i;
        }

        public static DataTable getTableLopQuanLy()
        {
            //Gọi thủ tục getLopQuanLy
            return Models.connection.getData("spgetTableLopQuanLy", CommandType.StoredProcedure);
        }
        //public static DataTable getTables

        public static LopQuanLy getLopQuanLy(string maLHP)
        {
            DataTable dt = new DataTable();
            dt = Models.connection.getData("spgetLopQuanLy", CommandType.StoredProcedure,
                new string[1] { "@MaLHP" }, new object[1] { maLHP });
            var obj = dt.Rows[0].ItemArray;
            var data = obj.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();
            return new LopQuanLy(data);
        }
    }
}
