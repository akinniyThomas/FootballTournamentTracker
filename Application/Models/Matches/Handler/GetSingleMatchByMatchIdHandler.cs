using Application.Interfaces.DA;
using Application.Models.Matches.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.Matches.Handler
{
    public class GetSingleMatchByMatchIdHandler : IRequestHandler<GetSingleMatchByMatchIdQuery, Match>
    {
        private readonly IMatchDA _matchDA;

        public GetSingleMatchByMatchIdHandler(IMatchDA matchDA)
        {
            _matchDA = matchDA;
        }

        public Task<Match> Handle(GetSingleMatchByMatchIdQuery request, CancellationToken cancellationToken)
        {
            return _matchDA.GetMatch(request.MatchId);
        }
    }
}
