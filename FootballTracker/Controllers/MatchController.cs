using Application.Models.Matches.Commands;
using Application.Models.Matches.Queries;
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
    public class MatchController:ControllerBase
    {
        private readonly IMediator _mediator;

        public MatchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<AnObjectResult<Match>> GetMatches() => await _mediator.Send(new GetMatchesQuery());

        [HttpGet("{id}")]
        public async Task<AnObjectResult<Match>> GetMatch(int id) => await _mediator.Send(new GetOneMatchQuery(id));

        [HttpPost]
        public async Task<AnObjectResult<Match>> AddMatch(Match match) => await _mediator.Send(new AddMatchCommand(match));

        [HttpPut("{id}")]
        public async Task<AnObjectResult<Match>> UpdateMatch(int id, Match match) => await _mediator.Send(new UpdateMatchCommand(id, match));

        [HttpDelete("{id}")]
        public async Task<AnObjectResult<Match>> DeleteMatch(int id) => await _mediator.Send(new DeleteMatchCommand(id));
    }
}
