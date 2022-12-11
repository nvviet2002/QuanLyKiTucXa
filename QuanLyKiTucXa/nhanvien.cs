﻿using System;
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
        public DataTable areaList;
        public DataTable buildingList;
        public DataTable roomTypeList;
        public DataTable deviceList;

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
            LoadAreaList();
            LoadBuildingList();
            LoadRoomTypeList();
            LoadDeviceList();
            LoadComboBox();
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
            DataTable temp = _table;
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
            if (cbbStaff_SearchType.SelectedItem == null)
            {
                dgvStaff_Show.DataSource = NormalizeStaffList(staffList);
                return;
            }
            if (cbbStaff_SearchType.SelectedItem == "Mã nhân viên")
            {
                staffList = CSDL.CSDL.Instance.Search("MaNV", txtStaff_SearchInput.Text,
                    "NHANVIEN", false);
                dgvStaff_Show.DataSource = NormalizeStaffList(staffList);
                return;
            }
            if (cbbStaff_SearchType.SelectedItem == "Tên nhân viên")
            {
                staffList = CSDL.CSDL.Instance.Search("TenNV", txtStaff_SearchInput.Text,
                    "NHANVIEN", true);
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
            if (dgvStaff_Show.SelectedRows.Count <= 0)
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
            DataTable temp = _table;
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

        #endregion

        #region Area
        DataTable NormalizeAreaList(DataTable _table)
        {
            DataTable temp = _table;
            temp.Columns["MaKhu"].ColumnName = "Mã khu";
            temp.Columns["TenKhu"].ColumnName = "Tên khu";
            temp.Columns["ViTri"].ColumnName = "Vị trí";
            temp.Columns["GhiChu"].ColumnName = "Ghi chú";
            return temp;
        }

        public void LoadAreaList()
        {
            areaList = CSDL.CSDL.Instance.ExecuteQuery($@"select * from KHU");

            dgvArea_Show.DataSource = NormalizeAreaList(areaList);

            SetAreaControls(false);
        }

        private void SetAreaControls(bool _enable)
        {
            txtArea_ID.Enabled = txtArea_Name.Enabled = txtArea_Note.Enabled = txtArea_Position.Enabled
            = btnArea_Save.Enabled = _enable;
        }

        private void SetAreaData(DataGridViewCellCollection _cells)
        {
            if (_cells == null)
            {
                txtArea_ID.Text = txtArea_Name.Text = txtArea_Note.Text = txtArea_Position.Text = "";
                return;
            }
            txtArea_ID.Text = _cells["Mã khu"].Value.ToString();
            txtArea_Name.Text = _cells["Tên khu"].Value.ToString();
            txtArea_Note.Text = _cells["Ghi chú"].Value.ToString();
            txtArea_Position.Text = _cells["Vị trí"].Value.ToString();
        }

        private void btnArea_Add_Click(object sender, EventArgs e)
        {
            SetAreaControls(true);
            SetAreaData(null);
            txtArea_ID.Focus();
        }

        private void dgvArea_Show_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArea_Show.SelectedRows.Count <= 0) return;
            SetAreaControls(false);
            SetAreaData(dgvArea_Show.SelectedRows[0].Cells);
        }

        private void btnArea_Edit_Click(object sender, EventArgs e)
        {
            if (dgvArea_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn khu cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            SetAreaData(dgvArea_Show.SelectedRows[0].Cells);
            SetAreaControls(true);
            txtArea_ID.Enabled = false;
        }

        private void btnArea_Delete_Click(object sender, EventArgs e)
        {
            if (dgvArea_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn khu cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string temp = dgvArea_Show.SelectedRows[0].Cells["Mã khu"].Value.ToString();
            if (CSDL.CSDL.Instance.DeleteArea(temp))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadAreaList();
            }
        }

        private void btnArea_Save_Click(object sender, EventArgs e)
        {
            if (txtArea_ID.Text.Trim() == "" || txtArea_Name.Text.Trim() == "" || txtArea_Position.Text.Trim()
                == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CSDL.KHU tempArea = new CSDL.KHU();
            tempArea.MaKhu = txtArea_ID.Text;
            tempArea.TenKhu = txtArea_Name.Text;
            tempArea.Vitri = txtArea_Position.Text;
            tempArea.Ghichu = txtArea_Note.Text;
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery($@"select * from KHU where MaKhu =
            '{tempArea.MaKhu}'");

            if (tempTable == null || tempTable.Rows.Count <= 0)
            {
                if (CSDL.CSDL.Instance.AddArea(tempArea))
                {
                    MessageBox.Show("Thêm thành công thông tin khu", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                if (CSDL.CSDL.Instance.UpdateArea(tempArea))
                {
                    MessageBox.Show("Cập nhật thành công thông tin khu", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            LoadAreaList();
            SetAreaControls(false);
            SetAreaData(null);
        }


        #endregion

        #region Building
        DataTable NormalizeBuildingList(DataTable _table)
        {
            DataTable temp = _table;
            temp.Columns["MaTN"].ColumnName = "Mã tòa nhà";
            temp.Columns["TenTN"].ColumnName = "Tên tòa nhà";
            temp.Columns["MaKhu"].ColumnName = "Khu";
            temp.Columns["GhiChu"].ColumnName = "Ghi chú";
            return temp;
        }

        public void LoadBuildingList()
        {
            buildingList = CSDL.CSDL.Instance.ExecuteQuery($@"select * from TOANHA");

            dgvBuilding_Show.DataSource = NormalizeBuildingList(buildingList);

            SetBuildingControls(false);
        }

        private void SetBuildingControls(bool _enable)
        {
            txtBuilding_ID.Enabled = txtBuilding_Name.Enabled = txtBuilding_Note.Enabled = cbbBuilding_Area.Enabled
            = btnBuilding_Save.Enabled = _enable;
        }

        private void SetBuildingData(DataGridViewCellCollection _cells)
        {
            if (_cells == null)
            {
                txtBuilding_ID.Text = txtBuilding_Name.Text = txtBuilding_Note.Text = "";
                cbbBuilding_Area.SelectedItem = null;
                return;
            }
            txtBuilding_ID.Text = _cells["Mã tòa nhà"].Value.ToString();
            txtBuilding_Name.Text = _cells["Tên tòa nhà"].Value.ToString();
            cbbBuilding_Area.SelectedItem = _cells["Khu"].Value.ToString();
            txtBuilding_Note.Text = _cells["Ghi chú"].Value.ToString();

        }

        private void btnBuilding_Add_Click(object sender, EventArgs e)
        {
            SetBuildingControls(true);
            SetBuildingData(null);
            txtBuilding_ID.Focus();
        }

        private void dgvBuilding_Show_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBuilding_Show.SelectedRows.Count <= 0) return;
            SetBuildingControls(false);
            SetBuildingData(dgvBuilding_Show.SelectedRows[0].Cells);
        }

        private void btnBuilding_Edit_Click(object sender, EventArgs e)
        {
            if (dgvBuilding_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn tòa nhà cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            SetBuildingData(dgvBuilding_Show.SelectedRows[0].Cells);
            SetBuildingControls(true);
            txtBuilding_ID.Enabled = false;
        }

        private void btnBuilding_Delete_Click(object sender, EventArgs e)
        {
            if (dgvBuilding_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn tòa nhà cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string temp = dgvBuilding_Show.SelectedRows[0].Cells["Mã tòa nhà"].Value.ToString();
            if (CSDL.CSDL.Instance.DeleteBuilding(temp))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadBuildingList();
            }
        }

        private void btnBuilding_Save_Click(object sender, EventArgs e)
        {
            if (txtBuilding_ID.Text.Trim() == "" || txtBuilding_Name.Text.Trim() == "" || cbbBuilding_Area.SelectedItem
                == null)
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CSDL.TOANHA tempBuilding = new CSDL.TOANHA();
            tempBuilding.MaTN = txtBuilding_ID.Text;
            tempBuilding.TenTN = txtBuilding_Name.Text;
            tempBuilding.MaKhu = cbbBuilding_Area.SelectedItem.ToString();
            tempBuilding.Ghichu = txtBuilding_Note.Text;
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery($@"select * from TOANHA where MaTN =
            '{tempBuilding.MaTN}'");

            if (tempTable == null || tempTable.Rows.Count <= 0)
            {
                if (CSDL.CSDL.Instance.AddBuilding(tempBuilding))
                {
                    MessageBox.Show("Thêm thành công thông tin tòa nhà", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                if (CSDL.CSDL.Instance.UpdateBuilding(tempBuilding))
                {
                    MessageBox.Show("Cập nhật thành công thông tin tòa nhà", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            LoadBuildingList();
            SetBuildingControls(false);
            SetBuildingData(null);
        }

        private void LoadComboBox()
        {
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select MaKhu from KHU");
            cbbBuilding_Area.Items.Clear();
            foreach (DataRow row in temp.Rows)
            {
                cbbBuilding_Area.Items.Add(row["MaKhu"].ToString());
            }
        }

        #endregion

        #region RoomType
        DataTable NormalizeRoomTypeList(DataTable _table)
        {
            DataTable temp = _table;
            temp.Columns["MaLoaiPhong"].ColumnName = "Mã loại phòng";
            temp.Columns["TenLoaiPhong"].ColumnName = "Tên loại phòng";
            temp.Columns["SoNguoi"].ColumnName = "Số người";
            temp.Columns["DienTich"].ColumnName = "Diện tích";
            temp.Columns["GiaPhong"].ColumnName = "Giá phòng";
            temp.Columns["GhiChu"].ColumnName = "Ghi chú";
            return temp;
        }

        public void LoadRoomTypeList()
        {
            roomTypeList = CSDL.CSDL.Instance.ExecuteQuery($@"select * from LOAIPHONG");

            dgvRoomType_Show.DataSource = NormalizeRoomTypeList(roomTypeList);

            SetRoomTypeControls(false);
        }

        private void SetRoomTypeControls(bool _enable)
        {
            txtRoomType_ID.Enabled = txtRoomType_Name.Enabled = txtRoomType_Note.Enabled = txtRoomType_Price.Enabled
            = txtRoomType_S.Enabled = txtRoomType_PeopleCount.Enabled = btnRoomType_Save.Enabled = _enable;
        }

        private void SetRoomTypeData(DataGridViewCellCollection _cells)
        {
            if (_cells == null)
            {
                txtRoomType_ID.Text = txtRoomType_Name.Text = txtRoomType_Note.Text =
                txtRoomType_PeopleCount.Text = txtRoomType_S.Text = txtRoomType_Price.Text = "";
                return;
            }
            txtRoomType_ID.Text = _cells["Mã loại phòng"].Value.ToString();
            txtRoomType_Name.Text = _cells["Tên loại phòng"].Value.ToString();
            txtRoomType_PeopleCount.Text = _cells["Số người"].Value.ToString();
            txtRoomType_S.Text = _cells["Diện tích"].Value.ToString();
            txtRoomType_Price.Text = _cells["Giá phòng"].Value.ToString();
            txtRoomType_Note.Text = _cells["Ghi chú"].Value.ToString();

        }

        private void btnRoomType_Add_Click(object sender, EventArgs e)
        {
            SetRoomTypeControls(true);
            SetRoomTypeData(null);
            txtRoomType_ID.Focus();
        }

        private void dgvRoomType_Show_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoomType_Show.SelectedRows.Count <= 0) return;
            SetRoomTypeControls(false);
            SetRoomTypeData(dgvRoomType_Show.SelectedRows[0].Cells);
        }

        private void btnRoomType_Edit_Click(object sender, EventArgs e)
        {
            if (dgvRoomType_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn loại phòng cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            SetRoomTypeData(dgvRoomType_Show.SelectedRows[0].Cells);
            SetRoomTypeControls(true);
            txtRoomType_ID.Enabled = false;
        }

        private void btnRoomType_Delete_Click(object sender, EventArgs e)
        {
            if (dgvRoomType_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn loại phòng cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string temp = dgvRoomType_Show.SelectedRows[0].Cells["Mã loại phòng"].Value.ToString();
            if (CSDL.CSDL.Instance.DeleteRoomType(temp))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadRoomTypeList();
            }
        }

        private void btnRoomType_Save_Click(object sender, EventArgs e)
        {
            if (txtRoomType_ID.Text.Trim() == "" || txtRoomType_Name.Text.Trim() == "" ||
                txtRoomType_Price.Text.Trim() == "" || txtRoomType_PeopleCount.Text.Trim() == ""
                || txtRoomType_S.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CSDL.LOAIPHONG tempRoomType = new CSDL.LOAIPHONG();
            tempRoomType.MaLoaiPhong = txtRoomType_ID.Text;
            tempRoomType.TenLoaiPhong = txtRoomType_Name.Text;
            tempRoomType.SoNguoi = int.Parse(txtRoomType_PeopleCount.Text);
            tempRoomType.DienTich = decimal.Parse(txtRoomType_S.Text);
            tempRoomType.GiaPhong = decimal.Parse(txtRoomType_Price.Text);
            tempRoomType.Ghichu = txtRoomType_Note.Text;
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery($@"select * from LOAIPHONG where MaLoaiPhong =
            '{tempRoomType.MaLoaiPhong}'");

            if (tempTable == null || tempTable.Rows.Count <= 0)
            {
                if (CSDL.CSDL.Instance.AddRoomType(tempRoomType))
                {
                    MessageBox.Show("Thêm thành công thông tin loại phòng", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                if (CSDL.CSDL.Instance.UpdateRoomType(tempRoomType))
                {
                    MessageBox.Show("Cập nhật thành công thông tin loại phòng", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            LoadRoomTypeList();
            SetRoomTypeControls(false);
            SetRoomTypeData(null);
        }

        #endregion

        #region Device
        DataTable NormalizeDeviceList(DataTable _table)
        {
            DataTable temp = _table;
            temp.Columns["MaTB"].ColumnName = "Mã thiết bị";
            temp.Columns["TenTB"].ColumnName = "Tên thiết bị";
            temp.Columns["GhiChu"].ColumnName = "Ghi chú";
            return temp;
        }

        public void LoadDeviceList()
        {
            deviceList = CSDL.CSDL.Instance.ExecuteQuery($@"select * from THIETBI");

            dgvDevice_Show.DataSource = NormalizeDeviceList(deviceList);

            SetDeviceControls(false);
        }

        private void SetDeviceControls(bool _enable)
        {
            txtDevice_ID.Enabled = txtDevice_Name.Enabled = txtDevice_Note.Enabled = 
            btnDevice_Save.Enabled = _enable;
        }

        private void SetDeviceData(DataGridViewCellCollection _cells)
        {
            if (_cells == null)
            {
                txtDevice_ID.Text = txtDevice_Name.Text = txtDevice_Note.Text ="";
                return;
            }
            txtDevice_ID.Text = _cells["Mã thiết bị"].Value.ToString();
            txtDevice_Name.Text = _cells["Tên thiết bị"].Value.ToString();
            txtDevice_Note.Text = _cells["Ghi chú"].Value.ToString();

        }

        private void btnDevice_Add_Click(object sender, EventArgs e)
        {
            SetDeviceControls(true);
            SetDeviceData(null);
            txtDevice_ID.Focus();
        }

        private void dgvDevice_Show_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevice_Show.SelectedRows.Count <= 0) return;
            SetDeviceControls(false);
            SetDeviceData(dgvDevice_Show.SelectedRows[0].Cells);
        }

        private void btnDevice_Edit_Click(object sender, EventArgs e)
        {
            if (dgvDevice_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn loại phòng cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            SetDeviceData(dgvDevice_Show.SelectedRows[0].Cells);
            SetDeviceControls(true);
            txtDevice_ID.Enabled = false;
        }

        private void btnDevice_Delete_Click(object sender, EventArgs e)
        {
            if (dgvDevice_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn thiết bị cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string temp = dgvDevice_Show.SelectedRows[0].Cells["Mã thiết bị"].Value.ToString();
            if (CSDL.CSDL.Instance.DeleteDevice(temp))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadDeviceList();
            }
        }

        private void btnDevice_Save_Click(object sender, EventArgs e)
        {
            if (txtDevice_ID.Text.Trim() == "" || txtDevice_Name.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CSDL.THIETBI tempDevice = new CSDL.THIETBI();
            tempDevice.MaTB = txtDevice_ID.Text;
            tempDevice.TenTB = txtDevice_Name.Text;
            tempDevice.Ghichu = txtDevice_Note.Text;
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery($@"select * from THIETBI where MaTB=
                '{tempDevice.MaTB}'");

            if (tempTable == null || tempTable.Rows.Count <= 0)
            {
                if (CSDL.CSDL.Instance.AddDevice(tempDevice))
                {
                    MessageBox.Show("Thêm thành công thông tin thiết bị", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                if (CSDL.CSDL.Instance.UpdateDevice(tempDevice))
                {
                    MessageBox.Show("Cập nhật thành công thông tin thiết bị", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            LoadDeviceList();
            SetDeviceControls(false);
            SetDeviceData(null);
        }

        #endregion

    }
}

