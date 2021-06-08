using Application.Models.TeamScores.Commands;
using Domain.Models;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.TeamScores
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
        public async Task CanAddTeamScore()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var match = (await MatchesMethods.AddNewMatch(_testFixture)).Object.FirstOrDefault();
            TeamScore score = new()
            {
                Score = 30,
                Team = team,
                Match = match
            };

            var result = await _testFixture.SendAsync(new AddTeamScoreCommand(score));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TeamIsNull()
        {
            var match = (await MatchesMethods.AddNewMatch(_testFixture)).Object.FirstOrDefault();
            TeamScore score = new()
            {
                Score = 30,
                Team = null,
                Match = match
            };

            var result = await _testFixture.SendAsync(new AddTeamScoreCommand(score));
            var error = "Either the Team or Match is invalid!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task MatchIsNull()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            TeamScore score = new()
            {
                Score = 30,
                Team = team,
                Match = null
            };

            var result = await _testFixture.SendAsync(new AddTeamScoreCommand(score));

            var error = "Either the Team or Match is invalid!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TeamScoreIsNull()
        {
            var result = await _testFixture.SendAsync(new AddTeamScoreCommand(null));

            var error = "TeamScore Cannot be empty!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
