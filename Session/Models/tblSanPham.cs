namespace Session.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSanPham")]
    public partial class tblSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSanPham()
        {
            tblChiTiets = new HashSet<tblChiTiet>();
        }

        [Key]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? DonGia { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        public int? SoLuongTon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChiTiet> tblChiTiets { get; set; }
    }
}
