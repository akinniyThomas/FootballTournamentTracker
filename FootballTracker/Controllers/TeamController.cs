using Application.Interfaces.Context;
using Application.Models.Teams.Commands;
using Application.Models.Teams.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController:ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<AnObjectResult<Team>> Get() => await _mediator.Send(new GetAllTeamsQuery());

        [HttpGet("{id}")]
        public async Task<AnObjectResult<Team>> GetById(int id) => await _mediator.Send(new GetOneTeamQuery(id));

        [HttpPost]
        public async Task<AnObjectResult<Team>> Post(Team team) => await _mediator.Send(new AddTeamCommand(team));

        [HttpPut("{id}")]
        public async Task<AnObjectResult<Team>> Put(int id, Team team) => await _mediator.Send(new UpdateTeamCommand(id, team));

        [HttpDelete("{id}")]
        public async Task<AnObjectResult<Team>> Delete(int id) => await _mediator.Send(new DeleteTeamCommand(id));
    }
}
