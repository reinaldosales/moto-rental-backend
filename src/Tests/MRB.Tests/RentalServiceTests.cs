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
    public class RentalServiceTests
    {
        private Mock<IRentalRepository> _rentalRepositoryMock;
        private Mock<IMotorcycleRepository> _motorcycleRepositoryMock;
        private Mock<IDeliveryPersonRepository> _deliveryPersonRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private RentalService _service;

        [SetUp]
        public void Setup()
        {
            _rentalRepositoryMock = new Mock<IRentalRepository>();
            _motorcycleRepositoryMock = new Mock<IMotorcycleRepository>();
            _deliveryPersonRepositoryMock = new Mock<IDeliveryPersonRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _service = new RentalService(_rentalRepositoryMock.Object, _motorcycleRepositoryMock.Object, _deliveryPersonRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Test]
        public async Task Save_Should_Throw_If_DeliveryPerson_NotFound()
        {
            _deliveryPersonRepositoryMock.Setup(x => x.GetByIdentifier(It.IsAny<string>())).ReturnsAsync((DeliveryPerson)null);
            var model = new CreateRentalModel("entregador", "moto", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), DateTime.Now.AddDays(2), RentalPlan.SevenDays);
            Assert.ThrowsAsync<Exception>(async () => await _service.Save(model));
        }

        [Test]
        public async Task Save_Should_Throw_If_Motorcycle_NotFound()
        {
            _deliveryPersonRepositoryMock.Setup(x => x.GetByIdentifier(It.IsAny<string>())).ReturnsAsync(new DeliveryPerson());
            _motorcycleRepositoryMock.Setup(x => x.GetByIdentifier(It.IsAny<string>())).ReturnsAsync((Motorcycle)null);
            var model = new CreateRentalModel("entregador", "moto", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), DateTime.Now.AddDays(2), RentalPlan.SevenDays);
            Assert.ThrowsAsync<Exception>(async () => await _service.Save(model));
        }
    }
}
