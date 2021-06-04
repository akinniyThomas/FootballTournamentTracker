using Domain.Models;
using Domain.Validations.TournamentValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{
    public class TournamentTeamsMustMatchTeamsAddedTest
    {
        List<TeamTournament> TeamTournaments = new List<TeamTournament>()
        {
            new TeamTournament(){},
            new TeamTournament(){},
            new TeamTournament(){},
            new TeamTournament(){}
        };

        //[Fact]
        //public void TournamentTeamsDoesntMatchTeamsAdded() => Assert.True(CantExceedNumberOfTeamsInTournament.NumberOfTeamsInTournamentDoesNotMatchTeamsInTournament(new Tournament() { TeamsInTournament = TeamTournaments, NumberOfTeamsInTournament = 5 }));

        //[Fact]
        //public void TournamentTeamsMatchTeamsAdded() => Assert.False(CantExceedNumberOfTeamsInTournament.NumberOfTeamsInTournamentDoesNotMatchTeamsInTournament(new Tournament() { TeamsInTournament = TeamTournaments, NumberOfTeamsInTournament = 4 }));

        //[Fact]
        //public void TournamentIsNull() => Assert.False(CantExceedNumberOfTeamsInTournament.NumberOfTeamsInTournamentDoesNotMatchTeamsInTournament(null));
    }
}
