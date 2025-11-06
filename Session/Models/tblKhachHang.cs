namespace Session.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKhachHang")]
    public partial class tblKhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblKhachHang()
        {
            tblHoaDons = new HashSet<tblHoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaKhachHang { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHoaDon> tblHoaDons { get; set; }
    }
}
