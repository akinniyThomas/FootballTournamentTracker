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
    public class PrizeDA : IPrizeDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public PrizeDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task<AnObjectResult<Prize>> AddPrize(Prize prize, CancellationToken cancellationToken)
        {
            if (prize.IsNotNull())
            {
                prize.Tournament = await _tournamentContext.Tournaments.FindAsync(prize.Tournament.Id);
                await _tournamentContext.Prizes.AddAsync(prize);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<Prize>.ReturnObjectResult(prize, true, "");
            }
            return AnObjectResult<Prize>.ReturnObjectResult(false, "Prize cannot be empty");
        }

        public async Task<AnObjectResult<Prize>> DeletePrize(int id, CancellationToken cancellationToken)
        {
            var prize = await _tournamentContext.Prizes.FindAsync(id);
            if (prize.IsNotNull())
            {
                _tournamentContext.Prizes.Remove(prize);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
                return AnObjectResult<Prize>.ReturnObjectResult(true, "");
            }
            return AnObjectResult<Prize>.ReturnObjectResult(false, "No such Prize exists, Please refresh and try again!");
        }

        public async Task<AnObjectResult<Prize>> GetPrize(int id)
        {
            var prize = await _tournamentContext.Prizes.Include(x => x.Tournament).FirstOrDefaultAsync(x => x.Id == id);
            if (prize.IsNotNull())
                return AnObjectResult<Prize>.ReturnObjectResult(prize, true, "");
            return AnObjectResult<Prize>.ReturnObjectResult(false, "No such Prize Exists!");
        }

        public async Task<AnObjectResult<Prize>> GetPrizes() => AnObjectResult<Prize>.ReturnObjectResult(await _tournamentContext.Prizes.ToListAsync(), true, "");

        public async Task<AnObjectResult<Prize>> UpdatePrize(int id, Prize prize, CancellationToken cancellationToken)
        {
            var updatePrize = await _tournamentContext.Prizes.FindAsync(id);
            if(updatePrize.IsNotNull() && prize.IsNotNull())
            {
                if (updatePrize.Id == prize.Id)
                {
                    updatePrize.Postion = prize.Postion;
                    updatePrize.PrizeAmount = prize.PrizeAmount;
                    updatePrize.PrizePercentage = prize.PrizePercentage;
                    updatePrize.Tournament = await _tournamentContext.Tournaments.FindAsync(prize.Id);
                    await _tournamentContext.SaveChangesAsync(cancellationToken);
                    return AnObjectResult<Prize>.ReturnObjectResult(updatePrize, true, "");
                }
                return AnObjectResult<Prize>.ReturnObjectResult(false, "Updating the wrong Prize!");
            }
            return AnObjectResult<Prize>.ReturnObjectResult(false, "No such Prize exists!");
        }
    }
}
