using Application.Models.TournamentPositions.Commands;
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
    public class DeleteRequest
    {
        private readonly Testing _testFixture;

        public DeleteRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanDeleteTournamentPosition()
        {
            var tp = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            var result = await _testFixture.SendAsync(new DeleteTournamentPositionCommand(tp.Id));

            Assert.True(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentPositionIsNull()
        {
            var tp = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            var result = await _testFixture.SendAsync(new DeleteTournamentPositionCommand(0));

            var error = "Tournament Position Doesn't Exist!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
