namespace QuanLyKiTucXa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        public DateTime NgayLap { get; set; }

        public DateTime HanThu { get; set; }

        public DateTime TuNgay { get; set; }

        public DateTime DenNgay { get; set; }

        public decimal TongTien { get; set; }

        public decimal TienDaNop { get; set; }

        [Required]
        [StringLength(30)]
        public string TrangThai { get; set; }

        [Required]
        [StringLength(5)]
        public string MaHD { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual HOPDONG HOPDONG { get; set; }
    }
}
