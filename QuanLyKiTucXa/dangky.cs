using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace QuanLyKiTucXa
{
    public partial class dangky : MetroFramework.Forms.MetroForm  
    {
        public CSDL.TAIKHOAN account;

        public Action refreshAccountData;

        public dangky()
        {
            InitializeComponent();
        }

        private void LoadAccountData()
        {
            txtAccountName.Text = account.TaiKhoan;
            txtPassWord.Text = account.MatKhau;
            txtEmail.Text = account.Email;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtNewPassword.Text.Trim() == "" || txtNewPassword.Text != txtNewPasswordAgain.Text || txtEmail.Text.Trim() == "")
            {
                Close();
                return;
            }
            account.MatKhau = txtNewPassword.Text;
            account.Email = txtEmail.Text;
            if (CSDL.CSDL.Instance.UpdateAccount(account))
            {
                MessageBox.Show("Cập nhập tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (account.LoaiTK != "Sinh viên")
                {
                    refreshAccountData.Invoke();
                }
                
                Close();
                return;
            }
            
        }

        private void dangky_Load(object sender, EventArgs e)
        {
            LoadAccountData();
        }
    }
}
