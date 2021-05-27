using Application.Models.Players.Commands;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Players
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
        public async Task CanAddPlayer()
        {
            var userId = await _testFixture.RunAsUserAsync("user123@user.com", "password123P{", "phoneNumber", new string[] { });

            var playerCommand = AddPlayerDetails(12, new DateTime(2008, 11, 23), "Akinniyi Wonderful", Domain.Enums.Sex.Male, userId);

            var player = await _testFixture.SendAsync(playerCommand);
            Assert.NotNull(player);
            Assert.Equal(userId, player.ApplicationUserId);
        }

        [Fact]
        public async Task DontAddIfApplicationUserIdIsMissing()
        {
            var playerCommand =  AddPlayerDetails(12, new DateTime(2008, 11, 23), "Akinniyi Wonderful", Domain.Enums.Sex.Male, null);

            await Assert.ThrowsAsync<DbUpdateException>(async () => await _testFixture.SendAsync(playerCommand));
        }

        [Fact]
        public async Task PasswordNotStrongEnough()
        {
            var userId = await _testFixture.RunAsUserAsync("user123@user.com", "password", "phoneNumber", new string[] { });

            var playerCommand = AddPlayerDetails(12, new DateTime(2008, 11, 23), "Akinniyi Wonderful", Domain.Enums.Sex.Male, userId);

            await Assert.ThrowsAsync<DbUpdateException>(async () => await _testFixture.SendAsync(playerCommand));
        }

        public AddPlayerCommand AddPlayerDetails(int age, DateTime dob, string playerName, Domain.Enums.Sex sex, string appId)
        {
            return new(new Player()
            {
                Age = age,
                DOB = dob,
                PlayerName = playerName,
                PlayerSex = sex,
                ApplicationUserId = appId
            });
        }
    }
}
