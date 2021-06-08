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
    public class TeamScoreDA : ITeamScoreDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public TeamScoreDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task<AnObjectResult<TeamScore>> AddTeamScore(TeamScore teamScore, CancellationToken cancellationToken)
        {
            if (teamScore.IsNotNull())
            {
                teamScore.Team = await _tournamentContext.Teams.FindAsync(teamScore.Team?.Id);
                teamScore.Match = await _tournamentContext.Matches.FindAsync(teamScore.Match?.Id);
                if (teamScore.Match.IsNotNull() && teamScore.Team.IsNotNull())
                {
                    await _tournamentContext.TeamsScores.AddAsync(teamScore);
                    await _tournamentContext.SaveChangesAsync(cancellationToken);
                    return AnObjectResult<TeamScore>.ReturnObjectResult(teamScore, true, "");
                }
                return AnObjectResult<TeamScore>.ReturnObjectResult(false, "Either the Team or Match is invalid!");
            }
            return AnObjectResult<TeamScore>.ReturnObjectResult(false, "TeamScore Cannot be empty!");
        }

        public async Task<AnObjectResult<TeamScore>> DeleteTeamScore(int id, CancellationToken cancellationToken)
        {
            var teamScore = await _tournamentContext.TeamsScores.FindAsync(id);
            if (teamScore.IsNotNull())
            {
                _tournamentContext.TeamsScores.Remove(teamScore);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<TeamScore>.ReturnObjectResult(true, "");
            }
            return AnObjectResult<TeamScore>.ReturnObjectResult(false, "No such TeamScore Exists! Please refresh and try again!");
        }

        public async Task<AnObjectResult<TeamScore>> GetTeamScore(int id)
        {
            var teamScore = await _tournamentContext.TeamsScores.Include(x => x.Team).Include(x => x.Match).FirstOrDefaultAsync(x => x.Id == id);
            if (teamScore.IsNotNull())
                return AnObjectResult<TeamScore>.ReturnObjectResult(teamScore, true, "");
            return AnObjectResult<TeamScore>.ReturnObjectResult(false, "No such TeamScore Exists!");
        }

        public async Task<AnObjectResult<TeamScore>> GetTeamScores() => AnObjectResult<TeamScore>.ReturnObjectResult(await _tournamentContext.TeamsScores.ToListAsync(), true, "");

        public async Task<AnObjectResult<TeamScore>> UpdateTeamScore(int id, TeamScore teamScore, CancellationToken cancellationToken)
        {
            var updateTeamScore = await _tournamentContext.TeamsScores.FindAsync(id);
            if(updateTeamScore.IsNotNull() && teamScore.IsNotNull())
            {
                if (updateTeamScore.Id != teamScore.Id)
                    return AnObjectResult<TeamScore>.ReturnObjectResult(false, "Trying to update the wrong TeamScore");
                updateTeamScore.Score = teamScore.Score;
                updateTeamScore.Team = await _tournamentContext.Teams.FindAsync(teamScore.Team?.Id);
                updateTeamScore.Match = await _tournamentContext.Matches.FindAsync(teamScore.Match?.Id);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<TeamScore>.ReturnObjectResult(updateTeamScore, true, "");
            }
            return AnObjectResult<TeamScore>.ReturnObjectResult(false, "No such TeamScore Exists!");
        }
    }
}
