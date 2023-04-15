using GameStoreWeb.Data.Enums;
using GameStoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GameStoreWeb.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer_Games>().HasKey(dg => new
            {
                dg.DeveloperId,
                dg.GamesId
            });

            modelBuilder.Entity<Developer_Games>().HasOne(g => g.Developer).WithMany(dg => dg.Developer_Games).HasForeignKey(g => g.DeveloperId);
            modelBuilder.Entity<Developer_Games>().HasOne(g => g.Games).WithMany(dg => dg.Developer_Games).HasForeignKey(g => g.GamesId);
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Developer_Games> Developer_Games { get; set; }
    }
}
