using Application.Interfaces.DA;
using Application.Models.Players.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.Players.Handler
{
    public class DeletePlayerHandler : IRequestHandler<DeletePlayerCommand, bool>
    {
        private readonly IPlayerDA _player;

        public DeletePlayerHandler(IPlayerDA player)
        {
            _player = player;
        }

        public Task<bool> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            return _player.DeletePlayer(request.PlayerId, cancellationToken);
        }
    }
}
