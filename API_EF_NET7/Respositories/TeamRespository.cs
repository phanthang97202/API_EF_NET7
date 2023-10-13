using API_EF_NET7.Interfaces;
using API_EF_NET7.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
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

        public async Task<int> DeleteTeam(int teamId)
        {
            try
            {
                var rowEffected = await _dbContextTeam.Team.Where(item => item.TeamId == teamId).ExecuteDeleteAsync();
                return rowEffected;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Team>> GetAllTeams()
        {
            try
            {
                var teams = await _dbContextTeam.Team.Select(e => new Team { CountryName = e.CountryName, TeamId = e.TeamId, ConfederationId = e.ConfederationId }).ToListAsync();
                return teams;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Team> GetTeamById(int teamId)
        {
            try
            {
                var team = await _dbContextTeam.Team.SingleOrDefaultAsync(team => team.TeamId == teamId);
                if (team != null)
                {
                    return team;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateTeam(Team team)
        {
            try
            {
                var x = await _dbContextTeam.Team.Where(t => t.TeamId == team.TeamId)
                    .ExecuteUpdateAsync(setter => setter
                    .SetProperty(p => p.CountryName, team.CountryName)
                    .SetProperty(p => p.ConfederationId, team.ConfederationId));
                return x;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
