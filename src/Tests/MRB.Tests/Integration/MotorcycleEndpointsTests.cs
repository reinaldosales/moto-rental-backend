using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using MRB.Api.Contracts;
using MRB.Application.DTOs;

namespace MRB.Tests.Integration
{
    [TestFixture]
    public class MotorcycleEndpointsTests
    {
        private WebApplicationFactory<Program> _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
        }
        
        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
        }

        [Test]
        public async Task Post_CreateMotorcycle_ReturnsCreated()
        {
            var client = _factory.CreateClient();
            
            var request = new CreateMotorcycleRequest
            {
                Identificador = "moto-it-1",
                Ano = 2024,
                Modelo = "Honda",
                Placa = "ABC1234"
            };
            var response = await client.PostAsJsonAsync("/motos", request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
        }

        [Test]
        public async Task Get_Motorcycles_ReturnsOk()
        {
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("/motos");
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
    }
}
