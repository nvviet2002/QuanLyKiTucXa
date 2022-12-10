namespace QuanLyKiTucXa.CSDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOANHA")]
    public partial class TOANHA
    {
        

        [Key]
        [StringLength(5)]
        public string MaTN { get; set; }

        [Required]
        [StringLength(30)]
        public string TenTN { get; set; }

        [Required]
        [StringLength(5)]
        public string MaKhu { get; set; }

        [StringLength(200)]
        public string Ghichu { get; set; }
    }
}
