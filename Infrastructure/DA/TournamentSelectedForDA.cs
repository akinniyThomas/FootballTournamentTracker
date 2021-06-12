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
    public class TournamentSelectedForDA : ITournamentSelectedForDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public TournamentSelectedForDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> AddTournamentSelectedFor(TournamentSelectedFor tsf, CancellationToken cancellationToken)
        {
            if (tsf.IsNotNull())
            {
                tsf.Player = await _tournamentContext.Players.FindAsync(tsf.Player?.Id);
                tsf.Tournament = await _tournamentContext.Tournaments.FindAsync(tsf.Tournament?.Id);
                if(tsf.Player.IsNotNull() && tsf.Tournament.IsNotNull())
                {
                    await _tournamentContext.TournamentsSelectedFor.AddAsync(tsf);
                    await _tournamentContext.SaveChangesAsync(cancellationToken);
                    return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(tsf, true, "");
                }
                return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, "Either Player or Tournament For the TournamentSelectedFor is Empty!");
            }
            return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, "TournamentSelectedFor Cannot be empty!");
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> DeleteTournamentSelectedFor(int tsfId, CancellationToken cancellationToken)
        {
            var tsf = await _tournamentContext.TournamentsSelectedFor.FindAsync(tsfId);
            if (tsf.IsNotNull())
            {
                _tournamentContext.TournamentsSelectedFor.Remove(tsf);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(true, "");
            }
            return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, "TournamentSelectedFor Cannot be null!");
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> GetTournamentSelectedFor(int tsfId)
        {
            var tsf = await _tournamentContext.TournamentsSelectedFor.Include(x => x.Tournament).Include(x => x.Player).FirstOrDefaultAsync(x => x.Id == tsfId);
            if (tsf.IsNotNull())
                return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(tsf, true, "");
            return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, "No such TournamentSelectedFor Exists!");
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> GetTournamentSelectedFors() => AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(await _tournamentContext.TournamentsSelectedFor.ToListAsync(), true, "");

        public async Task<AnObjectResult<TournamentSelectedFor>> UpdateTournamentSelectedFor(int tsfId, TournamentSelectedFor tsf, CancellationToken cancellationToken)
        {
            var updateTsf = await _tournamentContext.TournamentsSelectedFor.FindAsync(tsfId);

            if(updateTsf.IsNotNull() && tsf.IsNotNull())
            {
                if (updateTsf.Id != tsf.Id)
                    return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, "Trying to update the wrong TournamentSelectedFor!");
                updateTsf.IsSelected = tsf.IsSelected;
                updateTsf.Player = await _tournamentContext.Players.FindAsync(tsf.Player?.Id);
                updateTsf.Tournament = await _tournamentContext.Tournaments.FindAsync(tsf.Tournament?.Id);
                if (updateTsf.Tournament.IsNotNull() && updateTsf.Player.IsNotNull())
                {
                    await _tournamentContext.SaveChangesAsync(cancellationToken);
                    return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(updateTsf, true, "");
                }
                return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, "Player or Tournament cannot be null!");
            }
            return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, "No such TournamentSelectedFor Exists!");
        }
    }
}
