using AlignAPITest.Logical;
using AlignAPITest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlignAPITest.Services
{
    public interface IAgentMissionService
    {
        Task   AddAgentMissionAsync(AgentMission agent);
        Task<string> MostIsolatedCountryAsync();
        Task<AgentMission> TheClosestMissionAync(Location location);

    }
}
