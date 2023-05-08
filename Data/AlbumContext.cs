using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Albumes.Models;
using Albumes.ViewModels;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Artist>()
            .HasMany(p=>p.Albums)
            .WithOne(p=>p.Artist)
            .HasForeignKey(p=>p.ArtistId);
        }
    }
}
