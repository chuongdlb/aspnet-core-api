using Microsoft.EntityFrameworkCore;
using NetcoreMvc.EntityFrameworkCore.Entities;

namespace NetcoreMvc.EntityFrameworkCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            optionsBuilder.UseSqlServer("connectionString");
            base.OnConfiguring(optionsBuilder);
            
        }
    }
}