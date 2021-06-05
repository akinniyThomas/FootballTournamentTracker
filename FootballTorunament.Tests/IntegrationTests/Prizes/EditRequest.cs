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
    public class EditRequest
    {
        private readonly Testing _testFixture;

        public EditRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanUpdatePrize()
        {
            var prize = (await PrizesMethods.AddNewPrize(_testFixture)).Object.FirstOrDefault();

            prize.Postion = 3;
            var result = await _testFixture.SendAsync(new UpdatePrizeCommand(prize.Id, prize));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object); 
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            Assert.Equal(3, result.Object.FirstOrDefault().Postion);
        }

        [Fact]
        public async Task PrizeIsNull()
        {
            var prize = (await PrizesMethods.AddNewPrize(_testFixture)).Object.FirstOrDefault();

            prize.Postion = 3;
            var result = await _testFixture.SendAsync(new UpdatePrizeCommand(prize.Id, null));

            var error = "No such Prize exists!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task InvalidIdGiven()
        {
            var prize = (await PrizesMethods.AddNewPrize(_testFixture)).Object.FirstOrDefault();

            prize.Postion = 3;
            var result = await _testFixture.SendAsync(new UpdatePrizeCommand(0, prize));

            var error = "No such Prize exists!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task WrongIdGiven()
        {
            var prize = (await PrizesMethods.AddNewPrize(_testFixture)).Object.FirstOrDefault();
            var anotherPrize = (await PrizesMethods.AddNewPrize(_testFixture)).Object.FirstOrDefault();

            prize.Postion = 3;
            var result = await _testFixture.SendAsync(new UpdatePrizeCommand(prize.Id, anotherPrize));

            var error = "Updating the wrong Prize!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task AmountAndPercentageGiven()
        {
            var prize = (await PrizesMethods.AddNewPrize(_testFixture)).Object.FirstOrDefault();

            prize.Postion = 3;
            prize.PrizeAmount = 3000;
            prize.PrizePercentage = 20;
            var result = await _testFixture.SendAsync(new UpdatePrizeCommand(prize.Id, prize));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            Assert.Equal(3, result.Object.FirstOrDefault().Postion);
        }
    }
}
