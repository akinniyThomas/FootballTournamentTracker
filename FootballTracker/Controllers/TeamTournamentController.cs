using Application.Models.TeamTournaments.Commands;
using Application.Models.TeamTournaments.Queries;
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
    public class TeamTournamentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamTournamentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<AnObjectResult<TeamTournament>> GetTeamTournaments() => await _mediator.Send(new GetTeamTournamentsQuery());

        [HttpGet("{teamId}/{tournamentId}")]
        public async Task<AnObjectResult<TeamTournament>> GetOneTeamTournament(int teamId, int tournamentId) => await _mediator.Send(new GetOneTeamTournamentQuery(teamId, tournamentId));

        [HttpPost]
        public async Task<AnObjectResult<TeamTournament>> AddTeamTournament(int teamId, int tournamentId) => await _mediator.Send(new AddTeamTournamentCommand(teamId, tournamentId));

        [HttpDelete("{teamId}/{tournamentId}")]
        public async Task<AnObjectResult<TeamTournament>> DeleteTeamTournament(int teamId, int tournamentId) => await _mediator.Send(new DeleteTeamTournamentCommand(teamId, tournamentId));
    }
}
