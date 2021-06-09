﻿using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.TeamTournaments.Commands
{
    public record UpdateTeamTournamentCommand(int TeamId, int TournamentId, TeamTournament TeamTournament) : IRequest<AnObjectResult<TeamTournament>>;
}