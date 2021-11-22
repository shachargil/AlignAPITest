using AlignAPITest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlignAPITest.UnitOfWork
{
   public interface IUnitOfWork
    {
        IAgentMissionRepository Agent { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
