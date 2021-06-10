using Application.Models.TournamentPositions.Commands;
using Application.Models.TournamentPositions.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentPositionController:ControllerBase
    {
        private readonly IMediator _mediator;

        public TournamentPositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<AnObjectResult<TournamentPosition>> GetTournamentPositions() => await _mediator.Send(new GetTournamentPositionsQuery());

        [HttpGet("{id}")]
        public async Task<AnObjectResult<TournamentPosition>> GetTournamentPosition(int id) => await _mediator.Send(new GetOneTournamentPositionQuery(id));

        [HttpPost]
        public async Task<AnObjectResult<TournamentPosition>> AddTournamentPosition(TournamentPosition tournamentPosition) => await _mediator.Send(new AddTournamentPositionCommand(tournamentPosition));

        [HttpPut("{id}")]
        public async Task<AnObjectResult<TournamentPosition>> UpdateTournamentPosition(int id, TournamentPosition tournamentPosition) => await _mediator.Send(new UpdateTournamentPositionCommand(id, tournamentPosition));

        [HttpDelete("{id}")]
        public async Task<AnObjectResult<TournamentPosition>> DeleteTournamentPosition(int id) => await _mediator.Send(new DeleteTournamentPositionCommand(id));
    }
}
