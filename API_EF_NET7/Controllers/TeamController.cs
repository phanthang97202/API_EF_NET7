using API_EF_NET7.Interfaces;
using API_EF_NET7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EF_NET7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRespository _teamRespository;
        public TeamController(ITeamRespository teamRespository)
        {
            this._teamRespository = teamRespository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(Team newTeam)
        {
            try
            {
                Team result = await _teamRespository.AddTeam(newTeam);
                return Ok(newTeam);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
