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
    public class TournamentPositionDA : ITournamentPositionDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public TournamentPositionDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

         public async Task<AnObjectResult<TournamentPosition>> AddTournamentPosition(TournamentPosition tournamentPosition, CancellationToken cancellationToken)
        {
            if (tournamentPosition.IsNotNull())
            {
                tournamentPosition.Team = await _tournamentContext.Teams.FindAsync(tournamentPosition.Team?.Id);
                tournamentPosition.Tournament = await _tournamentContext.Tournaments.FindAsync(tournamentPosition.Tournament?.Id);
                if (tournamentPosition.Team.IsNotNull() && tournamentPosition.Tournament.IsNotNull())
                {
                    await _tournamentContext.TournamentPositions.AddAsync(tournamentPosition);
                    await _tournamentContext.SaveChangesAsync(cancellationToken);
                    return AnObjectResult<TournamentPosition>.ReturnObjectResult(tournamentPosition, true, "");
                }
                return AnObjectResult<TournamentPosition>.ReturnObjectResult(false, "Team or Tournament for the position cannot be empty!");
            }
            return AnObjectResult<TournamentPosition>.ReturnObjectResult(false, "Tournament Position Cannot be empty!");
        }

        public async Task<AnObjectResult<TournamentPosition>> DeleteTournamentPosition(int tournamentPositionId, CancellationToken cancellationToken)
        {
            var tp = await _tournamentContext.TournamentPositions.FindAsync(tournamentPositionId);
            if (tp.IsNotNull())
            {
                _tournamentContext.TournamentPositions.Remove(tp);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<TournamentPosition>.ReturnObjectResult(true, "");
            }
            return AnObjectResult<TournamentPosition>.ReturnObjectResult(false, "Tournament Position Doesn't Exist!");
        }

        public async Task<AnObjectResult<TournamentPosition>> GetTournamentPosition(int tournamentPositionId)
        {
            var tp = await _tournamentContext.TournamentPositions.Include(x => x.Team).Include(x => x.Tournament).FirstOrDefaultAsync(x => x.Id == tournamentPositionId);
            if (tp.IsNotNull())
            {
                return AnObjectResult<TournamentPosition>.ReturnObjectResult(tp, true, "");
            }
            return AnObjectResult<TournamentPosition>.ReturnObjectResult(false, "Tournament Position Doesn't Exist!");
        }

        public async Task<AnObjectResult<TournamentPosition>> GetTournamentPositions() => AnObjectResult<TournamentPosition>.ReturnObjectResult(await _tournamentContext.TournamentPositions.ToListAsync(), true, "");

        public async Task<AnObjectResult<TournamentPosition>> UpdateTounamentPosition(int tournamentPositionId, TournamentPosition tournamentPosition, CancellationToken cancellationToken)
        {
            var tp = await _tournamentContext.TournamentPositions.FindAsync(tournamentPositionId);
            if(tp.IsNotNull() && tournamentPosition.IsNotNull())
            {
                if (tp.Id != tournamentPosition.Id)
                    return AnObjectResult<TournamentPosition>.ReturnObjectResult(false, "Trying to update the wrong Tournament Position!");

                tp.Position = tournamentPosition.Position;
                tp.Team = await _tournamentContext.Teams.FindAsync(tournamentPosition.Team?.Id);
                tp.Tournament = await _tournamentContext.Tournaments.FindAsync(tournamentPosition.Tournament?.Id);
                if(tp.Team.IsNotNull() && tp.Tournament.IsNotNull())
                {
                    await _tournamentContext.SaveChangesAsync(cancellationToken);
                    return AnObjectResult<TournamentPosition>.ReturnObjectResult(tp, true, "");
                }
                return AnObjectResult<TournamentPosition>.ReturnObjectResult(false, "Team or Tournament for the Tournament Position Cannot be empty!");
            }
            return AnObjectResult<TournamentPosition>.ReturnObjectResult(false, "No such Tournament Position Exists!");
        }
    }
}
