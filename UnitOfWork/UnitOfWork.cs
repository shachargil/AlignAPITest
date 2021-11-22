using AlignAPITest.Model;
using AlignAPITest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlignAPITest.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AgentMissionDBContext context;
        public IAgentMissionRepository Agent { get; }
        public UnitOfWork(AgentMissionDBContext agentMissionDBContext,IAgentMissionRepository agentMissionRepository)
        {
            context = agentMissionDBContext;
            Agent = agentMissionRepository;
        }
        public async Task CompleteAsync()
        {
             await context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
