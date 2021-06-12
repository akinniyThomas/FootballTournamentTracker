using Application.Models.TournamentSelectedFors.Commands;
using Application.Models.TournamentSelectedFors.Queries;
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
    public class TournamentSelectedForController:ControllerBase
    {
        private readonly IMediator _mediator;

        public TournamentSelectedForController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<AnObjectResult<TournamentSelectedFor>> GetTournamentSelectedFors() => await _mediator.Send(new GetTournamentSelectedForsQuery());

        [HttpGet("{id}")]
        public async Task<AnObjectResult<TournamentSelectedFor>> GetOneTournamentSelectedFor(int id) => await _mediator.Send(new GetOneTournamentSelectedForQuery(id));

        [HttpPost]
        public async Task<AnObjectResult<TournamentSelectedFor>> AddTournamentSelectedFor(TournamentSelectedFor tsf) => await _mediator.Send(new AddTournamentSelectedForCommand(tsf));

        [HttpPut("{id}")]
        public async Task<AnObjectResult<TournamentSelectedFor>> UpdateTournamentSelectedFor(int id, TournamentSelectedFor tsf) => await _mediator.Send(new UpdateTournamentSelectedForCommand(id, tsf));

        [HttpDelete("{id}")]
        public async Task<AnObjectResult<TournamentSelectedFor>> DeleteTournamentSelectedFor(int id) => await _mediator.Send(new DeleteTournamentSelectedForCommand(id));
    }
}
