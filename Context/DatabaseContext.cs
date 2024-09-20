namespace netschool.Context;

using Microsoft.EntityFrameworkCore;
using netschool.Models;

public class DatabaseContext
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Teacher> Teachers { get; set; }
        
        public DbSet<Class> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            String connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0)));
        }
    }
}