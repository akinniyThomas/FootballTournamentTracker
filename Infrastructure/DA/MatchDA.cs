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
    public class MatchDA : IMatchDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public MatchDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task<AnObjectResult<Match>> AddMatch(Match match, CancellationToken cancellationToken)
        {
            if (match.IsNotNull())
            {
                match.Tournament = await _tournamentContext.Tournaments.FindAsync(match.Tournament?.Id);
                match.MatchWinner = await _tournamentContext.Teams.FindAsync(match.MatchWinner?.Id);
                await _tournamentContext.Matches.AddAsync(match);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<Match>.ReturnObjectResult(match, true, "");
            }
            return AnObjectResult<Match>.ReturnObjectResult(false, "Match cannot be empty!");
        }

        public async Task<AnObjectResult<Match>> DeleteMatch(int matchId, CancellationToken cancellationToken)
        {
            var match = await _tournamentContext.Matches.FindAsync(matchId);
            if (match.IsNotNull())
            {
                _tournamentContext.Matches.Remove(match);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<Match>.ReturnObjectResult(true, "");
            }
            return AnObjectResult<Match>.ReturnObjectResult(false, "No such Match exist, Please refresh and try again!");
        }

        public async Task<AnObjectResult<Match>> GetMatch(int matchId)
        {
            var match = await _tournamentContext.Matches.Include(x => x.Tournament).Include(x => x.MatchWinner).FirstOrDefaultAsync(x => x.Id == matchId);
            if (match.IsNotNull())
                return AnObjectResult<Match>.ReturnObjectResult(match, true, "");
            return AnObjectResult<Match>.ReturnObjectResult(false, "No such Match exist!");
        }

        public Task<AnObjectResult<Match>> GetMatches() => Task.FromResult(AnObjectResult<Match>.ReturnObjectResult(_tournamentContext.Matches.ToList(), true, ""));

        public async Task<AnObjectResult<Match>> UpdateMatch(int matchId, Match match, CancellationToken cancellationToken)
        {
            var updateMatch = await _tournamentContext.Matches.FindAsync(matchId);
            if(updateMatch.IsNotNull() && match.IsNotNull())
            {
                if (updateMatch.Id == match.Id)
                {
                    updateMatch.Round = match.Round;
                    updateMatch.Played = match.Played;
                    updateMatch.MatchDay = match.MatchDay;
                    updateMatch.MatchWinner = await _tournamentContext.Teams.FindAsync(match.MatchWinner?.Id);
                    updateMatch.Tournament = await _tournamentContext.Tournaments.FindAsync(match.Tournament?.Id);
                    await _tournamentContext.SaveChangesAsync(cancellationToken);
                    return AnObjectResult<Match>.ReturnObjectResult(updateMatch, true, "");
                }
                return AnObjectResult<Match>.ReturnObjectResult(false, "Trying to update wrong Match");
            }
            return AnObjectResult<Match>.ReturnObjectResult(false, "No such Match exists!");
        }
    }
}
