using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using CarRentalMS.DataAccess;
using CarRentalMS.DataAccess.Repositories.Interfaces;
using CarRentalMS.Services;
using Moq;
using Xunit;

namespace CarRentalMS.Tests
{
    public class CarServicesTests
    {
        //mock data
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

        private List<Car> GetSampleFilterCars()
        {
            List<Car> output = new List<Car>
            {
                new Car{ Id= 1,CarModel= "Saga",Location= "Bayan Baru",PricePerDay= 110.00},
                new Car{Id= 4,CarModel= "Saga",Location= "Bukit Mertajam",PricePerDay= 98.50}
            };
            return output;
        }

        private Car GetASampleCar()
        {
            return new Car { Id = 3, CarModel = "Wira", Location = "Bayan Lepas", PricePerDay = 108.50 };
        }

        [Fact]
        public void GetAllCars_WithNoFilterShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarRepository>()
                    .Setup(x => x.GetAll())
                    .Returns(GetSampleCars().AsQueryable);

                var cls = mock.Create<CarServices>();
                var expected = GetSampleCars();

                //Act
                var actual = cls.GetAllCars(null, null).ToList();

                //Assert
                Assert.False(actual == null);
                Assert.Equal(expected.Count(), actual.Count());

                for (int i = 0; i < expected.Count(); i++)
                {
                    Assert.Equal(expected[i].Id, actual[i].Id);
                    Assert.Equal(expected[i].CarModel, actual[i].CarModel);
                    Assert.Equal(expected[i].Location, actual[i].Location);
                    Assert.Equal(expected[i].PricePerDay, actual[i].PricePerDay);
                }
            }
        }

        [Fact]
        public void GetAllCars_WithFilterShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarRepository>()
                    .Setup(x => x.GetCarsByFilter("Saga", ""))
                    .Returns(GetSampleFilterCars().AsQueryable);

                var cls = mock.Create<CarServices>();
                var expected = GetSampleFilterCars();

                //Act
                var actual = cls.GetAllCars("Saga", "").ToList();

                //Assert
                Assert.False(actual == null);
                Assert.Equal(expected.Count(), actual.Count());

                for (int i = 0; i < expected.Count(); i++)
                {
                    Assert.Equal(expected[i].Id, actual[i].Id);
                    Assert.Equal(expected[i].CarModel, actual[i].CarModel);
                    Assert.Equal(expected[i].Location, actual[i].Location);
                    Assert.Equal(expected[i].PricePerDay, actual[i].PricePerDay);
                }
            }
        }

        [Fact]
        public async Task AddCar_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var car = GetASampleCar();
                mock.Mock<ICarRepository>();
                var cls = mock.Create<CarServices>();

                //Act
                await cls.AddCar(car);

                //Assert
                mock.Mock<ICarRepository>()
                    .Verify(x => x.Create(car), Times.Exactly(1));


            }
        }

        [Fact]
        public async Task AddCar_ShouldFail()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarRepository>()
                    .Setup(x => x.Create(null));

                var cls = mock.Create<CarServices>();

                //Act
                var ex = await Record.ExceptionAsync(() => cls.AddCar(null));

                //Assert
                Assert.NotNull(ex);
                if (ex is ArgumentException argEx)
                {
                    Assert.Equal("addCar", argEx.ParamName);
                }
            }
        }

        [Fact]
        public async Task FindCar_ShouldReturnACar()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarRepository>()
                    .Setup(m => m.FindById(3))
                    .Returns(Task.FromResult(GetASampleCar()));


                var cls = mock.Create<CarServices>();
                var expected = GetASampleCar();

                //Act
                Car actual = await cls.FindCar(3);

                //Assert
                Assert.False(actual == null);
                Assert.Equal(expected.Id, actual.Id);
                Assert.Equal(expected.CarModel, actual.CarModel);
                Assert.Equal(expected.Location, actual.Location);
                Assert.Equal(expected.PricePerDay, actual.PricePerDay);

            }
        }

        [Fact]
        public async Task UpdateCar_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var car = GetASampleCar();
                mock.Mock<ICarRepository>()
                    .Setup(x => x.Update(car));

                var cls = mock.Create<CarServices>();

                //Act
                await cls.UpdateCar(car);

                //Assert
                mock.Mock<ICarRepository>()
                    .Verify(x => x.Update(car), Times.Exactly(1));
            }
        }

        [Fact]
        public async Task UpdateCar_ShouldFail()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarRepository>()
                    .Setup(x => x.Update(null));

                var cls = mock.Create<CarServices>();

                //Act
                var ex = await Record.ExceptionAsync(() => cls.UpdateCar(null));

                //Assert
                Assert.NotNull(ex);
                if (ex is ArgumentException argEx)
                {
                    Assert.Equal("updateCar", argEx.ParamName);
                }
            }
        }

        [Fact]
        public async Task DeleteCar_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var car = GetASampleCar();
                mock.Mock<ICarRepository>()
                    .Setup(x => x.Delete(car));

                var cls = mock.Create<CarServices>();

                //Act
                await cls.DeleteCar(car);

                //Assert
                mock.Mock<ICarRepository>()
                    .Verify(x => x.Delete(car), Times.Exactly(1));

            }
        }

        [Fact]
        public async Task DeleteCar_ShouldFail()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarRepository>()
                    .Setup(x => x.Delete(null));

                var cls = mock.Create<CarServices>();

                //Act
                var ex = await Record.ExceptionAsync(() => cls.DeleteCar(null));

                //Assert
                Assert.NotNull(ex);
                if (ex is ArgumentException argEx)
                {
                    Assert.Equal("deleteCar", argEx.ParamName);
                }
            }
        }

        [Fact]
        public void GetCurrentDate_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<ICarRepository>();
                var cls = mock.Create<CarServices>();

                //Act
                var actualDateTime = cls.GetCurrentDate();

                //Assert
                Assert.NotNull(actualDateTime);
            }


        }

    }
}
