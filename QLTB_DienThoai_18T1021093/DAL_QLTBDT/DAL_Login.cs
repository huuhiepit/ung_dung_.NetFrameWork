using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL_QLTBDT
{
    public class DAL_Login: DBConnection
    {
        public bool Check_Login( String user, String pass)
        {
            try
            {
                con.Open();

                String sql = string.Format("SELECT * FROM Admin WHERE UserName= '{0}' and Password= '{1}'", user, pass);

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable daLogin = new DataTable();
                da.Fill(daLogin);
                if(daLogin != null)
                {
                    foreach( DataRow row in daLogin.Rows)
                    {
                        if (row["UserName"].ToString().Equals(user) && row["Password"].ToString().Equals(pass))
                            return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Có lỗi xảy ra khi truy vấn đến server, xin vui lòng kiểm tra lại!!!!!!!" + e);
            }
            finally
            {
                con.Close();
            }
            return false;
        }
    }
}
