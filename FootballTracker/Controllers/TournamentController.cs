using Application.Models.Tournaments.Commands;
using Application.Models.Tournaments.Queries;
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
    public class TournamentController:ControllerBase
    {
        private readonly IMediator _mediator;

        public TournamentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<AnObjectResult<Tournament>> GetTournaments() => await _mediator.Send(new GetAllTournamentsQuery());

        [HttpGet("{id}")]
        public async Task<AnObjectResult<Tournament>> GetOneTournament(int id) => await _mediator.Send(new GetOneTournamentQuery(id));

        [HttpPost]
        public async Task<AnObjectResult<Tournament>> AddTournament(Tournament tournament) => await _mediator.Send(new AddTournamentCommand(tournament));

        [HttpPut("{id}")]
        public async Task<AnObjectResult<Tournament>> UpdateTournament(int id, Tournament tournament) => await _mediator.Send(new UpdateTournamentCommand(id, tournament));

        [HttpDelete("{id}")]
        public async Task<AnObjectResult<Tournament>> DeleteTournament(int id) => await _mediator.Send(new DeleteTournamentCommand(id));
    }
}
