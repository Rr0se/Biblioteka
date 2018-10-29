using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marta_M.Repository.AuthorRepository;
using Marta_M.Repository.PublisherRepository;

namespace Marta_M.Controllers
{
    [Produces("application/json")]
    [Route("api/Publisher")]
    public class PublisherController : Controller
    {
        private IPublishersRepository _rep;

        public PublisherController(IPublishersRepository rep)
        {
            _rep = rep;
        }
        // GET: api/Publisher
        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            return _rep.GetAll();
        }

        // GET: api/Publisher/5
        [HttpGet("{id}", Name = "Get")]
        public Publisher Get(int id)
        {
            return _rep.FindById(id);
        }

        // POST: api/Publisher
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Publisher/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
