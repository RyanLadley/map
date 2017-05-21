using Microsoft.EntityFrameworkCore;
using Tutorial.Models.Entities;

namespace Tutorial.Models.Context
{
    public class MainContext : DbContext, IDataContext
    {
        
        public MainContext( DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-many 
            modelBuilder.Entity<Region>()
                        .HasOne<State>(r => r.State) //Region has one state
                        .WithMany(s => s.Regions); //State has many regions
            
            modelBuilder.Entity<Location>()
                        .HasOne<Region>(l => l.Region) //Location has one region
                        .WithMany(r => r.Locations); //Region has many locations

        }
        public DbSet<State> States { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}
