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
    public class MatchDA : IMatchDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public MatchDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public Task<AnObjectResult<Match>> AddMatch(Match match, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Match>> DeleteMatch(int matchId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Match>> GetMatch(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Match>> GetMatches()
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Match>> UpdateMatch(int matchId, Match match, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
