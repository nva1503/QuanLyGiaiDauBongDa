using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace QuanLyGiaiDauBongDa.Models
{
    public partial class QuanLyGiaiDauBongDaContext : DbContext
    {
        public QuanLyGiaiDauBongDaContext()
        {
        }

        public QuanLyGiaiDauBongDaContext(DbContextOptions<QuanLyGiaiDauBongDaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchResult> MatchResults { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayingPosition> PlayingPositions { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Referee> Referees { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleAccount> RoleAccounts { get; set; }
        public virtual DbSet<Stadiun> Stadiuns { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=TUNG\\TUNG;database=QuanLyGiaiDauBongDa;uid=sa;pwd=yeuthuy111;TrustServerCertificate=True");
            }*/
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("QuanLyGiaiDauBongDa"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Card");

                entity.Property(e => e.CardTime).HasColumnName("card_time");

                entity.Property(e => e.CardType).HasColumnName("card_type");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.HasOne(d => d.Match)
                    .WithMany()
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Card_Match");

                entity.HasOne(d => d.Player)
                    .WithMany()
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Card_Player");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.ClubId).HasColumnName("club_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.LogoUrl)
                    .HasMaxLength(50)
                    .HasColumnName("logo_url");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.StadiumId).HasColumnName("stadium_id");

                entity.Property(e => e.YearCreated)
                    .HasMaxLength(4)
                    .HasColumnName("year_created");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Club_Country");

                entity.HasOne(d => d.Stadium)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.StadiumId)
                    .HasConstraintName("FK_Club_Stadiun");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("short_name");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("Feedback");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("content");

                entity.Property(e => e.Problem)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("problem");

                entity.Property(e => e.RateId).HasColumnName("rateId");

                entity.HasOne(d => d.Rate)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.RateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Rate");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.ToTable("Goal");

                entity.Property(e => e.GoalId)
                    .ValueGeneratedNever()
                    .HasColumnName("goal_id");

                entity.Property(e => e.GoalTime).HasColumnName("goal_time");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Goal_Match");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.MatchId)
                    .ValueGeneratedNever()
                    .HasColumnName("match_id");

                entity.Property(e => e.GuestId).HasColumnName("guest_id");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.Property(e => e.PlayDate)
                    .HasColumnType("date")
                    .HasColumnName("play_date");

                entity.Property(e => e.PlayStage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("play_stage");

                entity.Property(e => e.RefereeId).HasColumnName("referee_id");

                entity.Property(e => e.TourseasonId).HasColumnName("tourseason_id");

                entity.Property(e => e.VenueId).HasColumnName("venue_id");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.MatchGuests)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Club1");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.MatchHosts)
                    .HasForeignKey(d => d.HostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Club");

                entity.HasOne(d => d.Referee)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.RefereeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Referee");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Venue");
            });

            modelBuilder.Entity<MatchResult>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Match_Result");

                entity.Property(e => e.ClubId).HasColumnName("club_id");

                entity.Property(e => e.GoalScore).HasColumnName("goal_score");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.PlayStage)
                    .HasMaxLength(50)
                    .HasColumnName("play_stage");

                entity.Property(e => e.WinLose)
                    .HasMaxLength(50)
                    .HasColumnName("win_lose");

                entity.HasOne(d => d.Club)
                    .WithMany()
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_Match_Result_Club");

                entity.HasOne(d => d.Match)
                    .WithMany()
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Result_Match");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedNever()
                    .HasColumnName("player_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Dob)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dob");

                entity.Property(e => e.Height)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("height");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PositionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("position_id");

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("weight");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_Country");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_Playing_Position");
            });

            modelBuilder.Entity<PlayingPosition>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.ToTable("Playing_Position");

                entity.Property(e => e.PositionId)
                    .HasMaxLength(50)
                    .HasColumnName("position_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.ToTable("Rate");

                entity.Property(e => e.RateId)
                    .ValueGeneratedNever()
                    .HasColumnName("rateId");

                entity.Property(e => e.RateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("rateName");
            });

            modelBuilder.Entity<Referee>(entity =>
            {
                entity.ToTable("Referee");

                entity.Property(e => e.RefereeId).HasColumnName("referee_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.RefereeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("referee_name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Referees)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Referee_Country");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<RoleAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Role_Account");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Role_Account_Role");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_Role_Account_Account");
            });

            modelBuilder.Entity<Stadiun>(entity =>
            {
                entity.HasKey(e => e.StadiumId);

                entity.ToTable("Stadiun");

                entity.Property(e => e.StadiumId).HasColumnName("stadium_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Team");

                entity.Property(e => e.ClubId).HasColumnName("club_id");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.HasOne(d => d.Club)
                    .WithMany()
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_Team_Club");

                entity.HasOne(d => d.Match)
                    .WithMany()
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_Team_Match");

                entity.HasOne(d => d.Player)
                    .WithMany()
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_Team_Player");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("Venue");

                entity.Property(e => e.VenueId).HasColumnName("venue_id");

                entity.Property(e => e.AudienceCapacity).HasColumnName("audience_capacity");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
