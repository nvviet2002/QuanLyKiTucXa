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
    public partial class ThongTinNhanVien : MetroFramework.Forms.MetroForm
    {
        public Stages stage;

        public ThongTinNhanVien()
        {
            InitializeComponent();
        }



        private void btnStaff_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStaff_Save_Click(object sender, EventArgs e)
        {
            
            if (txtStaff_AccountName.Text.Trim() == "" || txtStaff_Password.Text.Trim() == ""
               || txtStaff_ID.Text.Trim() == "" || txtStaff_Name.Text.Trim() == ""
               || txtStaff_Phone.Text.Trim() == "" || cbbStaff_AccountType.SelectedItem == null
               || cbbStaff_Position.SelectedItem == null || cbbStaff_Sex.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            
            CSDL.TAIKHOAN tempAccount = new CSDL.TAIKHOAN();
            tempAccount.SetTAIKHOAN( txtStaff_AccountName.Text, txtStaff_Password.Text, txtStaff_Email.Text,
                txtStaff_Note.Text, cbbStaff_AccountType.SelectedItem.ToString());

            CSDL.NHANVIEN tempStaff = new CSDL.NHANVIEN();
            tempStaff.SetNHANVIEN(txtStaff_ID.Text, txtStaff_Name.Text, dtpStaff_Birthday.Value,
                cbbStaff_Sex.SelectedItem.ToString(), txtStaff_Phone.Text,
                cbbStaff_Position.SelectedItem.ToString(), txtStaff_Note.Text, txtStaff_AccountName.Text);
            if (stage == Stages.Add)
            {
                ;
                if (CSDL.CSDL.Instance.AddAccount(tempAccount) && CSDL.CSDL.Instance.AddStaff(tempStaff))
                {
                    MessageBox.Show("Thêm thành công thông tin nhân viên", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ((nhanvien)this.Tag).LoadStaffList();
                    this.Close();
                }
                return;
            }
            if (stage == Stages.Update)
            {
                
                if (CSDL.CSDL.Instance.UpdateStaff(tempStaff) && CSDL.CSDL.Instance.UpdateAccount(tempAccount))
                {
                    MessageBox.Show("Cập nhật thành công thông tin nhân viên", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ((nhanvien)this.Tag).LoadStaffList();
                    this.Close();
                }
                return;
            }

        }

        public void SetControls(Stages _stage)
        {
            if(_stage == Stages.Add)
            {
                return;
            }
            if(_stage == Stages.View)
            {
                txtStaff_AccountName.Enabled = txtStaff_AccountNote.Enabled = txtStaff_Email.Enabled
                = txtStaff_ID.Enabled = txtStaff_Name.Enabled = txtStaff_Note.Enabled =
                txtStaff_Password.Enabled = txtStaff_Phone.Enabled = cbbStaff_AccountType.Enabled
                = cbbStaff_Position.Enabled = cbbStaff_Sex.Enabled = dtpStaff_Birthday.Enabled = false;
                btnStaff_Save.Enabled = true;
                return;
            }
            if (_stage == Stages.Update)
            {
                txtStaff_ID.Enabled = txtStaff_AccountName.Enabled = false;
                return;
            }
        }
        

        public void SetStaffInfo(string _maNV)
        {
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select * from NHANVIEN 
            inner join TAIKHOAN on NHANVIEN.TaiKhoan = TAIKHOAN.TaiKhoan where MaNV = '{_maNV}'");
            txtStaff_AccountName.Text = temp.Rows[0]["TaiKhoan"].ToString();
            txtStaff_Password.Text = temp.Rows[0]["MatKhau"].ToString();
            txtStaff_ID.Text = temp.Rows[0]["MaNV"].ToString();
            txtStaff_Email.Text = temp.Rows[0]["Email"].ToString();
            txtStaff_Name.Text = temp.Rows[0]["TenNV"].ToString();
            txtStaff_Phone.Text = temp.Rows[0]["SDT"].ToString();
            txtStaff_AccountNote.Text = temp.Rows[0]["GhiChu"].ToString();
            cbbStaff_AccountType.SelectedItem = temp.Rows[0]["LoaiTK"].ToString();
            cbbStaff_Position.SelectedItem = temp.Rows[0]["ChucVu"].ToString();
            cbbStaff_Sex.SelectedItem = temp.Rows[0]["GioiTinh"].ToString();
            dtpStaff_Birthday.Value = ((DateTime)temp.Rows[0]["NgaySinh"]);


        }

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
            SetControls(stage);
        }
    }
}
