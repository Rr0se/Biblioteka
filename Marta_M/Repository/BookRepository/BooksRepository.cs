using Marta_M.Entieties;
using Marta_M.Entities;
using Marta_M.Repository.BookRepository;
using Marta_M.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Repository.BooksRepository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DataBaseContext context;

        public BooksRepository(DataBaseContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public List<Book> GetAll()
        {
            return context.Books.ToList();
        }
        public Book FindById(int id)
        {
            return context.Books
                .Include(b => b.AuthorBooks)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.GenreBooks)
                .ThenInclude(bg => bg.Genre)
                .Include(b => b.Publisher)
                .SingleOrDefault(b => b.Id == id);
        }
        public void Insert(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();

        }
        public void Update(Book book)
        {
            context.Set<Book>().Update(book);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Book book = context.Books.Find(Id);
            context.Books.Remove(book);

            context.SaveChanges();
            //return StatusCode((int)HttpStatusCode.OK);
        }

    }
}
