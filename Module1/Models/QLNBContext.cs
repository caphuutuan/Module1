using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Module1.Models
{
    public partial class QLNBContext : DbContext
    {
        public QLNBContext()
        {
        }

        public QLNBContext(DbContextOptions<QLNBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaiBao> BaiBaos { get; set; } = null!;
        public virtual DbSet<Ctdh> Ctdhs { get; set; } = null!;
        public virtual DbSet<DoanhThu> DoanhThus { get; set; } = null!;
        public virtual DbSet<DocGium> DocGia { get; set; } = null!;
        public virtual DbSet<DoiTac> DoiTacs { get; set; } = null!;
        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<LinhVucNb> LinhVucNbs { get; set; } = null!;
        public virtual DbSet<NhaBao> NhaBaos { get; set; } = null!;
        public virtual DbSet<QuangCao> QuangCaos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TheLoaiBaiBao> TheLoaiBaiBaos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OCRR1TC\\huutuan;Database=QLNB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiBao>(entity =>
            {
                entity.HasKey(e => e.MaBb);

                entity.ToTable("BaiBao");

                entity.Property(e => e.MaBb).HasColumnName("MaBB");

                entity.Property(e => e.DanhGia).HasMaxLength(50);

                entity.Property(e => e.MaLv).HasColumnName("MaLV");

                entity.Property(e => e.MaTl).HasColumnName("MaTL");

                entity.Property(e => e.NgayChinhSua).HasColumnType("datetime");

                entity.Property(e => e.NgayViet).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TenBb)
                    .HasMaxLength(50)
                    .HasColumnName("TenBB");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.MaLvNavigation)
                    .WithMany(p => p.BaiBaos)
                    .HasForeignKey(d => d.MaLv)
                    .HasConstraintName("FK_BaiBao_LinhVucNB");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany(p => p.BaiBaos)
                    .HasForeignKey(d => d.MaTl)
                    .HasConstraintName("FK_BaiBao_TheLoaiBaiBao");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BaiBaos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_BaiBao_User");
            });

            modelBuilder.Entity<Ctdh>(entity =>
            {
                entity.HasKey(e => e.MaCtdh);

                entity.ToTable("CTDH");

                entity.Property(e => e.MaCtdh).HasColumnName("MaCTDH");

                entity.Property(e => e.MaBb).HasColumnName("MaBB");

                entity.Property(e => e.MaDh).HasColumnName("MaDH");

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.Ctdhs)
                    .HasForeignKey(d => d.MaDh)
                    .HasConstraintName("FK_CTDH_BaiBao");

                entity.HasOne(d => d.MaDh1)
                    .WithMany(p => p.Ctdhs)
                    .HasForeignKey(d => d.MaDh)
                    .HasConstraintName("FK_CTDH_DonHang");
            });

            modelBuilder.Entity<DoanhThu>(entity =>
            {
                entity.HasKey(e => e.MaDt);

                entity.ToTable("DoanhThu");

                entity.Property(e => e.MaDt).HasColumnName("MaDT");

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.Ngay).HasColumnType("date");
            });

            modelBuilder.Entity<DocGium>(entity =>
            {
                entity.HasKey(e => e.MaDg);

                entity.Property(e => e.MaDg).HasColumnName("MaDG");

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TenDg)
                    .HasMaxLength(50)
                    .HasColumnName("TenDG");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.DocGia)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_DocGia_Role");
            });

            modelBuilder.Entity<DoiTac>(entity =>
            {
                entity.HasKey(e => e.MaDt);

                entity.ToTable("DoiTac");

                entity.Property(e => e.MaDt).HasColumnName("MaDT");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.DoiTacs)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_DoiTac_Role");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDh);

                entity.ToTable("DonHang");

                entity.Property(e => e.MaDh).HasColumnName("MaDH");

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<LinhVucNb>(entity =>
            {
                entity.HasKey(e => e.MaLinhVuc);

                entity.ToTable("LinhVucNB");

                entity.Property(e => e.TenLinhVuc).HasMaxLength(50);
            });

            modelBuilder.Entity<NhaBao>(entity =>
            {
                entity.HasKey(e => e.MaNb);

                entity.ToTable("NhaBao");

                entity.Property(e => e.MaNb).HasColumnName("MaNB");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.NhaBaos)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_NhaBao_Role");
            });

            modelBuilder.Entity<QuangCao>(entity =>
            {
                entity.HasKey(e => e.MaQc);

                entity.ToTable("QuangCao");

                entity.Property(e => e.MaQc).HasColumnName("MaQC");

                entity.Property(e => e.HinhAnh)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Link)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.MoTa)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Ten)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TheLoaiBaiBao>(entity =>
            {
                entity.HasKey(e => e.MaTl);

                entity.ToTable("TheLoaiBaiBao");

                entity.Property(e => e.MaTl).HasColumnName("MaTL");

                entity.Property(e => e.TenTl)
                    .HasMaxLength(50)
                    .HasColumnName("TenTL");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.NgaySinh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
