using System;
using CarRentalMS.DataAccess.Repositories;
using Xunit;

namespace CarRentalMS.Tests
{
    public class CarRepositoryTests
    {
        //[Fact]
        //public void incerementIntByOne_SimpleValueShouldCalculate()
        //{
        //    //Arrange
        //    int expected = 6;

        //    //Act
        //    int actual = CarRepository.incrementIntByOne(5);

        //    //Assert
        //    Assert.Equal(expected, actual);
        //}

        [Theory]
        [InlineData(2, 3)]
        [InlineData(78, 79)]
        public void incerementIntByOne_ShouldWork(int x, int expected)
        {
            int actual = CarRepository.incrementIntByOne(x);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(int.MaxValue, "NewId")]
        public void incerementIntByOne_ShouldFail(int x, string param)
        {
            Assert.Throws<ArgumentException>(param, () => CarRepository.incrementIntByOne(x));
        }
    }
}
