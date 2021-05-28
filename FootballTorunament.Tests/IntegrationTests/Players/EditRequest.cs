using Application.Models.Players.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Players
{
    public class EditRequest:IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public EditRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanEditSuccessfully()
        {
            var objectResult = await AddRequest.AddNewPlayerToDB(_testFixture);
            var player = objectResult.Object.FirstOrDefault();

            player.Age = 999;

            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(player.Id, player));

            Assert.True(result.Succeeded);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal(999, result.Object.FirstOrDefault().Age);
        }

        [Fact]
        public async Task PlayerIsNull()
        {
            var objectResult = await AddRequest.AddNewPlayerToDB(_testFixture);
            var player = objectResult.Object.FirstOrDefault();

            player.Age = 999;

            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(player.Id, null));
            var error = "Player to be updated is empty!";

            Assert.False(result.Succeeded);
            Assert.Contains(error, result.ErrorMessages);
            Assert.Null(result.Object);
        }

        [Fact]
        public async Task PlayerIdIsWrong()
        {
            var objectResult = await AddRequest.AddNewPlayerToDB(_testFixture);
            var player = objectResult.Object.FirstOrDefault();

            player.Age = 999;

            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(-1, player));
            var error = "Player to be updated is not correct!";

            Assert.False(result.Succeeded);
            Assert.Contains(error, result.ErrorMessages);
            Assert.Null(result.Object);
        }

        [Fact]
        public async Task PlayerIdIsForDifferentPlayer()
        {
            var objectResult = await AddRequest.AddNewPlayerToDB(_testFixture);

            var player = objectResult.Object.FirstOrDefault();
            var playerId = (await AddRequest.AddNewPlayerToDB(_testFixture)).Object.FirstOrDefault().Id;

            player.Age = 999;

            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(playerId, player));
            var error = "Trying to update the wrong player, please check again and try afterwards!";

            Assert.False(result.Succeeded);
            Assert.Contains(error, result.ErrorMessages);
            Assert.Null(result.Object);
        }
    }
}
