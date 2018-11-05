using Marta_M.Entities;
using Marta_M.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Repository.GenreRepository
{
    public interface IGenresRepository
    {
        IUnitOfWork UnitOfWork { get; }
        List<Genre> GetAll();
        Genre FindById(int Id);
        void Insert(Genre genre);
        void Update(Genre genre);
        void Delete(int Id);
    }
}
