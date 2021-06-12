using Application.Interfaces.DA;
using Application.Models.TournamentSelectedFors.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.TournamentSelectedFors.Handler
{
    public class GetOneTournamentSelectedForHandler : IRequestHandler<GetOneTournamentSelectedForQuery, AnObjectResult<TournamentSelectedFor>>
    {
        private readonly ITournamentSelectedForDA _tsf;

        public GetOneTournamentSelectedForHandler(ITournamentSelectedForDA tsf)
        {
            _tsf = tsf;
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> Handle(GetOneTournamentSelectedForQuery request, CancellationToken cancellationToken) => await _tsf.GetTournamentSelectedFor(request.TsfId);
    }
}
