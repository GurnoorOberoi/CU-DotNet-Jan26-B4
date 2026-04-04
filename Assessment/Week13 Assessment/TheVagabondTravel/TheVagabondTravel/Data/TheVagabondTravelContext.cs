using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheVagabondTravel.Models;

namespace TheVagabondTravel.Data
{
    public class TheVagabondTravelContext : DbContext
    {
        public TheVagabondTravelContext (DbContextOptions<TheVagabondTravelContext> options)
            : base(options)
        {
        }

        public DbSet<TheVagabondTravel.Models.Destination> Destination { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CityName).IsRequired();
                entity.Property(e => e.Country).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.Rating).HasDefaultValue(3);

            });
        }
    }
}
