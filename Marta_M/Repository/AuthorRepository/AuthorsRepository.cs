using Marta_M.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Marta_M.Repository.UnitOfWork;

namespace Marta_M.Repository.AuthorRepository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly DataBaseContext context;

        public AuthorsRepository(DataBaseContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public List<Author> GetAll()
        {
            return context.Authors.ToList();
        }
        public Author FindById(int id)
        {
            return context.Authors.SingleOrDefault(x => x.Id == id); 
        }
        public void Insert(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();

        }
        public void Update(Author author)
        {
            context.Set<Author>().Update(author);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Author author = context.Authors.Find(Id);
            context.Authors.Remove(author);

            context.SaveChanges();
            //return StatusCode((int)HttpStatusCode.OK);
        }
        
    }
}
