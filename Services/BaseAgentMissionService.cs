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
    public abstract class BaseAgentMissionService : IAgentMissionService
    {
        private static readonly string cacheKey = "AgentMissionKey";
        private readonly IMemoryCache memoryCache;
        public BaseAgentMissionService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        protected abstract Task<IEnumerable<AgentMission>> AgentMissionsAsync();
        public virtual async Task AddAgentMissionAsync(AgentMission agent)
        {
            IEnumerable<AgentMission> mission = await LoadFromCacheAsync();
            List<AgentMission> missionList = mission.ToList();
            missionList.Add(agent);
            SetCache(missionList);
        }
        public virtual async Task<string> MostIsolatedCountryAsync()
        {
            IEnumerable<AgentMission> result = await LoadFromCacheAsync();
            Dictionary<string, string> agentDic = result.GroupBy(x => x.Agent).Where(x => x.Count() == 1).ToDictionary(x => x.Key, x => x.Select(x => x.Country).First());
            IGrouping<string, KeyValuePair<string, string>> mostIsolateCountry = agentDic.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).First();
            return mostIsolateCountry.Key;
        }
        public virtual async Task<AgentMission> TheClosestMissionAync(Location location)
        {
            Coordinate coordinate=await  CalcAddress.GetCoordinateByAddressAsync(location);
            IEnumerable<AgentMission> result = await LoadFromCacheAsync();
            AgentMission mostClosestAgentMission =result.OrderBy(x => CalcAddress.CalcDistance(new Coordinate(x.Lat, x.Lon), coordinate)).First();
            return mostClosestAgentMission;
        }
        private async Task<IEnumerable<AgentMission>> LoadFromCacheAsync()
        {
            IEnumerable<AgentMission> mission;
            if (!memoryCache.TryGetValue(cacheKey,out mission))
            {
                mission = await AgentMissionsAsync();
                SetCache(mission);
            }
            return mission;
        }
        private void SetCache(IEnumerable<AgentMission> mission)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(60)
            };
            memoryCache.Set(cacheKey, mission, cacheExpiryOptions);
        }
    }
}
