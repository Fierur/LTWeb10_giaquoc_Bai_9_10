namespace Session.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHoaDon")]
    public partial class tblHoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblHoaDon()
        {
            tblChiTiets = new HashSet<tblChiTiet>();
        }

        [Key]
        [StringLength(10)]
        public string MaHoaDon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHoaDon { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChiTiet> tblChiTiets { get; set; }

        public virtual tblKhachHang tblKhachHang { get; set; }
    }
}
