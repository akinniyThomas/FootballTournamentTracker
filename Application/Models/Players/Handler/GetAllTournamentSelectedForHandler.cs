using Application.Interfaces.DA;
using Application.Models.Players.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.Players.Handler
{
    public class GetAllTournamentSelectedForHandler : IRequestHandler<GetAllTournamentSelectedForQuery, AnObjectResult<TournamentSelectedFor>>
    {
        private readonly IPlayerDA _player;

        public GetAllTournamentSelectedForHandler(IPlayerDA player)
        {
            _player = player;
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> Handle(GetAllTournamentSelectedForQuery request, CancellationToken cancellationToken)
        {
            return await _player.GetAllTournamentSelectedFor(request.PlayerId);
        }
    }
}
