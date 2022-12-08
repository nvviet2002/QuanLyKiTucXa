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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOPDONGs = new HashSet<HOPDONG>();
        }

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

        [Required]
        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(100)]
        public string Ghichu { get; set; }

        public int? MaTK { get; set; }

        public virtual CHUCVU CHUCVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        public void SetDataNHANVIEN(DataTable _table)
        {
            this.MaNV = _table.Rows[0]["MaNV"].ToString();
            this.TenNV = _table.Rows[0]["TenNV"].ToString();
            this.Ngaysinh = (DateTime)_table.Rows[0]["NgaySinh"];
            this.Gioitinh = _table.Rows[0]["GioiTinh"].ToString();
            this.SDT = _table.Rows[0]["SDT"].ToString();
            this.ChucVu = _table.Rows[0]["ChucVu"].ToString();
            this.Ghichu = _table.Rows[0]["GhiChu"].ToString();
            this.MaTK = (int)_table.Rows[0]["MaTK"];
        }
    }
}
