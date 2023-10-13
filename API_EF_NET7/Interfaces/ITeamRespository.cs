using API_EF_NET7.Models;

namespace API_EF_NET7.Interfaces
{
    public interface ITeamRespository
    {
        public Task<List<Team>> GetAllTeams();
        public Task<Team> GetTeamById(int teamId);
        public Task<Team> AddTeam(Team team);
        public Task<int> DeleteTeam(int teamId);
        public Task<int> UpdateTeam(Team team);
    }
}
