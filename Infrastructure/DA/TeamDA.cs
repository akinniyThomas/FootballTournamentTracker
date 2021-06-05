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

        public async Task<AnObjectResult<Team>> DeleteTeam(int teamId, CancellationToken cancellation)
        {
            var team = await _tournamentContext.Teams.FindAsync(teamId);
            if (team.IsNotNull())
            {
                _tournamentContext.Teams.Remove(team);
                await _tournamentContext.SaveChangesAsync(cancellation);
                return AnObjectResult<Team>.ReturnObjectResult(true, "");
            }
            return AnObjectResult<Team>.ReturnObjectResult(false, "No team such team exist, kindly refresh and try again!");
        }

        public Task<AnObjectResult<Team>> GetAllTeams() => Task.FromResult(AnObjectResult<Team>.ReturnObjectResult(_tournamentContext.Teams.ToList(), true, ""));

        public async Task<AnObjectResult<Team>> GetOneTeam(int teamId)
        {
            var team = await _tournamentContext.Teams.FindAsync(teamId);
            if (team.IsNotNull())
                return AnObjectResult<Team>.ReturnObjectResult(team, true, "");
            return AnObjectResult<Team>.ReturnObjectResult(false, "No Team with given parameter exist! Refresh an try again!!");
        }

        public async Task<AnObjectResult<Team>> UpdateTeam(int teamId, Team team, CancellationToken cancellation)
        {
            var findTeam = await _tournamentContext.Teams.FindAsync(teamId);
            if (findTeam.IsNotNull() && team.IsNotNull())
            {
                if (findTeam.Id == team.Id)
                {
                    findTeam.TeamName = team.TeamName;
                    await _tournamentContext.SaveChangesAsync(cancellation);
                    return AnObjectResult<Team>.ReturnObjectResult(findTeam, true, "");
                }
                return AnObjectResult<Team>.ReturnObjectResult(false, "Trying to update wrong Team");
            }

            return AnObjectResult<Team>.ReturnObjectResult(false, "No Team with given parameter exist! Refresh an try again!!");
        }
    }
}
