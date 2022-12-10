namespace QuanLyKiTucXa.CSDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(20)]
        public string LoaiTK { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Ghichu { get; set; }

        public void SetTAIKHOAN(string _tenTK,string _matkhau,string _email,
            string _ghiChu,string _loaiTK)
        {
            this.TaiKhoan = _tenTK;
            this.MatKhau = _matkhau;
            this.Email = _email;
            this.Ghichu = _ghiChu;
            this.LoaiTK = _loaiTK;
        }
    }
}
