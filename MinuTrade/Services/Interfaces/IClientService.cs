using Domain.Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IClientService
    {
        string Create(Client client);
        IList<Client> GetAll();
    }
}
