using Application.Interfaces.DA;
using Application.Models.TournamentPositions.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.TournamentPositions.Handler
{
    public class GetTournamentPositionHandler : IRequestHandler<GetTournamentPositionsQuery, AnObjectResult<TournamentPosition>>
    {
        private readonly ITournamentPositionDA _tournamentPosition;

        public GetTournamentPositionHandler(ITournamentPositionDA tournamentPosition)
        {
            _tournamentPosition = tournamentPosition;
        }

        public async Task<AnObjectResult<TournamentPosition>> Handle(GetTournamentPositionsQuery request, CancellationToken cancellationToken) => await _tournamentPosition.GetTournamentPositions();
    }
}
