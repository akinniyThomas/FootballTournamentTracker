using Application.Models.TeamTournaments.Commands;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTorunament.Tests.IntegrationTests.Methods
{
    public class TeamTournamentsMethods
    {
        public async static Task<AnObjectResult<TeamTournament>> AddNewTeamTournament(Testing testFixture)
        {
            var team = (await TeamsMethods.AddNewTeamToDB(testFixture)).Object.FirstOrDefault();
            var tournament = (await TournamentsMethods.AddTournament(testFixture)).Object.FirstOrDefault();

            return await testFixture.SendAsync(new AddTeamTournamentCommand(team.Id, tournament.Id));
        }

        public static async Task<List<TeamTournament>> AddManyTeamTournaments(Testing testFixture) => new List<TeamTournament>()
        {
            (await AddNewTeamTournament(testFixture)).Object.FirstOrDefault(),
            (await AddNewTeamTournament(testFixture)).Object.FirstOrDefault(),
            (await AddNewTeamTournament(testFixture)).Object.FirstOrDefault(),
            (await AddNewTeamTournament(testFixture)).Object.FirstOrDefault()
        };
    }
}
