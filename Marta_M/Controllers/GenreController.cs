using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marta_M.Repository.AuthorRepository;
using Marta_M.Repository.GenreRepository;
using Marta_M.Utils;

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
        // GET: api/Genres
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rep.GetAll());
        }

        // GET: api/Genres/5
        [HttpGet("{id}", Name = "GetGenre")]
        public IActionResult Get(int id)
        {
            var genre = _rep.FindById(id);
            if (genre != null)
                return Ok(genre);
            else
                return NotFound();
        }

        // POST: api/Genres
        [HttpPost]
        public IActionResult Post([FromBody] Genre genre)
        {
            try
            {
                _rep.Insert(genre);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetGenre", new { id = genre.Id }, ApiResponse.Ok(genre));
            }
            catch (Exception e)
            {
                return BadRequest(ApiResponse.Error(genre, e.Message));
            }
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Genre genre)
        {
            try
            {
                _rep.Update(genre);
                _rep.UnitOfWork.SaveChanges();
                return Ok(ApiResponse.Ok(genre));
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
