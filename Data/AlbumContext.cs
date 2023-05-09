using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Albumes.Models;

namespace Albumes.Data
{
    public class AlbumContext : DbContext
    {
        public AlbumContext (DbContextOptions<AlbumContext> options)
            : base(options)
        {
        }

        public DbSet<Albumes.Models.Album> Album { get; set; } = default!;

        public DbSet<Albumes.Models.Artist> Artist { get; set; } = default!;

        public DbSet<Albumes.Models.Stock> Stock { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Artist>()
            .HasMany(e => e.Stocks)
            .WithOne(e => e.Artist)
            .HasForeignKey(e => e.ArtistId)
            .IsRequired();

            modelBuilder.Entity<Album>()
            .HasMany(e => e.Stocks)
            .WithOne(e => e.Album)
            .HasForeignKey(e => e.AlbumId)
            .IsRequired();
        }
    }
}
