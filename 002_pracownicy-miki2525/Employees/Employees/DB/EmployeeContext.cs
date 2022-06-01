using Employees.Model;
using Employees.type;
using Microsoft.EntityFrameworkCore;

namespace Employees.DB
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.FirstName).IsRequired();
                e.Property(e => e.LastName).IsRequired();
                e.Property(e => e.StreetName).IsRequired();
                e.Property(e => e.City).IsRequired();

            });

            modelBuilder.Entity<OfficeEmployee>(e =>
            {
                
/*               e.Property(e => e.OfficeId).ValueGeneratedOnAdd();
                e.HasIndex(e => e.OfficeId).IsUnique();*/
               
            });

            modelBuilder.Entity<Trader>(e =>    
            {
                e.Property(e => e.Effectiveness).HasMaxLength(25).HasConversion(
                i => i.ToString(),
                i => (Effectiveness)Enum.Parse(typeof(Effectiveness), i))
                .IsUnicode(false);
            });
        }
        public DbSet<OfficeEmployee> OfficeEmployees { get; set; }
        public DbSet<Trader> Traders { get; set; }
        public DbSet<Workman> Workmen { get; set; }
        public DbSet<Employee> AllEmployees { get; set; }

    }
}
