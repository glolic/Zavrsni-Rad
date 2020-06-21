using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZavrsniRadASPNET.Models
{
    public partial class HokejKlubContext : DbContext
    {
        public HokejKlubContext()
        {
        }

        public HokejKlubContext(DbContextOptions<HokejKlubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzave> Drzave { get; set; }
        public virtual DbSet<IgracMomcad> IgracMomcad { get; set; }
        public virtual DbSet<Igraci> Igraci { get; set; }
        public virtual DbSet<IgraciPlacanja> IgraciPlacanja { get; set; }
        public virtual DbSet<Klub> Klub { get; set; }
        public virtual DbSet<Lokacija> Lokacija { get; set; }
        public virtual DbSet<Momcadi> Momcadi { get; set; }
        public virtual DbSet<Natjecanja> Natjecanja { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<Osoblje> Osoblje { get; set; }
        public virtual DbSet<OsobljeMomcad> OsobljeMomcad { get; set; }
        public virtual DbSet<Partneri> Partneri { get; set; }
        public virtual DbSet<PlacanjaPartneri> PlacanjaPartneri { get; set; }
        public virtual DbSet<Pozicija> Pozicija { get; set; }
        public virtual DbSet<Spol> Spol { get; set; }
        public virtual DbSet<Stadioni> Stadioni { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Utakmice> Utakmice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BEVM3ON\\SQLEXPRESS;Database=HokejKlub;Trusted_Connection=True;MultipleActiveResultSets=true;");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzave>(entity =>
            {
                entity.ToTable("drzave");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NazivDrzave)
                    .HasColumnName("nazivDrzave")
                    .HasMaxLength(50);

                entity.Property(e => e.Oznaka)
                    .HasColumnName("oznaka")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IgracMomcad>(entity =>
            {
                entity.ToTable("igracMomcad");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IgracId).HasColumnName("igracID");

                entity.Property(e => e.MomcadId).HasColumnName("momcadID");

                entity.HasOne(d => d.Igrac)
                    .WithMany(p => p.IgracMomcad)
                    .HasForeignKey(d => d.IgracId)
                    .HasConstraintName("FK_igracMomcad_igraci");

                entity.HasOne(d => d.Momcad)
                    .WithMany(p => p.IgracMomcad)
                    .HasForeignKey(d => d.MomcadId)
                    .HasConstraintName("FK_igracMomcad_momcadi");
            });

            modelBuilder.Entity<Igraci>(entity =>
            {
                entity.ToTable("igraci");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrojDresa).HasColumnName("brojDresa");

                entity.Property(e => e.OsobaId).HasColumnName("osobaID");

                entity.Property(e => e.PozicijaId).HasColumnName("pozicijaID");

                entity.HasOne(d => d.Osoba)
                    .WithMany(p => p.Igraci)
                    .HasForeignKey(d => d.OsobaId)
                    .HasConstraintName("FK_igraci_Osoba");

                entity.HasOne(d => d.Pozicija)
                    .WithMany(p => p.Igraci)
                    .HasForeignKey(d => d.PozicijaId)
                    .HasConstraintName("FK_igraci_pozicija");
            });

            modelBuilder.Entity<IgraciPlacanja>(entity =>
            {
                entity.ToTable("igraciPlacanja");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IgracId).HasColumnName("igracID");

                entity.Property(e => e.Iznos).HasColumnName("iznos");

                entity.Property(e => e.RazlogPlacanja)
                    .HasColumnName("razlogPlacanja")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Igrac)
                    .WithMany(p => p.IgraciPlacanja)
                    .HasForeignKey(d => d.IgracId)
                    .HasConstraintName("FK_igraciPlacanja_igraci");
            });

            modelBuilder.Entity<Klub>(entity =>
            {
                entity.ToTable("klub");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GodinaOsnivanja).HasColumnName("godinaOsnivanja");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(50);

                entity.Property(e => e.SjedisteKlubaId).HasColumnName("sjedisteKlubaID");

                entity.Property(e => e.StadionId).HasColumnName("stadionID");
            });

            modelBuilder.Entity<Lokacija>(entity =>
            {
                entity.ToTable("lokacija");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adresa)
                    .HasColumnName("adresa")
                    .HasMaxLength(50);

                entity.Property(e => e.DrzavaId).HasColumnName("drzavaID");

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Lokacija)
                    .HasForeignKey(d => d.DrzavaId)
                    .HasConstraintName("FK_lokacija_drzave");
            });

            modelBuilder.Entity<Momcadi>(entity =>
            {
                entity.ToTable("momcadi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KlubId).HasColumnName("klubID");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Klub)
                    .WithMany(p => p.Momcadi)
                    .HasForeignKey(d => d.KlubId)
                    .HasConstraintName("FK_momcadi_klub");
            });

            modelBuilder.Entity<Natjecanja>(entity =>
            {
                entity.ToTable("natjecanja");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DrzavaId).HasColumnName("drzavaID");

                entity.Property(e => e.ImeNatjecanja)
                    .HasColumnName("imeNatjecanja")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Natjecanja)
                    .HasForeignKey(d => d.DrzavaId)
                    .HasConstraintName("FK_natjecanja_drzave");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumRodenja)
                    .HasColumnName("datumRodenja")
                    .HasColumnType("date");

                entity.Property(e => e.DrzavaRodenjaId).HasColumnName("drzavaRodenjaID");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(50);

                entity.Property(e => e.Oib)
                    .HasColumnName("OIB")
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(50);

                entity.Property(e => e.SpolId).HasColumnName("spolID");

                entity.Property(e => e.UlogaId).HasColumnName("ulogaID");

                entity.HasOne(d => d.DrzavaRodenja)
                    .WithMany(p => p.Osoba)
                    .HasForeignKey(d => d.DrzavaRodenjaId)
                    .HasConstraintName("FK_Osoba_drzave");

                entity.HasOne(d => d.Spol)
                    .WithMany(p => p.Osoba)
                    .HasForeignKey(d => d.SpolId)
                    .HasConstraintName("FK_Osoba_spol");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.Osoba)
                    .HasForeignKey(d => d.UlogaId)
                    .HasConstraintName("FK_Osoba_uloga");
            });

            modelBuilder.Entity<Osoblje>(entity =>
            {
                entity.ToTable("osoblje");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OsobaId).HasColumnName("osobaID");

                entity.HasOne(d => d.Osoba)
                    .WithMany(p => p.Osoblje)
                    .HasForeignKey(d => d.OsobaId)
                    .HasConstraintName("FK_osoblje_Osoba");
            });

            modelBuilder.Entity<OsobljeMomcad>(entity =>
            {
                entity.ToTable("osobljeMomcad");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MomcadId).HasColumnName("momcadID");

                entity.Property(e => e.OsobljeId).HasColumnName("osobljeID");

                entity.HasOne(d => d.Momcad)
                    .WithMany(p => p.OsobljeMomcad)
                    .HasForeignKey(d => d.MomcadId)
                    .HasConstraintName("FK_osobljeMomcad_momcadi");

                entity.HasOne(d => d.Osoblje)
                    .WithMany(p => p.OsobljeMomcad)
                    .HasForeignKey(d => d.OsobljeId)
                    .HasConstraintName("FK_osobljeMomcad_osoblje");
            });

            modelBuilder.Entity<Partneri>(entity =>
            {
                entity.ToTable("partneri");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LokacijaId).HasColumnName("lokacijaID");

                entity.Property(e => e.NazivPartnera)
                    .HasColumnName("nazivPartnera")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.Partneri)
                    .HasForeignKey(d => d.LokacijaId)
                    .HasConstraintName("FK_partneri_lokacija");
            });

            modelBuilder.Entity<PlacanjaPartneri>(entity =>
            {
                entity.ToTable("placanjaPartneri");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iznos).HasColumnName("iznos");

                entity.Property(e => e.PartnerId).HasColumnName("partnerID");

                entity.Property(e => e.Placeno).HasColumnName("placeno");

                entity.Property(e => e.RazlogPlacanja)
                    .HasColumnName("razlogPlacanja")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.PlacanjaPartneri)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_placanjaPartneri_partneri");
            });

            modelBuilder.Entity<Pozicija>(entity =>
            {
                entity.ToTable("pozicija");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Spol>(entity =>
            {
                entity.ToTable("spol");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Stadioni>(entity =>
            {
                entity.ToTable("stadioni");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Kapacitet).HasColumnName("kapacitet");

                entity.Property(e => e.LokacijaId).HasColumnName("lokacijaID");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.ToTable("uloga");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Utakmice>(entity =>
            {
                entity.ToTable("utakmice");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrojPosjetitelja).HasColumnName("brojPosjetitelja");

                entity.Property(e => e.DatumUtakmice)
                    .HasColumnName("datumUtakmice")
                    .HasColumnType("date");

                entity.Property(e => e.Momcad1Id).HasColumnName("momcad1ID");

                entity.Property(e => e.Momcad2Id).HasColumnName("momcad2ID");

                entity.Property(e => e.NatjecanjeId).HasColumnName("natjecanjeID");

                entity.Property(e => e.Rezultat)
                    .HasColumnName("rezultat")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Momcad1)
                    .WithMany(p => p.UtakmiceMomcad1)
                    .HasForeignKey(d => d.Momcad1Id)
                    .HasConstraintName("FK_utakmice_momcadi");

                entity.HasOne(d => d.Momcad2)
                    .WithMany(p => p.UtakmiceMomcad2)
                    .HasForeignKey(d => d.Momcad2Id)
                    .HasConstraintName("FK_utakmice_momcadi1");

                entity.HasOne(d => d.Natjecanje)
                    .WithMany(p => p.Utakmice)
                    .HasForeignKey(d => d.NatjecanjeId)
                    .HasConstraintName("FK_utakmice_natjecanja");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
