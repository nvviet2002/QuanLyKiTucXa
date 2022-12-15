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
        public DataTable areaList;
        public DataTable buildingList;
        public DataTable roomTypeList;
        public DataTable deviceList;
        public DataTable roomList;
        public DataTable contractList;
        public DataTable billList;

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
            LoadRoomList();
            LoadContractList();
            LoadBillList();
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
            LoadComboBox();
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
            LoadComboBox();
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

        #region Room

        DataTable NormalizeRoomList(DataTable _table)
        {
            DataTable temp = _table;
            temp.Columns["MaPhong"].ColumnName = "Phòng";
            temp.Columns["TenLoaiPhong"].ColumnName = "Loại phòng";
            temp.Columns["MaTN"].ColumnName = "Tòa nhà";
            temp.Columns["TongSoHD"].ColumnName = "Số người";
            temp.Columns["SoNguoi"].ColumnName = "Số người tối đa";
            return temp;
        }

        public void LoadRoomList()
        {
            roomList = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong,MaTN,TenLoaiPhong,PHONG.TongSoHD
            ,SoNguoi from PHONG inner join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong");

            dgvRoom_Show.DataSource = NormalizeRoomList(roomList);

            SetRoomControls(false);
        }

        private void SetRoomControls(bool _enable)
        {
            txtRoom_ID.Enabled = cbbRoom_Building.Enabled =
            cbbRoom_Type.Enabled = btnRoom_Save.Enabled = _enable;
        }

        private void SetRoomData(DataGridViewCellCollection _cells)
        {
            if (_cells == null)
            {
                txtRoom_ID.Text = txtRoom_PeopleCount.Text = txtRoom_MaxPeopleCount.Text = "";
                cbbRoom_Type.SelectedItem = cbbRoom_Building.SelectedItem = null;
                return;
            }
            txtRoom_ID.Text = _cells["Phòng"].Value.ToString();
            txtRoom_PeopleCount.Text = _cells["Số người"].Value.ToString();
            txtRoom_MaxPeopleCount.Text = _cells["Số người tối đa"].Value.ToString();
            cbbRoom_Building.SelectedItem = _cells["Tòa nhà"].Value.ToString();
            cbbRoom_Type.SelectedItem = _cells["Loại phòng"].Value.ToString();
        }

        private void btnRoom_Add_Click(object sender, EventArgs e)
        {
            SetRoomControls(true);
            SetRoomData(null);
            SetRoomDeviceData(null);
            txtRoom_ID.Focus();
        }

        private void dgvRoom_Show_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoom_Show.SelectedRows.Count <= 0)
            {
                SetRoomDeviceData(null);
                return;
            }
            SetRoomControls(false);
            SetRoomData(dgvRoom_Show.SelectedRows[0].Cells);
            SetRoomDeviceData(dgvRoom_Show.SelectedRows[0].Cells);

        }

        private void SetRoomDeviceData(DataGridViewCellCollection _cell)
        {
            if(_cell == null)
            {
                dgvRoom_ShowDevice.DataSource = null;
                return;
            }
            string _roomID = _cell["Phòng"].Value.ToString();
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select TenTB,SoLuong,TrangThai 
            from PHONG inner join THIETBIPHONG on PHONG.MaPhong= THIETBIPHONG.MaPhong inner join
            THIETBI on THIETBI.MaTB = THIETBIPHONG.MaTB where THIETBIPHONG.MaPhong = '{_roomID}'");
            temp.Columns["TenTB"].ColumnName = "Tên thiết bị";
            temp.Columns["SoLuong"].ColumnName = "Số lượng";
            temp.Columns["TrangThai"].ColumnName = "Trạng thái";
            
            dgvRoom_ShowDevice.DataSource = temp;
        }

        private void btnRoom_Edit_Click(object sender, EventArgs e)
        {
            if (dgvRoom_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn phòng cần sửa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            SetRoomData(dgvRoom_Show.SelectedRows[0].Cells);
            SetRoomControls(true);
            txtRoom_ID.Enabled = false;
        }

        private void btnRoom_Delete_Click(object sender, EventArgs e)
        {
            if (dgvRoom_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn phòng cần xóa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string temp = dgvRoom_Show.SelectedRows[0].Cells["Phòng"].Value.ToString();
            if (CSDL.CSDL.Instance.DeleteRoomDevice(temp) && CSDL.CSDL.Instance.DeleteRoom(temp))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadRoomList();
            }
        }

        private void btnRoom_Save_Click(object sender, EventArgs e)
        {
            if (txtRoom_ID.Text.Trim() == "" || cbbRoom_Type.SelectedItem == null ||
                cbbRoom_Building.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }


            CSDL.PHONG tempRoom = new CSDL.PHONG();
            tempRoom.MaPhong = txtRoom_ID.Text;
            string tempMaLoaiPphong = CSDL.CSDL.Instance.ExecuteQuery($@"select MaLoaiPhong from LOAIPHONG
            where TenLoaiPhong like N'{cbbRoom_Type.SelectedItem.ToString()}'").Rows[0]["MaLoaiPhong"].ToString();
            MessageBox.Show(tempMaLoaiPphong);
            tempRoom.MaLoaiPhong = tempMaLoaiPphong;
            tempRoom.MaTN = cbbRoom_Building.SelectedItem.ToString();
            tempRoom.Ghichu = "";
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery($@"select * from PHONG where MaPhong=
                '{tempRoom.MaPhong}'");

            if (tempTable == null || tempTable.Rows.Count <= 0)
            {
                if (CSDL.CSDL.Instance.AddRoom(tempRoom))
                {
                    MessageBox.Show("Thêm thành công thông tin phòng", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                if (CSDL.CSDL.Instance.UpdateRoom(tempRoom))
                {
                    MessageBox.Show("Cập nhật thành công thông tin phòng", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            LoadRoomList();
            SetRoomControls(false);
            SetRoomData(null);
        }

        private void cbbRoom_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbRoom_Type.SelectedItem == null)
            {
                txtRoom_MaxPeopleCount.Text = "";
            }
            else
            {
                txtRoom_MaxPeopleCount.Text = CSDL.CSDL.Instance.ExecuteQuery($@"select SoNguoi from 
                LOAIPHONG where TenLoaiPhong like N'{cbbRoom_Type.SelectedItem.ToString()}'")
                .Rows[0]["SoNguoi"].ToString();
            }
        }

        private void btnRoom_Search_Click(object sender, EventArgs e)
        {
            if (cbbRoom_SearchType.SelectedItem == null)
            {
                dgvRoom_Show.DataSource = NormalizeRoomList(roomList);
                return;
            }
            if (cbbRoom_SearchType.SelectedItem == "Phòng")
            {
                roomList = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong,MaTN,TenLoaiPhong,PHONG.TongSoHD
                ,SoNguoi from PHONG inner join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong
                where MaPhong like '%{txtRoom_SearchInput.Text}%'");
                dgvRoom_Show.DataSource = NormalizeRoomList(roomList);
                return;
            }
            if (cbbRoom_SearchType.SelectedItem == "Tòa nhà")
            {
                roomList = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong,MaTN,TenLoaiPhong,PHONG.TongSoHD
                ,SoNguoi from PHONG inner join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong
                where MaTN like '%{txtRoom_SearchInput.Text}%'");
                dgvRoom_Show.DataSource = NormalizeRoomList(roomList);
                return;
            }
            if (cbbRoom_SearchType.SelectedItem == "Loại phòng")
            {

                roomList = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong,MaTN,TenLoaiPhong,PHONG.TongSoHD
                ,SoNguoi from PHONG inner join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong
                where TenLoaiPhong like '%{txtRoom_SearchInput.Text}%'");
                dgvRoom_Show.DataSource = NormalizeRoomList(roomList);
                return;
            }
        }

        #endregion

        #region Contract
        DataTable NormalizeContractList(DataTable _table)
        {
            DataTable temp = _table;
            temp.Columns["MaHD"].ColumnName = "Mã";
            temp.Columns["NgayLap"].ColumnName = "Ngày lập";
            temp.Columns["NgayBatDau"].ColumnName = "Ngày bắt đầu";
            temp.Columns["NgayHetHan"].ColumnName = "Ngày hết hạn";
            temp.Columns["TrangThai"].ColumnName = "Trạng thái";
            temp.Columns["MaSV"].ColumnName = "Mã sinh viên";
            temp.Columns["MaNV"].ColumnName = "Mã nhân viên";
            temp.Columns["MaPhong"].ColumnName = "Phòng";
            temp.Columns["GhiChu"].ColumnName = "Ghi chú";
            return temp;
        }

        public void LoadContractList()
        {
            contractList = CSDL.CSDL.Instance.ExecuteQuery($@"select * from HOPDONG");

            dgvContract_Show.DataSource = NormalizeContractList(contractList);
        }

        private void btnContract_Add_Click(object sender, EventArgs e)
        {
            ThongTinHopDong form = new ThongTinHopDong();
            form.stage = Stages.Add;
            CSDL.HOPDONG tempContract = new CSDL.HOPDONG();
            tempContract.MaNV = this.staff.MaNV;
            form.contract = tempContract;
            form.loadContractList += LoadContractList;
            form.ShowDialog();

        }

        private void btnContract_AddTime_Click(object sender, EventArgs e)
        {
            if (dgvContract_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn hợp đồng cần gia hạn", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            DataGridViewCellCollection cell = dgvContract_Show.SelectedRows[0].Cells;
            ThongTinHopDong form = new ThongTinHopDong();
            form.stage = Stages.Update;
            CSDL.HOPDONG tempContract = new CSDL.HOPDONG();
            tempContract.MaHD = (int)cell["Mã"].Value;
            tempContract.NgayLap = (DateTime)cell["Ngày lập"].Value;
            tempContract.NgayBatDau = (DateTime)cell["Ngày bắt đầu"].Value;
            tempContract.NgayHetHan = (DateTime)cell["Ngày hết hạn"].Value;
            tempContract.TrangThai = cell["Trạng thái"].Value.ToString();
            //tempContract.MaNV = cell["Mã nhân viên"].Value.ToString();
            tempContract.MaNV = this.staff.MaNV;
            tempContract.MaSV = cell["Mã sinh viên"].Value.ToString();
            tempContract.MaPhong = cell["Phòng"].Value.ToString();
            tempContract.GhiChu = cell["Ghi chú"].Value.ToString();

            form.contract = tempContract;
            form.loadContractList += LoadContractList;
            form.ShowDialog();
        }

        private void btnContract_Refresh_Click(object sender, EventArgs e)
        {
            LoadContractList();
        }

        

        

        private void btnContract_Cancel_Click(object sender, EventArgs e)
        {
            if (dgvContract_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn hợp đồng cần hủy", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int temp = (int)dgvContract_Show.SelectedRows[0].Cells["Mã"].Value;
            if (CSDL.CSDL.Instance.DeleteContract(temp))
            {
                MessageBox.Show("Hủy thành công","Thông báo", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                LoadContractList();
                return;
            }
            
        }

        private void btnContract_Search_Click(object sender, EventArgs e)
        {

            if (cbbContract_SearchType.SelectedItem == null)
            {
                dgvContract_Show.DataSource = NormalizeContractList(contractList);
                return;
            }
            if (cbbContract_SearchType.SelectedItem == "Mã sinh viên")
            {
                contractList = CSDL.CSDL.Instance.Search("MaSV", txtContract_SearchInput.Text,
                    "HOPDONG", false);
                dgvContract_Show.DataSource = NormalizeContractList(contractList);
                return;
            }
            if (cbbContract_SearchType.SelectedItem == "Mã nhân viên")
            {
                contractList = CSDL.CSDL.Instance.Search("TenSV", txtContract_SearchInput.Text,
                    "HOPDONG", false);
                dgvContract_Show.DataSource = NormalizeContractList(contractList);
                return;
            }
            if (cbbContract_SearchType.SelectedItem == "Phòng")
            {
                contractList = CSDL.CSDL.Instance.Search("MaPhong", txtContract_SearchInput.Text,
                    "HOPDONG", false);
                dgvContract_Show.DataSource = NormalizeContractList(contractList);
                return;
            }
        }

        #endregion

        DataTable NormalizeBillList(DataTable _table)
        {
            DataTable temp = _table;
            temp.Columns["MaHoaDon"].ColumnName = "Mã";
            temp.Columns["NgayLap"].ColumnName = "Ngày lập";
            temp.Columns["HanThu"].ColumnName = "Hạn thu";
            temp.Columns["TuNgay"].ColumnName = "Từ ngày";
            temp.Columns["DenNgay"].ColumnName = "Đến ngày";
            temp.Columns["TongTien"].ColumnName = "Tổng tiền";
            temp.Columns["TienDaNop"].ColumnName = "Đã nộp";
            temp.Columns["TrangThai"].ColumnName = "Trạng thái";
            temp.Columns["MaHD"].ColumnName = "Mã hợp đồng";
            temp.Columns["MaSV"].ColumnName = "Mã sinh viên";
            temp.Columns["GhiChu"].ColumnName = "Ghi chú";
            return temp;
        }

        public void LoadBillList()
        {
            billList = CSDL.CSDL.Instance.ExecuteQuery($@"select MaHoaDon,HOADON.NgayLap,HanThu,TuNgay,DenNgay,
            TongTien,TienDaNop,HOADON.TrangThai,HOADON.MaHD,MaSV,HOADON.GhiChu from HOADON inner join HOPDONG 
            on HOADON.MaHD = HOPDONG.MaHD");

            dgvBill_Show.DataSource = NormalizeBillList(billList);
        }

        private void btnBill_Add_Click(object sender, EventArgs e)
        {
            ThongTinHoaDon form = new ThongTinHoaDon();
            form.stage = Stages.Add;
            form.staffName = staff.TenNV;
            form.loadBillList += LoadBillList;
            form.ShowDialog();
            //CSDL.HOADON tempBill = new CSDL.HOADON();
            //tempBill.NgayLap = DateTime.Now;
            //tempBill.HanThu = DateTime.Now;
            //tempBill.TuNgay = DateTime.Now;
            //tempBill.DenNgay = DateTime.Now;
            //tempBill.TrangThai = "Thiếu";
            //tempBill.MaHD = ;
            //tempBill.TienDaNop = 0;
            //tempBill.TongTien = 0;
            //tempBill.GhiChu = "";
            //if (CSDL.CSDL.Instance.AddBill(tempBill))
            //{
            //    DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select MaHoaDon from HOADON where MaHD = 'none'");
            //    if (temp.Rows.Count <= 0) return;
            //    tempBill.MaHoaDon = (int)temp.Rows[0]["MaHoaDon"];
            //    form.bill = tempBill;
            //    form.loadBillList += LoadBillList;
            //    form.ShowDialog();
            //}

        }

        //private void btnBill_AddTime_Click(object sender, EventArgs e)
        //{
        //    if (dgvBill_Show.SelectedRows.Count <= 0)
        //    {
        //        MessageBox.Show("Bạn hãy chọn hợp đồng cần gia hạn", "Thông báo", MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning);
        //        return;
        //    }
        //    DataGridViewCellCollection cell = dgvBill_Show.SelectedRows[0].Cells;
        //    ThongTinHopDong form = new ThongTinHopDong();
        //    form.stage = Stages.Update;
        //    CSDL.HOPDONG tempBill = new CSDL.HOPDONG();
        //    tempBill.MaHD = (int)cell["Mã"].Value;
        //    tempBill.NgayLap = (DateTime)cell["Ngày lập"].Value;
        //    tempBill.NgayBatDau = (DateTime)cell["Ngày bắt đầu"].Value;
        //    tempBill.NgayHetHan = (DateTime)cell["Ngày hết hạn"].Value;
        //    tempBill.TrangThai = cell["Trạng thái"].Value.ToString();
        //    //tempBill.MaNV = cell["Mã nhân viên"].Value.ToString();
        //    tempBill.MaNV = this.staff.MaNV;
        //    tempBill.MaSV = cell["Mã sinh viên"].Value.ToString();
        //    tempBill.MaPhong = cell["Phòng"].Value.ToString();
        //    tempBill.GhiChu = cell["Ghi chú"].Value.ToString();

        //    form.Bill = tempBill;
        //    form.loadBillList += LoadBillList;
        //    form.ShowDialog();
        //}

        //private void btnBill_Refresh_Click(object sender, EventArgs e)
        //{
        //    LoadBillList();
        //}





        //private void btnBill_Cancel_Click(object sender, EventArgs e)
        //{
        //    if (dgvBill_Show.SelectedRows.Count <= 0)
        //    {
        //        MessageBox.Show("Bạn hãy chọn hợp đồng cần hủy", "Thông báo", MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning);
        //        return;
        //    }
        //    int temp = (int)dgvBill_Show.SelectedRows[0].Cells["Mã"].Value;
        //    if (CSDL.CSDL.Instance.DeleteBill(temp))
        //    {
        //        MessageBox.Show("Hủy thành công", "Thông báo", MessageBoxButtons.OK,
        //           MessageBoxIcon.Information);
        //        LoadBillList();
        //        return;
        //    }

        //}

        private void btnBill_Search_Click(object sender, EventArgs e)
        {

            if (cbbBill_SearchType.SelectedItem == null)
            {
                dgvBill_Show.DataSource = NormalizeBillList(billList);
                return;
            }
            if (cbbBill_SearchType.SelectedItem == "Mã sinh viên")
            {
                string tempQuery = $@"select MaHoaDon,HOADON.NgayLap,HanThu,TuNgay,DenNgay,
                TongTien,TienDaNop,HOADON.TrangThai,HOADON.MaHD,MaSV,HOADON.GhiChu from HOADON inner join HOPDONG 
                on HOADON.MaHD = HOPDONG.MaHD where MaSV like '%{txtBill_SearchInput.Text}%'";
                if(cbbBill_SearchStatus.SelectedItem != null && cbbBill_SearchStatus.SelectedItem.ToString() != "Tất cả")
                {
                    tempQuery += $@" and HOADON.TrangThai like N'%{cbbBill_SearchStatus.SelectedItem.ToString()}%'";
                }
                billList = CSDL.CSDL.Instance.ExecuteQuery(tempQuery);
                dgvBill_Show.DataSource = NormalizeBillList(billList);
                return;
            }
            if (cbbBill_SearchType.SelectedItem == "Mã hóa đơn")
            {
                billList = CSDL.CSDL.Instance.ExecuteQuery($@"select MaHoaDon,HOADON.NgayLap,HanThu,TuNgay,DenNgay,
                TongTien,TienDaNop,HOADON.TrangThai,HOADON.MaHD,MaSV,HOADON.GhiChu from HOADON inner join HOPDONG 
                on HOADON.MaHD = HOPDONG.MaHD where MaHoaDon like '%{txtBill_SearchInput.Text}%'");
                dgvBill_Show.DataSource = NormalizeBillList(billList);
                return;
            }
            if (cbbBill_SearchType.SelectedItem == "Mã hợp đồng")
            {
                billList = CSDL.CSDL.Instance.ExecuteQuery($@"select MaHoaDon,HOADON.NgayLap,HanThu,TuNgay,DenNgay,
                TongTien,TienDaNop,HOADON.TrangThai,HOADON.MaHD,MaSV,HOADON.GhiChu from HOADON inner join HOPDONG 
                on HOADON.MaHD = HOPDONG.MaHD where MaHD like '%{txtBill_SearchInput.Text}%'");
                dgvBill_Show.DataSource = NormalizeBillList(billList);
                return;
            }
        }

        private void LoadComboBox()
        {
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select MaKhu from KHU");
            cbbBuilding_Area.Items.Clear();
            foreach (DataRow row in temp.Rows)
            {
                cbbBuilding_Area.Items.Add(row["MaKhu"].ToString());
            }

            temp = CSDL.CSDL.Instance.ExecuteQuery($@"select TenLoaiPhong from LOAIPHONG ");
            cbbRoom_Type.Items.Clear();
            foreach (DataRow row in temp.Rows)
            {
                cbbRoom_Type.Items.Add(row["TenLoaiPhong"].ToString());
            }

            temp = CSDL.CSDL.Instance.ExecuteQuery($@"select MaTN from TOANHA ");
            cbbRoom_Building.Items.Clear();
            foreach (DataRow row in temp.Rows)
            {
                cbbRoom_Building.Items.Add(row["MaTN"].ToString());
            }
        }

        
    }
}

