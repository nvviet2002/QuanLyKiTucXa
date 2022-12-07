namespace QuanLyKiTucXa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOANHA")]
    public partial class TOANHA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOANHA()
        {
            PHONGs = new HashSet<PHONG>();
        }

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

        public virtual KHU KHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONG> PHONGs { get; set; }
    }
}
