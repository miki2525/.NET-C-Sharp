using Garage.Models;
using System.Linq;

namespace Garage.Data
{
    public class DataInitializer
    {

        public static void Run(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Owners.Any())
            {
                return;  // DB has been seeded
            }

            var owners = new Owner[]
            {
            new Owner{FisrtName="Carson",LastName="Alexander",Phone="123456789", Email="alex@garage.com", Gender=Gender.Mężczyzna},
            new Owner{FisrtName="Meredith",LastName="Alonso",Phone="987654321", Email="alo@garage.com", Gender=Gender.Inne},
            new Owner{FisrtName="Arturo",LastName="Anand",Phone="321654987", Email="anand@garage.com", Gender=Gender.Mężczyzna},
            new Owner{FisrtName="Gytis",LastName="Barzdukas",Phone="789456123", Email="barz@garage.com", Gender=Gender.Mężczyzna},
            new Owner{FisrtName="Yan",LastName="Li",Phone="321456987", Email="li@garage.com", Gender=Gender.Mężczyzna},
            new Owner{FisrtName="Peggy",LastName="Justice",Phone="789321567", Email="just@garage.com", Gender=Gender.Kobieta},
            new Owner{FisrtName="Laura",LastName="Norman",Phone="789032567", Email="norm@garage.com", Gender=Gender.Kobieta },
            new Owner{FisrtName="Nino",LastName="Olivetto",Phone="123000789", Email="oliv@garage.com", Gender=Gender.Mężczyzna}
            };
            foreach (Owner o in owners)
            {
                context.Owners.Add(o);
            }
            context.SaveChanges();

            var cars = new Car[]
            {
            new Car{Brand="Mazda",Name="RX-7",Price=10000, Year=2009, Color="Yellow", OwnerId=1},
            new Car{Brand="Mazda",Name="MX-5",Price=8500, Year=2005, Color="Black", OwnerId=2},
            new Car{Brand="Skoda",Name="Rapid",Price=8500, Year=2016, Color="White", OwnerId=3},
            new Car{Brand="Dodge",Name="Viper",Price=30000, Year=2012, Color="Blue", OwnerId=4},
            new Car{Brand="Toyota",Name="Corolla",Price=30000, Year=2021, Color="Red", OwnerId=5},
            new Car{Brand="Volkswagen",Name="Touran",Price=28000, Year=2021, Color="Black", OwnerId=6},
            new Car{Brand="Toyota",Name="Landcruiser",Price=18000, Year=2017, Color="White", OwnerId=7},
            new Car{Brand="Reanult",Name="Clio",Price=15000, Year=2021, Color="Yellow", OwnerId=8},
            };
            foreach (Car c in cars)
            {
                context.Cars.Add(c);
            }
            context.SaveChanges();
        }
    }
}
