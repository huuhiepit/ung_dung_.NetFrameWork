using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLTBDT;

namespace GUI_QLTBDT
{
    public partial class FrmLogin : Form
    {
        BUS_Admin busAdmin = new BUS_Admin();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult dg = MessageBox.Show("Bạn muốn trở về giao diện menu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                txtPass.PasswordChar = (char)0;
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsename.Text != "" && txtPass.Text != "")
            {
                if(busAdmin.Check_Login(txtUsename.Text, txtPass.Text))
                {
                    MessageBox.Show("Đăng nhập thành công!!!!!!!", "Thông báo");
                    Close();
                    mySave.KT = !mySave.KT;
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại, xin vui lòng thử lại!!!!!!!", "Thông báo");
                    txtPass.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ các thông tin!!!", "Cảnh báo");
            }
        }
    }
}
