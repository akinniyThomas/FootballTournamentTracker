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
    public class PrizeDA : IPrizeDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public PrizeDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public Task<AnObjectResult<Prize>> AddPrize(Prize prize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Prize>> DeletePrize(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Prize>> GetPrize(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Prize>> GetPrizes()
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Prize>> UpdatePrize(int id, Prize prize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
