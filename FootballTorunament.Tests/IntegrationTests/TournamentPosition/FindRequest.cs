using Application.Models.TournamentPositions.Queries;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.TournamentPositions
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
        public async Task CanGetTournamentPositions()
        {
            var tps = await TournamentPostionsMethods.AddManyTournamentPosition(_testFixture);
            var result = await _testFixture.SendAsync(new GetTournamentPositionsQuery());

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            foreach (var tp in tps)
                Assert.Contains(tp.Id, result.Object.Select(x => x.Id));
        }

        [Fact]
        public async Task CanGetOneTournamentPosition()
        {
            var tp = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            var result = await _testFixture.SendAsync(new GetOneTournamentPositionQuery(tp.Id));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            Assert.Equal(tp.Id, result.Object.FirstOrDefault().Id);
        }

        [Fact]
        public async Task TournamentPositionDoesNotExist()
        {
            var tp = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            var result = await _testFixture.SendAsync(new GetOneTournamentPositionQuery(0));

            var error = "Tournament Position Doesn't Exist!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
