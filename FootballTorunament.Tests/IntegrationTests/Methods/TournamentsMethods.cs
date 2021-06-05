using Application.Models.Tournaments.Commands;
using Application.ViewModels;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTorunament.Tests.IntegrationTests.Methods
{
    public class TournamentsMethods
    {
        public static async Task<AnObjectResult<Tournament>> AddTournament(Testing testFixture)
        {
            Tournament tournament = new()
            {
                TournamentName = "Champions League 20/21",
                TournamentSex = Sex.Both,
                NumberOfTeamsInTournament = 4,
                RegistrationFee = 30000,
                MaxTeamSize=12,
                MaxPlayersOnField=5,
                DateStarted=DateTime.Today
            };

            return await testFixture.SendAsync(new AddTournamentCommand(tournament));
        }

        public static async Task<List<Tournament>> AddManyTournaments(Testing testFixture) => new()
        {
            (await AddTournament(testFixture)).Object.FirstOrDefault(),
            (await AddTournament(testFixture)).Object.FirstOrDefault(),
            (await AddTournament(testFixture)).Object.FirstOrDefault(),
            (await AddTournament(testFixture)).Object.FirstOrDefault()
        };

        internal static Task AddTournament(object testFixture)
        {
            throw new NotImplementedException();
        }
    }
}
