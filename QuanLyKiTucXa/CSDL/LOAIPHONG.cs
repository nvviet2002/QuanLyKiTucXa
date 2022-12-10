namespace QuanLyKiTucXa.CSDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIPHONG")]
    public partial class LOAIPHONG
    {


        [Key]
        [StringLength(5)]
        public string MaLoaiPhong { get; set; }

        [Required]
        [StringLength(30)]
        public string TenLoaiPhong { get; set; }

        public int SoNguoi { get; set; }

        public decimal DienTich { get; set; }

        public decimal GiaPhong { get; set; }

        [StringLength(200)]
        public string Ghichu { get; set; }

    }
}
