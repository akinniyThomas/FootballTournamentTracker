using Application.Models.TeamTournaments.Commands;
using Domain.Models;
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
    public class AddRequest
    {
        private readonly Testing _testFixture;

        public AddRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanAddTeamTournaments()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new AddTeamTournamentCommand(team.Id, tournament.Id));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TeamTournamentIsNull()
        {
            var result = await _testFixture.SendAsync(new AddTeamTournamentCommand(0, 0));
            var error = "Team or Tournament Doesn't Exists!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
