using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
{
    public partial class NewNetflixContext : DbContext
    {
        public NewNetflixContext()
        {
        }

        public NewNetflixContext(DbContextOptions<NewNetflixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Genre> Genre { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Series> Series { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserWatch> UserWatches { get; set; } = null!;
        public virtual DbSet<VwMoviesGenre> VwMoviesGenres { get; set; } = null!;
        public virtual DbSet<VwSeriesGenre> VwSeriesGenres { get; set; } = null!;
        public virtual DbSet<WatchLater> WatchLaters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=NewNetflix;Username=postgres;Password=Kk967551590");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => e.FavoritesId)
                    .HasName("favorites_pkey");

                entity.ToTable("favorites");

                entity.Property(e => e.FavoritesId).HasColumnName("favorites_id");

                entity.Property(e => e.MvId).HasColumnName("mv_id");

                entity.Property(e => e.SeId).HasColumnName("se_id");

                entity.Property(e => e.UsrId).HasColumnName("usr_id");

                entity.HasOne(d => d.Mv)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.MvId)
                    .HasConstraintName("favorites_mv_id_fkey");

                entity.HasOne(d => d.Se)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.SeId)
                    .HasConstraintName("favorites_se_id_fkey");

                entity.HasOne(d => d.Usr)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UsrId)
                    .HasConstraintName("favorites_usr_id_fkey");
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
                    .WithMany(p => p.Movies)
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

            modelBuilder.Entity<User>(entity =>
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

            modelBuilder.Entity<UserWatch>(entity =>
            {
                entity.HasKey(e => e.UsrWatchId)
                    .HasName("user_watch_pkey");

                entity.ToTable("user_watch");

                entity.Property(e => e.UsrWatchId).HasColumnName("usr_watch_id");

                entity.Property(e => e.MvId).HasColumnName("mv_id");

                entity.Property(e => e.SeId).HasColumnName("se_id");

                entity.Property(e => e.UsrId).HasColumnName("usr_id");

                entity.Property(e => e.Watched).HasColumnName("watched");

                entity.HasOne(d => d.Mv)
                    .WithMany(p => p.UserWatches)
                    .HasForeignKey(d => d.MvId)
                    .HasConstraintName("user_watch_mv_id_fkey");

                entity.HasOne(d => d.Se)
                    .WithMany(p => p.UserWatches)
                    .HasForeignKey(d => d.SeId)
                    .HasConstraintName("user_watch_se_id_fkey");

                entity.HasOne(d => d.Usr)
                    .WithMany(p => p.UserWatches)
                    .HasForeignKey(d => d.UsrId)
                    .HasConstraintName("user_watch_usr_id_fkey");
            });

            modelBuilder.Entity<VwMoviesGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_movies_genre");

                entity.Property(e => e.Genre)
                    .HasMaxLength(30)
                    .HasColumnName("genre");

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
            });

            modelBuilder.Entity<VwSeriesGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_series_genre");

                entity.Property(e => e.Genre)
                    .HasMaxLength(30)
                    .HasColumnName("genre");

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
            });

            modelBuilder.Entity<WatchLater>(entity =>
            {
                entity.ToTable("watch_later");

                entity.Property(e => e.WatchLaterId).HasColumnName("watch_later_id");

                entity.Property(e => e.MvId).HasColumnName("mv_id");

                entity.Property(e => e.SeId).HasColumnName("se_id");

                entity.Property(e => e.UsrId).HasColumnName("usr_id");

                entity.HasOne(d => d.Mv)
                    .WithMany(p => p.WatchLaters)
                    .HasForeignKey(d => d.MvId)
                    .HasConstraintName("watch_later_mv_id_fkey");

                entity.HasOne(d => d.Se)
                    .WithMany(p => p.WatchLaters)
                    .HasForeignKey(d => d.SeId)
                    .HasConstraintName("watch_later_se_id_fkey");

                entity.HasOne(d => d.Usr)
                    .WithMany(p => p.WatchLaters)
                    .HasForeignKey(d => d.UsrId)
                    .HasConstraintName("watch_later_usr_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
