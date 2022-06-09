
using Garage.Data;
using Microsoft.EntityFrameworkCore;
using System;

public class GarageSeedDataFixture : IDisposable
{
    public ApplicationDbContext applicationDbContext { get; private set; }

    public GarageSeedDataFixture()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("GarageDBTest")
            .Options;

        applicationDbContext = new ApplicationDbContext(options);

        applicationDbContext.Owners.Add(new Garage.Models.Owner
        {
            FisrtName = "Test",
            LastName = "Test",
            Phone = "123456789",
            Email = "test@test.com",
            Gender = Garage.Models.Gender.Mężczyzna
        });
        
        applicationDbContext.Cars.Add(new Garage.Models.Car
        {
            Name = "NameTest",
            Brand = "BrandTest",
            Year = 2010,
            Color = "Blue",
            Price = 100000,
            OwnerId = 1
        });
        applicationDbContext.SaveChanges();
    }
    public void Dispose()
    {
        applicationDbContext.Dispose();
    }
}