﻿using Application.Interfaces.DA;
using Application.Models.Teams.Queries;
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
    public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsQuery, AnObjectResult<Team>>
    {
        private readonly ITeamDA _team;

        public GetAllTeamsHandler(ITeamDA team)
        {
            _team = team;
        }

        public async Task<AnObjectResult<Team>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken) => await _team.GetAllTeams();
    }
}
