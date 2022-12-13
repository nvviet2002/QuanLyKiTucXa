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

        public DataTable roomShow;

        public ThongTinHopDong()
        {
            InitializeComponent();
        }

        void LoadRoomShow()
        {
            roomShow = CSDL.CSDL.Instance.ExecuteQuery($@"select MaPhong,TenLoaiPhong, CONCAT(CONVERT(char(1),
            TongSoHD),'/',CONVERT(char(1),TongSoHD)) as SoNguoiO, MaTN,PHONG.Ghichu
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
        }
    }
}
