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
    public class BUS_ThietBi
    {
        DAL_ThietBi daThietBi = new DAL_ThietBi();
        public DataTable getThietBi()
        {
            return daThietBi.getThietBi();
        } 
        public DataTable SearchTB(String TenTB, String HangDT)
        {
            return daThietBi.SearchTB(TenTB, HangDT);
        }
        public DataTable SearchTenTB(String TenTB)
        {
            return daThietBi.SearchTenTB(TenTB);
        }
        public DataTable SearchHangTB(String HangDT)
        {
            return daThietBi.SearchHangTB(HangDT);
        }

        public void InsertThietBi(String TenTB, String HangDT, String MauSac, String ManHinh, String HeDieuHanh, String Chip, String RAM, String BoNhoTrong, int Gia, int SoLuongTon)
        {
            daThietBi.InsertThietBi(TenTB, HangDT, MauSac, ManHinh, HeDieuHanh, Chip, RAM, BoNhoTrong, Gia, SoLuongTon);
        }
        public void UpdateThietBi(int MaTB ,String TenTB, String HangDT, String MauSac, String ManHinh, String HeDieuHanh, String Chip, String RAM, String BoNhoTrong, int Gia, int SoLuongTon)
        {
            daThietBi.UpdateThietBi( MaTB, TenTB, HangDT, MauSac, ManHinh, HeDieuHanh, Chip, RAM, BoNhoTrong, Gia, SoLuongTon);
        }
        public void DeleteThietBi(int MaTB)
        {
            daThietBi.DeleteThietBi(MaTB);
        }
    }
}
