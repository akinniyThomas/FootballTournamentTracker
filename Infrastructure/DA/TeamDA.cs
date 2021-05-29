using Application.Interfaces.DA;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DA
{
    public class TeamDA : ITeamDA
    {
        public Task<AnObjectResult<Team>> AddTeam(Team team, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Team>> DeleteTeam(int teamId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Team>> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Player>> GetCaptain(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Team>> GetOneTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<TournamentPosition>> GetPastTournaments(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Player>> GetPlayersInTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<TeamTournament>> GetPresentTournaments(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Team>> UpdateTeam(int teamId, Team team, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
