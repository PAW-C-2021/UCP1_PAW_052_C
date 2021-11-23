using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UcpPraktikum.Models
{
    public partial class PenjualannnContext : DbContext
    {
        public PenjualannnContext()
        {
        }

        public PenjualannnContext(DbContextOptions<PenjualannnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barang { get; set; }
        public virtual DbSet<Pembeli> Pembeli { get; set; }
        public virtual DbSet<Pembelian> Pembelian { get; set; }
        public virtual DbSet<Pemesanan> Pemesanan { get; set; }
        public virtual DbSet<Suplier> Suplier { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.Property(e => e.IdBarang)
                    .HasColumnName("id_barang")
                    .ValueGeneratedNever();

                entity.Property(e => e.HargaBeli).HasColumnName("harga_beli");

                entity.Property(e => e.HargaJual).HasColumnName("harga_jual");

                entity.Property(e => e.JenisBarang)
                    .HasColumnName("jenis_barang")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaBarang)
                    .HasColumnName("nama_barang")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.Property(e => e.IdPembeli)
                    .HasColumnName("id_pembeli")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("alamat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasColumnName("nama")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.TglLahir)
                    .HasColumnName("tgl_lahir")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Pembelian>(entity =>
            {
                entity.HasKey(e => e.IdPembelian);

                entity.Property(e => e.IdPembelian)
                    .HasColumnName("id_pembelian")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdBarang).HasColumnName("id_barang");

                entity.Property(e => e.IdSuplier).HasColumnName("id_suplier");

                entity.Property(e => e.Jumlah).HasColumnName("jumlah");

                entity.Property(e => e.TglPembelian)
                    .HasColumnName("tgl_pembelian")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Pembelian)
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("FK_Pembelian_Barang");

                entity.HasOne(d => d.IdSuplierNavigation)
                    .WithMany(p => p.Pembelian)
                    .HasForeignKey(d => d.IdSuplier)
                    .HasConstraintName("FK_Pembelian_Suplier");
            });

            modelBuilder.Entity<Pemesanan>(entity =>
            {
                entity.HasKey(e => e.IdPesanan);

                entity.Property(e => e.IdPesanan)
                    .HasColumnName("id_pesanan")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdBarang).HasColumnName("id_barang");

                entity.Property(e => e.IdPelanggan).HasColumnName("id_pelanggan");

                entity.Property(e => e.Jumlah).HasColumnName("jumlah");

                entity.Property(e => e.TglPemesanan)
                    .HasColumnName("tgl_pemesanan")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Pemesanan)
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("FK_Pemesanan_Barang");

                entity.HasOne(d => d.IdPelangganNavigation)
                    .WithMany(p => p.Pemesanan)
                    .HasForeignKey(d => d.IdPelanggan)
                    .HasConstraintName("FK_Pemesanan_Pembeli");
            });

            modelBuilder.Entity<Suplier>(entity =>
            {
                entity.HasKey(e => e.IdSuplier);

                entity.Property(e => e.IdSuplier)
                    .HasColumnName("id_suplier")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("alamat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasColumnName("nama")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
