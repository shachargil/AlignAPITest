using AlignAPITest.Logical;
using AlignAPITest.Model;
using AlignAPITest.UnitOfWork;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlignAPITest.Services
{
    public class AgentMissionService : BaseAgentMissionService
    {
        private IUnitOfWork unitOfWork;

        public AgentMissionService(IUnitOfWork unitOfWork,IMemoryCache memoryCache):base(memoryCache)
        {
            this.unitOfWork = unitOfWork;
        }
        public override async Task AddAgentMissionAsync(AgentMission agent)
        {
            Coordinate coordinate = await CalcAddress.GetCoordinateByAddressAsync(new Location(agent.Country, agent.Address));
            agent.Lat = coordinate.Lat;
            agent.Lon = coordinate.Lon;
            await unitOfWork.Agent.AddAsync(agent);
            await unitOfWork.CompleteAsync();
            await base.AddAgentMissionAsync(agent);
        }

        protected override async Task<IEnumerable<AgentMission>> AgentMissionsAsync()
        {
            var result= await unitOfWork.Agent.GetAllAsync();
            return result;
        }
    }
}
