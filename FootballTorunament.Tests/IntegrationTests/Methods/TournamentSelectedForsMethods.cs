using Application.Models.TournamentSelectedFors.Commands;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTorunament.Tests.IntegrationTests.Methods
{
    public class TournamentSelectedForsMethods
    {
        public static async Task<AnObjectResult<TournamentSelectedFor>> AddNewTournamentSelectedFor(Testing testFixture)
        {
            var team = (await TeamsMethods.AddNewTeamToDB(testFixture)).Object.FirstOrDefault();
            var player = (await PlayersMethods.AddNewPlayerToDB(testFixture, team)).Object.FirstOrDefault();
            var tournament = (await TournamentsMethods.AddTournament(testFixture)).Object.FirstOrDefault();

            TournamentSelectedFor tsf = new()
            {
                Player = player,
                Tournament = tournament,
                IsSelected = false
            };

            return await testFixture.SendAsync(new AddTournamentSelectedForCommand(tsf));
        }

        public static async Task<List<TournamentSelectedFor>> AddManyTournamentSelectedFors(Testing testFixture) => new List<TournamentSelectedFor>()
        {
            (await AddNewTournamentSelectedFor(testFixture)).Object.FirstOrDefault(),
            (await AddNewTournamentSelectedFor(testFixture)).Object.FirstOrDefault(),
            (await AddNewTournamentSelectedFor(testFixture)).Object.FirstOrDefault(),
            (await AddNewTournamentSelectedFor(testFixture)).Object.FirstOrDefault()
        };
    }
}
