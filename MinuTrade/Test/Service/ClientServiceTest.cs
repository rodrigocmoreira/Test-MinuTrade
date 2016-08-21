using System.Collections.Generic;
using NUnit.Framework;
using Services;
using Domain.Entities;

namespace Test.Service
{
    [TestFixture]
    public class ClientServiceTest
    {
        [Test]
        public void Create_Client_Service()
        {
            var service = new ClientService(new MockClientRepository());

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

            Assert.AreEqual(service.Create(client1), Messages.Ok);
            Assert.AreNotEqual(service.Create(client2), Messages.Ok);
        }

        [Test]
        public void Check_Validate_CPF()
        {
            var service = new ClientService(new MockClientRepository());

            //CPF Válido
            var cpf1 = "351.128.037-03";
            //Cpf inválido
            var cpf2 = "111.175.232-65";

            Assert.IsTrue(service.ValidateCpf(cpf1));
            Assert.IsFalse(service.ValidateCpf(cpf2));
        }

        [Test]
        public void Get_All_Clients_Service()
        {
            var service = new ClientService(new MockClientRepository());

            var result = service.GetAll();

            Assert.AreEqual(result.Count, 2);
        }
    }
}