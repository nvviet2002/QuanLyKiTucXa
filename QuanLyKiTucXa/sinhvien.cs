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
    public partial class sinhvien : MetroFramework.Forms.MetroForm
    {
        private CSDL.SINHVIEN student;
        private CSDL.TAIKHOAN studentAccount;

        public sinhvien()
        {
            InitializeComponent();

        }

        public void LoadData()
        {
            studentAccount = (CSDL.TAIKHOAN)this.Tag;
            student = new CSDL.SINHVIEN();
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery($@"select * from SINHVIEN where MaTK = {studentAccount.MaTK}");
            if(tempTable.Rows.Count == 1)
            {
                student.SetDataSINHVIEN(tempTable);
            }
            else
            {
                MessageBox.Show("Loi lay sinh vien");
            }

            lbAccountName.Text = student.TenSV;

            SetEnableStudentControls(false);
        }

        private void SetEnableStudentControls(bool _enable)
        {
            //txtStudent_Class.Enabled = txtStudent_Faculty.Enabled = 
            txtStudent_PhoneNumber.Enabled = txtStudent_Address.Enabled = btnStudent_Save.Enabled = _enable;
            btnStudent_Change.Enabled = !_enable;
            /*= dtpStudent_BirthDay.Enabled = cbbStudent_Sex.Enabled =*/
        }

        private void LoadStudentData()
        {
            student.SetDataSINHVIEN(CSDL.CSDL.Instance.ExecuteQuery($@"select * from SINHVIEN"));
            txtStudent_Idenity.Text = student.MaSV;
            txtStudent_Name.Text = student.TenSV;
            txtStudent_Faculty.Text = student.Khoa;
            txtStudent_Class.Text = student.Lop;
            txtStudent_Address.Text = student.Diachi;
            txtStudent_Note.Text = student.Ghichu;
            txtStudent_PhoneNumber.Text = student.SDT;
            dtpStudent_BirthDay.Value = student.Ngaysinh;
            if (student.Gioitinh.Equals("Nam"))
            {
                cbbStudent_Sex.SelectedItem = "Nam";
            }
            else
            {
                cbbStudent_Sex.SelectedItem = "Nữ";
            }
        }

        private void llbLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void btnStudent_Change_Click(object sender, EventArgs e)
        {
            SetEnableStudentControls(true);
        }

        private void btnStudent_Save_Click(object sender, EventArgs e)
        {
            if (txtStudent_PhoneNumber.Text == "" || txtStudent_Address.Text == "" ||)
            {
                MetroMessageBox.Show(this, "Không được để trống dữ liệu", "Thông báo lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, 100);
                return;
            }

            student.Diachi = txtStudent_Address.Text;
            student.SDT = txtStudent_PhoneNumber.Text;
            student.Ghichu = txtStudent_Note.Text;
            if (CSDL.CSDL.Instance.ChangeStudentInfomation(student) >= 1)
            {
                MetroMessageBox.Show(this, "Cập nhật thông tin cá nhân thành công", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, 100);
            }
            else
            {
                MetroMessageBox.Show(this, "Cập nhật thông tin cá nhân thất bại", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning, 100);
            }
            LoadStudentData();
            SetEnableStudentControls(true);
        }

        private void sinhvien_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadStudentData();
        }
    }
}
