using Application.Interfaces.DA;
using Application.Models.Matches.Commands;
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
    public class UpdateMatchHandler : IRequestHandler<UpdateMatchCommand, AnObjectResult<Match>>
    {
        private readonly IMatchDA _match;

        public UpdateMatchHandler(IMatchDA match)
        {
            _match = match;
        }

        public async Task<AnObjectResult<Match>> Handle(UpdateMatchCommand request, CancellationToken cancellationToken) => await _match.UpdateMatch(request.MatchId, request.Match, cancellationToken);
    }
}
