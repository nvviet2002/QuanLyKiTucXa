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
        DataTable billList;
        string maPhong;

        public sinhvien()
        {
            InitializeComponent();
        }

        public void LoadAccountData()
        {
            studentAccount = (CSDL.TAIKHOAN)this.Tag;
            student = new CSDL.SINHVIEN();
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery($@"select * from SINHVIEN where TaiKhoan = '{studentAccount.TaiKhoan}'");
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
            txtStudent_PhoneNumber.Enabled = txtStudent_Address.Enabled = 
            txtStudent_Note.Enabled = btnStudent_Save.Enabled = _enable;
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

        private void LoadRoomData()
        {
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery(
            $@"select PHONG.*,LOAIPHONG.TenLoaiPhong,LOAIPHONG.SoNguoi,
            LOAIPHONG.GiaPhong,LOAIPHONG.DienTich,TenKhu,TenTN from 
            LOAIPHONG inner join PHONG on LOAIPHONG.MaLoaiPhong = PHONG.MaLoaiPhong
            inner join TOANHA on TOANHA.MaTN = PHONG.MaTN
            inner join KHU on KHU.MaKhu = TOANHA.MaKhu
            where PHONG.MaPhong  = '{txtContract_RoomID.Text}'");
            if(temp.Rows.Count >= 1)
            {
                txtRoom_ID.Text = temp.Rows[0]["MaPhong"].ToString();
                txtRoom_Area.Text = temp.Rows[0]["TenKhu"].ToString();
                txtRoom_Building.Text = temp.Rows[0]["TenTN"].ToString();
                txtRoom_Note.Text = temp.Rows[0]["GhiChu"].ToString();
                txtRoom_S.Text = temp.Rows[0]["DienTich"].ToString() + " m2";
                txtRoom_Type.Text = temp.Rows[0]["TenLoaiPhong"].ToString();
                txtRoom_Max.Text = temp.Rows[0]["SoNguoi"].ToString();
                txtRoom_Living.Text = temp.Rows[0]["TongSoHD"].ToString();
                txtRoom_Money.Text = temp.Rows[0]["GiaPhong"].ToString() + @" VND / 1 người";
            }
            LoadDeviceList();
        }

        private void LoadDeviceList()
        {
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery(
            $@"select TenTB,SoLuong,TrangThai from THIETBIPHONG inner join THIETBI on THIETBIPHONG.MaTB = THIETBI.MaTB
            where MaPhong = '{txtContract_RoomID.Text}'");
            temp.Columns["TenTB"].ColumnName = "Tên thiết bị";
            temp.Columns["SoLuong"].ColumnName = "Số lượng";
            temp.Columns["TrangThai"].ColumnName = "Tình trạng";
            dgvRoom_ShowDevice.DataSource = temp;
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
            if (txtStudent_PhoneNumber.Text == "" || txtStudent_Address.Text == "" )
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
            SetEnableStudentControls(false);
        }

        private void sinhvien_Load(object sender, EventArgs e)
        {
            LoadAccountData();
            LoadStudentData();
            LoadContractData();
            LoadRoomData();
            LoadBillList();
        }

        private void LoadContractData()
        {
            DataTable tempTable = CSDL.CSDL.Instance.ExecuteQuery(
                $@"select NHANVIEN.TenNV,HOPDONG.*,SINHVIEN.TenSV,HOPDONG.MaPhong from 
                NHANVIEN inner join HOPDONG on NHANVIEN.MaNV = HOPDONG.MaNV
                inner join SINHVIEN on HOPDONG.MaSV = SINHVIEN.MaSV
                where HOPDONG.MaSV = '{student.MaSV}' and TrangThai = N'Còn hiệu lực'");
           if(tempTable.Rows.Count >= 1)
            {
                txtContract_Identity.Text = tempTable.Rows[0]["MaHD"].ToString();
                txtContract_Note.Text = tempTable.Rows[0]["GhiChu"].ToString();
                txtContract_RoomID.Text = tempTable.Rows[0]["MaPhong"].ToString();
                txtContract_StaffIdentity.Text = tempTable.Rows[0]["MaNV"].ToString();
                txtContract_StaffName.Text = tempTable.Rows[0]["TenNV"].ToString();
                txtContract_StudentIdentity.Text = tempTable.Rows[0]["MaSV"].ToString();
                txtContract_StudentName.Text = tempTable.Rows[0]["TenNV"].ToString();
                dtpContract_CreateDay.Value = (DateTime)tempTable.Rows[0]["NgayLap"];
                dtpContract_BeginDay.Value = (DateTime)tempTable.Rows[0]["NgayBatDau"];
                dtpContract_EndDay.Value = (DateTime)tempTable.Rows[0]["NgayHetHan"];
                return;
            }
        }

        #region Bill
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
            on HOADON.MaHD = HOPDONG.MaHD where MaSV = '{student.MaSV}'");

            dgvBill_Show.DataSource = NormalizeBillList(billList);
        }

        private void btnBill_Search_Click(object sender, EventArgs e)
        {

            if (cbbBill_SearchType.SelectedItem == null || cbbBill_SearchStatus.SelectedItem == null)
            {
                LoadBillList();
                return;
            }
            if (cbbBill_SearchType.SelectedItem == "Mã sinh viên")
            {
                string tempQuery = $@"select MaHoaDon,HOADON.NgayLap,HanThu,TuNgay,DenNgay,
                TongTien,TienDaNop,HOADON.TrangThai,HOADON.MaHD,MaSV,HOADON.GhiChu from HOADON inner join HOPDONG 
                on HOADON.MaHD = HOPDONG.MaHD where MaSV like '%{txtBill_SearchInput.Text}%'";
                if (cbbBill_SearchStatus.SelectedItem != null && cbbBill_SearchStatus.SelectedItem.ToString() != "Tất cả")
                {
                    tempQuery += $@" and HOADON.TrangThai like N'%{cbbBill_SearchStatus.SelectedItem.ToString()}%'";
                }
                billList = CSDL.CSDL.Instance.ExecuteQuery(tempQuery);
                dgvBill_Show.DataSource = NormalizeBillList(billList);
                return;
            }
            if (cbbBill_SearchType.SelectedItem == "Mã hóa đơn")
            {
                string tempQuery = $@"select MaHoaDon,HOADON.NgayLap,HanThu,TuNgay,DenNgay,
                TongTien,TienDaNop,HOADON.TrangThai,HOADON.MaHD,MaSV,HOADON.GhiChu from HOADON inner join HOPDONG 
                on HOADON.MaHD = HOPDONG.MaHD where MaHoaDon like '%{txtBill_SearchInput.Text}%'";
                if (cbbBill_SearchStatus.SelectedItem != null && cbbBill_SearchStatus.SelectedItem.ToString() != "Tất cả")
                {
                    tempQuery += $@" and HOADON.TrangThai like N'%{cbbBill_SearchStatus.SelectedItem.ToString()}%'";
                }
                billList = CSDL.CSDL.Instance.ExecuteQuery(tempQuery);
                dgvBill_Show.DataSource = NormalizeBillList(billList);
                return;
            }
            if (cbbBill_SearchType.SelectedItem == "Mã hợp đồng")
            {
                string tempQuery = $@"select MaHoaDon,HOADON.NgayLap,HanThu,TuNgay,DenNgay,
                TongTien,TienDaNop,HOADON.TrangThai,HOADON.MaHD,MaSV,HOADON.GhiChu from HOADON inner join HOPDONG 
                on HOADON.MaHD = HOPDONG.MaHD where HOADON.MaHD like '%{txtBill_SearchInput.Text}%'";
                if (cbbBill_SearchStatus.SelectedItem != null && cbbBill_SearchStatus.SelectedItem.ToString() != "Tất cả")
                {
                    tempQuery += $@" and HOADON.TrangThai like N'%{cbbBill_SearchStatus.SelectedItem.ToString()}%'";
                }
                billList = CSDL.CSDL.Instance.ExecuteQuery(tempQuery);
                dgvBill_Show.DataSource = NormalizeBillList(billList);
                return;
            }
        }

        private void btnBill_Detail_Click()
        {
            if (dgvBill_Show.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Hãy chọn hóa đơn cần xem chi tiết", "Thông báo", MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                return;
            }
            DataGridViewCellCollection cell = dgvBill_Show.SelectedRows[0].Cells;
            CSDL.HOADON tempBill = new CSDL.HOADON();
            tempBill.MaHoaDon = (int)cell["Mã"].Value;
            tempBill.NgayLap = (DateTime)cell["Ngày lập"].Value;
            tempBill.HanThu = (DateTime)cell["Hạn thu"].Value;
            tempBill.TuNgay = (DateTime)cell["Từ ngày"].Value;
            tempBill.DenNgay = (DateTime)cell["Đến ngày"].Value;
            tempBill.TongTien = decimal.Parse(cell["Tổng tiền"].Value.ToString());
            tempBill.TienDaNop = decimal.Parse(cell["Đã nộp"].Value.ToString());
            tempBill.TrangThai = cell["Trạng thái"].Value.ToString();
            tempBill.MaHD = (int)cell["Mã hợp đồng"].Value;
            tempBill.GhiChu = cell["Ghi chú"].Value.ToString();



            ThongTinHoaDon form = new ThongTinHoaDon();
            form.stage = Stages.View;
            form.bill = tempBill;
            form.ViewForStudent();

            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select * from CHITIETHOADON where MaHoaDon = {tempBill.MaHoaDon}");
            foreach (DataRow item in temp.Rows)
            {
                CSDL.CHITIETHOADON tempDetailBill = new CSDL.CHITIETHOADON();
                tempDetailBill.LoaiTien = item["LoaiTien"].ToString();
                tempDetailBill.SoCu = (int)item["SoCu"];
                tempDetailBill.SoCu = (int)item["SoMoi"];
                tempDetailBill.DonGia = (decimal)item["DonGia"];
                tempDetailBill.SoTien = (decimal)item["SoTien"];
                tempDetailBill.DonViTinh = item["DonViTinh"].ToString();
                tempDetailBill.MaHoaDon = (int)item["MaHoaDon"];
                tempDetailBill.GhiChu = item["GhiChu"].ToString();
                form.detailBillList.Add(tempDetailBill);
            }


            form.ShowDialog();
        }


        #endregion

        private void dgvBill_Show_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnBill_Detail_Click();
        }

        private void btnInfomation_Click(object sender, EventArgs e)
        {
            pInfomation.Show();
            pContract.Hide();
            pRoom.Hide();
            pBill.Hide();
            ChangeColor(sender, e);
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            pInfomation.Hide();
            pContract.Hide();
            pRoom.Show();
            pBill.Hide();
            ChangeColor(sender, e);
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            pInfomation.Hide();
            pContract.Hide();
            pRoom.Hide();
            pBill.Show();
            ChangeColor(sender, e);
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            pInfomation.Hide();
            pContract.Show();
            pRoom.Hide();
            pBill.Hide();
            ChangeColor(sender, e);
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.MediumOrchid;
            if(btn.Name == btnInfomation.Name)
            {
                btnBill.BackColor = Color.Thistle;
                btnContract.BackColor = Color.Thistle;
                btnRoom.BackColor = Color.Thistle;
                return;
            }
            if (btn.Name == btnRoom.Name)
            {
                btnBill.BackColor = Color.Thistle;
                btnContract.BackColor = Color.Thistle;
                btnInfomation.BackColor = Color.Thistle;
                return;
            }
            if (btn.Name == btnBill.Name)
            {
                btnInfomation.BackColor = Color.Thistle;
                btnContract.BackColor = Color.Thistle;
                btnRoom.BackColor = Color.Thistle;
                return;
            }
            if (btn.Name == btnContract.Name)
            {
                btnBill.BackColor = Color.Thistle;
                btnInfomation.BackColor = Color.Thistle;
                btnRoom.BackColor = Color.Thistle;
                return;
            }
        }

        private void llbLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            dangky form = new dangky();
            form.account = studentAccount;
            form.ShowDialog();
        }
    }
}
