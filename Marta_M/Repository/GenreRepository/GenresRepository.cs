using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;
using Marta_M.Repository.UnitOfWork;

namespace Marta_M.Repository.GenreRepository
{
    public class GenresRepository : IGenresRepository
    {
        private readonly DataBaseContext context;

        public GenresRepository(DataBaseContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;
        
        public List<Genre> GetAll()
        {
            return context.Genres.ToList();
        }

        public Genre FindById(int Id)
        {
            return context.Genres.SingleOrDefault(x => x.Id == Id);
        }

        public void Insert(Genre genre)
        {
            context.Genres.Add(genre);
            context.SaveChanges();
        }

        public void Update(Genre genre)
        {
            context.Set<Genre>().Update(genre);
            context.SaveChanges();

        }

        public void Delete(int Id)
        {
            Genre genre = context.Genres.Find(Id);
            context.Genres.Remove(genre);
            context.SaveChanges();

        }
    }
}
