using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZavršniCORE.Models
{
    public partial class HokeJKlubContext : DbContext
    {
        public HokeJKlubContext()
        {
        }

        public HokeJKlubContext(DbContextOptions<HokeJKlubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Leagues> Leagues { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<PartnerPayments> PartnerPayments { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<PlayerPayments> PlayerPayments { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Referees> Referees { get; set; }
        public virtual DbSet<Stadiums> Stadiums { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BEVM3ON\\SQLExpress;Database=HokeJKlub;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CountryName)
                    .HasColumnName("countryName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.ToTable("games");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfGame)
                    .HasColumnName("dateOfGame")
                    .HasColumnType("date");

                entity.Property(e => e.RefereeId).HasColumnName("refereeID");

                entity.Property(e => e.Team1Id).HasColumnName("team1_ID");

                entity.Property(e => e.Team2Id).HasColumnName("team2_ID");

                entity.Property(e => e.Visitors).HasColumnName("visitors");

                entity.HasOne(d => d.Referee)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.RefereeId)
                    .HasConstraintName("FK_games_referees");

                entity.HasOne(d => d.Team1)
                    .WithMany(p => p.GamesTeam1)
                    .HasForeignKey(d => d.Team1Id)
                    .HasConstraintName("FK_games_teams");

                entity.HasOne(d => d.Team2)
                    .WithMany(p => p.GamesTeam2)
                    .HasForeignKey(d => d.Team2Id)
                    .HasConstraintName("FK_games_teams1");
            });

            modelBuilder.Entity<Leagues>(entity =>
            {
                entity.ToTable("leagues");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasColumnName("countryID");

                entity.Property(e => e.NameOfLeague)
                    .HasColumnName("nameOfLeague")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Leagues)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_leagues_countries");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.CountryId).HasColumnName("countryID");

                entity.Property(e => e.CountryName)
                    .HasColumnName("countryName")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_locations_countries");
            });

            modelBuilder.Entity<PartnerPayments>(entity =>
            {
                entity.ToTable("partnerPayments");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.PartnerId).HasColumnName("partnerID");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.PartnerPayments)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_partnerPayments_partners");
            });

            modelBuilder.Entity<Partners>(entity =>
            {
                entity.ToTable("partners");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.PartnerName)
                    .HasColumnName("partnerName")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Partners)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_partners_locations");
            });

            modelBuilder.Entity<PlayerPayments>(entity =>
            {
                entity.ToTable("playerPayments");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.PlayerId).HasColumnName("playerID");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerPayments)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_playerPayments_players");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Oib)
                    .HasColumnName("oib")
                    .HasMaxLength(11);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(50);

                entity.Property(e => e.TeamId).HasColumnName("teamID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_players_teams");
            });

            modelBuilder.Entity<Referees>(entity =>
            {
                entity.ToTable("referees");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Oib)
                    .HasColumnName("oib")
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<Stadiums>(entity =>
            {
                entity.ToTable("stadiums");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Stadiums)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_stadiums_locations");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staff");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Oib)
                    .HasColumnName("oib")
                    .HasMaxLength(11);

                entity.Property(e => e.TeamId).HasColumnName("teamID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_staff_teams");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.ToTable("teams");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StadiumId).HasColumnName("stadiumID");

                entity.Property(e => e.TeamName)
                    .HasColumnName("teamName")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Stadium)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.StadiumId)
                    .HasConstraintName("FK_teams_stadiums");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
