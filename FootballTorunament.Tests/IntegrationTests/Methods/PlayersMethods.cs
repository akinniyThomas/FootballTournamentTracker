using Application.Models.Players.Commands;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTorunament.Tests.IntegrationTests.Methods
{
    public static class PlayersMethods
    {
        public static int AddPlayerCount = 0;

        public static AddPlayerCommand AddPlayerDetails(int age, DateTime dob, string playerName, Domain.Enums.Sex sex, UserViewModel user, Team team)
        {
            return new(new Player()
            {
                Age = age,
                DOB = dob,
                PlayerName = playerName,
                PlayerSex = sex,
                Team = team
            }, user);
        }

        public async static Task<AnObjectResult<Player>> AddNewPlayerToDB(Testing testFixture, Team team)
        {
            var password = "password123P{";
            var user = testFixture.CreateUserModel($"user{AddPlayerCount}@user.com", $"user{AddPlayerCount}@user.com", password, password, $"phoneNumber{AddPlayerCount}");
            AddPlayerCount++;
            var playerCommand = AddPlayerDetails(12, new DateTime(2008, 11, 23), $"Player - {AddPlayerCount}", Domain.Enums.Sex.Male, user, team);

            return await testFixture.SendAsync(playerCommand);
        }



        public static async Task<List<Player>> AddManyPlayers(Testing _testFixture, Team team)
        {
            var p1 = (await AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();
            var p2 = (await AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();
            var p3 = (await AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();
            var p4 = (await AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();
            return new List<Player>() { p1, p2, p3, p4 };
        }
    }
}
