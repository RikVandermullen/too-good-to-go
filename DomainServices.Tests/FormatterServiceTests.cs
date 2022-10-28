using Domain;
using DomainServices.Services;

namespace DomainServices.Tests
{
    public class FormatterServiceTests
    {
        [Fact]
        public void FormattedDateTimeShouldReturnCorrectFormat()
        {
            //Arrange
            var sut = new FormatterService();

            //Act
            var result = sut.FormatDateTime(new DateTime(2022, 10, 28)).ToString();

            //Assert
            Assert.Equal("10/28/2022", result);
        }

        [Fact]
        public void FormattedDateTimeShouldNotReturnTimesLowerThenDays()
        {
            //Arrange
            var sut = new FormatterService();

            //Act
            var result = sut.FormatDateTime(new DateTime(2022, 10, 28, 12, 12, 12)).ToString();

            //Assert
            Assert.NotEqual("28-10-2022 12:12:12", result);
            Assert.Equal("10/28/2022", result);
        }

        [Fact]
        public void ToStringCityEnumShouldReturnCorrectFormat()
        {
            //Arrange
            var sut = new FormatterService();

            //Act
            var result = sut.ToString(City.BREDA.ToString());

            //Assert
            Assert.Equal("Breda", result);
        }

        [Fact]
        public void ToStringMealTypeEnumShouldReturnCorrectFormat()
        {
            //Arrange
            var sut = new FormatterService();

            //Act
            var result = sut.ToString(MealType.BROOD.ToString());

            //Assert
            Assert.Equal("Brood", result);
        }
    }
}
