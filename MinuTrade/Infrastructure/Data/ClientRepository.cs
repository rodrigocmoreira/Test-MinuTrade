using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.IData;
using LiteDB;

namespace Infrastructure.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Returns all clients
        /// </summary>
        public IList<Client> GetAll()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var clients = db.GetCollection<Client>("clients");

                return clients.FindAll().ToList();
            }
        }

        /// <summary>
        /// Add a Client
        /// </summary>
        /// <param name="client">Client Item</param>
        public void Add(Client client)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(_connectionString))
            {
                // Get client collection
                var clients = db.GetCollection<Client>("clients");

                clients.Insert(client);
            }
        }
    }
}
