using Application.Interfaces.DA;
using Application.Models.Matches.Queries;
using Application.ViewModels;
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
    public class GetOneMatchHandler : IRequestHandler<GetOneMatchQuery, AnObjectResult<Match>>
    {
        private readonly IMatchDA _matchDA;

        public GetOneMatchHandler(IMatchDA matchDA)
        {
            _matchDA = matchDA;
        }

        public async Task<AnObjectResult<Match>> Handle(GetOneMatchQuery request, CancellationToken cancellationToken) => await _matchDA.GetMatch(request.MatchId);
    }
}
