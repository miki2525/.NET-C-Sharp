using Garage.Controllers;
using Garage.Data;
using Garage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace GarageTest.Controllers
{
    public class GarageControllerTest : IClassFixture<GarageSeedDataFixture>
    {

        private GarageSeedDataFixture fixture;
        private GarageController _controller;

        public GarageControllerTest(GarageSeedDataFixture fixture)
        {
            this.fixture = fixture;
            _controller = new GarageController(fixture.applicationDbContext);
        }


        [Fact]
        public async void Index_ActionExecutes_ReturnsViewAndModelForIndex()
        {
            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var cars = Assert.IsType<List<Car>>(viewResult.Model);
            Assert.Equal(1, cars.Count);
        }

        [Fact]
        public void CreateTest_ReturnsViewForCreate()
        {

            var result = _controller.Create();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void CreateTest_ReturnsViewAndDontCreateModelForCreate()
        {
            _controller.ModelState.AddModelError("Marka", "Marka is required");

            var car = new Car
            {
                Name = "NameTest2",
                Year = 2012,
                Color = "Black",
                Price = 10000,
                OwnerId = 1
            };

            var result = await _controller.Create(car);
            var viewResult = Assert.IsType<ViewResult>(result);
            var carResult = Assert.IsType<Car>(viewResult.Model);
            Assert.Equal(car.Name, car.Name);

        }
        [Fact]
        public async void CreateTest_ReturnsRedirectAndCreateModelForCreate()
        {

            var car = new Car
            {

                Name = "NameTest2",
                Brand = "BrandTest2",
                Year = 2012,
                Color = "Black",
                Price = 10000,
                OwnerId = 1

            };

            var result = await _controller.Create(car);

            Assert.IsType<RedirectToActionResult>(result);

        }
        [Fact]
        public async void EditTest_ReturnsNotFoundForEdit()
        {

            var result = await _controller.Edit(102);

            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async void EditTest_ReturnsVieResultAndReturnsModelForEdit()
        {

            var result = await _controller.Edit(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Car>(viewResult.Model);

        }

        [Fact]
        public async void DetailsTest_ReturnsNotFoundForDetails()
        {

            var result = await _controller.Details(102);

            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async void DetailsTest_ReturnsViewResultAndReturnsModelForDetails()
        {

            var result = await _controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Car>(viewResult.Model);

        }

        [Fact]
        public async void DeleteTest_ReturnsViewResultAndReturnsModelForDelete()
        {

            var result = await _controller.Delete(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Car>(viewResult.Model);

        }

        [Fact]
        public async void DeleteTest_ReturnsNotFoundForDelete()
        {

            var result = await _controller.Delete(102);

            Assert.IsType<NotFoundResult>(result);


        }

        [Fact]
        public async void DeleteConfirmed_ReturnsRedirectResult()
        {
           
           var result = await _controller.DeleteConfirmed(105);

           Assert.IsType<RedirectToActionResult>(result);
     

        }


    }
}