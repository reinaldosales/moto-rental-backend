using Moq;
using NUnit.Framework;
using MRB.Application.Abstractions;
using MRB.Application.Implementations;
using MRB.Application.Models.Create;
using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Domain.Enums;
using System;
using System.Threading.Tasks;
using MRB.Infra.Data.Abstractions;

namespace MRB.Tests
{
    [TestFixture]
    public class DeliveryPersonServiceTests
    {
        private Mock<IDeliveryPersonRepository> _deliveryPersonRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private DeliveryPersonService _service;

        [SetUp]
        public void Setup()
        {
            _deliveryPersonRepositoryMock = new Mock<IDeliveryPersonRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _service = new DeliveryPersonService(_deliveryPersonRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Test]
        public async Task Save_Should_Save_And_Commit()
        {
            var model = new CreateDeliveryPersonModel("id1", "Name", "12345678901", DateTime.Now, "123456", DriverLicense.A, "img.png");
            _deliveryPersonRepositoryMock.Setup(x => x.SaveAsync(It.IsAny<DeliveryPerson>())).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(x => x.CommitAsync()).Returns(Task.CompletedTask);

            await _service.Save(model);

            _deliveryPersonRepositoryMock.Verify(x => x.SaveAsync(It.IsAny<DeliveryPerson>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateDriverLicenseImage_Should_Update_And_Commit()
        {
            var deliveryPerson = new DeliveryPerson();
            _deliveryPersonRepositoryMock.Setup(x => x.GetByIdentifier(It.IsAny<string>())).ReturnsAsync(deliveryPerson);
            _unitOfWorkMock.Setup(x => x.CommitAsync()).Returns(Task.CompletedTask);

            var result = await _service.UpdateDriverLicenseImage("img2.png", "id1");

            Assert.That(result, Is.True);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateDriverLicenseImage_Should_ReturnFalse_IfNotFound()
        {
            _deliveryPersonRepositoryMock.Setup(x => x.GetByIdentifier(It.IsAny<string>())).ReturnsAsync((DeliveryPerson)null);
            var result = await _service.UpdateDriverLicenseImage("img2.png", "id1");
            Assert.That(result, Is.False);
        }
    }
}
