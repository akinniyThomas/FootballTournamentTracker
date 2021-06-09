using Application.Extensions;
using Application.Interfaces.Context;
using Application.Interfaces.DA;
using Application.ViewModels;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DA
{
    public class TeamTournamentDA : ITeamTournamentDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public TeamTournamentDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task<AnObjectResult<TeamTournament>> AddTeamTournament(int teamId, int tournamentId, CancellationToken cancellationToken)
        {
            var team = await _tournamentContext.Teams.FindAsync(teamId);
            var tournament = await _tournamentContext.Tournaments.FindAsync(tournamentId);
            if (team.IsNotNull() && tournament.IsNotNull())
            {
                TeamTournament tt = new()
                {
                    Team = team,
                    TeamId = team.Id,
                    Tournament = tournament,
                    TournamentId = tournament.Id
                };
                await _tournamentContext.TeamsTournaments.AddAsync(tt);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<TeamTournament>.ReturnObjectResult(tt, true, "");
            }
            return AnObjectResult<TeamTournament>.ReturnObjectResult(false, "Team or Tournament Doesn't Exists!");
        }

        public async Task<AnObjectResult<TeamTournament>> DeleteTeamTournament(int teamId, int tournamentId, CancellationToken cancellationToken)
        {
            var tt = _tournamentContext.TeamsTournaments.Where(x => x.TeamId == teamId).Where(x => x.TournamentId == tournamentId).FirstOrDefault();
            if (tt.IsNotNull())
            {
                _tournamentContext.TeamsTournaments.Remove(tt);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<TeamTournament>.ReturnObjectResult(true, "");
            }
            return AnObjectResult<TeamTournament>.ReturnObjectResult(false, "TeamTournament Doesn't Exist!");
        }

        public async Task<AnObjectResult<TeamTournament>> GetTeamTournament(int teamId, int tournamentId)
        {
            var tt = await _tournamentContext.TeamsTournaments.Include(x => x.Team).Include(x => x.Tournament).Where(x => x.TeamId == teamId).Where(x => x.TournamentId == tournamentId).FirstOrDefaultAsync();
            if (tt.IsNotNull())
                return AnObjectResult<TeamTournament>.ReturnObjectResult(tt, true, "");
            return AnObjectResult<TeamTournament>.ReturnObjectResult(false, "No such TeamTournament Exists!");
        }

        public async Task<AnObjectResult<TeamTournament>> GetTeamTournaments() => AnObjectResult<TeamTournament>.ReturnObjectResult(await _tournamentContext.TeamsTournaments.ToListAsync(), true, "");
    }
}
