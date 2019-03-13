using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac.Extras.Moq;
using CarRentalMS.Controllers;
using CarRentalMS.DataAccess;
using CarRentalMS.Services.Interfaces;
using Xunit;

namespace CarRentalMS.Tests
{
    public class CarsControllerTests
    {
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

        [Fact]
        public void Index_ShouldReturnView()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarServices>()
                    .Setup(x => x.GetAllCars(null, null))
                    .Returns(GetSampleCars().AsQueryable);

                var cls = mock.Create<CarsController>();

                //Act
                var actual = cls.Index(null, null);

                //Assert
                //Assert.NotNull(actual);
                var aResult = Assert.IsType<Task<ActionResult>>(actual);

                //IEnumerable<Car> model = Assert.IsAssignableFrom<IEnumerable<Car>>(aResult.Result);
                //Assert.Equal(4, model.Count());
                //var actionResult = Assert.IsAssignableFrom<Task<ActionResult>>(actual);

            }

            //var carServices = new Mock<ICarServices>();
            //var carsController = new CarsController(carServices.Object);
            //var actionResultTask = carsController.Index(null,null);
            //actionResultTask.Wait();
            //var viewResult = actionResultTask.Result as ViewResult;
            //Assert.NotNull(viewResult);
            //Assert.Equal("Index", viewResult.ViewName);
        }

        private List<Car> GetSampleCars()
        {
            List<Car> output = new List<Car>
            {
                new Car
                {
                    Id= 1,
                    CarModel= "Saga",
                    Location= "Bayan Baru",
                    PricePerDay= 110.00
                },
                new Car
                {
                    Id=2,
                    CarModel= "Wira",
                    Location= "Bayan Lepas",
                    PricePerDay= 108
                },
                new Car
                {
                    Id= 3,
                    CarModel= "Avanza",
                    Location= "Bandar Baru",
                    PricePerDay= 134.56
                },
                new Car
                {
                    Id= 4,
                    CarModel= "Saga",
                    Location= "Bukit Mertajam",
                    PricePerDay= 98.50
                }

            };
            return output;
        }
    }
}
