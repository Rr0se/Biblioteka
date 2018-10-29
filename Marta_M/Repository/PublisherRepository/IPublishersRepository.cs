using Marta_M.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Repository.PublisherRepository
{
    public interface IPublishersRepository
    {
        List<Publisher> GetAll();
        Publisher FindById(int Id);
        void Insert(Publisher publisher);
        void UpDate(Publisher publisher);
        void Delete(int Id);
    }
}
