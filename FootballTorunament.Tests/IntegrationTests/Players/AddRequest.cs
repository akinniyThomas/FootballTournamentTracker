using Application.Models.Players.Commands;
using Application.ViewModels;
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
    //[Collection(nameof(Testing))]
    public class AddRequest:IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public AddRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanAddPlayer()
        {
            var objectResult = await AddNewPlayerToDB(_testFixture);
            var playerObject = objectResult.Object;

            Assert.True(objectResult.Succeeded);
            Assert.NotNull(playerObject?.FirstOrDefault());
            Assert.Single(playerObject);
        }

        [Fact]
        public async Task UserIsNotGiven()
        {
            var playerCommand =  AddPlayerDetails(12, new DateTime(2008, 11, 23), "Akinniyi Wonderful", Domain.Enums.Sex.Male, null);

            var objectResult = await _testFixture.SendAsync(playerCommand);
            
            var error = "No user detail is given";

            Assert.False(objectResult.Succeeded);
            Assert.Equal(error, objectResult.ErrorMessages.FirstOrDefault());
            Assert.Null(objectResult.Object);
        }

        [Fact]
        public async Task PlayerIsNotGiven()
        {
            var password = "password123P{";
            var user = _testFixture.CreateUserModel("user123@user.com", "user123@user.com", password, password, "phoneNumber");

            var playerCommand = new AddPlayerCommand(null, user);

            var objectResult = await _testFixture.SendAsync(playerCommand);

            var error = "No player detail is given";

            Assert.False(objectResult.Succeeded);
            Assert.Equal(error, objectResult.ErrorMessages.FirstOrDefault());
            Assert.Null(objectResult.Object);
        }

        [Fact]
        public async Task PlayerAndUserIsNotGiven()
        { 
            var playerCommand = new AddPlayerCommand(null, null);

            var objectResult = await _testFixture.SendAsync(playerCommand);

            var error = "No player detail is given";

            Assert.False(objectResult.Succeeded);
            Assert.Equal(error, objectResult.ErrorMessages.FirstOrDefault());
            Assert.Null(objectResult.Object);
        }

        [Theory]
        [InlineData("password")]//, "Could not add User")]
        [InlineData("password1")]//, "Could not add User")]
        [InlineData("password1A")]//, "Could not add User")]
        [InlineData("pA$1")]//, "Could not add User")]
        [InlineData("##########")]//, "Could not add User")]
        [InlineData("password1$")]//, "Could not add User")]
        [InlineData("password32")]//, "Could not add User")]
        public async Task PasswordNotStrongEnough(string password)
        {
            var user = _testFixture.CreateUserModel("user123@user.com", "user123@user.com", password, password, "phoneNumber");
            var error = "Could not add User";
            var playerCommand = AddPlayerDetails(12, new DateTime(2008, 11, 23), "Akinniyi Wonderful", Domain.Enums.Sex.Male, user);

            var objectResult = await _testFixture.SendAsync(playerCommand);

            Assert.False(objectResult.Succeeded);
            Assert.Contains(error, objectResult.ErrorMessages);
            Assert.Null(objectResult.Object);
        }

        [Fact]
        public async Task PlayerIsMissing()
        {
            var user = _testFixture.CreateUserModel("user123@user.com", "user123@user.com", "passwordA1@", "passwordA1@", "phoneNumber");

            AddPlayerCommand playerCommand = new(null, user);

            var objectResult = await _testFixture.SendAsync(playerCommand);

            Assert.False(objectResult.Succeeded);
            Assert.Equal("No player detail is given",objectResult.ErrorMessages.FirstOrDefault());
            Assert.Null(objectResult.Object);
        }

        [Fact]
        public async Task PasswordNotSameAsConfirmPassword()
        {
            var user = _testFixture.CreateUserModel("user123@user.com", "user123@user.com", "password1", "password2", "phoneNumber");
            var error = "Password and Confirm Password are not same!";
            var playerCommand = AddPlayerDetails(12, new DateTime(2008, 11, 23), "Akinniyi Wonderful", Domain.Enums.Sex.Male, user);

            var objectResult = await _testFixture.SendAsync(playerCommand);

            Assert.False(objectResult.Succeeded);
            Assert.Contains(error, objectResult.ErrorMessages);
            Assert.Null(objectResult.Object);
        }

        public static AddPlayerCommand AddPlayerDetails(int age, DateTime dob, string playerName, Domain.Enums.Sex sex, UserViewModel user)
        {
            return new(new Player()
            {
                Age = age,
                DOB = dob,
                PlayerName = playerName,
                PlayerSex = sex
            }, user);
        }

        public async static Task<AnObjectResult<Player>> AddNewPlayerToDB(Testing testFixture)
        {
            var password = "password123P{";
            var user = testFixture.CreateUserModel($"user{Testing.AddCount}@user.com", $"user{Testing.AddCount}@user.com", password, password, $"phoneNumber{Testing.AddCount}");
            Testing.AddCount++;
            var playerCommand = AddPlayerDetails(12, new DateTime(2008, 11, 23), "Akinniyi Wonderful", Domain.Enums.Sex.Male, user);

            return await testFixture.SendAsync(playerCommand);
        }
    }
}
