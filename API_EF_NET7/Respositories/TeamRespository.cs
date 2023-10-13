using API_EF_NET7.Interfaces;
using API_EF_NET7.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;

namespace API_EF_NET7.Respositories
{
    public class TeamRespository : ITeamRespository
    {
        private readonly WCDbContext _dbContextTeam;
        public TeamRespository(WCDbContext dbContextTeam)
        {
            _dbContextTeam = dbContextTeam;
        }
        public async Task<Team> AddTeam(Team team)
        {
            try
            {

                Team newTeam = new Team() { ConfederationId = team.ConfederationId, CountryName = team.CountryName };

                _dbContextTeam.Team.Add(newTeam);
                await _dbContextTeam.SaveChangesAsync();
                return new Team
                {
                    ConfederationId = newTeam.ConfederationId,
                    CountryName = newTeam.CountryName,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<int> DeleteTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Team>> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetTeamById(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
