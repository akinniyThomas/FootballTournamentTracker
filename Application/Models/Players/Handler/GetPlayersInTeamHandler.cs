using Application.Interfaces.DA;
using Application.Models.Players.Queries;
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
    public class GetPlayersInTeamHandler : IRequestHandler<GetPlayersInTeamQuery, List<Player>>
    {
        private readonly IPlayerDA _player;

        public GetPlayersInTeamHandler(IPlayerDA player)
        {
            _player = player;
        }

        public Task<List<Player>> Handle(GetPlayersInTeamQuery request, CancellationToken cancellationToken)
        {
            return _player.GetPlayersInTeam(request.TeamId);
        }
    }
}
