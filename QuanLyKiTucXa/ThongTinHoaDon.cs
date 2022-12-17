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
    public partial class ThongTinHoaDon : MetroFramework.Forms.MetroForm
    {
        public CSDL.HOADON bill;
        public Stages stage;
        public string staffName;
        public List<CSDL.CHITIETHOADON> detailBillList = new List<CSDL.CHITIETHOADON>();
        public DataTable detailBillTable = new DataTable();
        public Action loadBillList;

        public ThongTinHoaDon()
        {
            InitializeComponent();
        }

        public void LoadDetailBillTable()
        {
            detailBillTable = new DataTable();

            detailBillTable.Columns.Add("Loại tiền");
            detailBillTable.Columns.Add("Số cũ");
            detailBillTable.Columns.Add("Số mới");
            detailBillTable.Columns.Add("Đơn giá");
            detailBillTable.Columns.Add("Đơn vị tính");
            detailBillTable.Columns.Add("Số tiền");
            detailBillTable.Columns.Add("Ghi chú");
            
            foreach(CSDL.CHITIETHOADON item in detailBillList)
            {
                detailBillTable.Rows.Add(item.LoaiTien, item.SoCu, item.SoMoi, item.DonGia, item.DonViTinh, item.SoTien,
                item.GhiChu);
            }
            dgvShow.DataSource = detailBillTable;
            CaculateSum();
        }

        private void CaculateSum()
        {
            decimal sum = 0;
            if(detailBillList.Count<=0)
            {
                txtSum.Text = 0.ToString();
                return;
            }
            foreach(CSDL.CHITIETHOADON item in detailBillList)
            {
                sum += item.SoTien;
            }
            txtSum.Text = sum.ToString();
        }

        private void ThongTinHoaDon_Load(object sender, EventArgs e)
        {
            if(stage == Stages.Add)
            {
                txtStaffName.Text = staffName;
                cbbStatus.SelectedIndex = 0;
                btnConfirm.Hide();
                btnCreate.Show();
                return;
            }
            if (stage == Stages.View)
            {
                txtStaffName.Text = staffName;
                cbbStatus.SelectedIndex = 0;
                LoadDetailBill();
                LoadDetailBillTable();
                dtpBeginDay.Enabled = dtpEnđay.Enabled = dtpLimitDay.Enabled = cbbStatus.Enabled = txtStudentID.Enabled =
                txtSubmit.Enabled = txtNote.Enabled = false;
                btnAdd.Hide();
                btnCreate.Hide();
                btnDelete.Hide();
                btnConfirm.Hide();
                return;
            }
            if (stage == Stages.Update)
            {
                txtStaffName.Text = staffName;
                cbbStatus.SelectedIndex = 0;
                LoadDetailBill();
                LoadDetailBillTable();
                dtpBeginDay.Enabled = dtpEnđay.Enabled = dtpLimitDay.Enabled = cbbStatus.Enabled = txtStudentID.Enabled = false;
                btnAdd.Hide();
                btnCreate.Hide();
                btnDelete.Hide();
                btnConfirm.Show();
                return;
            }

        }

        private void LoadDetailBill()
        {
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select * from HOPDONG where MaHD = {bill.MaHD}");
            if (temp.Rows.Count <= 0) return;
            string maSV = temp.Rows[0]["MaSV"].ToString();

            dtpCreateDay.Value = bill.NgayLap;
            dtpBeginDay.Value = bill.TuNgay;
            dtpEnđay.Value = bill.DenNgay;
            dtpLimitDay.Value = bill.HanThu;
            cbbStatus.SelectedItem = bill.TrangThai;
            txtStudentID.Text = maSV;
            txtSubmit.Text = bill.TienDaNop.ToString();
            txtSum.Text = bill.TongTien.ToString();
            txtNote.Text = bill.GhiChu;

            if(bill.MaHoaDon != null)
            {
                lbID.Text = bill.MaHoaDon.ToString();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemChiTietHoaDon form = new ThemChiTietHoaDon();
            form.billForm = this;
            form.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn mục cần xóa", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            DataGridViewCellCollection cell = dgvShow.SelectedRows[0].Cells;
            foreach(CSDL.CHITIETHOADON item in detailBillList)
            {
                if(item.LoaiTien == cell["Loại tiền"].Value.ToString() && 
                    item.SoTien == decimal.Parse(cell["Số tiền"].Value.ToString()) && 
                    item.DonGia == decimal.Parse(cell["Đơn giá"].Value.ToString()))
                {
                    detailBillList.Remove(item);
                    break;
                }
            }
            LoadDetailBillTable();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(dtpBeginDay.Value > dtpEnđay.Value)
            {
                MessageBox.Show("Từ ngày phải trước đến ngày", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if(txtStudentID.Text.Trim() == "" || cbbStatus.SelectedItem == null || txtSubmit.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            DataTable temp = CSDL.CSDL.Instance.ExecuteQuery($@"select * from HOPDONG where MaSV like '{txtStudentID.Text}'
            and TrangThai like N'Còn hiệu lực'");
            if (temp.Rows.Count <= 0)
            {
                MessageBox.Show("Mã sinh viên hoặc hợp đồng không tồn tại", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (detailBillList.Count <= 0)
            {
                MessageBox.Show("Bạn hãy thêm mục vào hóa đơn", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CSDL.HOADON tempBill = new CSDL.HOADON();
            tempBill.NgayLap = dtpCreateDay.Value;
            tempBill.HanThu = dtpLimitDay.Value;
            tempBill.TuNgay = dtpBeginDay.Value;
            tempBill.DenNgay = dtpEnđay.Value;
            tempBill.MaHD = (int)temp.Rows[0]["MaHD"];
            tempBill.TrangThai = cbbStatus.SelectedItem.ToString();
            tempBill.TienDaNop = decimal.Parse(txtSubmit.Text);
            tempBill.TongTien = decimal.Parse(txtSum.Text);
            tempBill.GhiChu = txtNote.Text;
            if (CSDL.CSDL.Instance.AddBill(tempBill))
            {
                int billID = (int)CSDL.CSDL.Instance.ExecuteQuery($@"select * from HOADON where MaHD = {tempBill.MaHD} and TongTien
                = {tempBill.TongTien} and TienDaNop = {tempBill.TienDaNop}").Rows[0]["MaHoaDon"];
                foreach(CSDL.CHITIETHOADON item in detailBillList)
                {
                    item.MaHoaDon = billID;
                    if (!CSDL.CSDL.Instance.AddDetailBill(item))
                    {
                        MessageBox.Show("Tạo hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                        return;
                    }
                }
                loadBillList.Invoke();
                this.Close();
            }

        }

        private void txtSubmit_TextChanged(object sender, EventArgs e)
        {
            decimal tempSubmit;
            if (txtSum.Text.Trim() == "") return;
            if(decimal.TryParse(txtSubmit.Text,out tempSubmit))
            {
                if(tempSubmit >= decimal.Parse(txtSum.Text))
                {
                    cbbStatus.SelectedItem = "Đủ";
                }
                else
                {
                    cbbStatus.SelectedItem = "Thiếu";
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if ( cbbStatus.SelectedItem == null || txtSubmit.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            bill.TienDaNop = decimal.Parse(txtSubmit.Text);
            bill.GhiChu = txtNote.Text;
            bill.TrangThai = cbbStatus.SelectedItem.ToString();
            if (CSDL.CSDL.Instance.UpdateBill(bill))
            {
                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                loadBillList.Invoke();
                this.Close();
                return;
            }
        }
    }
}
