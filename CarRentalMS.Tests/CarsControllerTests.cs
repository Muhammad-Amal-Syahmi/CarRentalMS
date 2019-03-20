using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac.Extras.Moq;
using AutoMapper;
using CarRentalMS.Controllers;
using CarRentalMS.DataAccess;
using CarRentalMS.Infrastructure;
using CarRentalMS.Services.Interfaces;
using CarRentalMS.ViewModels;
using Xunit;

namespace CarRentalMS.Tests
{
    public class CarsControllerTests : IDisposable
    {
        public CarsControllerTests()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<AutomapperWebProfile>(); });
        }
        private List<Car> GetSampleCars()
        {
            List<Car> output = new List<Car>
            {
                new Car{Id= 1,CarModel= "Saga",Location= "Bayan Baru",PricePerDay= 110.00},
                new Car{Id=2,CarModel= "Wira",Location= "Bayan Lepas",PricePerDay= 108},
                new Car{Id= 3,CarModel= "Avanza",Location= "Bandar Baru",PricePerDay= 134.56},
                new Car{Id= 4,CarModel= "Saga",Location= "Bukit Mertajam",PricePerDay= 98.50}
            };
            return output;
        }

        private Car GetASampleCar()
        {
            return new Car { Id = 3, CarModel = "Wira", Location = "Bayan Lepas", PricePerDay = 108.50 };
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("Saga", null)]
        [InlineData(null, "Bayan Baru")]
        [InlineData("Viva", "Gelugor")]
        public async Task Index_ShouldReturnView(string carModel, string location)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarServices>()
                    .Setup(x => x.GetAllCars(carModel, location))
                    .Returns(GetSampleCars().AsQueryable);
                var cls = mock.Create<CarsController>();

                //Act
                var actual = await cls.Index(carModel, location);

                //Assert
                Assert.NotNull(actual);
                var AResult = Assert.IsAssignableFrom<ActionResult>(actual);
            }
        }

        [Fact]
        public async Task Details_ShouldReturnView()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var expected = GetASampleCar();
                mock.Mock<ICarServices>()
                    .Setup(x => x.FindCar(3))
                    .Returns(Task.FromResult(expected));
                //Mapper.Initialize(cfg => { cfg.AddProfile<AutomapperWebProfile>(); });

                var cls = mock.Create<CarsController>();

                //Act
                var actual = await cls.Details(3);

                //Assert
                Assert.NotNull(actual);
                var AResult = Assert.IsAssignableFrom<ActionResult>(actual);
                var PVResult = AResult as PartialViewResult;
                var actualResult = Assert.IsAssignableFrom<CarViewModel>(PVResult.ViewData.Model);
            }
        }

        [Fact]
        public void Create_ShouldReturnView()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarServices>();

                var cls = mock.Create<CarsController>();

                //Act
                var actual = cls.Create();

                //Assert
                Assert.NotNull(actual);
            }
        }

        //Todo: Create car

        [Fact]
        public async Task Edit_ShouldReturnView()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var expected = GetASampleCar();
                mock.Mock<ICarServices>()
                    .Setup(x => x.FindCar(3))
                    .Returns(Task.FromResult(expected));
                //Mapper.Initialize(cfg => { cfg.AddProfile<AutomapperWebProfile>(); });

                var cls = mock.Create<CarsController>();

                //Act
                var actual = await cls.Edit(3);

                //Assert
                Assert.NotNull(actual);
                var AResult = Assert.IsAssignableFrom<ActionResult>(actual);
                var PVResult = AResult as PartialViewResult;
                var actualResult = Assert.IsAssignableFrom<CarViewModel>(PVResult.ViewData.Model);
            }
        }

        //Todo: Edit car

        [Fact]
        public async Task Delete_ShouldReturnView()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var expected = GetASampleCar();
                mock.Mock<ICarServices>()
                    .Setup(x => x.FindCar(3))
                    .Returns(Task.FromResult(expected));
                //Mapper.Initialize(cfg => { cfg.AddProfile<AutomapperWebProfile>(); });

                var cls = mock.Create<CarsController>();

                //Act
                var actual = await cls.Delete(3);

                //Assert
                Assert.NotNull(actual);
                var AResult = Assert.IsAssignableFrom<ActionResult>(actual);
                var PVResult = AResult as PartialViewResult;
                var actualResult = Assert.IsAssignableFrom<CarViewModel>(PVResult.ViewData.Model);
            }
        }

        //Todo: Delete car

        public void Dispose()
        {
            Mapper.Reset();
        }
    }
}
