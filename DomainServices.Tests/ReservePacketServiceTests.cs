using Domain;
using DomainServices.Services;
using Moq;

namespace DomainServices.Tests
{
    public class ReservePacketServiceTests
    {
        [Fact]
        public void PacketWithProductThatContainAlcoholShouldReturnContainsAlcohol()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2000, 5, 14) };
            var StudentOfAgeServiceMock = new Mock<StudentOfAgeService>(student);
            List<Product> products = new List<Product> { new Product { Id = 1, Name = "Bier", HasAlcohol = true } };
            var Packet = new Packet { Name = "Test Pakket", Products = products };

            var sut = new ReservePacketService(StudentOfAgeServiceMock.Object);

            //Act
            var result = sut.DoesProductsInPacketContainAlcohol(Packet);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void PacketWithoutProductThatContainAlcoholShouldNotReturnContainsAlcohol()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2000, 5, 14) };
            var StudentOfAgeServiceMock = new Mock<StudentOfAgeService>(student);
            List<Product> products = new List<Product> { new Product { Id = 1, Name = "Appel", HasAlcohol = false } };
            var Packet = new Packet { Name = "Test Pakket", Products = products };

            var sut = new ReservePacketService(StudentOfAgeServiceMock.Object);

            //Act
            var result = sut.DoesProductsInPacketContainAlcohol(Packet);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void StudentOfAgeCanReservePacketThatContainsAlcohol()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2000, 5, 14) };
            var StudentOfAgeServiceMock = new Mock<StudentOfAgeService>(student);
            List<Product> products = new List<Product> { new Product { Id = 1, Name = "Bier", HasAlcohol = true } };
            var Packet = new Packet { Name = "Test Pakket", Products = products, PickUpTime = new DateTime(2022,10,28) };

            var sut = new ReservePacketService(StudentOfAgeServiceMock.Object);

            //Act
            var result = sut.CanStudentReservePacket(Packet, student);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void StudentNotOfAgeCanNotReservePacketThatContainsAlcohol()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2006, 5, 14) };
            var StudentOfAgeServiceMock = new Mock<StudentOfAgeService>(student);
            List<Product> products = new List<Product> { new Product { Id = 1, Name = "Bier", HasAlcohol = true } };
            var Packet = new Packet { Name = "Test Pakket", Products = products, PickUpTime = new DateTime(2022, 10, 28) };

            var sut = new ReservePacketService(StudentOfAgeServiceMock.Object);

            //Act
            var result = sut.CanStudentReservePacket(Packet, student);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void StudentOfAgeCanReservePacketThatDoesNotContainsAlcohol()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2000, 5, 14) };
            var StudentOfAgeServiceMock = new Mock<StudentOfAgeService>(student);
            List<Product> products = new List<Product> { new Product { Id = 1, Name = "Appel", HasAlcohol = false } };
            var Packet = new Packet { Name = "Test Pakket", Products = products, PickUpTime = new DateTime(2022, 10, 28) };

            var sut = new ReservePacketService(StudentOfAgeServiceMock.Object);

            //Act
            var result = sut.CanStudentReservePacket(Packet, student);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void StudentNotOfAgeCanReservePacketThatDoesNotContainsAlcohol()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2006, 5, 14) };
            var StudentOfAgeServiceMock = new Mock<StudentOfAgeService>(student);
            List<Product> products = new List<Product> { new Product { Id = 1, Name = "Appel", HasAlcohol = false } };
            var Packet = new Packet { Name = "Test Pakket", Products = products, PickUpTime = new DateTime(2022, 10, 28) };

            var sut = new ReservePacketService(StudentOfAgeServiceMock.Object);

            //Act
            var result = sut.CanStudentReservePacket(Packet, student);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void PacketCannotBeReservedWhenStudentDoesNotExist()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2000, 5, 14) };
            var StudentOfAgeServiceMock = new Mock<StudentOfAgeService>(student);
            List<Product> products = new List<Product> { new Product { Id = 1, Name = "Appel", HasAlcohol = false } };
            var Packet = new Packet { Name = "Test Pakket", Products = products, PickUpTime = new DateTime(2022, 10, 28) };

            var sut = new ReservePacketService(StudentOfAgeServiceMock.Object);

            //Act
            // if student is not found it would be null
            var result = sut.CanStudentReservePacket(Packet, null);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void PacketCannotBeReservedWhenPacketDoesNotExist()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2000, 5, 14) };
            var StudentOfAgeServiceMock = new Mock<StudentOfAgeService>(student);
            List<Product> products = new List<Product> { new Product { Id = 1, Name = "Appel", HasAlcohol = false } };
            var Packet = new Packet { Name = "Test Pakket", Products = products, PickUpTime = new DateTime(2022, 10, 28) };

            var sut = new ReservePacketService(StudentOfAgeServiceMock.Object);

            //Act
            // if packet is not found it would be null
            var result = sut.CanStudentReservePacket(null, student);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void PacketCannotBeReservedWhenPacketAndStudentDoNotExist()
        {
            //Arrange
            var student = new Student { Name = "Rik Vandermullen", BirthDate = new DateTime(2000, 5, 14) };
            var StudentOfAgeServiceMock = new Mock<StudentOfAgeService>(student);
            List<Product> products = new List<Product> { new Product { Id = 1, Name = "Appel", HasAlcohol = false } };
            var Packet = new Packet { Name = "Test Pakket", Products = products, PickUpTime = new DateTime(2022, 10, 28) };

            var sut = new ReservePacketService(StudentOfAgeServiceMock.Object);

            //Act
            // if packet and student are not found they would be null
            var result = sut.CanStudentReservePacket(null, null);

            //Assert
            Assert.False(result);
        }
    }
}
