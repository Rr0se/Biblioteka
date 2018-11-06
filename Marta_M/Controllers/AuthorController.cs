using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marta_M.Repository.AuthorRepository;
using Marta_M.Utils;

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
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {
            var author = _rep.FindById(id);
            if (author != null)
                return Ok(author);
            else
                return NotFound();
        }
        
        // POST: api/Author
        [HttpPost]
        public IActionResult Post([FromBody]Author author)
        {
            try
            {
                _rep.Insert(author);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetAuthor", new { id = author.Id }, ApiResponse.Ok(author));

            }
            catch (Exception e)
            {
                return BadRequest(ApiResponse.Error(author, e.Message));
            }
        }
        
        // PUT: api/Author/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Author author)
        {
            try
            {
                _rep.Update(author);
                _rep.UnitOfWork.SaveChanges();
                return Ok(ApiResponse.Ok(author));
            }
            catch (Exception e)
            {
                return BadRequest(ApiResponse.Error(id, e.Message));
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _rep.Delete(id);
                _rep.UnitOfWork.SaveChanges();
                return Ok(ApiResponse.Ok(id));
            }
            catch (Exception e)
            {
                return BadRequest(ApiResponse.Error(id, e.Message));
            }
        }
    }
}
