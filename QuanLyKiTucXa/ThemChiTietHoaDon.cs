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
    public partial class ThemChiTietHoaDon : MetroFramework.Forms.MetroForm
    {
        public int maHoaDon;
        public ThongTinHoaDon billForm;
        public ThemChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbType.SelectedItem == null) return;
            if (cbbType.SelectedItem.ToString() == "Tiền phòng")
            {
                SetControls(false);
                cbbUnit.SelectedItem = "Kỳ";
                return;
            }
            if (cbbType.SelectedItem.ToString() == "Tiền điện")
            {
                SetControls(false);
                cbbUnit.SelectedItem = "kWh";
                SetControls(true);
                return;
            }
            if (cbbType.SelectedItem.ToString() == "Tiền nước")
            {
                SetControls(false);
                cbbUnit.SelectedItem = "m3";
                SetControls(true);
                return;
            }
            
        }

        private void SetControls(bool _enable)
        {
            if (_enable)
            {
                txtNewNum.Enabled = _enable;
                txtOldNum.Enabled = _enable;
                txtOldNum.Text = txtNewNum.Text = 0.ToString();
                return;
            }
            txtNewNum.Enabled = _enable;
            txtOldNum.Enabled = _enable;
            txtNewNum.Text = 1.ToString();
            txtOldNum.Text = 0.ToString();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cbbType.SelectedItem == null || cbbUnit.SelectedItem == null || txtNewNum.Text.Trim() == ""||
            txtOldNum.Text.Trim() == "" || txtPrice.Text.Trim() == "" || txtMoney.Text.Trim() == "")
            {
                MessageBox.Show("Bạn hãy nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            CSDL.CHITIETHOADON tempDetailBill = new CSDL.CHITIETHOADON();
            tempDetailBill.LoaiTien = cbbType.SelectedItem.ToString();
            tempDetailBill.SoCu = int.Parse(txtOldNum.Text);
            tempDetailBill.SoMoi = int.Parse(txtNewNum.Text);
            tempDetailBill.DonGia = decimal.Parse(txtPrice.Text);
            tempDetailBill.DonViTinh = cbbUnit.SelectedItem.ToString();
            tempDetailBill.SoTien = decimal.Parse(txtMoney.Text);
            tempDetailBill.GhiChu = txtNote.Text;
            billForm.detailBillList.Add(tempDetailBill);
            billForm.LoadDetailBillTable();
            this.Close();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            decimal tempNum;
            if (decimal.TryParse(txtPrice.Text,out tempNum) == true)
            {
                txtMoney.Text = (tempNum * (int.Parse(txtNewNum.Text) - int.Parse(txtOldNum.Text))).ToString();
            }
        }
    }
}
