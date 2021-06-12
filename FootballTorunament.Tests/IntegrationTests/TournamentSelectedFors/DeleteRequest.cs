using Application.Models.TournamentSelectedFors.Commands;
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
    public class DeleteRequest
    {
        private readonly Testing _testFixture;

        public DeleteRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanDeleteTournamentSelectedFor()
        {
            var tsf = (await TournamentSelectedForsMethods.AddNewTournamentSelectedFor(_testFixture)).Object.FirstOrDefault();
            var result = await _testFixture.SendAsync(new DeleteTournamentSelectedForCommand(tsf.Id));

            Assert.True(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentSelectedForIdIsWrong()
        {
            var result = await _testFixture.SendAsync(new DeleteTournamentSelectedForCommand(0));

            var error = "TournamentSelectedFor Cannot be null!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
