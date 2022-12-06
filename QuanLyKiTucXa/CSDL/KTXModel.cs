using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyKiTucXa.CSDL
{
    public partial class KTXModel : DbContext
    {
        public KTXModel()
            : base("name=KTXModel")
        {
        }

        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<HOPDONG> HOPDONGs { get; set; }
        public virtual DbSet<KHU> KHUs { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TOANHA> TOANHAs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.SoTien)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CHUCVU>()
                .Property(e => e.MaCV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHUCVU>()
                .HasMany(e => e.NHANVIENs)
                .WithRequired(e => e.CHUCVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TongTien)
                .HasPrecision(12, 2);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TienDaNop)
                .HasPrecision(12, 2);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOPDONG>()
                .Property(e => e.MaHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOPDONG>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOPDONG>()
                .Property(e => e.MaSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOPDONG>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOPDONG>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.HOPDONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHU>()
                .Property(e => e.MaKhu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHU>()
                .HasMany(e => e.TOANHAs)
                .WithRequired(e => e.KHU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.MaLoaiPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.DienTich)
                .HasPrecision(12, 2);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.GiaPhong)
                .HasPrecision(12, 2);

            modelBuilder.Entity<LOAIPHONG>()
                .HasMany(e => e.PHONGs)
                .WithRequired(e => e.LOAIPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaCV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOPDONGs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaTN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaLoaiPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.HOPDONGs)
                .WithRequired(e => e.PHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.MaSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .HasMany(e => e.HOPDONGs)
                .WithRequired(e => e.SINHVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TaiKhoan1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TOANHA>()
                .Property(e => e.MaTN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TOANHA>()
                .Property(e => e.MaKhu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TOANHA>()
                .HasMany(e => e.PHONGs)
                .WithRequired(e => e.TOANHA)
                .WillCascadeOnDelete(false);
        }
    }
}
