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
        private CSDL.TAIKHOAN staffAccount;
        private CSDL.NHANVIEN staff;
        private DataTable staffList;

        public nhanvien()
        {
            InitializeComponent();
        }

        public void LoadAccountData()
        {
            staffAccount = (CSDL.TAIKHOAN)this.Tag;
            staff = new CSDL.NHANVIEN();
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery($@"select * from NHANVIEN where MaTK = {staffAccount.MaTK}");
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

        private void LoadStaffList()
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
            temp.Columns.Remove("MaTK");
            return temp;
        }

        private void nhanvien_Load(object sender, EventArgs e)
        {
            LoadAccountData();
            LoadStaffList();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
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
    }
}
