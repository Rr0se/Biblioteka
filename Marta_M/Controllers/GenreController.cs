using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marta_M.Repository.AuthorRepository;
using Marta_M.Repository.GenreRepository;

namespace Marta_M.Controllers
{
    [Produces("application/json")]
    [Route("api/Genre")]
    public class GenreController : Controller
    {
        private IGenresRepository _rep;

        public GenreController(IGenresRepository rep)
        {
            _rep = rep;
        }
        // GET: api/Genre
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return _rep.GetAll();
        }

        // GET: api/Genre/5
        [HttpGet("{id}", Name = "Get")]
        public Genre Get(int id)
        {
            return _rep.FindById(id);
        }

        // POST: api/Genre
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Genre/5
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
