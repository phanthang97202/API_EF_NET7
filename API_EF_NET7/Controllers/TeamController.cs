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
        [HttpPatch]
        public async Task<IActionResult> UpdateTeam(Team editTeam)
        {
            try
            {
                int result = await _teamRespository.UpdateTeam(editTeam);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            try
            {
                int rowEffected = await _teamRespository.DeleteTeam(id);
                return Ok(rowEffected);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeam()
        {
            try
            {
                List<Team> teams = await _teamRespository.GetAllTeams();
                return Ok(teams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpGet("TeamId")]
        public async Task<IActionResult> GetByIdTeam(int id)
        {
            try
            {
                Team teams = await _teamRespository.GetTeamById(id);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
