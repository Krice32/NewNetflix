using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace NewNeflixFrontEnd.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;

        public virtual DbSet<Genre> genres { get; set; } = null!;

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

          
        }

    }
}
