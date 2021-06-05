using Application.Models.Prizes.Queries;
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
    public class FindRequest
    {
        private readonly Testing _testFixture;

        public FindRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanGetPrizes()
        {
            var prizes = await PrizesMethods.AddManyPrizes(_testFixture);

            var result = await _testFixture.SendAsync(new GetPrizesQuery());

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            foreach (var prize in prizes)
                Assert.Contains(prize.Id, result.Object.Select(x => x.Id));
        }

        [Fact]
        public async Task CanGetPrize()
        {
            var prize = (await PrizesMethods.AddNewPrize(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new GetOnePrizeQuery(prize.Id));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task PrizeIsNull()
        {
            var result = await _testFixture.SendAsync(new GetOnePrizeQuery(0));

            var error = "No such Prize Exists!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
