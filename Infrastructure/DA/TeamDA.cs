using Application.Extensions;
using Application.Interfaces.Context;
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
        private readonly ITournamentDbContext _tournamentContext;

        public TeamDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task<AnObjectResult<Team>> AddTeam(Team team, CancellationToken cancellation)
        {
            if (team.IsNotNull())
            {
                await _tournamentContext.Teams.AddAsync(team);
                await _tournamentContext.SaveChangesAsync(cancellation);
                return AnObjectResult<Team>.ReturnObjectResult(team, true, "");
            }
            else return AnObjectResult<Team>.ReturnObjectResult(false, "The Team is given!");
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
