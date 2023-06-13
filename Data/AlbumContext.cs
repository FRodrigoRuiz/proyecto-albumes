using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Albumes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Albumes.Data
{
    public class AlbumContext : IdentityDbContext
    {
        public AlbumContext (DbContextOptions<AlbumContext> options)
            : base(options)
        {
        }

        public DbSet<Albumes.Models.Album> Album { get; set; } = default!;

        public DbSet<Albumes.Models.Artist> Artist { get; set; } = default!;

        public DbSet<Albumes.Models.Stock> Stock { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stock>()
            .HasOne(i => i.Album)
            .WithMany()
            .HasForeignKey(i => i.AlbumId);
            
        }
    }
}
