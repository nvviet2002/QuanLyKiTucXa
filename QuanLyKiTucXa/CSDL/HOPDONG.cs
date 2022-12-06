namespace QuanLyKiTucXa.CSDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOPDONG")]
    public partial class HOPDONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOPDONG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(5)]
        public string MaHD { get; set; }

        public DateTime NgayLap { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayHetHan { get; set; }

        public int TrangThai { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(5)]
        public string MaSV { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPhong { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
