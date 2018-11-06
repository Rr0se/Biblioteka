using Marta_M.Entieties;
using Marta_M.Repository.BookRepository;
using Marta_M.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : Controller
    {
        private IBooksRepository _rep;

        public BookController(IBooksRepository rep)
        {
            _rep = rep;
        }
        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _rep.GetAll();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult Get(int id)
        {
            var book = _rep.FindById(id);
            if (book != null)
                return Ok(book);
            else
                return NotFound();
        }

        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            try
            {
                _rep.Insert(book);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetBook", new { id = book.Id }, ApiResponse.Ok(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Error(book, ex.Message));
            }
           

        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            try
            {
                _rep.Update(book);
                _rep.UnitOfWork.SaveChanges();
                return Ok(ApiResponse.Ok(book));
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
