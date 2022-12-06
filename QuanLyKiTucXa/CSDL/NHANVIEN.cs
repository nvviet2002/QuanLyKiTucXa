namespace QuanLyKiTucXa.CSDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        [StringLength(5)]
        public string MaCV { get; set; }

        [StringLength(100)]
        public string Ghichu { get; set; }

        public int? MaTK { get; set; }

        public virtual CHUCVU CHUCVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
