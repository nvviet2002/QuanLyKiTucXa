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

        [Key]
        public int MaHD { get; set; }

        public DateTime NgayLap { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayHetHan { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

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

    }
}
