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
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, List<Player>>
    {
        private readonly IPlayerDA _player;

        public GetAllPlayersHandler(IPlayerDA player)
        {
            _player = player;
        }
        public async Task<List<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            return await _player.GetAllPlayers();
        }
    }
}
