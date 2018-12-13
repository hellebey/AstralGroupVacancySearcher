using AstralGroupVacancySearcher.Models.HHRestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AstralGroupVacancySearcher.Models
{
    public class CurrentDbContext : DbContext
    {
       

        string _connectionString
        {
            get
            {
                return Config.DbconnectionString;
            }
        }
        public CurrentDbContext()
        {
        }

        public CurrentDbContext(DbContextOptions<CurrentDbContext> options) : base(options)
        { }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Log> Logs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();
        }
    }
}
