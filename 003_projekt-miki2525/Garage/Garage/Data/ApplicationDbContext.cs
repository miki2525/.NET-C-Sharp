using Garage.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Garage.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>(c =>
            {
                c.HasKey(c => c.Id);
                c.Property(c => c.Brand).IsRequired();
                c.Property(c => c.Name).IsRequired();
                c.Property(c => c.Color).IsRequired();
                c.Property(c => c.OwnerId).IsRequired();
                c.HasOne(c => c.Owner).WithMany(o => o.Cars).HasForeignKey(c => c.OwnerId);

            });

            modelBuilder.Entity<Owner>(o =>
            {
                o.HasKey(o => o.Id);
                o.HasIndex(o => o.Phone).IsUnique();
                o.Property(o => o.FisrtName).IsRequired();
                o.Property(o => o.LastName).IsRequired();
                o.Property(o => o.Phone).IsRequired();
                o.Property(o => o.Email).IsRequired();
                o.Property(o => o.Gender).IsRequired();
                o.HasMany(c => c.Cars).WithOne(c => c.Owner).OnDelete(DeleteBehavior.Cascade);
            });
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }

    }
}