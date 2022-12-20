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
    public partial class ThongTinHopDong : MetroFramework.Forms.MetroForm
    {
        public Stages stage;
        public CSDL.HOPDONG contract;
        public Action loadContractList;

        public DataTable roomShow;

        public ThongTinHopDong()
        {
            InitializeComponent();
        }

        void LoadRoomShow()
        {
            roomShow = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong,TenLoaiPhong, CONCAT(CONVERT(char(1),
            TongSoHD),'/',CONVERT(char(1),SoNguoi)) as SoNguoiO, MaTN,PHONG.Ghichu
            from PHONG inner join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong");
            dgvRoomShow.DataSource = NormalizeRoomShow(roomShow);
        }

        DataTable NormalizeRoomShow(DataTable _value)
        {
            _value.Columns["MaPhong"].ColumnName = "Phòng";
            _value.Columns["TenLoaiPhong"].ColumnName = "Loại phòng";
            _value.Columns["SoNguoiO"].ColumnName = "Số người";
            _value.Columns["MaTN"].ColumnName = "Tòa nhà";
            _value.Columns["GhiChu"].ColumnName = "Ghi chú";
            return _value;
        }

        private void ThongTinHopDong_Load(object sender, EventArgs e)
        {
            LoadRoomShow();
            LoadComboBox();
        }

        private void btnStaff_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadComboBox()
        {
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select MaNV from NHANVIEN");
            txtStaffName.Text = CSDL.CSDL.Instance.ExecuteQuery($@"select TenNV from NHANVIEN where MaNV = 
            '{contract.MaNV}'").Rows[0]["TenNV"].ToString();

            temp = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong from PHONG");
            cbbRoomID.Items.Clear();
            foreach (DataRow row in temp.Rows)
            {
                cbbRoomID.Items.Add(row["MaPhong"].ToString());
            }
            if(stage != Stages.Add)
            {
                cbbRoomID.SelectedItem = contract.MaPhong;
                txtStudentID.Text = contract.MaSV;
                txtStudentID.Enabled = false;
            }
        }

        private void dgvRoomShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoomShow.SelectedRows.Count <= 0) return;
            cbbRoomID.SelectedItem = dgvRoomShow.SelectedRows[0].Cells["Phòng"].Value.ToString();
        }

        private void btnRoom_Save_Click(object sender, EventArgs e)
        {
            if (txtStaffName.Text == "" || txtStudentID.Text.Trim() == "" || cbbRoomID.SelectedItem == null
            || cbbStatus.SelectedItem == null ){
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if( dtpBeginDay.Value > dtpEnđay.Value)
            {
                MessageBox.Show("Ngày hết hạn thúc phải sau ngày bắt đầu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            CSDL.HOPDONG tempContract = new CSDL.HOPDONG();
            tempContract.NgayLap = dtpCreateDay.Value;
            tempContract.NgayBatDau = dtpBeginDay.Value;
            tempContract.NgayHetHan = dtpEnđay.Value;
            tempContract.MaNV = contract.MaNV;
            tempContract.MaSV = txtStudentID.Text;
            tempContract.MaPhong = cbbRoomID.SelectedItem.ToString();
            tempContract.TrangThai = cbbStatus.SelectedItem.ToString();
            tempContract.GhiChu = txtNote.Text;
            if(stage == Stages.Add)
            {
                if (CSDL.CSDL.Instance.AddContract(tempContract))
                {
                    MessageBox.Show("Thêm hợp đồng thành công", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    loadContractList.Invoke();
                    this.Close();
                    return;
                }
            }
            if (stage == Stages.Update)
            {
                
                if (CSDL.CSDL.Instance.DeleteContract(contract.MaHD) && CSDL.CSDL.Instance.AddContract(tempContract))
                {
                    this.Close();
                    MessageBox.Show("Gia hạn hợp đồng thành công", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    loadContractList.Invoke();
                    this.Close();
                    return;
                }
            }
        }

        private void cbbFilterType_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbbFilterType.SelectedItem.ToString() == "Tòa nhà")
            {
                DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select MaTN from TOANHA");
                cbbFilter.Items.Clear();
                foreach (DataRow row in temp.Rows)
                {
                    cbbFilter.Items.Add(row["MaTN"].ToString());
                }
                cbbFilter.SelectedIndex = 0;
                return;
            }
            if (cbbFilterType.SelectedItem.ToString() == "Trạng thái")
            {
                cbbFilter.Items.Clear();
                cbbFilter.Items.Add("Còn chỗ");
                cbbFilter.Items.Add("Hết chỗ");
                cbbFilter.SelectedIndex = 0;
                return;
            }
        }

        private void cbbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbFilterType.SelectedItem == null || cbbFilter.SelectedItem == null) return;
            if(cbbFilterType.SelectedItem.ToString() == "Tòa nhà")
            {
                roomShow = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong,TenLoaiPhong, CONCAT(CONVERT(char(1),
                TongSoHD),'/',CONVERT(char(1),SoNguoi)) as SoNguoiO, MaTN,PHONG.Ghichu
                from PHONG inner join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong
                where MaTN = '{cbbFilter.SelectedItem.ToString()}'");
                dgvRoomShow.DataSource = NormalizeRoomShow(roomShow);
                
                return;
            }
            if (cbbFilterType.SelectedItem.ToString() == "Trạng thái")
            {
                if(cbbFilter.SelectedItem.ToString() == "Còn chỗ")
                {
                    roomShow = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong,TenLoaiPhong, CONCAT(CONVERT(char(1),
                    TongSoHD),'/',CONVERT(char(1),SoNguoi)) as SoNguoiO, MaTN,PHONG.Ghichu
                    from PHONG inner join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong
                    where PHONG.TongSoHD < LOAIPHONG.SoNguoi ");
                    dgvRoomShow.DataSource = NormalizeRoomShow(roomShow);
                    return;
                }
                if(cbbFilter.SelectedItem.ToString() == "Hết chỗ")
                {
                    roomShow = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong,TenLoaiPhong, CONCAT(CONVERT(char(1),
                    TongSoHD),'/',CONVERT(char(1),TongSoHD)) as SoNguoiO, MaTN,PHONG.Ghichu
                    from PHONG inner join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong
                    where PHONG.TongSoHD = LOAIPHONG.SoNguoi");
                    dgvRoomShow.DataSource = NormalizeRoomShow(roomShow);
                    return;
                }
            }

        }
    }
}
