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
    public partial class ThongTinNhanVien : MetroFramework.Forms.MetroForm
    {
        public ThongTinNhanVien()
        {
            InitializeComponent();
        }



        private void btnStaff_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
