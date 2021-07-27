using System;
using System.Collections.Generic;
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
        public virtual DbSet<ApplicationUser> AppUsers { get; set; }

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

            List<Movie> movies = new List<Movie>
	        {
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Interstellar",
			        Description = "Epic science fiction film co-written, directed and produced by Christopher Nolan.",
			        ReleaseDate = new DateTime(2014, 10, 26),
			        Duration = new TimeSpan(2, 49, 0)
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Fast & Furious 9",
			        Description =
				        "American action film directed by Justin Lin from a screenplay by Daniel Casey and Lin.",
			        ReleaseDate = new DateTime(2021, 5, 19),
			        Duration = new TimeSpan(2, 23, 0)
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Yolki 2",
			        Description = "Russian comedy film, sequel to Yolki.",
			        ReleaseDate = new DateTime(2011, 12, 15),
			        Duration = new TimeSpan(1, 40, 0)
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "The Dark Tower",
			        Description =
				        "American science fantasy Western action film directed and co-written by Nikolaj Arcel.",
			        ReleaseDate = new DateTime(2017, 7, 31),
			        Duration = new TimeSpan(1, 35, 0)
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Shrek 2",
			        Description =
				        "American computer-animated comedy film loosely based on the 1990 picture book Shrek! by William Steig.",
			        ReleaseDate = new DateTime(2004, 5, 15),
			        Duration = new TimeSpan(1, 32, 0)
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Yolki 1914",
			        Description = "Russian comedy film. It is a prequel to the 2013 film Yolki 3.",
			        ReleaseDate = new DateTime(2014, 12, 25),
			        Duration = new TimeSpan(1, 49, 0)
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Star Wars IV",
			        Description =
				        "American epic space-opera film written and directed by George Lucas, produced by Lucasfilm " +
				        "and distributed by 20th Century Fox.",
			        ReleaseDate = new DateTime(1977, 5, 25),
			        Duration = new TimeSpan(2, 1, 0)
		        }
	        };
	        List<Actor> actors = new List<Actor>
	        {
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Ivan Urgant",
			        Description = "Russian television host, presenter, actor, musician and producer."
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Sergei Svetlakov",
			        Description = "Russian comedian, film and television actor, TV host, producer, screenwriter."
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Matthew McConaughey",
			        Description = "American actor and producer."
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Vin Diesel",
			        Description = "American actor and filmmaker."
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Eddie Murphy",
			        Description = "American actor, comedian, writer, producer, and singer."
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Mark Hamill",
			        Description = "American actor, voice actor, and writer."
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Harrison Ford",
			        Description = "American actor, pilot, and environmental activist."
		        }
	        };
	        List<Genre> genres = new List<Genre>
	        {
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Comedy"
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Sci-fi"
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Drama"
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Action"
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Animation"
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Adventure"
		        },
		        new()
		        {
			        Id = Guid.NewGuid(),
			        Name = "Detective"
		        }
	        };

	        List<MovieGenreJunction> movieGenreJunctions = new List<MovieGenreJunction>
	        {
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Interstellar").Id,
			        GenreId = genres.Find(g => g.Name == "Drama").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Interstellar").Id,
			        GenreId = genres.Find(g => g.Name == "Adventure").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Interstellar").Id,
			        GenreId = genres.Find(g => g.Name == "Detective").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Fast & Furious 9").Id,
			        GenreId = genres.Find(g => g.Name == "Action").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Fast & Furious 9").Id,
			        GenreId = genres.Find(g => g.Name == "Adventure").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Yolki 2").Id,
			        GenreId = genres.Find(g => g.Name == "Comedy").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "The Dark Tower").Id,
			        GenreId = genres.Find(g => g.Name == "Adventure").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "The Dark Tower").Id,
			        GenreId = genres.Find(g => g.Name == "Action").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "The Dark Tower").Id,
			        GenreId = genres.Find(g => g.Name == "Sci-fi").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Shrek 2").Id,
			        GenreId = genres.Find(g => g.Name == "Comedy").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Shrek 2").Id,
			        GenreId = genres.Find(g => g.Name == "Animation").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Shrek 2").Id,
			        GenreId = genres.Find(g => g.Name == "Adventure").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Yolki 1914").Id,
			        GenreId = genres.Find(g => g.Name == "Comedy").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Star Wars IV").Id,
			        GenreId = genres.Find(g => g.Name == "Sci-fi").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Star Wars IV").Id,
			        GenreId = genres.Find(g => g.Name == "Adventure").Id
		        },
		        new()
		        {
			        MovieId = movies.Find(m => m.Name == "Star Wars IV").Id,
			        GenreId = genres.Find(g => g.Name == "Action").Id
		        }
	        };
	        List<ActorParticipation> actorParticipations = new List<ActorParticipation>
	        {
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Ivan Urgant").Id,
			        MovieId = movies.Find(m => m.Name == "Yolki 2").Id
		        },
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Ivan Urgant").Id,
			        MovieId = movies.Find(m => m.Name == "Yolki 1914").Id
		        },
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Sergei Svetlakov").Id,
			        MovieId = movies.Find(m => m.Name == "Yolki 2").Id
		        },
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Sergei Svetlakov").Id,
			        MovieId = movies.Find(m => m.Name == "Yolki 1914").Id
		        },
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Matthew McConaughey").Id,
			        MovieId = movies.Find(m => m.Name == "Interstellar").Id
		        },
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Matthew McConaughey").Id,
			        MovieId = movies.Find(m => m.Name == "The Dark Tower").Id
		        },
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Vin Diesel").Id,
			        MovieId = movies.Find(m => m.Name == "Fast & Furious 9").Id
		        },
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Eddie Murphy").Id,
			        MovieId = movies.Find(m => m.Name == "Shrek 2").Id
		        },
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Mark Hamill").Id,
			        MovieId = movies.Find(m => m.Name == "Star Wars IV").Id
		        },
		        new()
		        {
			        ActorId = actors.Find(a => a.Name == "Harrison Ford").Id,
			        MovieId = movies.Find(m => m.Name == "Star Wars IV").Id
		        }
	        };

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

                entity.HasIndex(a => a.Id);

                entity.HasMany(a => a.Movies)
	                .WithMany(m => m.Actors)
	                .UsingEntity<ActorParticipation>(j => j.HasOne(j => j.Movie)
			                .WithMany()
			                .HasForeignKey(j => j.MovieId),
		                j => j.HasOne(j => j.Actor)
			                .WithMany()
			                .HasForeignKey(j => j.ActorId));

                entity.HasMany(a => a.UsersLiked)
	                .WithMany(u => u.Actors)
	                .UsingEntity<ActorLike>(j => j.HasOne(j => j.User)
			                .WithMany()
			                .HasForeignKey(j => j.UserId),
		                j => j.HasOne(j => j.Actor)
			                .WithMany()
			                .HasForeignKey(j => j.ActorId));

                entity.HasData(actors);
            });

            modelBuilder.Entity<ActorLike>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ActorId });

                entity.ToTable("ActorLike");
            });

            modelBuilder.Entity<ActorParticipation>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorId });

                entity.ToTable("ActorParticipation");

                entity.HasData(actorParticipations);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("('GENRE_NAME')");

                entity.HasIndex(g => g.Id);

                entity.HasData(genres);
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

                entity.HasIndex(m => m.Id);

                entity.HasMany(m => m.Genres)
	                .WithMany(g => g.Movies)
	                .UsingEntity<MovieGenreJunction>(j => j.HasOne(j => j.Genre)
			                .WithMany()
			                .HasForeignKey(j => j.GenreId),
		                j => j.HasOne(j => j.Movie)
			                .WithMany()
			                .HasForeignKey(j => j.MovieId));

                entity.HasMany(m => m.UsersLiked)
	                .WithMany(u => u.Movies)
	                .UsingEntity<MovieLike>(j => j.HasOne(j => j.User)
			                .WithMany()
			                .HasForeignKey(j => j.UserId),
		                j => j.HasOne(j => j.Movie)
			                .WithMany()
			                .HasForeignKey(j => j.MovieId));

                entity.HasData(movies);
            });

            modelBuilder.Entity<MovieGenreJunction>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.GenreId });

                entity.ToTable("MovieGenreJunction");

                entity.HasData(movieGenreJunctions);
            });

            modelBuilder.Entity<MovieLike>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MovieId });

                entity.ToTable("MovieLike");
            });
        }
    }
}
