using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Session.Models
{
    public partial class DuLieu : DbContext
    {
        public DuLieu()
            : base("name=DuLieu")
        {
        }

        public virtual DbSet<tblChiTiet> tblChiTiets { get; set; }
        public virtual DbSet<tblHoaDon> tblHoaDons { get; set; }
        public virtual DbSet<tblKhachHang> tblKhachHangs { get; set; }
        public virtual DbSet<tblSanPham> tblSanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblChiTiet>()
                .Property(e => e.MaHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblChiTiet>()
                .Property(e => e.MaSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblHoaDon>()
                .Property(e => e.MaHoaDon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblHoaDon>()
                .Property(e => e.MaKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblHoaDon>()
                .HasMany(e => e.tblChiTiets)
                .WithRequired(e => e.tblHoaDon)
                .HasForeignKey(e => e.MaHD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblKhachHang>()
                .Property(e => e.MaKhachHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblKhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<tblKhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<tblKhachHang>()
                .HasMany(e => e.tblHoaDons)
                .WithOptional(e => e.tblKhachHang)
                .HasForeignKey(e => e.MaKH);

            modelBuilder.Entity<tblSanPham>()
                .Property(e => e.MaSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblSanPham>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<tblSanPham>()
                .HasMany(e => e.tblChiTiets)
                .WithRequired(e => e.tblSanPham)
                .HasForeignKey(e => e.MaSP)
                .WillCascadeOnDelete(false);
        }
    }
}
