using Application.Models.TeamScores.Commands;
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
    public class DeleteRequest
    {
        private readonly Testing _testFixture;

        public DeleteRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanDeleteTeamScore()
        {
            var teamScore = (await TeamScoresMethods.AddNewTeamScore(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new DeleteTeamScoreCommand(teamScore.Id));

            Assert.True(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TeamScoreIsNull()
        {
            var result = await _testFixture.SendAsync(new DeleteTeamScoreCommand(0));
            var error = "No such TeamScore Exists! Please refresh and try again!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
