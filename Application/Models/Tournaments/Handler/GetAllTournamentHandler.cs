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
    public class GetAllTournamentHandler : IRequestHandler<GetAllTournamentsQuery, AnObjectResult<Tournament>>
    {
        private readonly ITournamentDA _tournament;

        public GetAllTournamentHandler(ITournamentDA tournament)
        {
            _tournament = tournament;
        }

        public Task<AnObjectResult<Tournament>> Handle(GetAllTournamentsQuery request, CancellationToken cancellationToken) => _tournament.GetAllTournaments();
    }
}
