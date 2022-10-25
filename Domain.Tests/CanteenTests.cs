namespace Domain.Tests
{
    public class CanteenTests
    {
        [Fact]
        public void Properties_WhenSetThenPropertiesCanBeGet()
        {
            //Arrange
            const int expectedId = 1;
            const City expectedCity = City.BREDA;
            const string expectedLocation = "LA";
            const bool expectedWarmMeals = true;

            //Act
            Canteen subject = new()
            {
                Id = expectedId,
                City = expectedCity,
                Location = expectedLocation,
                WarmMeals = expectedWarmMeals
            };

            //Assert
            Assert.Equal(expectedId, subject.Id);
            Assert.Equal(expectedCity, subject.City);
            Assert.Equal(expectedLocation, subject.Location);
            Assert.Equal(expectedWarmMeals, subject.WarmMeals);
        }
    }
}
