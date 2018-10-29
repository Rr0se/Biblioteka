using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marta_M.Repository.AuthorRepository;

namespace Marta_M.Controllers
{
    [Produces("application/json")]
    [Route("api/Author")]
    public class AuthorController : Controller
    {
        private IAuthorsRepository _rep;

        public AuthorController(IAuthorsRepository  rep)
        {
            _rep = rep;
        }
        // GET: api/Author
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _rep.GetAll();
        }

        // GET: api/Author/5
        [HttpGet("{id}", Name = "Get")]
        public Author Get(int id)
        {
            return _rep.FindById(id);
        }
        
        // POST: api/Author
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Author/5
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
