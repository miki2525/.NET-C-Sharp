using Employees.DB;
using Employees.Model;
using Microsoft.EntityFrameworkCore;
using System;

public class EmployeeSeedDataFixture : IDisposable
{
    public EmployeeContext EmployeeContext { get; private set; }

    public EmployeeSeedDataFixture()
    {
        var options = new DbContextOptionsBuilder<EmployeeContext>()
            .UseInMemoryDatabase("EmployeeDBTest")
            .Options;

        EmployeeContext = new EmployeeContext(options);

        EmployeeContext.Workmen.Add(new Workman()
        {
            FirstName = "GringoTest",
            LastName = "ThirdTest",
            Age = 33,
            Experience = 5,
            StreetName = "Street",
            BuildNumber = 6,
            ApartmentNumber = 2,
            City = "City",
            PhysicalStrength = 50
        });
        EmployeeContext.Traders.Add(new Trader()
        {
            FirstName = "MikeTest",
            LastName = "FirstTest",
            Age = 41,
            Experience = 21,
            StreetName = "Street",
            BuildNumber = 3,
            ApartmentNumber = 3,
            City = "Gotham",
            Effectiveness = Employees.type.Effectiveness.ŚREDNIA,
            Provision = 25
        });
        EmployeeContext.SaveChanges();
    }

    public void Dispose()
    {
        EmployeeContext.Dispose();
    }
}