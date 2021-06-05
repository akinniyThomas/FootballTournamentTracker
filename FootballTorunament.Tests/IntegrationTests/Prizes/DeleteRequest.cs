using Application.Models.Prizes.Commands;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Prizes
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
        public async Task CanDelete()
        {
            var prize = (await PrizesMethods.AddNewPrize(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new DeletePrizeCommand(prize.Id));

            Assert.True(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }
    }
}
