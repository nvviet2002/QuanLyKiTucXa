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
using MetroFramework;

namespace QuanLyKiTucXa
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private char passwordChar;
        public Form1()
        {
            InitializeComponent();
            InitializeControls();
            this.Focus();
            txtAccountName.Focus();

        }

        private void InitializeControls()
        {
            passwordChar = txtPassword.PasswordChar;
            ckbHidePassword.Checked = false;
        }

        private void InitializeComponent()
        {
            this.txtAccountName = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.btnSignIn = new MetroFramework.Controls.MetroButton();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.llbSignUp = new System.Windows.Forms.LinkLabel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.ckbHidePassword = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
            // 
            // txtAccountName
            // 
            // 
            // 
            // 
            this.txtAccountName.CustomButton.Image = null;
            this.txtAccountName.CustomButton.Location = new System.Drawing.Point(149, 2);
            this.txtAccountName.CustomButton.Name = "";
            this.txtAccountName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtAccountName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountName.CustomButton.TabIndex = 1;
            this.txtAccountName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountName.CustomButton.UseSelectable = true;
            this.txtAccountName.CustomButton.Visible = false;
            this.txtAccountName.Lines = new string[0];
            this.txtAccountName.Location = new System.Drawing.Point(81, 209);
            this.txtAccountName.MaxLength = 32767;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.PasswordChar = '\0';
            this.txtAccountName.PromptText = "Nhập tài khoản";
            this.txtAccountName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountName.SelectedText = "";
            this.txtAccountName.SelectionLength = 0;
            this.txtAccountName.SelectionStart = 0;
            this.txtAccountName.ShortcutsEnabled = true;
            this.txtAccountName.Size = new System.Drawing.Size(177, 30);
            this.txtAccountName.TabIndex = 2;
            this.txtAccountName.UseSelectable = true;
            this.txtAccountName.WaterMark = "Nhập tài khoản";
            this.txtAccountName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(149, 2);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(81, 267);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PromptText = "Nhập mật khẩu";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(177, 30);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMark = "Nhập mật khẩu";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(36, 339);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(83, 34);
            this.btnSignIn.TabIndex = 5;
            this.btnSignIn.Text = "Đăng nhập";
            this.btnSignIn.UseSelectable = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(175, 339);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 34);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // llbSignUp
            // 
            this.llbSignUp.AutoSize = true;
            this.llbSignUp.Location = new System.Drawing.Point(109, 385);
            this.llbSignUp.Name = "llbSignUp";
            this.llbSignUp.Size = new System.Drawing.Size(73, 13);
            this.llbSignUp.TabIndex = 7;
            this.llbSignUp.TabStop = true;
            this.llbSignUp.Text = "Đăng ký ngay";
            // 
            // metroPanel3
            // 
            this.metroPanel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.metroPanel3.BackgroundImage = global::QuanLyKiTucXa.Properties.Resources.tải_xuống;
            this.metroPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(36, 263);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(34, 34);
            this.metroPanel3.TabIndex = 3;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackgroundImage = global::QuanLyKiTucXa.Properties.Resources.icon_login;
            this.metroPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(36, 205);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(34, 34);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.metroPanel1.BackgroundImage = global::QuanLyKiTucXa.Properties.Resources.images;
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(36, 39);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(222, 131);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // ckbHidePassword
            // 
            this.ckbHidePassword.AutoSize = true;
            this.ckbHidePassword.Checked = true;
            this.ckbHidePassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbHidePassword.Location = new System.Drawing.Point(81, 303);
            this.ckbHidePassword.Name = "ckbHidePassword";
            this.ckbHidePassword.Size = new System.Drawing.Size(101, 15);
            this.ckbHidePassword.TabIndex = 8;
            this.ckbHidePassword.Text = "Hiện mật khẩu";
            this.ckbHidePassword.UseSelectable = true;
            this.ckbHidePassword.CheckedChanged += new System.EventHandler(this.ckbHidePassword_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSignIn;
            this.ClientSize = new System.Drawing.Size(307, 418);
            this.Controls.Add(this.ckbHidePassword);
            this.Controls.Add(this.llbSignUp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ckbHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHidePassword.Checked)
            {
                txtPassword.PasswordChar = passwordChar;
                
            }
            else
            {
                txtPassword.PasswordChar = '*';
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK == MetroMessageBox.Show(this, "Bạn có muốn thoát chương trình không ?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, 100)){
                Application.Exit();
            }
        }

        private void SignInAutomaticly()
        {
            txtAccountName.Text = txtPassword.Text = "Nhanvien1";
            btnSignIn_Click(new object(),new EventArgs());
        }


        private void btnSignIn_Click(object sender, EventArgs e)
        {
            DataTable table = CSDL.CSDL.Instance.ExecuteQuery(
                $@"select * from TAIKHOAN where TaiKhoan = '{txtAccountName.Text}' and MatKhau = '{txtPassword.Text}' ");
            if(table.Rows.Count == 1)
            {
                
                CSDL.TAIKHOAN tempTK = new CSDL.TAIKHOAN();
                tempTK.MaTK = (int) table.Rows[0]["MaTK"];
                tempTK.TaiKhoan1 = table.Rows[0]["TaiKhoan"].ToString();
                tempTK.MatKhau = table.Rows[0]["MatKhau"].ToString();
                tempTK.LoaiTK = table.Rows[0]["LoaiTK"].ToString();
                tempTK.Email = table.Rows[0]["Email"].ToString();
                tempTK.Ghichu = table.Rows[0]["GhiChu"].ToString();
                if(tempTK.LoaiTK.Equals("Sinh viên"))
                {
                    sinhvien form = new sinhvien();
                    form.Tag = tempTK;
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                    return;
                }
                if (tempTK.LoaiTK.Equals("Nhân viên"))
                {
                    nhanvien form = new nhanvien();
                    form.Tag = tempTK;
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SignInAutomaticly();
        }
    }
}
