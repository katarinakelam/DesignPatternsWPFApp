using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDAL.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        bool Commit();
        void Rollback();
        bool IsTransactionOpen { get; }
    }
}
