using Marta_M.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Repository.AuthorRepository
{
    public interface IAuthorsRepository
    {
        List<Author> GetAll();
        Author FindById(int Id);
        void Insert(Author author);
        void UpDate(Author author);
        void Delete(int Id);
    }
}
