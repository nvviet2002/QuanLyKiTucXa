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

    }
}
