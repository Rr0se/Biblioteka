using Marta_M.Entities;
using Marta_M.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Repository.PublisherRepository
{
    public interface IPublishersRepository
    {
        IUnitOfWork UnitOfWork { get; }
        List<Publisher> GetAll();
        Publisher FindById(int Id);
        void Insert(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(int Id);
    }
}
