namespace QuanLyKiTucXa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string LoaiTien { get; set; }

        public decimal SoTien { get; set; }

        public int MaHoaDon { get; set; }

        [Required]
        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
