using Application.Interfaces.DA;
using Application.Models.Tournaments.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.Tournaments.Handler
{
    public class GetOneTournamentHandler : IRequestHandler<GetOneTournamentQuery, AnObjectResult<Tournament>>
    {
        private readonly ITournamentDA _tournament;

        public GetOneTournamentHandler(ITournamentDA tournament)
        {
            _tournament = tournament;
        }

        public async Task<AnObjectResult<Tournament>> Handle(GetOneTournamentQuery request, CancellationToken cancellationToken) => await _tournament.GetOneTournament(request.TournamentId);
    }
}
