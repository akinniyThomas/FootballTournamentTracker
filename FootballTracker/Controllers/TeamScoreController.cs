using Application.Models.TeamScores.Commands;
using Application.Models.TeamScores.Queries;
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
    public class TeamScoreController:ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamScoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<AnObjectResult<TeamScore>> GetTeamScores() => await _mediator.Send(new GetTeamScoresQuery());

        [HttpGet("{id}")]
        public async Task<AnObjectResult<TeamScore>> GetTeamScore(int id) => await _mediator.Send(new GetOneTeamScoreQuery(id));

        [HttpPost]
        public async Task<AnObjectResult<TeamScore>> AddTeamScore(TeamScore teamScore) => await _mediator.Send(new AddTeamScoreCommand(teamScore));

        [HttpPut("{id}")]
        public async Task<AnObjectResult<TeamScore>> UpdateTeamScore(int id, TeamScore teamScore) => await _mediator.Send(new UpdateTeamScoreCommand(id, teamScore));

        [HttpDelete("{id}")]
        public async Task<AnObjectResult<TeamScore>> DeleteTeamScore(int id) => await _mediator.Send(new DeleteTeamScoreCommand(id));
    }
}
