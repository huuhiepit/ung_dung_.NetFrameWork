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
    public partial class FrmQLThietBi : Form
    {
        int maTB;
        bool lock1, lock2;
        BUS_ThietBi busThietBi = new BUS_ThietBi();
        public FrmQLThietBi()
        {
            InitializeComponent();
            lock1 = lock2 = true;
            Lock_Unlock1(lock1);
            Lock_Unlock2(lock2);
        }
        void Lock_Unlock1(bool lock1)
        {
            txtTenTB.Enabled = cmbHangDT.Enabled = txtManHinh.Enabled = txtMauSac.Enabled = txtHDH.Enabled = lock1;
            btnAdd.Enabled = txtChip.Enabled = txtRam.Enabled = txtBNT.Enabled = txtSLTK.Enabled = txtGia.Enabled = lock1;
        }
        void Lock_Unlock2(bool lock2)
        {
            dgvThietBi.Enabled = btnSearch.Enabled = cmbSearch.Enabled = txtSearch.Enabled = btnAdd.Enabled = lock2;
            btnUpdate.Enabled = btnDelete.Enabled = !lock2;
        }
        void Clear()
        {
            lock1 = !lock1;
            Lock_Unlock1(lock1);
            lock2 = !lock2;
            Lock_Unlock1(lock2);
            txtTenTB.Text = "";
            cmbHangDT.Text = "Chọn hãng hiệu";
            txtMauSac.Text = "";
            txtManHinh.Text = "";
            txtHDH.Text = "";
            txtChip.Text = "";
            txtRam.Text = "";
            txtBNT.Text = "";
            txtGia.Text = "";
            txtSLTK.Text = "";
            txtSearch.Text = "";
            cmbSearch.Text = "Chọn hãng tìm kiếm";
        }
        private void FrmQLThietBi_Load(object sender, EventArgs e)
        {
            dgvThietBi.DataSource = busThietBi.getThietBi();
        }


        private void btnClear_Click(object sender, EventArgs e)
        { 
           Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn muốn trở về giao diện menu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Hide();
                FrmMenu menu = new FrmMenu();
                menu.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtTenTB.Text != "" && cmbHangDT.Text != "" && txtMauSac.Text != "" && txtGia.Text != "" && txtSLTK.Text != "")
            {
                lock1 = !lock1;
                Lock_Unlock1(lock1);
                int gia = int.Parse(txtGia.Text);
                int sltk = int.Parse(txtSLTK.Text);

                busThietBi.InsertThietBi(txtTenTB.Text, cmbHangDT.Text, txtMauSac.Text, txtManHinh.Text, txtHDH.Text, txtChip.Text
                    , txtRam.Text, txtBNT.Text, gia, sltk);
                dgvThietBi.DataSource = busThietBi.getThietBi();
                MessageBox.Show("Thêm thiết bị điện thoại" + txtTenTB.Text + "thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm thiết bị điện thoại thất bại, xin vui lòng nhập đầy đủ các thông tin yêu cầu", "Thông báo");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text!= "")
            {
                dgvThietBi.DataSource = busThietBi.SearchTenTB(txtSearch.Text);
            }
            if (cmbSearch.Text != "" && txtSearch.Text == "")
            {
                dgvThietBi.DataSource = busThietBi.SearchHangTB(cmbSearch.Text);
            }
            if (txtSearch.Text != "" && cmbSearch.Text != "Chọn hãng tìm kiếm")
            {
                dgvThietBi.DataSource = busThietBi.SearchTB(txtSearch.Text, cmbSearch.Text);
            }
            if (txtSearch.Text == "" && cmbSearch.Text == "Chọn hãng tìm kiếm" || txtSearch.Text == "" && cmbSearch.Text == "")
            {
                dgvThietBi.DataSource = busThietBi.getThietBi();
            }

        }

        private void dgvThietBi_Click(object sender, EventArgs e)
        {
            if (lock1)
            {
                int i = dgvThietBi.CurrentRow.Index;

                String MaTB = dgvThietBi[0, i].Value.ToString();
                if (MaTB != "")
                {
                    maTB = int.Parse(MaTB);
                }
                txtTenTB.Text = dgvThietBi[1, i].Value.ToString();
                cmbHangDT.Text = dgvThietBi[2, i].Value.ToString();
                txtMauSac.Text = dgvThietBi[3, i].Value.ToString();
                txtManHinh.Text = dgvThietBi[4, i].Value.ToString();
                txtHDH.Text = dgvThietBi[5, i].Value.ToString();
                txtChip.Text = dgvThietBi[6, i].Value.ToString();
                txtRam.Text = dgvThietBi[7, i].Value.ToString();
                txtBNT.Text = dgvThietBi[8, i].Value.ToString();
                txtGia.Text = dgvThietBi[9, i].Value.ToString();
                txtSLTK.Text = dgvThietBi[10, i].Value.ToString();
                lock2 = !lock2;
                Lock_Unlock2(lock2);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTenTB.Text != "" && cmbHangDT.Text != "" && txtMauSac.Text != "" && txtGia.Text != "" && txtSLTK.Text != "")
            {
                int gia = int.Parse(txtGia.Text);
                int sltk = int.Parse(txtSLTK.Text);

                busThietBi.UpdateThietBi( maTB, txtTenTB.Text, cmbHangDT.Text, txtMauSac.Text, txtManHinh.Text, txtHDH.Text, txtChip.Text
                    , txtRam.Text, txtBNT.Text, gia, sltk);
                dgvThietBi.DataSource = busThietBi.getThietBi();
                MessageBox.Show("Sửa thiết bị điện thoại" + txtTenTB.Text + "thành công!!!", "Thông báo");
                lock2 = !lock2;
                Lock_Unlock2(lock2);
                Clear();
            }
            else
            {
                MessageBox.Show("Sửa thiết bị điện thoại thất bại!!!", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        { 
            DialogResult dg = MessageBox.Show("Bạn có muốn xóa thiết bị điện thoại" + txtTenTB.Text + "này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                busThietBi.DeleteThietBi(maTB);
                dgvThietBi.DataSource = busThietBi.getThietBi();
                MessageBox.Show("Xóa thiết bị điện thoại" + txtTenTB.Text + "thành công!!!", "Thông báo");
                lock2 = !lock2;
                Lock_Unlock2(lock2);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmView print = new FrmView();
            print.Show();
        }
    }
}
