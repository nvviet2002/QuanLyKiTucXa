using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace QuanLyKiTucXa
{
    public partial class admin : MetroFramework.Forms.MetroForm
    {
        DataTable accountList;
        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        private void LoadAccountList()
        {
            accountList = CSDL.CSDL.Instance.ExecuteQuery($@"select * from TAIKHOAN");
            dgvShow.DataSource = NormalizeAccountList(accountList);
            LoadSum();
        }

        DataTable NormalizeAccountList(DataTable _table)
        {
            DataTable temp = _table;
            temp.Columns["TaiKhoan"].ColumnName = "Tài khoản";
            temp.Columns["MatKhau"].ColumnName = "Mật khẩu";
            temp.Columns["Email"].ColumnName = "Email";
            temp.Columns["LoaiTK"].ColumnName = "Loại tài khoản";
            temp.Columns["GhiChu"].ColumnName = "Ghi chú";
            return temp;
        }

        void LoadSum()
        {
            lbSum.Text = accountList.Rows.Count.ToString();
        }

        private void cbbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbAccountType.SelectedItem != null)
            {
                accountList = CSDL.CSDL.Instance.Search("LoaiTK", cbbAccountType.SelectedItem.ToString(), "TAIKHOAN", true);
                dgvShow.DataSource = NormalizeAccountList(accountList);
                LoadSum();
            }
        }

        private void btnRoomType_Add_Click(object sender, EventArgs e)
        {
            tk form = new tk();
            form.stage = Stages.Add;
            form.loadAccountList += LoadAccountList;
            form.ShowDialog();
        }

        private void btnRoomType_Edit_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn tài khoản cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            CSDL.TAIKHOAN tempAccount = new CSDL.TAIKHOAN();
            tempAccount.TaiKhoan = dgvShow.SelectedRows[0].Cells["Tài khoản"].Value.ToString();
            tempAccount.MatKhau = dgvShow.SelectedRows[0].Cells["Mật khẩu"].Value.ToString();
            tempAccount.LoaiTK = dgvShow.SelectedRows[0].Cells["Loại tài khoản"].Value.ToString();
            tempAccount.Email = dgvShow.SelectedRows[0].Cells["Email"].Value.ToString();
            tempAccount.Ghichu = dgvShow.SelectedRows[0].Cells["Ghi chú"].Value.ToString();
            tk form = new tk();
            form.stage = Stages.Update;
            form.account = tempAccount;
            form.loadAccountList += LoadAccountList;
            form.ShowDialog();
        }

        private void btnRoomType_Delete_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn tài khoản cần xóa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if(CSDL.CSDL.Instance.DeleteAccount(dgvShow.SelectedRows[0].Cells["Tài khoản"].Value.ToString()))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                LoadAccountList();
                return;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            nhanvien form1 = new nhanvien();
            form1.Tag =this.Tag;
            this.Hide();
            form1.ShowDialog();
            this.Show();
        }
    }
}
