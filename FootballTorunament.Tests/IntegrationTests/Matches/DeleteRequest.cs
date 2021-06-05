using Application.Models.Matches.Commands;
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
    public class DeleteRequest
    {
        private readonly Testing _testFixture;

        public DeleteRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanDeleteMatch()
        {
            var match = (await MatchesMethods.AddNewMatch(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new DeleteMatchCommand(match.Id));

            Assert.True(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }
    }
}
