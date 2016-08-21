using System;
using System.Collections.Generic;
using Infrastructure.Data;
using Infrastructure.IData;
using Services.Interfaces;
using Domain.Entities;
using System.Text.RegularExpressions;
using System.Linq;
using System.Configuration;

namespace Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRep;

        public ClientService(IClientRepository clientRep)
        {
            _clientRep = clientRep;
        }

        public ClientService()
        {
            _clientRep = new ClientRepository(ConfigurationManager.AppSettings["dbName"]);
        }

        public string Create(Client client)
        {
            try
            {
                if (!ValidateCpf(client.CPF))
                    return Messages.InvalidCPF;

                _clientRep.Add(client);

                return Messages.Ok;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Client> GetAll()
        {
            return _clientRep.GetAll();
        }

        public bool ValidateCpf(string cpf)
        {
            var digitsOnly = new Regex(@"[^\d]");   
            cpf = digitsOnly.Replace(cpf, "");

            if (cpf.Length != 11)
               return false;
            
            var v = new[] {0,0};

            var cpfInts = cpf.ToCharArray().Select(x => (int)char.GetNumericValue(x)).ToArray();

            //Compute 1st verification digit.
            //using https://en.wikipedia.org/wiki/Cadastro_de_Pessoas_F%C3%ADsicas algorithm
            v[0] = 1 * cpfInts[0] + 2 * cpfInts[1] + 3 * cpfInts[2];
            v[0] += 4 * cpfInts[3] + 5 * cpfInts[4] + 6 * cpfInts[5];
            v[0] += 7 * cpfInts[6] + 8 * cpfInts[7] + 9 * cpfInts[8];
            v[0] = v[0] % 11;
            v[0] = v[0] % 10;

            //Compute 2nd verification digit.
            v[1] = 1 * cpfInts[1] + 2 * cpfInts[2] + 3 * cpfInts[3];
            v[1] += 4 * cpfInts[4] + 5 * cpfInts[5] + 6 * cpfInts[6];
            v[1] += 7 * cpfInts[7] + 8 * cpfInts[8] + 9 * v[0];
            v[1] = v[1] % 11;
            v[1] = v[1] % 10;

            //True if verification digits are as expected.
            return ((v[0] == cpfInts[9]) && (v[1] == cpfInts[10]));
        }
    }
}
