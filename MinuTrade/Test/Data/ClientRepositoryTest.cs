using System;
using System.Collections.Generic;
using Infrastructure.Data;
using NUnit.Framework;
using Domain.Entities;
using System.Configuration;

namespace Test.Data
{
    [TestFixture]
    public class ClientRepositoryTest
    {
        [Test]
        public void Add_Client_Repository()
        {
            var repo = new ClientRepository(ConfigurationManager.AppSettings["dbName"]);

            var totalClients = repo.GetAll().Count;
            var rng = new Random();

            var client = new Client
            {
                CPF = string.Format("{0}.{1}.{2}-{3}", new[] { rng.Next(1, 999).ToString("000"), rng.Next(1, 999).ToString("000"), rng.Next(1, 999).ToString("000"), rng.Next(1, 99).ToString("00") }),
                ClientAddress = new Address { AddressLine = "Rua do Teste" },
                Email = "teste@teste.com",
                MaritalStatus = "Single",
                Name = "Teste Teste",
                PhoneNumbers = new List<string> { "5555-5555", "99999-9999" }
            };

            repo.Add(client);

            Assert.AreEqual(totalClients + 1, repo.GetAll().Count);
        }
    }
}