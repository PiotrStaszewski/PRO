using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRO_BackendApp.Models
{
    public partial class s16648Context : DbContext
    {
        public s16648Context()
        {
        }

        public s16648Context(DbContextOptions<s16648Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Lokal> Lokal { get; set; }
        public virtual DbSet<Platnosc> Platnosc { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Przepis> Przepis { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowienieSzczegoly> ZamowienieSzczegoly { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16648;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("Admin_pk");

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("Id_admin")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.HasKey(e => e.IdAdres)
                    .HasName("Adres_pk");

                entity.Property(e => e.IdAdres)
                    .HasColumnName("Id_adres")
                    .ValueGeneratedNever();

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NrDomu).HasColumnName("Nr_domu");

                entity.Property(e => e.NrMieszkania).HasColumnName("Nr_mieszkania");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlienta)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlienta)
                    .HasColumnName("Id_klienta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lokal>(entity =>
            {
                entity.HasKey(e => e.IdLokalu)
                    .HasName("Lokal_pk");

                entity.Property(e => e.IdLokalu)
                    .HasColumnName("Id_lokalu")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresIdAdres).HasColumnName("Adres_Id_adres");

                entity.HasOne(d => d.AdresIdAdresNavigation)
                    .WithMany(p => p.Lokal)
                    .HasForeignKey(d => d.AdresIdAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lokal_Adres");
            });

            modelBuilder.Entity<Platnosc>(entity =>
            {
                entity.HasKey(e => e.IdPlatnosc)
                    .HasName("Platnosc_pk");

                entity.Property(e => e.IdPlatnosc)
                    .HasColumnName("Id_platnosc")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.HasKey(e => e.IdProduktu)
                    .HasName("Produkt_pk");

                entity.Property(e => e.IdProduktu)
                    .HasColumnName("Id_produktu")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocji)
                    .HasName("Promocja_pk");

                entity.Property(e => e.IdPromocji)
                    .HasColumnName("Id_promocji")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Przepis>(entity =>
            {
                entity.HasKey(e => e.IdPrzepisu)
                    .HasName("Przepis_pk");

                entity.Property(e => e.IdPrzepisu)
                    .HasColumnName("Id_przepisu")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProduktIdProduktu).HasColumnName("Produkt_Id_produktu");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_Id_skladnik");

                entity.HasOne(d => d.ProduktIdProduktuNavigation)
                    .WithMany(p => p.Przepis)
                    .HasForeignKey(d => d.ProduktIdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Przepis_Produkt");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.Przepis)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Przepis_Skladnik");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("Id_skladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.Koszt).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie)
                    .HasColumnName("Id_zamowienie")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresIdAdres).HasColumnName("Adres_Id_adres");

                entity.Property(e => e.Cena).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.KlientIdKlienta).HasColumnName("Klient_Id_klienta");

                entity.Property(e => e.LokalIdLokalu).HasColumnName("Lokal_Id_lokalu");

                entity.Property(e => e.PlatnoscIdPlatnosc).HasColumnName("Platnosc_Id_platnosc");

                entity.HasOne(d => d.AdresIdAdresNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.AdresIdAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Adres");

                entity.HasOne(d => d.KlientIdKlientaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KlientIdKlienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");

                entity.HasOne(d => d.LokalIdLokaluNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.LokalIdLokalu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Lokal");

                entity.HasOne(d => d.PlatnoscIdPlatnoscNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PlatnoscIdPlatnosc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Platnosc");
            });

            modelBuilder.Entity<ZamowienieSzczegoly>(entity =>
            {
                entity.HasKey(e => e.IdSzczegoly)
                    .HasName("ZamowienieSzczegoly_pk");

                entity.Property(e => e.IdSzczegoly)
                    .HasColumnName("Id_szczegoly")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ProduktIdProduktu).HasColumnName("Produkt_Id_produktu");

                entity.Property(e => e.PromocjaIdPromocji).HasColumnName("Promocja_Id_promocji");

                entity.Property(e => e.ZamowienieIdZamowienie).HasColumnName("Zamowienie_Id_zamowienie");

                entity.HasOne(d => d.ProduktIdProduktuNavigation)
                    .WithMany(p => p.ZamowienieSzczegoly)
                    .HasForeignKey(d => d.ProduktIdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ZamowienieSzczegoly_Produkt");

                entity.HasOne(d => d.PromocjaIdPromocjiNavigation)
                    .WithMany(p => p.ZamowienieSzczegoly)
                    .HasForeignKey(d => d.PromocjaIdPromocji)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ZamowienieSzczegoly_Promocja");

                entity.HasOne(d => d.ZamowienieIdZamowienieNavigation)
                    .WithMany(p => p.ZamowienieSzczegoly)
                    .HasForeignKey(d => d.ZamowienieIdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ZamowienieSzczegoly_Zamowienie");
            });
        }
    }
}
