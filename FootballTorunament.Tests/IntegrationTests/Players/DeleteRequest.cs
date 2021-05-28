using Application.Models.Players.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Players
{
    //[Collection(nameof(Testing))]
    public class DeleteRequest:IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public DeleteRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanDeleteSuccessfully()
        {
            var objectResult = await AddRequest.AddNewPlayerToDB(_testFixture);
            var player = objectResult.Object.FirstOrDefault();
            var result = await _testFixture.SendAsync(new DeletePlayerCommand(player.Id));
            Assert.True(result.Succeeded);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
            Assert.Null(result.Object);
        }

        [Fact]
        public async Task PlayerIsNull()
        {
            var result = await _testFixture.SendAsync(new DeletePlayerCommand(376));
            var error = "Player you are trying to delete doesn't exist!";

            Assert.False(result.Succeeded);
            Assert.Contains(error, result.ErrorMessages);
            Assert.Null(result.Object);
        }

        [Fact]
        public async Task PlayerAlreadyDeleted()
        {
            var objectResult = await AddRequest.AddNewPlayerToDB(_testFixture);
            var player = objectResult.Object.FirstOrDefault();
            await _testFixture.SendAsync(new DeletePlayerCommand(player.Id));
            var result = await _testFixture.SendAsync(new DeletePlayerCommand(player.Id));
            var error = "Player you are trying to delete doesn't exist!";

            Assert.False(result.Succeeded);
            Assert.Contains(error, result.ErrorMessages);
            Assert.Null(result.Object);
        }
    }
}
