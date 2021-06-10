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
    public class GetOneTournamentPositionHandler : IRequestHandler<GetOneTournamentPositionQuery, AnObjectResult<TournamentPosition>>
    {
        private readonly ITournamentPositionDA _tournamentPosition;

        public GetOneTournamentPositionHandler(ITournamentPositionDA tournamentPosition)
        {
            _tournamentPosition = tournamentPosition;
        }

        public async Task<AnObjectResult<TournamentPosition>> Handle(GetOneTournamentPositionQuery request, CancellationToken cancellationToken) => await _tournamentPosition.GetTournamentPosition(request.TournamentPositionQueryId);
    }
}
