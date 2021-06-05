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
    public class AddMatchHandler : IRequestHandler<AddMatchCommand, AnObjectResult<Match>>
    {
        private readonly IMatchDA _match;

        public AddMatchHandler(IMatchDA match)
        {
            _match = match;
        }

        public async Task<AnObjectResult<Match>> Handle(AddMatchCommand request, CancellationToken cancellationToken) => await _match.AddMatch(request.Match, cancellationToken);
    }
}
