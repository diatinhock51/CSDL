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
        string maLQL;
        string tenLQL;
        string khoa;
        #region Field
        public string MaLQL
        {
            get
            {
                return maLQL;
            }

            set
            {
                maLQL = value;
            }
        }

        public string TenLQL
        {
            get
            {
                return tenLQL;
            }

            set
            {
                tenLQL = value;
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
        public LopQuanLy(string _maLQL, string _tenLQL, string _khoa)
        {
            maLQL = _maLQL;
            tenLQL = _tenLQL;
            khoa = _khoa;
        }
        public LopQuanLy(string[] data)
        {
            //DateTime.f
            maLQL = data[0];
            tenLQL = data[1];
            khoa = data[2];
        }
        public int InsertLopQuanLy()
        {
            string[] paras = new string[3] { "@MALQL", "@TENLQL", "@KHOA"};
            object[] values = new object[3] { maLQL, tenLQL, khoa };
            var i = Models.connection.ExcuteQuery("spInsertLopQuanLy",
                CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateLopQuanLy()
        {
            string[] paras = new string[3] { "@MALQL", "@TENLQL", "@KHOA" };
            object[] values = new object[3] { maLQL, tenLQL, khoa };
            var i = Models.connection.ExcuteQuery("spUpdateLopQuanLy",
                CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteLopQuanLy()
        {
            var i = Models.connection.ExcuteQuery("spDeleteLopQuanLy",
                CommandType.StoredProcedure, new string[1] { "@MALQL" }, new object[1] { maLQL });
            return i;
        }

        public static DataTable getTableLopQuanLy()
        {
            //Gọi thủ tục getLopQuanLy
            return Models.connection.getData("spgetTableLopQuanLy", CommandType.StoredProcedure);
        }
        //public static DataTable getTables

        public static LopQuanLy getLopQuanLy(string maLQL)
        {
            DataTable dt = new DataTable();
            dt = Models.connection.getData("spgetLopQuanLy", CommandType.StoredProcedure,
                new string[1] { "@MaLQL" }, new object[1] { maLQL });
            var obj = dt.Rows[0].ItemArray;
            var data = obj.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();
            return new LopQuanLy(data);
        }
    }
}
