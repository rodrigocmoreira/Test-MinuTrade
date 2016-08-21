using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.IData
{
    public interface IClientRepository
    {
        IList<Client> GetAll(); 
        void Add(Client client);
    }
}
