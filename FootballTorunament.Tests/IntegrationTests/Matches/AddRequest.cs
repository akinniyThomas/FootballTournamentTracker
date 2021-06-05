using Application.Models.Matches.Commands;
using Application.Models.Players.Commands;
using Domain.Models;
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
    public class AddRequest
    {
        private readonly Testing _testFixture;

        public AddRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanAddMatch()
        {
            var result = await MatchesMethods.AddNewMatch(_testFixture);

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
            Assert.Single(result.Object);

            Assert.Equal(4, result.Object.FirstOrDefault().Round);
        }
    }
}
