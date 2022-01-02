using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLTBDT;
using System.Data;
using System.Data.SqlClient;

namespace BUS_QLTBDT
{
    public class BUS_Admin
    {
        DAL_Login login = new DAL_Login();
        public bool Check_Login(String user, String pass)
        {
            return login.Check_Login(user, pass);
        }
    }
}
