using AlignAPITest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlignAPITest.Repository
{
    public class AgentMissionRepository : IAgentMissionRepository
    {
        private readonly AgentMissionDBContext context;
        public AgentMissionRepository(AgentMissionDBContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(AgentMission entity)
        {
            await context.AgentMission.AddAsync(entity);
            
        }

        public async Task DeleteAsync(long id)
        {
            var agentMission = await context.AgentMission.FindAsync(id);
            context.AgentMission.Remove(agentMission);
            
        }

        public async Task<AgentMission> GetAsync(long id)
        {
            return await context.AgentMission.FindAsync(id);
        }

        public async Task<IEnumerable<AgentMission>> GetAllAsync()
        {
            return await context.AgentMission.ToListAsync();
        }

        public async Task UpdateAsync(AgentMission entity)
        {
            var agentMission = await context.AgentMission.FindAsync(entity);
            context.Entry(agentMission).CurrentValues.SetValues(entity);
            
        }
    }
}
