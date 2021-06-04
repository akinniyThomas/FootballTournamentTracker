using Application.Models.Tournaments.Queries;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Tournaments
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
        public async Task CanGetAllTournaments()
        {
            var tournaments = await TournamentsMethods.AddManyTournaments(_testFixture);

            var result = await _testFixture.SendAsync(new GetAllTournamentsQuery());

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.LastOrDefault());

            var resultObject = result.Object;

            foreach (var tournament in tournaments)
                Assert.Contains(tournament.Id, resultObject.Select(x => x.Id));
        }

        [Fact]
        public async Task CanGetOneTournament()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new GetOneTournamentQuery(tournament.Id));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.LastOrDefault());

            var resultObject = result.Object;
            Assert.Contains(tournament.Id, resultObject.Select(c => c.Id));
        }
    }
}
