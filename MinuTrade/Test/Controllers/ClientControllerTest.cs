using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http.Results;
using NUnit.Framework;
using ClientsApi.Controllers;
using Services;
using Domain.Entities;

namespace Test.Controllers
{
    [TestFixture]
    public class ClientControllerTests
    {
        [Test]
        public void Create_Client_Controller()
        {
            var controller = new ClientController(new ClientService(new MockClientRepository()));

            var client1 = new Client
            {
                CPF = "351.128.037-03",
                ClientAddress = new Address { AddressLine = "Rua do Teste" },
                Email = "teste@teste.com",
                MaritalStatus = "Single",
                Name = "Teste Teste",
                PhoneNumbers = new List<string> { "5555-5555", "99999-9999" }
            };

            var client2 = new Client
            {
                CPF = "111.175.232-65",
                ClientAddress = new Address { AddressLine = "Rua do Teste 2" },
                Email = "teste2@teste.com",
                MaritalStatus = "Single",
                Name = "Teste Dois Teste Dois",
                PhoneNumbers = new List<string> { "5555-5556", "99999-9990" }
            };

            var result1 = controller.Create(client1) as CreatedAtRouteNegotiatedContentResult<Client>;
    
            Assert.IsNotNull(result1);
            Assert.AreEqual("DefaultApi", result1.RouteName);
            Assert.AreEqual(result1.Content.CPF, result1.RouteValues["id"]);

            var result2 = controller.Create(client2) as NegotiatedContentResult<string>;

            Assert.AreEqual(result2 != null ? result2.StatusCode : new object(), HttpStatusCode.BadRequest);
        }

        [Test]
        public void Test_Get_All_Controller()
        {
            var controller = new ClientController(new ClientService(new MockClientRepository()));

            var result = controller.Get();

            Assert.AreEqual(result.Count(), 2);
        } 
    }
}