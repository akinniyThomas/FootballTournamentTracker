using Application.Models.TournamentSelectedFors.Queries;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.TournamentSelected
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
        public async Task GetTournamentSelectedFors()
        {
            var tsfs = await TournamentSelectedForsMethods.AddManyTournamentSelectedFors(_testFixture);

            var result = await _testFixture.SendAsync(new GetTournamentSelectedForsQuery());

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            foreach (var tsf in tsfs)
                Assert.Contains(tsf.Id, result.Object.Select(x => x.Id));
        }

        [Fact]
        public async Task GetOneTournamentSelectedFor()
        {
            var tsf = (await TournamentSelectedForsMethods.AddNewTournamentSelectedFor(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new GetOneTournamentSelectedForQuery(tsf.Id));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            Assert.Contains(tsf.Id, result.Object.Select(x => x.Id));
        }

        [Fact]
        public async Task TournamentSelectedForDoesNotExist()
        {
            var result = await _testFixture.SendAsync(new GetOneTournamentSelectedForQuery(0));

            var error = "No such TournamentSelectedFor Exists!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
