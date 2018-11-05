using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marta_M.Entities;
using Marta_M.Repository.UnitOfWork;

namespace Marta_M.Repository.PublisherRepository
{
    public class PublishersRepository : IPublishersRepository
    {
        private readonly DataBaseContext context;

        public PublishersRepository(DataBaseContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public List<Publisher> GetAll()
        {
            return context.Publishers.ToList();
        }

        public Publisher FindById(int Id)
        {
            return context.Publishers.SingleOrDefault(x => x.Id == Id);
        }

        public void Insert(Publisher publisher)
        {
            context.Publishers.Add(publisher);
            context.SaveChanges();
        }

        public void Update(Publisher publisher)
        {
            context.Set<Publisher>().Update(publisher);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Publisher publisher = context.Publishers.Find(Id);
            context.Publishers.Remove(publisher);

            context.SaveChanges();
        }
    }
}
