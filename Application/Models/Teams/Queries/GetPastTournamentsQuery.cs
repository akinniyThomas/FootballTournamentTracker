﻿using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Teams.Queries
{
    public record GetPastTournamentsQuery(int TeamId):IRequest<AnObjectResult<TournamentPosition>>;
}