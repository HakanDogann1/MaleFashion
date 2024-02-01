using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DataAccessLayer.UnitOfWork
{
    public interface IUow
    {
        Task CommitAsync();
        void Commit();
    }
}
