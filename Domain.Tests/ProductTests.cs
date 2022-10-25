namespace Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Properties_WhenSetThenPropertiesCanBeGet()
        {
            //Arrange
            const int expectedId = 1;
            const string expectedName = "Appel";
            const bool expectedHasAlcohol = false;
            const string expectedImage = "imagebase64link";
            const bool expectedIsChecked = false;

            //Act
            Product subject = new()
            {
                Id = expectedId,
                Name = expectedName,
                HasAlcohol = expectedHasAlcohol,
                Image = expectedImage,
                IsChecked = expectedIsChecked
            };

            //Assert
            Assert.Equal(expectedId, subject.Id);
            Assert.Equal(expectedName, subject.Name);
            Assert.Equal(expectedHasAlcohol, subject.HasAlcohol);
            Assert.Equal(expectedIsChecked, subject.IsChecked);
        }
    }
}
