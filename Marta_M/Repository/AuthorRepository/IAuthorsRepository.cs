using Marta_M.Entities;
using Marta_M.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Repository.AuthorRepository
{
    public interface IAuthorsRepository
    {
        IUnitOfWork UnitOfWork { get; }
        List<Author> GetAll();
        Author FindById(int Id);
        void Insert(Author author);
        void Delete(int Id);
        void Update(Author author);
    }
}
