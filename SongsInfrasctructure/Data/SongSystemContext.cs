using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SongsDomain;

namespace SongSystem.Data
{
    public class SongSystemContext : DbContext
    {
        public SongSystemContext()
        {
            
        }

        public SongSystemContext (DbContextOptions <SongSystemContext> options) : base(options)
        {

        }

        public DbSet <SongDetails> Songs { get; set; }
        public DbSet <PlaylistDetails> Playlists { get; set; }
        public DbSet <SongForPlaylist> songForPlaylists { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            ConfigureSongDetails(modelBuilder);

            SeedDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedDatabase (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongForPlaylist>().HasData(
                new SongForPlaylist { Id = 1, SongDetailsId = 1, PlaylistId = 1 },
                new SongForPlaylist { Id = 2, SongDetailsId = 4, PlaylistId = 1 },
                new SongForPlaylist { Id = 3, SongDetailsId = 5, PlaylistId = 1 },

                new SongForPlaylist { Id = 4, SongDetailsId = 6, PlaylistId = 2 },
                new SongForPlaylist { Id = 5, SongDetailsId = 7, PlaylistId = 2 }
        );
            modelBuilder.Entity<SongDetails>().HasData(
                        new SongDetails { Id = 1, Title = "Without you", ArtistName = "Avicii", Length = 10 },
                        new SongDetails { Id = 2, Title = "The nights", ArtistName = "Avicii", Length = 15 },
                        new SongDetails { Id = 3, Title = "Waiting for love", ArtistName = "Avicii", Length = 12 },
                        new SongDetails { Id = 4, Title = "Beautiful", ArtistName = "Eminem", Length = 11 },
                        new SongDetails { Id = 5, Title = "Lose Yourself", ArtistName = "Eminem", Length = 19 },
                        new SongDetails { Id = 6, Title = "The Bones", ArtistName = "Marren Morris", Length = 25 },
                        new SongDetails { Id = 7, Title = "Forever And Ever", ArtistName = "Randy Travis", Length = 20 }
                       
               );

            modelBuilder.Entity<PlaylistDetails>().HasData(
                new PlaylistDetails { Id = 1, Name = "Favourites", Description = "Songs I like" },
                new PlaylistDetails { Id = 2, Name = "Country music", Description = "a form of popular music originating in the rural southern US. It is a mixture of ballads and dance tunes played characteristically on fiddle, banjo, guitar, and pedal steel guitar." }
                );
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            //var builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("appsettings.json");
            //IConfiguration Configuration = builder.Build();

            //optionsBuilder.UseSqlServer(
            //    Configuration.GetConnectionString("SongsInfrastructure"));
            //base.OnConfiguring(optionsBuilder);


        }


        private static void ConfigureSongDetails (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongDetails>().HasKey(x => x.Id);

            modelBuilder.Entity<SongDetails>()
                .Property(p => p.Id).ValueGeneratedOnAdd();

            //modelBuilder.Entity<SongDetails>()
            //    .HasOne(b => b.Title);
            //.WithMany(a => a.Books)
            //.HasForeignKey(b => b.AuthorId);

            //modelBuilder.Entity<SongDetails>().HasMany(x => x.Copies).WithOne(x => x.BookDetails)
            //    .HasForeignKey(k => k.BookDetailsId);
        }

    }
}
