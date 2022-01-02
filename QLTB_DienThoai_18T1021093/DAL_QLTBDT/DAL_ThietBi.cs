using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLTBDT
{
    public class DAL_ThietBi: DBConnection
    {
        public DataTable getThietBi()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ThietBi ORDER BY MaTB DESC", con);
            DataTable daThietBi = new DataTable();
            da.Fill(daThietBi);
            daThietBi.Columns.Add("STT");
            for (int i = 1; i <= daThietBi.Rows.Count; i++)
                daThietBi.Rows[i-1]["STT"] = i.ToString();
            return daThietBi;

        }
        public DataTable SearchTB(String TenTB, String HangDT)
        {
            String sql = string.Format("SELECT * FROM ThietBi WHERE TenTB LIKE '%{0}%' AND HangDT= '{1}'", TenTB, HangDT);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable daThietBi = new DataTable();
            da.Fill(daThietBi);
            daThietBi.Columns.Add("STT");
            for (int i = 1; i <= daThietBi.Rows.Count; i++)
                daThietBi.Rows[i - 1]["STT"] = i.ToString();
            return daThietBi;

        }

        public DataTable SearchTenTB(String TenTB)
        {
            String sql = string.Format("SELECT * FROM ThietBi WHERE TenTB LIKE '%{0}%'", TenTB);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable daThietBi = new DataTable();
            da.Fill(daThietBi);
            daThietBi.Columns.Add("STT");
            for (int i = 1; i <= daThietBi.Rows.Count; i++)
                daThietBi.Rows[i - 1]["STT"] = i.ToString();
            return daThietBi;

        }
        public DataTable SearchHangTB(String HangTB)
        {
            String sql = string.Format("SELECT * FROM ThietBi WHERE HangDT= '{0}'", HangTB);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable daThietBi = new DataTable();
            da.Fill(daThietBi);
            daThietBi.Columns.Add("STT");
            for (int i = 1; i <= daThietBi.Rows.Count; i++)
                daThietBi.Rows[i - 1]["STT"] = i.ToString();
            return daThietBi;

        }
        public void InsertThietBi(String TenTB, String HangDT, String MauSac, String ManHinh, String HeDieuHanh, String Chip, String RAM, String BoNhoTrong, int Gia, int SoLuongTon)
        {
            try
            {
                con.Open();

                String sql = string.Format("INSERT INTO ThietBi( TenTB, HangDT, MauSac, ManHinh, HeDieuHanh, Chip, RAM, BoNhoTrong, Gia, SoLuongTon)" +
                    " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')"
                    , TenTB, HangDT, MauSac, ManHinh, HeDieuHanh, Chip, RAM, BoNhoTrong, Gia, SoLuongTon);

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Thêm thiết bị điện thoại thành công!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Có lỗi xảy ra khi truy vấn đến server, xin vui lòng kiểm tra lại!!!!!!!" + e);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateThietBi(int MaTB ,String TenTB, String HangDT, String MauSac, String ManHinh, String HeDieuHanh, String Chip, String RAM, String BoNhoTrong, int Gia, int SoLuongTon)
        {
            try
            {
                con.Open();

                String sql = string.Format("UPDATE ThietBi SET TenTB='{0}', HangDT='{1}', MauSac= '{2}', ManHinh= '{3}', " +
                    "HeDieuHanh= '{4}', Chip= '{5}', RAM= '{6}', BoNhoTrong= '{7}', Gia= '{8}', SoLuongTon= '{9}' WHERE MaTB= '{10}'"
                    , TenTB, HangDT, MauSac, ManHinh, HeDieuHanh, Chip, RAM, BoNhoTrong, Gia, SoLuongTon, MaTB);

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Sửa chữa thông tin thiết bị điện thoại thành công!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Có lỗi xảy ra khi truy vấn đến server, xin vui lòng kiểm tra lại!!!!!!!" + e);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteThietBi(int MaTB)
        {
            try
            {
                con.Open();

                String sql = string.Format("DELETE ThietBi WHERE MaTB= '{0}'", MaTB);

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Xóa thiết bị điện thoại thành công!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Có lỗi xảy ra khi truy vấn đến server, xin vui lòng kiểm tra lại!!!!!!!" + e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
