using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using MRB.Api.Contracts;

namespace MRB.Tests.Integration
{
    [TestFixture]
    public class RentalEndpointsTests
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
        public async Task Post_CreateRental_ReturnsCreatedOrBadRequest()
        {
            var client = _factory.CreateClient();

            var request = new CreateRentalRequest
            {
                Entregador_id = "entregador-it-1",
                Moto_id = "moto-it-1",
                Data_Inicio = System.DateTime.UtcNow.AddDays(1),
                Data_Termino = System.DateTime.UtcNow.AddDays(2),
                Data_Previsao_Termino = System.DateTime.UtcNow.AddDays(2),
                plano = MRB.Domain.Enums.RentalPlan.SevenDays
            };
            var response = await client.PostAsJsonAsync("/locacao", request);
            Assert.That(response.StatusCode == System.Net.HttpStatusCode.Created || response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }
    }
}
