using Microsoft.EntityFrameworkCore;
using Npgsql;
using NewNeflixFrontEnd.Models;

namespace NewNeflixFrontEnd.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;

        public virtual DbSet<Series> Series { get; set; } = null!;

        public virtual DbSet<Genre> genres { get; set; } = null!;

        public virtual DbSet<Users> users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=NewNetflix;Username=postgres;Password=1337");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MvId)
                    .HasName("movies_pkey");

                entity.ToTable("movies");

                entity.HasIndex(e => e.MvTitle, "idx_mv_title");

                entity.Property(e => e.MvId).HasColumnName("mv_id");

                entity.Property(e => e.GrId).HasColumnName("gr_id");

                entity.Property(e => e.MvDate)
                    .HasMaxLength(10)
                    .HasColumnName("mv_date")
                    .IsFixedLength();

                entity.Property(e => e.MvDuration).HasColumnName("mv_duration");

                entity.Property(e => e.MvImg).HasColumnName("mv_img");

                entity.Property(e => e.MvSynopsis).HasColumnName("mv_synopsis");

                entity.Property(e => e.MvTitle)
                    .HasMaxLength(60)
                    .HasColumnName("mv_title");

                entity.HasOne(d => d.Gr)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.GrId)
                    .HasConstraintName("movies_gr_id_fkey");
            });

             modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.SeId)
                    .HasName("series_pkey");

                entity.ToTable("series");

                entity.HasIndex(e => e.SeTitle, "idx_se_title");

                entity.Property(e => e.SeId).HasColumnName("se_id");

                entity.Property(e => e.GrId).HasColumnName("gr_id");

                entity.Property(e => e.SeDate)
                    .HasMaxLength(10)
                    .HasColumnName("se_date")
                    .IsFixedLength();

                entity.Property(e => e.SeImg).HasColumnName("se_img");

                entity.Property(e => e.SeQtdSeasons).HasColumnName("se_qtd_seasons");

                entity.Property(e => e.SeSynopsis).HasColumnName("se_synopsis");

                entity.Property(e => e.SeTitle)
                    .HasMaxLength(60)
                    .HasColumnName("se_title");

                entity.HasOne(d => d.Gr)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.GrId)
                    .HasConstraintName("series_gr_id_fkey");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GrId)
                    .HasName("genres_pkey");

                entity.ToTable("genres");

                entity.HasIndex(e => e.Genre1, "genres_genre_key")
                    .IsUnique();

                entity.HasIndex(e => e.Genre1, "idx_genre");

                entity.Property(e => e.GrId).HasColumnName("gr_id");

                entity.Property(e => e.Genre1)
                    .HasMaxLength(30)
                    .HasColumnName("genre");
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UsrId)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.HasIndex(e => e.UsrEmail, "users_usr_email_key")
                    .IsUnique();

                entity.Property(e => e.UsrId).HasColumnName("usr_id");

                entity.Property(e => e.UsrEmail)
                    .HasMaxLength(60)
                    .HasColumnName("usr_email");

                entity.Property(e => e.UsrName)
                    .HasMaxLength(60)
                    .HasColumnName("usr_name");

                entity.Property(e => e.UsrPassword)
                    .HasMaxLength(60)
                    .HasColumnName("usr_password");
            });

        }

    

    }
}
