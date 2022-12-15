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
                MessageBox.Show("Bạn hãy nhận đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if(maHoaDon != null)
            {
                
            }
        }
    }
}
