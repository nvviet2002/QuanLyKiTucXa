namespace QuanLyKiTucXa.CSDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data;

    [Table("SINHVIEN")]
    public partial class SINHVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SINHVIEN()
        {
            HOPDONGs = new HashSet<HOPDONG>();
        }

        [Key]
        [StringLength(5)]
        public string MaSV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSV { get; set; }

        public DateTime Ngaysinh { get; set; }

        [Required]
        [StringLength(20)]
        public string Gioitinh { get; set; }

        [Required]
        [StringLength(50)]
        public string Khoa { get; set; }

        [Required]
        [StringLength(50)]
        public string Lop { get; set; }

        [Required]
        [StringLength(15)]
        public string SDT { get; set; }

        [Required]
        [StringLength(200)]
        public string Diachi { get; set; }

        [StringLength(200)]
        public string Ghichu { get; set; }

        public int? MaTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        public void SetDataSINHVIEN(string _MSV,string _tenSV,DateTime _ngaySinh,string _GioiTinh
            ,string _khoa, string _lop, string _sdt,string _diaChi,string _ghiChu)
        {
            this.MaSV = _MSV;
            this.TenSV = _tenSV;
            this.Ngaysinh = _ngaySinh;
            this.Gioitinh = _GioiTinh;
            this.Khoa = _khoa;
            this.Lop = _lop;
            this.SDT = _sdt;
            this.Diachi = _diaChi;
            this.Ghichu = _ghiChu;
        }

        public void SetDataSINHVIEN(DataTable _table)
        {
            this.MaSV = _table.Rows[0]["MaSV"].ToString();
            this.TenSV = _table.Rows[0]["TenSV"].ToString();
            this.Ngaysinh = (DateTime)_table.Rows[0]["NgaySinh"];
            this.Gioitinh = _table.Rows[0]["GioiTinh"].ToString();
            this.Khoa = _table.Rows[0]["Khoa"].ToString();
            this.Lop = _table.Rows[0]["Lop"].ToString();
            this.SDT = _table.Rows[0]["SDT"].ToString();
            this.Diachi = _table.Rows[0]["DiaChi"].ToString();
            this.Ghichu = _table.Rows[0]["GhiChu"].ToString();
        }
    }
}
