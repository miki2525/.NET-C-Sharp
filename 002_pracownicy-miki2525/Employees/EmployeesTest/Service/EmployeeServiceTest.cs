using Employees.DB;
using Employees.Model;
using Employees.Model.type;
using Employees.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesTest
{
    public class EmployeeServiceTest : IClassFixture<EmployeeSeedDataFixture>
    {
        private EmployeeSeedDataFixture fixture;
        private EmployeeServiceImpl employeeServiceImpl;

        public EmployeeServiceTest(EmployeeSeedDataFixture fixture)
        {
            this.fixture = fixture;
            employeeServiceImpl = new EmployeeServiceImpl(fixture.EmployeeContext);
        }


        [Fact]
        public async void shouldAddEmployeeAndGetId()
        {
            //Arrange
            string stringJson = "{ \"firstName\": \"John\", \"lastName\": \"Last\", \"age\": 25,\"experience\": 10,\"streetName\": \"Street\",\"buildNumber\": 5," +
                "\"apartmentNumber\": 5,\"city\": \"City\",\"intellect\": 15 }";
            JsonElement rawEmployee = JsonDocument.Parse(stringJson).RootElement;

            //Act
            var saved = await employeeServiceImpl.AddEmployee(rawEmployee);
            Employee employee = (Employee)saved;

            //Assert
            Assert.NotNull(employee.Id);
        }

        [Fact]
        public async void shouldGetAllEmployees()
        {
            //Arrange
            List<Employee> list;
            List<Object> responseList;

            //Act
            responseList = await employeeServiceImpl.GetAllEmployees(false);
            list = responseList.ConvertAll(obj => (Employee)obj);

            //Assert
            Assert.NotEmpty(list);
        }

        [Fact]
        public async void shouldaddEmployees()
        {
            //
            List<Employee> list = await fixture.EmployeeContext.AllEmployees.ToListAsync();
            int sizeBefore = list.Count;
            ListEmployees listEmployees = new ListEmployees();
            listEmployees.OfficeEmployees = new List<OfficeEmployee>() {new OfficeEmployee(){FirstName = "JohnTest", LastName = "LastTest", Age = 41, Experience = 22,
                    StreetName = "Street2", BuildNumber = 5, ApartmentNumber = 2, City = "Gotham", Intellect = 80} };
            listEmployees.Traders = new List<Trader>() { new Trader(){FirstName = "Rafa", LastName = "Fokina", Age = 21, Experience = 4,
                    StreetName = "Street", BuildNumber = 1, ApartmentNumber = 12, City = "City",
                    Effectiveness = Employees.type.Effectiveness.ŒREDNIA, Provision = 50}};

            //
            employeeServiceImpl.AddEmployees(listEmployees);
            list = await fixture.EmployeeContext.AllEmployees.ToListAsync();
            int sizeAfter = list.Count;

            //
            Assert.True(sizeBefore < sizeAfter);
        }

        [Fact]
        public async void shouldDeleteEmployeeById()
        {
            //
            List<Employee> list = await fixture.EmployeeContext.AllEmployees.ToListAsync();
            int sizeBefore = list.Count;

            //
            employeeServiceImpl.DeleteEmployeeById(1);
            list = await fixture.EmployeeContext.AllEmployees.ToListAsync();
            int sizeAfter = list.Count;

            //
            Assert.True(sizeBefore > sizeAfter);
        }

        [Fact]
        public async void shouldGetEmployeesByCity()
        {
            //Arrange
            List<Employee> list;
            List<Object> responseList;
            String searchCity = "Gotham";

            //Act
            responseList = await employeeServiceImpl.GetEmployeesByCity(searchCity);
            list = responseList.ConvertAll(obj => (Employee)obj);

            //Assert
            list.ForEach(employee =>
            {
                if (!employee.City.Equals(searchCity))
                {
                    throw new NotImplementedException("searchCity should be in the list only but wasn't");
                }
            });
            Assert.True(true);
        }
    }
}