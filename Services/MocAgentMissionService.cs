using AlignAPITest.Logical;
using AlignAPITest.Model;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlignAPITest.Services
{
    public class MocAgentMissionService : BaseAgentMissionService
    {
        private static List<AgentMission> agentData;
        protected static List<AgentMission> AgentData => LazyInitializer.EnsureInitialized(ref agentData, FillData);

        public MocAgentMissionService( IMemoryCache memoryCache) : base(memoryCache)
        {
            
        }


        public override async Task AddAgentMissionAsync(AgentMission agent)
        {
            Coordinate coordinate = await CalcAddress.GetCoordinateByAddressAsync(new Location(agent.Country, agent.Address));
            agent.Lat = coordinate.Lat;
            agent.Lon = coordinate.Lon;
            agent.AgentId = AgentData.OrderByDescending(x => x.AgentId).First().AgentId+1;
             AgentData.Add(agent);
            await base.AddAgentMissionAsync(agent);
        }
        private static List<AgentMission> FillData()
        {
            return new List<AgentMission>
            {
                new AgentMission{AgentId=1,Agent="007",Address="Avenida Vieira Souto 168 Ipanema, Rio de Janeiro",Country="Brazil",Date=DateTime.Now,Lat=-22.98656,Lon=-43.19905},
                new AgentMission{AgentId=2,Agent="005",Address="Rynek Glowny 12, Krakow",Country="Poland",Date=DateTime.Now,Lat=50.06048,Lon=19.93789},
                new AgentMission{AgentId=3,Agent="007",Address="27 Derb Lferrane, Marrakech",Country="Morocco",Date=DateTime.Now,Lat=31.62834,Lon=-7.98339},
                new AgentMission{AgentId=4,Agent="005",Address="Rua Roberto Simonsen 122, Sao Paulo",Country="Brazil",Date=DateTime.Now,Lat=-23.54867,Lon=-46.63193},
                new AgentMission{AgentId=5,Agent="011",Address="swietego Tomasza 35, Krakow",Country="Poland",Date=DateTime.Now,Lat=50.06196,Lon=19.94243},
                new AgentMission{AgentId=6,Agent="003",Address="Rue Al-Aidi Ali Al-Maaroufi, Casablanca",Country="Morocco",Date=DateTime.Now,Lat=33.60165,Lon=-7.6198},
                new AgentMission{AgentId=7,Agent="008",Address="Rua tamoana 418, tefe",Country="Brazil",Date=DateTime.Now,Lat=-3.36077,Lon=-64.72167},
                new AgentMission{AgentId=8,Agent="013",Address="Zlota 9, Lublin",Country="Poland",Date=DateTime.Now,Lat=51.24764,Lon=22.56981},
                new AgentMission{AgentId=9,Agent="002",Address="Riad Sultan 19, Tangier",Country="Morocco",Date=DateTime.Now,Lat=35.78901,Lon=-5.81329},
                new AgentMission{AgentId=10,Agent="009",Address="atlas marina beach, agadir",Country="Morocco",Date=DateTime.Now,Lat=30.42673,Lon=-9.58648},


            };
        }

        protected override async Task<IEnumerable<AgentMission>> AgentMissionsAsync()
        {
            var result = await Task.Run(()=>  AgentData); 
            return result;
        }
    }
}
