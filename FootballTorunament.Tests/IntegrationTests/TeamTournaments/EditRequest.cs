using Application.Models.TeamTournaments.Commands;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.TeamTournaments
{
    [Collection(nameof(Testing))]
    public class EditRequest
    {
        //private readonly Testing _testFixture;

        //public EditRequest(Testing testFixture)
        //{
        //    _testFixture = testFixture;
        //}

        //[Fact]
        //public async Task CanUpdateTeamTournament()
        //{
        //    var tt = (await TeamTournamentsMethods.AddNewTeamTournament(_testFixture)).Object.FirstOrDefault();
        //    var teamId = tt.TeamId;
        //    var tournamentId = tt.TournamentId;

        //    var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();

        //    var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();

        //    tt.TournamentId = tournament.Id;
        //    tt.Tournament = tournament;
        //    tt.TeamId = team.Id;
        //    tt.Team = team;

        //    var result = await _testFixture.SendAsync(new UpdateTeamTournamentCommand(teamId, tournamentId, tt));

        //    Assert.True(result.Succeeded);
        //    Assert.NotNull(result.Object);
        //    Assert.NotEmpty(result.Object);
        //    Assert.Single(result.Object);
        //    Assert.Equal("", result.ErrorMessages.FirstOrDefault());

        //    var resultObject = result.Object.FirstOrDefault();

        //    Assert.Equal(team.Id, resultObject.TeamId);
        //    Assert.Equal(tournament.Id, resultObject.TournamentId);
        //}
    }
}
