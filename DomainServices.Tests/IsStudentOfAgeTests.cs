using DomainServices.Services;
using Domain;

namespace DomainServices.Tests
{
    public class IsStudentOfAgeTests
    {
        [Fact]
        public void StudentBornIn2000ShouldReturnTrue()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2000, 5, 14) };
            var sut = new StudentOfAgeService(student);

            //Act
            var result = sut.IsStudentOfAge(student, DateTime.Now);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void StudentBornIn2004ShouldReturnTrue()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2004, 5, 14) };
            var sut = new StudentOfAgeService(student);

            //Act
            var result = sut.IsStudentOfAge(student, DateTime.Now);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void StudentBornIn2005ShouldReturnFalse()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2005, 5, 14) };
            var sut = new StudentOfAgeService(student);

            //Act
            var result = sut.IsStudentOfAge(student, DateTime.Now);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void StudentBornIn2004WithBirthDayTodayShouldReturnTrue()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2004, DateTime.Now.Month, DateTime.Now.Day) };
            var sut = new StudentOfAgeService(student);

            //Act
            var result = sut.IsStudentOfAge(student, DateTime.Now);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void StudentBornIn2004WithBirthDayTomorrowShouldReturnFalse()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2004, DateTime.Now.Month, DateTime.Now.Day + 1) };
            var sut = new StudentOfAgeService(student);

            //Act
            var result = sut.IsStudentOfAge(student, DateTime.Now);

            //Assert
            Assert.True(result);
        }
    }
}