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
    public class TournamentDA : ITournamentDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public TournamentDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task<AnObjectResult<Tournament>> AddTournament(Tournament tournament, CancellationToken cancellationToken)
        {
            if (tournament.IsNotNull())
            {
                await _tournamentContext.Tournaments.AddAsync(tournament);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<Tournament>.ReturnObjectResult(tournament, true, "");
            }
            else return AnObjectResult<Tournament>.ReturnObjectResult(false, "Tournament is empty!");
        }

        public async Task<AnObjectResult<Tournament>> DeleteTournament(int tournamentId, CancellationToken cancellationToken)
        {
            var tournament = await _tournamentContext.Tournaments.FindAsync(tournamentId);
            if (tournament.IsNotNull())
            {
                _tournamentContext.Tournaments.Remove(tournament);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<Tournament>.ReturnObjectResult(true, "");
            }
            else return AnObjectResult<Tournament>.ReturnObjectResult(false, "No such Tournament Exist!");
        }

        public Task<AnObjectResult<Tournament>> GetAllTournaments() => Task.FromResult(AnObjectResult<Tournament>.ReturnObjectResult(_tournamentContext.Tournaments.ToList(), true, ""));

        public Task<AnObjectResult<Tournament>> GetOneTournament(int tournamentId)
        {
            var tournament = _tournamentContext.Tournaments.Include(x => x.TournamentRunnerUp).Include(x => x.TournamentWinner).FirstOrDefault(x => x.Id == tournamentId);
            if (tournament.IsNotNull())
                return Task.FromResult(AnObjectResult<Tournament>.ReturnObjectResult(tournament, true, ""));
            return Task.FromResult(AnObjectResult<Tournament>.ReturnObjectResult(false, "No such Tournament Exist!"));
        }

        public async Task<AnObjectResult<Tournament>> UpdateTournament(int tournamentId, Tournament tournament, CancellationToken cancellationToken)
        {
            var tnt = await _tournamentContext.Tournaments.FindAsync(tournamentId);
            if (tnt.IsNotNull() && tournament.IsNotNull())
            {
                if (tnt.Id == tournament.Id)
                {
                    tnt.DateFinished = tournament.DateFinished;
                    tnt.DateStarted = tournament.DateStarted;
                    tnt.MaxPlayersOnField = tournament.MaxPlayersOnField;
                    tnt.MaxTeamSize = tournament.MaxTeamSize;
                    tnt.NumberOfTeamsInTournament = tournament.NumberOfTeamsInTournament;
                    tnt.RegistrationFee = tournament.RegistrationFee;
                    tnt.TournamentName = tournament.TournamentName;
                    tnt.TournamentRunnerUp = await _tournamentContext.Teams.FindAsync(tournament.TournamentRunnerUp?.Id);
                    tnt.TournamentSex = tournament.TournamentSex;
                    tnt.TournamentWinner = await _tournamentContext.Teams.FindAsync(tournament.TournamentWinner?.Id);                    
                    await _tournamentContext.SaveChangesAsync(cancellationToken);
                    return AnObjectResult<Tournament>.ReturnObjectResult(tnt, true, "");
                }
                return AnObjectResult<Tournament>.ReturnObjectResult(false, "The Tournament you are trying to update is wrong");
            }
            return AnObjectResult<Tournament>.ReturnObjectResult(false, "No such tournament exist, Please refresh and try again!");
        }
    }
}
