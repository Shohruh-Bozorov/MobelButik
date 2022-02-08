using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MobelButik.Models
{
    public partial class NewtonContext : DbContext
    {
        public NewtonContext()
        {
        }

        public NewtonContext(DbContextOptions<NewtonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BetalningsAlternativ> BetalningsAlternativs { get; set; }
        public virtual DbSet<Färg> Färgs { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Kund> Kunds { get; set; }
        public virtual DbSet<Kundkorg> Kundkorgs { get; set; }
        public virtual DbSet<LeveransAlternativ> LeveransAlternativs { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<OrderHistorik> OrderHistoriks { get; set; }
        public virtual DbSet<Produkt> Produkts { get; set; }
        public virtual DbSet<Tillverkare> Tillverkares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:mobelbutik.database.windows.net,1433;Initial Catalog=Newton;Persist Security Info=False;User ID=vidrusen;Password=troll100!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BetalningsAlternativ>(entity =>
            {
                entity.ToTable("Betalnings alternativ");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Färg>(entity =>
            {
                entity.ToTable("Färg");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("Kategori");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kund>(entity =>
            {
                entity.ToTable("Kund");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kundkorg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Kundkorg");

                entity.Property(e => e.ProduktId).HasColumnName("ProduktID");

                entity.HasOne(d => d.Produkt)
                    .WithMany()
                    .HasForeignKey(d => d.ProduktId)
                    .HasConstraintName("FK_Kundkorg.ProduktID");
            });

            modelBuilder.Entity<LeveransAlternativ>(entity =>
            {
                entity.ToTable("Leverans alternativ");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderHistorik>(entity =>
            {
                entity.ToTable("OrderHistorik");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.KundId).HasColumnName("KundID");

                entity.Property(e => e.ProduktId).HasColumnName("ProduktID");

                entity.HasOne(d => d.Kund)
                    .WithMany(p => p.OrderHistoriks)
                    .HasForeignKey(d => d.KundId)
                    .HasConstraintName("FK_OrderHistorik.KundID");

                entity.HasOne(d => d.Produkt)
                    .WithMany(p => p.OrderHistoriks)
                    .HasForeignKey(d => d.ProduktId)
                    .HasConstraintName("FK_OrderHistorik.ProduktID");
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.ToTable("Produkt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProduktNamn)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FärgNavigation)
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.Färg)
                    .HasConstraintName("FK_Produkt.Färg");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Produkt.KategoriId");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.Material)
                    .HasConstraintName("FK_Produkt.Material");

                entity.HasOne(d => d.Tillverkare)
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.TillverkareId)
                    .HasConstraintName("FK_Produkt.TillverkareId");
            });

            modelBuilder.Entity<Tillverkare>(entity =>
            {
                entity.ToTable("Tillverkare");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Land)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
