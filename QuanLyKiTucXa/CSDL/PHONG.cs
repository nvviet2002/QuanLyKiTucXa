namespace QuanLyKiTucXa.CSDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            HOPDONGs = new HashSet<HOPDONG>();
        }

        [Key]
        [StringLength(5)]
        public string MaPhong { get; set; }

        public int? TongSoHD { get; set; }

        [StringLength(200)]
        public string Ghichu { get; set; }

        [Required]
        [StringLength(5)]
        public string MaTN { get; set; }

        [Required]
        [StringLength(5)]
        public string MaLoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }

        public virtual TOANHA TOANHA { get; set; }
    }
}
