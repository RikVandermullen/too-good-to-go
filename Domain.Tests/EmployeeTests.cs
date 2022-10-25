namespace Domain.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Properties_WhenSetThenPropertiesCanBeGet()
        {
            //Arrange
            const int expectedId = 1;
            const int expectedEmployeeNumber = 1;
            const string expectedName = "Merel de Laat";
            const string expectedEmailAddress = "canteenworker1@gmail.com";
            const int expectedCanteenId = 1;
            Canteen expectedCanteen = new() { Id = 1, City = City.BREDA, Location = "LA", WarmMeals = true };

            //Act
            Employee subject = new()
            {
                Id = expectedId,
                EmployeeNumber = expectedEmployeeNumber,
                Name = expectedName,
                EmailAddress = expectedEmailAddress,
                Canteen = expectedCanteen,
                CanteenId = expectedCanteenId
            };

            //Assert
            Assert.Equal(expectedId, subject.Id);
            Assert.Equal(expectedName, subject.Name);
            Assert.Equal(expectedEmailAddress, subject.EmailAddress);
            Assert.Equal(expectedEmployeeNumber, subject.EmployeeNumber);
            Assert.Equal(expectedCanteenId, subject.CanteenId);
            Assert.Equal(expectedCanteen, subject.Canteen);
        }
    }
}
