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

        public ThongTinHopDong()
        {
            InitializeComponent();
        }
    }
}
