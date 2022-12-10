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
    public partial class ThongTinSinhVien : MetroFramework.Forms.MetroForm 
    {
        public Stages stage;

        public ThongTinSinhVien()
        {
            InitializeComponent();
        }

        private void txtStudent_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetControls(Stages _stage)
        {
            if (_stage == Stages.Add)
            {
                return;
            }
            if (_stage == Stages.View)
            {
                txtStudent_AccountName.Enabled = txtStudent_AccountNote.Enabled = txtStudent_Email.Enabled
                = txtStudent_ID.Enabled = txtStudent_Name.Enabled = txtStudent_Note.Enabled =
                txtStudent_Password.Enabled = txtStudent_Phone.Enabled = cbbStudent_AccountType.Enabled
                = cbbStudent_Sex.Enabled = dtpStudent_Birthday.Enabled = txtStudent_Faculty.Enabled =
                txtStudent_Class.Enabled = txtStudent_Address.Enabled = false;
                btnStudent_Save.Enabled = true;
                return;
            }
            if (_stage == Stages.Update)
            {
                txtStudent_ID.Enabled = txtStudent_AccountName.Enabled = false;
                return;
            }
        }

        private void ThongTinSinhVien_Load(object sender, EventArgs e)
        {
            SetControls(stage);
        }

        public void SetStudentInfo(string _maSv)
        {
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select * from SINHVIEN 
            inner join TAIKHOAN on SINHVIEN.TaiKhoan = TAIKHOAN.TaiKhoan where MaSV = '{_maSv}'");
            txtStudent_AccountName.Text = temp.Rows[0]["TaiKhoan"].ToString();
            txtStudent_Password.Text = temp.Rows[0]["MatKhau"].ToString();
            txtStudent_ID.Text = temp.Rows[0]["MaSV"].ToString();
            txtStudent_Email.Text = temp.Rows[0]["Email"].ToString();
            txtStudent_Name.Text = temp.Rows[0]["TenSV"].ToString();
            txtStudent_Phone.Text = temp.Rows[0]["SDT"].ToString();
            txtStudent_Faculty.Text = temp.Rows[0]["Khoa"].ToString();
            txtStudent_Class.Text = temp.Rows[0]["Lop"].ToString();
            txtStudent_AccountNote.Text = temp.Rows[0]["GhiChu"].ToString();
            cbbStudent_AccountType.SelectedItem = temp.Rows[0]["LoaiTK"].ToString();
            txtStudent_Address.Text = temp.Rows[0]["DiaChi"].ToString();
            cbbStudent_Sex.SelectedItem = temp.Rows[0]["GioiTinh"].ToString();
            dtpStudent_Birthday.Value = ((DateTime)temp.Rows[0]["NgaySinh"]);


        }

        private void btnStudent_Save_Click(object sender, EventArgs e)
        {
            if (txtStudent_AccountName.Text.Trim() == "" || txtStudent_Password.Text.Trim() == ""
               || txtStudent_ID.Text.Trim() == "" || txtStudent_Name.Text.Trim() == ""
               || txtStudent_Phone.Text.Trim() == "" || cbbStudent_AccountType.SelectedItem == null
               || txtStudent_Address.Text.Trim() == ""|| txtStudent_Class.Text.Trim() == ""
               || txtStudent_Faculty.Text.Trim() == ""|| cbbStudent_Sex.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }


            CSDL.TAIKHOAN tempAccount = new CSDL.TAIKHOAN();
            tempAccount.SetTAIKHOAN(txtStudent_AccountName.Text, txtStudent_Password.Text, txtStudent_Email.Text,
                txtStudent_Note.Text, cbbStudent_AccountType.SelectedItem.ToString());

            CSDL.SINHVIEN tempStudent = new CSDL.SINHVIEN();
            tempStudent.SetDataSINHVIEN(txtStudent_ID.Text, txtStudent_Name.Text, dtpStudent_Birthday.Value,
                cbbStudent_Sex.SelectedItem.ToString(),txtStudent_Faculty.Text,txtStudent_Class.Text,
                txtStudent_Phone.Text,txtStudent_Address.Text, txtStudent_Note.Text, txtStudent_AccountName.Text);
            if (stage == Stages.Add)
            {
                ;
                if (CSDL.CSDL.Instance.AddAccount(tempAccount) && CSDL.CSDL.Instance.AddStudent(tempStudent))
                {
                    MessageBox.Show("Thêm thành công thông tin nhân viên", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ((nhanvien)this.Tag).LoadStudentList();
                    this.Close();
                }
                return;
            }
            if (stage == Stages.Update)
            {

                if (CSDL.CSDL.Instance.UpdateStudent(tempStudent) && CSDL.CSDL.Instance.UpdateAccount(tempAccount))
                {
                    MessageBox.Show("Cập nhật thành công thông tin nhân viên", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ((nhanvien)this.Tag).LoadStudentList();
                    this.Close();
                }
                return;
            }
        }
    }
}
