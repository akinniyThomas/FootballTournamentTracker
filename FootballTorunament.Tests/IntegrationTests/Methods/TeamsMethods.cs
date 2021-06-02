﻿using Application.Models.Teams.Commands;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTorunament.Tests.IntegrationTests.Methods
{
    public static class TeamsMethods
    {
        public static int AddTeamNameCount;

        private static AddTeamCommand AddNewTeamDetails(string teamName) =>
             new AddTeamCommand(new Team()
             {
                 TeamName = teamName
             });



        public async static Task<AnObjectResult<Team>> AddNewTeamToDB(Testing testFixture)
        {
            var team = AddNewTeamDetails($"TeamName - {AddTeamNameCount}");
            AddTeamNameCount++;
            return await testFixture.SendAsync(team);
        }

        public async static Task<List<Team>> AddManyTeamsToDB(Testing testFixture)
        {
            var t1 = (await AddNewTeamToDB(testFixture)).Object.FirstOrDefault();
            var t2 = (await AddNewTeamToDB(testFixture)).Object.FirstOrDefault();
            var t3 = (await AddNewTeamToDB(testFixture)).Object.FirstOrDefault();
            var t4 = (await AddNewTeamToDB(testFixture)).Object.FirstOrDefault();

            return new List<Team>() { t1, t2, t3, t4 };
        }
    }
}
