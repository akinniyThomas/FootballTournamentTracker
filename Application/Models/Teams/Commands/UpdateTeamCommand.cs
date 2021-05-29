using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Teams.Commands
{
    public record UpdateTeamCommand(int TeamId, Team Team):IRequest<AnObjectResult<Team>>;
}
