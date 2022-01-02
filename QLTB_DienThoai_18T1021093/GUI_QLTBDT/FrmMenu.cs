using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLTBDT
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            Lock_Unlock(mySave.KT);
        }
        void Lock_Unlock(Boolean kt)
        {
            menuDangNhap.Enabled = kt;
            menuDangXuat.Enabled = menuQLHTDT.Enabled = !kt;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn muốn đóng chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void quảnLýThiếtBịĐiệnThoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQLThietBi ql = new FrmQLThietBi();
            ql.Show();
            this.Hide();
            
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng xuất thành công!!!", "Thông báo");
            Lock_Unlock(!mySave.KT);
        }

        private void FrmMenu_Activated(object sender, EventArgs e)
        {
            Lock_Unlock(mySave.KT);
        }
    }
}
