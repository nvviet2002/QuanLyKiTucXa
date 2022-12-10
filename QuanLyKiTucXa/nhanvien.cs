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
    public partial class nhanvien : MetroFramework.Forms.MetroForm
    {
        public CSDL.TAIKHOAN staffAccount;
        public CSDL.NHANVIEN staff;
        public DataTable staffList;
        public DataTable studentList;

        public nhanvien()
        {
            InitializeComponent();
        }

        public void LoadAccountData()
        {
            staffAccount = (CSDL.TAIKHOAN)this.Tag;
            staff = new CSDL.NHANVIEN();
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery($@"select * from NHANVIEN where TaiKhoan = '{staffAccount.TaiKhoan}'");
            if (tempTable.Rows.Count == 1)
            {
                staff.SetDataNHANVIEN(tempTable);
            }
            else
            {
                MessageBox.Show("Loi lay nhan vien");
            }

            lbAccountName.Text = staff.TenNV;
        }

        private void nhanvien_Load(object sender, EventArgs e)
        {
            LoadAccountData();
            LoadStaffList();
            LoadStudentList();
        }





        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        #region Staff


        public void LoadStaffList()
        {
            staffList = CSDL.CSDL.Instance.ExecuteQuery($@"select * from NHANVIEN");

            dgvStaff_Show.DataSource = NormalizeStaffList(staffList);
        }

        DataTable NormalizeStaffList(DataTable _table)
        {
            DataTable temp = staffList;
            temp.Columns["MaNV"].ColumnName = "Mã nhân viên";
            temp.Columns["TenNV"].ColumnName = "Tên nhân viên";
            temp.Columns["GioiTinh"].ColumnName = "Giới tính";
            temp.Columns["ChucVu"].ColumnName = "Chức vụ";
            temp.Columns["NgaySinh"].ColumnName = "Ngày sinh";
            temp.Columns["SDT"].ColumnName = "Số điện thoại";
            temp.Columns["TaiKhoan"].ColumnName = "Tài khoản";
            return temp;
        }

        private void btnStaff_Search_Click(object sender, EventArgs e)
        {
            if(cbbStaff_SearchType.SelectedItem == null)
            {
                dgvStaff_Show.DataSource = NormalizeStaffList(staffList);
                return;
            }
            if (cbbStaff_SearchType.SelectedItem == "Mã nhân viên")
            {
                staffList = CSDL.CSDL.Instance.Search("MaNV", txtStaff_SearchInput.Text,
                    "NHANVIEN",false);
                dgvStaff_Show.DataSource = NormalizeStaffList(staffList);
                return;
            }
            if (cbbStaff_SearchType.SelectedItem == "Tên nhân viên")
            {
                staffList = CSDL.CSDL.Instance.Search("TenNV", txtStaff_SearchInput.Text,
                    "NHANVIEN",true);
                dgvStaff_Show.DataSource = NormalizeStaffList(staffList);
                return;
            }
        }

        private void btnStaff_Add_Click(object sender, EventArgs e)
        {
            ThongTinNhanVien form = new ThongTinNhanVien();
            form.Tag = this;
            form.stage = Stages.Add;
            form.ShowDialog();
        }

        private void btnStaff_Delete_Click(object sender, EventArgs e)
        {
            if(dgvStaff_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string ma = (string)dgvStaff_Show.SelectedRows[0].Cells[0].Value;
            string matk = (string)dgvStudent_Show.SelectedRows[0].Cells["Tài khoản"].Value;
            if (CSDL.CSDL.Instance.DeleteStaff(ma) && CSDL.CSDL.Instance.DeleteAccount(matk))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadStaffList();
                return;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dgvStaff_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn nhân viên cần xem chi tiết", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            ThongTinNhanVien temp = new ThongTinNhanVien();
            temp.SetStaffInfo(dgvStaff_Show.SelectedRows[0].Cells["Mã nhân viên"].Value.ToString());
            temp.stage = Stages.View;
            temp.ShowDialog();
        }

        private void btnSstaff_Edit_Click(object sender, EventArgs e)
        {
            if (dgvStaff_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn nhân viên cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            ThongTinNhanVien temp = new ThongTinNhanVien();
            temp.SetStaffInfo(dgvStaff_Show.SelectedRows[0].Cells["Mã nhân viên"].Value.ToString());
            temp.stage = Stages.Update;
            temp.Tag = this;
            temp.ShowDialog();
        }
        #endregion

        #region Student
        public void LoadStudentList()
        {
            studentList = CSDL.CSDL.Instance.ExecuteQuery($@"select * from SINHVIEN");

            dgvStudent_Show.DataSource = NormalizeStudentList(studentList);
        }

        DataTable NormalizeStudentList(DataTable _table)
        {
            DataTable temp = studentList;
            temp.Columns["MaSV"].ColumnName = "Mã sinh viên";
            temp.Columns["TenSV"].ColumnName = "Tên sinh viên";
            temp.Columns["GioiTinh"].ColumnName = "Giới tính";
            temp.Columns["Lop"].ColumnName = "Lớp";
            temp.Columns["NgaySinh"].ColumnName = "Ngày sinh";
            temp.Columns["SDT"].ColumnName = "Số điện thoại";
            temp.Columns["DiaChi"].ColumnName = "Địa chỉ";
            temp.Columns["TaiKhoan"].ColumnName = "Tài khoản";
            return temp;
        }

        #endregion

        private void btnStudent_Search_Click(object sender, EventArgs e)
        {
            if (cbbStudent_SearchType.SelectedItem == null)
            {
                dgvStudent_Show.DataSource = NormalizeStudentList(studentList);
                return;
            }
            if (cbbStudent_SearchType.SelectedItem == "Mã sinh viên")
            {
                studentList = CSDL.CSDL.Instance.Search("MaSV", txtStudent_SearchInput.Text,
                    "SINHVIEN", false);
                dgvStudent_Show.DataSource = NormalizeStudentList(studentList);
                return;
            }
            if (cbbStudent_SearchType.SelectedItem == "Tên sinh viên")
            {
                studentList = CSDL.CSDL.Instance.Search("TenSV", txtStudent_SearchInput.Text,
                    "SINHVIEN", true);
                dgvStudent_Show.DataSource = NormalizeStudentList(studentList);
                return;
            }
        }

        private void btnStudent_Add_Click(object sender, EventArgs e)
        {
            ThongTinSinhVien form = new ThongTinSinhVien();
            form.Tag = this;
            form.stage = Stages.Add;
            form.ShowDialog();
        }

        private void btnStudent_Detail_Click(object sender, EventArgs e)
        {

            if (dgvStudent_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn sinh viên cần xem chi tiết", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            ThongTinSinhVien temp = new ThongTinSinhVien();
            temp.SetStudentInfo(dgvStudent_Show.SelectedRows[0].Cells["Mã sinh viên"].Value.ToString());
            temp.stage = Stages.View;
            temp.ShowDialog();
        }

        private void btnStudent_Delete_Click(object sender, EventArgs e)
        {
            if (dgvStudent_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string ma = (string)dgvStudent_Show.SelectedRows[0].Cells[0].Value;
            string matk = (string)dgvStudent_Show.SelectedRows[0].Cells["Tài khoản"].Value;
            if (CSDL.CSDL.Instance.DeleteStudent(ma) && CSDL.CSDL.Instance.DeleteAccount(matk))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadStudentList();
                return;
            }
        }

        private void btnStudent_Edit_Click(object sender, EventArgs e)
        {
            if (dgvStudent_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn sinh viên cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            ThongTinSinhVien temp = new ThongTinSinhVien();
            temp.SetStudentInfo(dgvStudent_Show.SelectedRows[0].Cells["Mã sinh viên"].Value.ToString());
            temp.stage = Stages.Update;
            temp.Tag = this;
            temp.ShowDialog();
        }
    }
}
