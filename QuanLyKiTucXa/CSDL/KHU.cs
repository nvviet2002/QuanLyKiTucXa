namespace QuanLyKiTucXa.CSDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHU")]
    public partial class KHU
    {


        [Key]
        [StringLength(5)]
        public string MaKhu { get; set; }

        [Required]
        [StringLength(30)]
        public string TenKhu { get; set; }

        [Required]
        [StringLength(200)]
        public string Vitri { get; set; }

        [StringLength(100)]
        public string Ghichu { get; set; }

    }
}
