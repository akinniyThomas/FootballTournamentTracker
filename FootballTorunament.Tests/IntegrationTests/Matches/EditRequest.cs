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
    public class EditRequest
    {
        private readonly Testing _testFixture;

        public EditRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanEditMatch()
        {
            var match = (await MatchesMethods.AddNewMatch(_testFixture)).Object.FirstOrDefault();

            match.Round = 10;
            match.Played = true;

            var result = await _testFixture.SendAsync(new UpdateMatchCommand(match.Id, match));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            var resultObject = result.Object.FirstOrDefault();
            Assert.Equal(10, resultObject.Round);
            Assert.True(resultObject.Played);
        }
    }
}
