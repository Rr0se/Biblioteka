using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marta_M.Repository.AuthorRepository;
using Marta_M.Repository.PublisherRepository;
using Marta_M.Utils;

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
        [HttpGet("{id}", Name = "GetPublisher")]
        public Publisher Get(int id)
        {
            return _rep.FindById(id);
        }

        // POST: api/Publisher
        [HttpPost]
        public IActionResult Post([FromBody]Publisher publisher)
        {
            try
            {
                _rep.Insert(publisher);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetPublisher", new { id = publisher.Id }, ApiResponse.Ok(publisher));
            }
            catch (Exception e)
            {
                return BadRequest(ApiResponse.Error(publisher, e.Message));
            }
        }

        // PUT: api/Publisher/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Publisher publisher)
        {
            try
            {
                _rep.Update(publisher);
                _rep.UnitOfWork.SaveChanges();
                return Ok(ApiResponse.Ok(publisher));
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
