using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKiTucXa
{
    public partial class tk : MetroFramework.Forms.MetroForm
    {
        public Stages stage;
        public CSDL.TAIKHOAN account;
        public Action loadAccountList;
        public tk()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtAccountName.Text.Trim() == "" || txtPassWord.Text.Trim() == ""|| cbbAccountType.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDL.TAIKHOAN tempAccount = new CSDL.TAIKHOAN();
            tempAccount.TaiKhoan = txtAccountName.Text;
            tempAccount.MatKhau = txtPassWord.Text;
            tempAccount.LoaiTK = cbbAccountType.SelectedItem.ToString();
            tempAccount.Email = txtEmail.Text;
            tempAccount.Ghichu = txtNote.Text;
            if (stage == Stages.Add)
            {
                
                if (CSDL.CSDL.Instance.AddAccount(tempAccount))
                {
                    MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadAccountList.Invoke();
                    this.Close();
                    return;
                }
            }
            if (stage == Stages.Update)
            {

                if (CSDL.CSDL.Instance.UpdateAccount(tempAccount))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadAccountList.Invoke();
                    this.Close();
                    return;
                }
            }
        }

        private void tk_Load(object sender, EventArgs e)
        {
            if(stage == Stages.Update)
            {
                txtAccountName.Enabled = false;
                txtAccountName.Text = account.TaiKhoan;
                txtPassWord.Text = account.MatKhau;
                txtEmail.Text = account.Email;
                txtNote.Text = account.Ghichu;
                cbbAccountType.SelectedItem = account.LoaiTK;
            }
        }
    }
}
