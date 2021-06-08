using Application.Models.TeamScores.Queries;
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
    public class FindRequest
    {
        private readonly Testing _testFixture;

        public FindRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanGetTeamScores()
        {
            var scores = await TeamScoresMethods.AddManyTeamScores(_testFixture);

            var result = await _testFixture.SendAsync(new GetTeamScoresQuery());

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            foreach (var score in scores)
                Assert.Contains(score.Id, result.Object.Select(x => x.Id));
        }

        [Fact]
        public async Task CanGetTeamScore()
        {
            var score = await TeamScoresMethods.AddNewTeamScore(_testFixture);
            var result = await _testFixture.SendAsync(new GetOneTeamScoreQuery(score.Object.FirstOrDefault().Id));
            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TeamScoreIsNull()
        {
            var result = await _testFixture.SendAsync(new GetOneTeamScoreQuery(0));
            var error = "No such TeamScore Exists!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
