namespace QuanLyKiTucXa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHU")]
    public partial class KHU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHU()
        {
            TOANHAs = new HashSet<TOANHA>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOANHA> TOANHAs { get; set; }
    }
}
