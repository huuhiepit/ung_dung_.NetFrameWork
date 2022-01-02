using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLTBDT
{
    public class DBConnection
    {
        public static SqlConnection con = new SqlConnection("server=LAPTOP-T2UFPCLF;uid=sa;pwd=hiep123;database=QLTB_DienThoai_18T1021093");
    }
}
