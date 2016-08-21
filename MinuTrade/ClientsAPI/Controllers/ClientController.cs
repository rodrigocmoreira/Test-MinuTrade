using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Domain.Entities;
using Services;
using Services.Interfaces;
using System.Web.Http.Description;

namespace ClientsApi.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService();
        }

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IEnumerable<Client> Get()
        {
            return _clientService.GetAll();
        }

        // POST api/values
        [HttpPost]
        [ResponseType(typeof(Client))]
        public IHttpActionResult Create([FromBody]Client client)
        {
            try
            {
                if (client == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _clientService.Create(client);

                if(result == Messages.Ok)
                    return CreatedAtRoute("DefaultApi", new { id = client.CPF }, client);
                
                return Content(HttpStatusCode.BadRequest, result);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }
    }
}
