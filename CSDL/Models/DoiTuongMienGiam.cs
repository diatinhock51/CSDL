using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.Models
{
    class DoiTuongMienGiam
    {
        string maDT;
        string loaiDT;
        float heSoMG;
        #region Field
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

        public string LoaiDT
        {
            get
            {
                return loaiDT;
            }

            set
            {
                loaiDT = value;
            }
        }

        public float HeSoMG
        {
            get
            {
                return heSoMG;
            }

            set
            {
                heSoMG = value;
            }
        }

        #endregion
        public DoiTuongMienGiam(string _maDT, string _loaiDT, float _hesoMG )
        {
            maDT = _maDT;
            loaiDT = _loaiDT;
            HeSoMG = _hesoMG;
        }
        public DoiTuongMienGiam(string[] data)
        {
            //DateTime.f
            maDT = data[0];
            loaiDT = data[1];
            HeSoMG = (float)Convert.ToDouble(data[2]);
        }
        public int InsertDoiTuongMienGiam()
        {
            string[] paras = new string[3] { "@MADT", "@LOAIDT", "@HESOMG"};
            object[] values = new object[3] { maDT, loaiDT, HeSoMG};
            var i = Models.connection.ExcuteQuery("spInsertDoiTuongMienGiam",
                System.Data.CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateDoiTuongMienGiam()
        {
            string[] paras = new string[3] { "@MADT", "@LOAIDT", "@HESOMG" };
            object[] values = new object[3] { maDT, loaiDT, HeSoMG };
            var i = Models.connection.ExcuteQuery("spUpdateDoiTuongMienGiam",
                CommandType.StoredProcedure, paras, values);
            return i;
        }

        public int DeleteDoiTuongMienGiam()
        {
            var i = Models.connection.ExcuteQuery("spDeleteDoiTuongMienGiam",
                CommandType.StoredProcedure, new string[1] { "@MADT" }, new object[1] { maDT });
            return i;
        }

        public static DataTable getTableDoiTuongMienGiam()
        {
            //Gọi thủ tục getDoiTuongMienGiam
            return Models.connection.getData("spgetTableDoiTuongMienGiam", CommandType.StoredProcedure);
        }
        public static DoiTuongMienGiam getDoiTuongMienGiam(string maDT)
        {
            DataTable dt = new DataTable();
            dt = Models.connection.getData("spgetDoiTuongMienGiam", CommandType.StoredProcedure
                , new string[1] { "@MADT" }, new object[1] { maDT });
            var obj = dt.Rows[0].ItemArray;
            var data = obj.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();
            return new DoiTuongMienGiam(data);
        }
    }
}
