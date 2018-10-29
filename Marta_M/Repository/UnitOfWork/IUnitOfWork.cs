using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
