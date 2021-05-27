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
    public class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdQuery, AnObjectResult<Player>>
    {
        private readonly IPlayerDA _player;

        public GetPlayerByIdHandler(IPlayerDA player)
        {
            _player = player;
        }

        public async Task<AnObjectResult<Player>> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _player.GetPlayer(request.Id);
        }
    }
}
