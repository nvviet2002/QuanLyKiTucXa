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
        }

        private void ThongTinHoaDon_Load(object sender, EventArgs e)
        {
            txtStaffName.Text = staffName;
            cbbStatus.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
