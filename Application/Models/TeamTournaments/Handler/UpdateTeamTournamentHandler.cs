using Application.Interfaces.DA;
using Application.Models.TeamTournaments.Commands;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.TeamTournaments.Handler
{
    //public class UpdateTeamTournamentHandler : IRequestHandler<UpdateTeamTournamentCommand, AnObjectResult<TeamTournament>>
    //{
    //    private readonly ITeamTournamentDA _teamTournament;

    //    public UpdateTeamTournamentHandler(ITeamTournamentDA teamTournament)
    //    {
    //        _teamTournament = teamTournament;
    //    }

    //    public async Task<AnObjectResult<TeamTournament>> Handle(UpdateTeamTournamentCommand request, CancellationToken cancellationToken) => await _teamTournament.UpdateTeamTournament(request.TeamId, request.TournamentId, request.TeamTournament, cancellationToken);
    //}
}
