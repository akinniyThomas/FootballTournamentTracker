using Domain.Models;
using Domain.Validations.TournamentValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{
    public class TournamentWinnerRunnerUpNotUntilFinishedTest
    {
        Tournament tournament = null;

        [Fact]
        public void TournamentIsNull() => Assert.False(tournament.IsNotFinishedTournament(null));

        [Fact]
        public void TeamIsNull() => Assert.False(new Tournament().IsNotFinishedTournament(null));

        [Fact]
        public void TournamentNotFinishedNoWinner() => Assert.False(new Tournament() { DateFinished = null }.IsNotFinishedTournament(null));

        [Fact]
        public void TournamentFinishedNoWinner() => Assert.False(new Tournament() { DateFinished = DateTime.Now }.IsNotFinishedTournament(null));

        [Fact]
        public void TournamentNotFinishedWithWinner() => Assert.True(new Tournament() { DateFinished = null }.IsNotFinishedTournament(new Team()));

        [Fact]
        public void TournamentFinishedWithWinner() =>
            Assert.False(new Tournament() { DateFinished = DateTime.Now }.IsNotFinishedTournament(new Team()));
    }
}
