using Images_App.DataPersistence.Mappings;
using Images_App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Images_App.DataPersistence
{
    internal class MyDBContext : DbContext
    {
        internal DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            optionsBuilder.UseOracle(configuration.GetConnectionString("Oracle"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImageMap());
        }
    }
}
