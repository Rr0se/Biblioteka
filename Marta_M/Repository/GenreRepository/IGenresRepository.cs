using Marta_M.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Repository.GenreRepository
{
    public interface IGenresRepository
    {
        List<Genre> GetAll();
        Genre FindById(int Id);
        void Insert(Genre genre);
        void UpDate(Genre genre);
        void Delete(int Id);
    }
}
