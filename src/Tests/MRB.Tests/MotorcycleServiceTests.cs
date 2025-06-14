using Moq;
using NUnit.Framework;
using MRB.Application.Abstractions;
using MRB.Application.DTOs;
using MRB.Application.Implementations;
using MRB.Application.Models.Create;
using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Domain.Events;
using MRB.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRB.Infra.Data.Abstractions;

namespace MRB.Tests
{
    [TestFixture]
    public class MotorcycleServiceTests
    {
        private Mock<IMotorcycleRepository> _motorcycleRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IEventPublisher> _eventPublisherMock;
        private MotorcycleService _service;

        [SetUp]
        public void Setup()
        {
            _motorcycleRepositoryMock = new Mock<IMotorcycleRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _eventPublisherMock = new Mock<IEventPublisher>();
            _service = new MotorcycleService(_motorcycleRepositoryMock.Object, _unitOfWorkMock.Object, _eventPublisherMock.Object);
        }

        [Test]
        public async Task CreateMotorCycle_Should_Save_And_PublishEvent()
        {
            var model = new CreateMotorcycleModel("id1", 2024, "ModelX", "ABC1234");
            _motorcycleRepositoryMock.Setup(x => x.Save(It.IsAny<Motorcycle>())).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(x => x.CommitAsync()).Returns(Task.CompletedTask);
            _eventPublisherMock.Setup(x => x.PublishAsync(It.IsAny<MotorcycleCreatedDomainEvent>())).Returns(Task.CompletedTask);

            await _service.CreateMotorCycle(model);

            _motorcycleRepositoryMock.Verify(x => x.Save(It.IsAny<Motorcycle>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
            _eventPublisherMock.Verify(x => x.PublishAsync(It.IsAny<MotorcycleCreatedDomainEvent>()), Times.Once);
        }

        [Test]
        public async Task GetAll_Should_Return_Motorcycles()
        {
            var dtos = new List<MotorcycleDto> { new MotorcycleDto("id1", 2024, "ModelX", "ABC1234") };
            _motorcycleRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(new List<Motorcycle> { new Motorcycle(2024, "ModelX", "ABC1234", "id1", DateTime.Now, DateTime.Now, null) });
            var result = await _service.GetAll();
            Assert.That(result, Is.Not.Null);
        }
    }
}
