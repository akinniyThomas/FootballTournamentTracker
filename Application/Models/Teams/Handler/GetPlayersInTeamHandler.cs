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

namespace Application.Models.Teams.Handler
{
    public class GetPlayersInTeamHandler : IRequestHandler<GetPlayersInTeamQuery, AnObjectResult<Player>>
    {
        private readonly IPlayerDA _player;

        public GetPlayersInTeamHandler(IPlayerDA player)
        {
            _player = player;
        }

        //public Task<AnObjectResult<Player>> Handle(GetPlayersInTeamQuery request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<AnObjectResult<Player>> Handle(GetPlayersInTeamQuery request, CancellationToken cancellationToken) => await _player.GetPlayersInTeam(request.TeamId);
    }
}
