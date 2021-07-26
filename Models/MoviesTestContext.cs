using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class MoviesTestContext : IdentityDbContext<IdentityUser>
    {
        public MoviesTestContext()
        {
        }

        public MoviesTestContext(DbContextOptions<MoviesTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<ActorLike> ActorLikes { get; set; }
        public virtual DbSet<ActorParticipation> ActorParticipations { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieGenreJunction> MovieGenreJunctions { get; set; }
        public virtual DbSet<MovieLike> MovieLikes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MoviesTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>(entity =>
            {
	            entity.ToTable("Actor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('ACTOR_NAME')");
            });

            modelBuilder.Entity<ActorLike>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ActorId });

                entity.ToTable("ActorLike");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorLikes)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorLike_Actor");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActorLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorLike_User");
            });

            modelBuilder.Entity<ActorParticipation>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorId });

                entity.ToTable("ActorParticipation");

                entity.HasIndex(e => e.ActorId, "IX_ActorParticipation_ActorId");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorParticipations)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorParticipation_Actor");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.ActorParticipations)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorParticipation_Movie");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("('GENRE_NAME')");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('MOVIE_NAME')");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");
            });

            modelBuilder.Entity<MovieGenreJunction>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.GenreId });

                entity.ToTable("MovieGenreJunction");
            });

            modelBuilder.Entity<MovieLike>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MovieId });

                entity.ToTable("MovieLike");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieLikes)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieLike_Movie");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MovieLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieLike_User");
            });
        }
    }
}
