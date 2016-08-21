using System.Collections.Generic;
using Infrastructure.IData;
using Domain.Entities;

namespace Test
{
    public class MockClientRepository : IClientRepository
    {
        public IList<Client> GetAll()
        {
            var result = new List<Client>
            {
                new Client
                        {
                            CPF = "111.175.232-65",
                            ClientAddress = new Address {AddressLine = "Rua do Teste"},
                            Email = "teste@teste.com",
                            MaritalStatus = "Single",
                            Name = "Teste Teste",
                            PhoneNumbers = new List<string> {"5555-5555", "99999-9999"}
                        },
                new Client
                        {
                            CPF = "111.175.232-66",
                            ClientAddress = new Address {AddressLine = "Rua do Teste 2"},
                            Email = "teste2@teste.com",
                            MaritalStatus = "Maried",
                            Name = "Teste Dois Teste Dois",
                            PhoneNumbers = new List<string> {"5555-5556", "99999-9990"}
                        }
            };

            return result;
        }

        public void Add(Client client)
        {
            var listClient = new List<Client> { client };
        }
    }
}
