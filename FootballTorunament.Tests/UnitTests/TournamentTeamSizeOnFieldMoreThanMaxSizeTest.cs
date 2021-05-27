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
    public class TournamentTeamSizeOnFieldMoreThanMaxSizeTest
    {
        [Fact]
        public void TournamentIsNull() => Assert.False(TeamSizeMustBeGreaterThanPlayersOnField.IsMaxPlayersOnFieldMoreThanMaxTeamSize(null));

        [Fact]
        public void MaxTeamSizeMoreThanPlayersOnField() => Assert.False(TeamSizeMustBeGreaterThanPlayersOnField.IsMaxPlayersOnFieldMoreThanMaxTeamSize(new Tournament() { MaxTeamSize = 30, MaxPlayersOnField = 11 }));

        [Fact]
        public void PlayersOnFieldMoreThanMaxTeamSize() => Assert.True(TeamSizeMustBeGreaterThanPlayersOnField.IsMaxPlayersOnFieldMoreThanMaxTeamSize(new Tournament() { MaxTeamSize = 11, MaxPlayersOnField = 30 }));
    }
}
