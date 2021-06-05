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
    public class GetMatchesHandler : IRequestHandler<GetMatchesQuery, AnObjectResult<Match>>
    {
        private readonly IMatchDA _match;

        public GetMatchesHandler(IMatchDA match)
        {
            _match = match;
        }

        public async Task<AnObjectResult<Match>> Handle(GetMatchesQuery request, CancellationToken cancellationToken) => await _match.GetMatches();
    }
}
