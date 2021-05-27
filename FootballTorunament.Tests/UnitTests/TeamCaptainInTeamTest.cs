using Domain.Models;
using Domain.Validations.TeamValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{
    public class TeamCaptainInTeamTest
    {
        public Player Captain = new() {Id=4, PlayerName = "Captain", Age = 22, IsRetired = false };

        public List<Player> Players = new List<Player>()
        {
            new Player() { PlayerName = "Paul", Age = 34, IsRetired = true },
            new Player(){PlayerName="Peter", Age=12,IsRetired=false }
        };

        [Fact]
        public void TeamCaptainIsInTeam()
        {
            Players.Add(Captain);
            Assert.True(IsCaptainInTeamExtension.IsCaptainInThisTeam(new Team() { Players = Players, Captain = Captain }));
        }

        [Fact]
        public void TeamCaptainIsNotInTeam() =>
            Assert.False(IsCaptainInTeamExtension.IsCaptainInThisTeam(new Team() { Players = Players, Captain = Captain }));

        [Fact]
        public void TeamPlayersIsNull() => Assert.False(IsCaptainInTeamExtension.IsCaptainInThisTeam(new Team() { Players = null, Captain = Captain }));

        [Fact]
        public void TeamCaptainIsNull() => Assert.False(IsCaptainInTeamExtension.IsCaptainInThisTeam(new Team() { Players = Players, Captain = null }));

        [Fact]
        public void TeamIsNull() => Assert.False(IsCaptainInTeamExtension.IsCaptainInThisTeam(null));

        [Fact]
        public void TeamCaptainAndPlayersAreNull() => Assert.False(IsCaptainInTeamExtension.IsCaptainInThisTeam(new Team() { Players = null, Captain = null }));
    }
}
