namespace Domain.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Properties_WhenSetThenPropertiesCanBeGet()
        {
            //Arrange
            const int expectedId = 1;
            const int expextedStudentNumber = 2116527;
            const string expectedName = "Rik Vandermullen";
            const string expectedEmailAddress = "rik.vandermullen@gmail.com";
            DateTime expectedBirthDay = new DateTime(1998, 11, 09);
            const string expectedPhoneNumber = "0658942232";
            const string expectedCity = "Breda";
            const int expectedNoShows = 0;

            //Act
            Student subject = new()
            {
                Id = expectedId,
                StudentNumber = expextedStudentNumber,
                Name = expectedName,
                EmailAddress = expectedEmailAddress,
                BirthDate = expectedBirthDay,
                PhoneNumber = expectedPhoneNumber,
                City = expectedCity,
                noShows = expectedNoShows
            };

            //Assert
            Assert.Equal(expectedId, subject.Id);
            Assert.Equal(expectedName, subject.Name);
            Assert.Equal(expectedEmailAddress, subject.EmailAddress);
            Assert.Equal(expectedBirthDay, subject.BirthDate);
            Assert.Equal(expectedPhoneNumber, subject.PhoneNumber);
            Assert.Equal(expectedCity, subject.City);
            Assert.Equal(expectedNoShows, subject.noShows);
        }

        [Fact]
        public void StudentWhoIs18IsOfAge()
        {
            //Arrange
            Student subject = new Student { BirthDate = new DateTime(2004, 01, 01) };

            //Act
            bool OfAge = subject.IsStudentOfAge();

            //Assert
            Assert.True(OfAge);
        }

        [Fact]
        public void StudentWhoIs19IsOfAge()
        {
            //Arrange
            Student subject = new Student { BirthDate = new DateTime(2003, 01, 01) };

            //Act
            bool OfAge = subject.IsStudentOfAge();

            //Assert
            Assert.True(OfAge);
        }

        [Fact]
        public void StudentWhoIs17IsNotOfAge()
        {
            //Arrange
            Student subject = new Student { BirthDate = new DateTime(2005, 01, 01) };

            //Act
            bool OfAge = subject.IsStudentOfAge();

            //Assert
            Assert.False(OfAge);
        }
    }
}