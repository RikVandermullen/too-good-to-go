namespace Domain.Tests
{
    public class PacketTests
    {
        [Fact]
        public void Properties_WhenSetThenPropertiesCanBeGet()
        {
            //Arrange
            const int expectedId = 1;
            const string expectedName = "Groente Pakket";
            const double expectedPrice = 12.55;
            DateTime expectedPickUpTime = DateTime.Now;
            DateTime expectedLatestPickUpTime = DateTime.Now.AddHours(5);
            Student expectedReservedBy = new Student() { Id = 1 };
            const City expectedCity = City.BREDA;
            const int expectedCanteenId = 1;
            Canteen expectedCanteen = new() { Id = 1, City = City.BREDA, Location = "LA", WarmMeals = true };
            const MealType expectedMealType = MealType.GEZOND;
            const bool expectedContainsAlcohol = false;


            //Act
            Packet subject = new()
            {
                Id = expectedId,
                Name = expectedName,
                Price = expectedPrice,
                PickUpTime = expectedPickUpTime,
                LastestPickUpTime = expectedLatestPickUpTime,
                ReservedBy = expectedReservedBy,
                City = expectedCity,
                CanteenId = expectedCanteenId,
                Canteen = expectedCanteen,
                MealType = expectedMealType,
                ContainsAlcohol = expectedContainsAlcohol,
            };

            //Assert
            Assert.Equal(expectedId, subject.Id);
            Assert.Equal(expectedName, subject.Name);
            Assert.Equal(expectedPrice, subject.Price);
            Assert.Equal(expectedPickUpTime, subject.PickUpTime);
            Assert.Equal(expectedLatestPickUpTime, subject.LastestPickUpTime);
            Assert.Equal(expectedReservedBy, subject.ReservedBy);
            Assert.Equal(expectedCanteenId, subject.CanteenId);
            Assert.Equal(expectedCanteen, subject.Canteen);
            Assert.Equal(expectedMealType, subject.MealType);
            Assert.Equal(expectedContainsAlcohol, subject.ContainsAlcohol);
        }

        [Fact]
        public void PacketWithProductThatContainsAlcoholReturnTrue()
        {
            //Arrange
            List<Product> products = new List<Product>()
            {
                new Product { HasAlcohol = true}
            };

            //Act
            Packet subject = new()
            {
                Products = products
            };

            bool ContainsAlcohol = subject.DoesPacketContainAlcohol();

            //Assert
            Assert.True(ContainsAlcohol);
        }

        [Fact]
        public void PacketWithProductThatDoesNotContainsAlcoholReturnFalse()
        {
            //Arrange
            List<Product> products = new List<Product>()
            {
                new Product { HasAlcohol = false}
            };

            Packet subject = new()
            {
                Products = products
            };

            //Act
            bool ContainsAlcohol = subject.DoesPacketContainAlcohol();

            //Assert
            Assert.False(ContainsAlcohol);
        }

        [Fact]
        public void EnumToStringReturnCorrectString()
        {
            //Arrange
            Packet subject = new()
            {
                City = City.BREDA
            };

            //Act
            string CityToString = subject.ToString(subject.City.ToString());

            //Assert
            Assert.Equal("Breda",CityToString);
        }

        [Fact]
        public void FormatDateTimeReturnFormattedDateTime()
        {
            //Arrange
            Packet subject = new()
            {
                PickUpTime = new DateTime(2022, 10, 25)
            };

            //Act
            DateOnly dateOnly = subject.FormatDateTime(subject.PickUpTime);

            //Assert
            Assert.Equal(new DateOnly(2022, 10, 25), dateOnly);
        }
    }
}
