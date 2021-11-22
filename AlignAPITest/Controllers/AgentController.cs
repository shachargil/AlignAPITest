using AlignAPITest.Logical;
using AlignAPITest.Model;
using AlignAPITest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AlignAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private IAgentMissionService agentMissionService;
        public AgentController(IAgentMissionService agentMissionService)
        {
            this.agentMissionService = agentMissionService;
        }
        [HttpPost]
        [Route("Mission")]
        public async Task<IActionResult> Mission(AgentMission agentMission)
        {
           await agentMissionService.AddAgentMissionAsync(agentMission);
            return Ok("The operation was successful");
        }
        [HttpGet]
        [Route("CountriesByIsolation")]
        public async Task<IActionResult> CountriesByIsolation()
        {
           var result= await agentMissionService.MostIsolatedCountryAsync();
            return Ok($"The most isolated country: {result}");
        }
        [HttpPost]
        [Route("FindClosest")]
        public async Task<IActionResult> FindClosest(Location location)
        {
            if (location == null || string.IsNullOrWhiteSpace(location.Address) || string.IsNullOrWhiteSpace(location.Country))
                return BadRequest("Bad location");
            return Ok($"The closest mission:  {await agentMissionService.TheClosestMissionAync(location)}");

        }
        
    }
}
