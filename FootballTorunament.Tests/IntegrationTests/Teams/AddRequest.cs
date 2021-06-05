using Application.Models.Players.Queries;
using Application.Models.Teams.Commands;
using Domain.Models;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Teams
{
    [Collection(nameof(Testing))]
    public class AddRequest//:IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public AddRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanAddTeam()
        {
            var team = await TeamsMethods.AddNewTeamToDB(_testFixture);
            var teamObject = team.Object.FirstOrDefault();

            Assert.NotNull(team);
            Assert.NotNull(team.Object);
            Assert.NotEmpty(team.Object);
            Assert.Single(team.Object);

            Assert.True(team.Succeeded);

            Assert.Equal("", team.ErrorMessages.FirstOrDefault());

            Assert.Matches("TeamName", teamObject.TeamName);
        }

        [Fact]
        public async Task TeamIsNull()
        {
            var error = "The Team is given!";

            var team = await _testFixture.SendAsync(new AddTeamCommand(null));

            Assert.NotNull(team);
            Assert.Null(team.Object);

            Assert.False(team.Succeeded);

            Assert.Equal(error, team.ErrorMessages.FirstOrDefault());
        }
    }
}
