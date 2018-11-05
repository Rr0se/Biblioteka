using Marta_M.Entieties;
using Marta_M.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Repository.BookRepository
{
    public interface IBooksRepository
    {
        IUnitOfWork UnitOfWork { get; }
        List<Book> GetAll();
        Book FindById(int Id);
        void Insert(Book book);
        void Update(Book book);
        void Delete(int Id);
    }
}
