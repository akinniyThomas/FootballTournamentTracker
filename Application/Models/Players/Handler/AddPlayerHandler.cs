using Application.Interfaces.DA;
using Application.Models.Players.Commands;
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
    public class AddPlayerHandler : IRequestHandler<AddPlayerCommand, Player>
    {
        private readonly IPlayerDA _player;

        public AddPlayerHandler(IPlayerDA player)
        {
            _player = player;
        }

        public async Task<Player> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
        {
            return await _player.AddPlayer(request.Player,  cancellationToken);
        }
    }
}
