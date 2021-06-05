using Application.Models.Matches.Queries;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Matches
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
        public async Task CanGetMatches()
        {
            var matches = await MatchesMethods.AddManyNewMatches(_testFixture);

            var result = await _testFixture.SendAsync(new GetMatchesQuery());

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            foreach (var match in matches)
                Assert.Contains(match.Id, result.Object.Select(x => x.Id));
        }

        [Fact]
        public async Task CanGetMatch()
        {
            var match = (await MatchesMethods.AddNewMatch(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new GetOneMatchQuery(match.Id));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            Assert.Contains(match.Id, result.Object.Select(x => x.Id));
        }

        [Fact]
        public async Task MatchDoesNotExist()
        {
            var error = "No such Match exist!";

            var result = await _testFixture.SendAsync(new GetOneMatchQuery(0));

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
