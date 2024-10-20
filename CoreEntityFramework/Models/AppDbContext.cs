using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using PetAdoption.Models;


namespace PetAdoption
{
    public class AppDbContext : DbContext
    {

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Application> Applications { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}