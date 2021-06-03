using Application.Models.Players.Commands;
using Application.Models.Players.Queries;
using Application.ViewModels;
using Domain.Models;
using FootballTracker.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController:ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<AnObjectResult<Player>> AddPlayer(UserPlayerViewModel request) => await _mediator.Send(new AddPlayerCommand(request.Player, request.User, request.TeamId));

        [HttpDelete("id")]
        public async Task<AnObjectResult<Player>> DeletePlayer(int id) => await _mediator.Send(new DeletePlayerCommand(id));

        [HttpGet]
        public async Task<AnObjectResult<Player>> GetAllPlayers() { 
            var result = await _mediator.Send(new GetAllPlayersQuery());
            return result;
        }


        [HttpGet("id")]
        public async Task<AnObjectResult<Player>> GetOnePlayer(int id) => await _mediator.Send(new GetPlayerByIdQuery(id));

        [HttpPut("id")]
        public async Task<AnObjectResult<Player>> EditPlayer(int id, Player player) => await _mediator.Send(new UpdatePlayerCommand(id, player));

        [HttpGet]
        [Route("{id}/tournaments")]
        public async Task<AnObjectResult<TournamentSelectedFor>> GetTournamentsSelectedFor(int id) => await _mediator.Send(new GetAllTournamentSelectedForQuery(id));

        [HttpGet]
        [Route("{playerId}/tournaments/{tournamentId}")]
        public async Task<AnObjectResult<TournamentSelectedFor>> GetSingleTournamentSelectedFor(int playerId, int tournamentId) => await _mediator.Send(new GetOneTournamentSelectedForQuery(playerId, tournamentId));
    }
}
