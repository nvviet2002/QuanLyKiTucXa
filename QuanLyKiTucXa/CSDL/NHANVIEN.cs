namespace QuanLyKiTucXa.CSDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {

        [Key]
        [StringLength(5)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNV { get; set; }

        public DateTime Ngaysinh { get; set; }

        [Required]
        [StringLength(20)]
        public string Gioitinh { get; set; }

        [Required]
        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(100)]
        public string Ghichu { get; set; }

        public string TaiKhoan { get; set; }



        public void SetDataNHANVIEN(DataTable _table)
        {
            this.MaNV = _table.Rows[0]["MaNV"].ToString();
            this.TenNV = _table.Rows[0]["TenNV"].ToString();
            this.Ngaysinh = (DateTime)_table.Rows[0]["NgaySinh"];
            this.Gioitinh = _table.Rows[0]["GioiTinh"].ToString();
            this.SDT = _table.Rows[0]["SDT"].ToString();
            this.ChucVu = _table.Rows[0]["ChucVu"].ToString();
            this.Ghichu = _table.Rows[0]["GhiChu"].ToString();
            this.TaiKhoan = _table.Rows[0]["TaiKhoan"].ToString();
        }

        public void SetNHANVIEN(string _maNV,string _tenNV,DateTime _ngaySinh,string _gioiTinh,
            string _sdt, string _chucVu, string _ghiChu, string _TK)
        {
            this.MaNV = _maNV;
            this.TenNV = _tenNV;
            this.Ngaysinh = _ngaySinh;
            this.Gioitinh = _gioiTinh;
            this.SDT = _sdt;
            this.ChucVu = _chucVu;
            this.Ghichu = _ghiChu;
            this.TaiKhoan = _TK;
        }
    }
}
