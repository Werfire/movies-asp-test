using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MoviesAspTest.Models
{
	public partial class MoviesActorsContext : IdentityDbContext<IdentityUser>
    {
        public MoviesActorsContext()
        {
        }

        public MoviesActorsContext(DbContextOptions<MoviesActorsContext> options)
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
        public virtual DbSet<User> Users { get; set; }

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

                entity.HasData(
	                #region SeedMovieData
	                new Movie
                    {
                        Id = Guid.NewGuid(),
                        Name = "Interstellar",
                        Description = "Epic science fiction film co-written, directed and produced by Christopher Nolan.",
                        ReleaseDate = new DateTime(2014, 10, 26),
                        Duration = new TimeSpan(2, 49, 0)
                    },
                    new Movie
                    {
	                    Id = Guid.NewGuid(),
	                    Name = "Fast & Furious 9",
	                    Description = "American action film directed by Justin Lin from a screenplay by Daniel Casey and Lin.",
	                    ReleaseDate = new DateTime(2021, 5, 19),
	                    Duration = new TimeSpan(2, 23, 0)
                    },
                    new Movie
                    {
	                    Id = Guid.NewGuid(),
	                    Name = "Yolki 2",
	                    Description = "Russian comedy film, sequel to Yolki.",
	                    ReleaseDate = new DateTime(2011, 12, 15),
	                    Duration = new TimeSpan(1, 40, 0)
                    },
                    new Movie
                    {
	                    Id = Guid.NewGuid(),
	                    Name = "The Dark Tower",
	                    Description = "American science fantasy Western action film directed and co-written by Nikolaj Arcel.",
	                    ReleaseDate = new DateTime(2017, 7, 31),
	                    Duration = new TimeSpan(1, 35, 0)
                    },
                    new Movie
                    {
	                    Id = Guid.NewGuid(),
	                    Name = "Shrek 2",
	                    Description = "American computer-animated comedy film loosely based on the 1990 picture book Shrek! by William Steig.",
	                    ReleaseDate = new DateTime(2004, 5, 15),
	                    Duration = new TimeSpan(1, 32, 0)
                    },
                    new Movie
                    {
	                    Id = Guid.NewGuid(),
	                    Name = "Yolki 1914",
	                    Description = "Russian comedy film. It is a prequel to the 2013 film Yolki 3.",
	                    ReleaseDate = new DateTime(2014, 12, 25),
	                    Duration = new TimeSpan(1, 49, 0)
                    },
                    new Movie
                    {
	                    Id = Guid.NewGuid(),
	                    Name = "Star Wars IV",
	                    Description = "American epic space-opera film written and directed by George Lucas, produced by Lucasfilm " +
	                                  "and distributed by 20th Century Fox.",
	                    ReleaseDate = new DateTime(1977, 5, 25),
	                    Duration = new TimeSpan(2, 1, 0)
                    }
	                #endregion
                );
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

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32);
            });
        }
    }
}
