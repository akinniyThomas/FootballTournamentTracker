using Application.Extensions;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests.ViewModelsTests
{
    public class AnObjectResultTests
    {
        static List<Player> p = new List<Player>();
        public AnObjectResultTests()
        {
            p.Add(new Player() { PlayerName = "play1" });
            p.Add(new Player() { PlayerName = "play2" });
            p.Add(new Player() { PlayerName = "play3" });
        }

        [Theory]
        [InlineData(false, "first")]
        [InlineData(true, "second","third","fourth")]
        public void CanAddAnObjectResult(bool succeded, params string[] messages)
        {
            var firstAnObjectResult = new AnObjectResult<Player>(succeded, messages.ToList());
            var secondAnObjectResult = new AnObjectResult<Player>(p, succeded, messages.ToList());

            Assert.NotNull(firstAnObjectResult);
            Assert.NotNull(secondAnObjectResult);
            Assert.Null(firstAnObjectResult.Object);
            Assert.Equal(p[0].Id, secondAnObjectResult.Object[0].Id);
            Assert.Equal(succeded, firstAnObjectResult.Succeeded);
            Assert.Equal(succeded, secondAnObjectResult.Succeeded);
            Assert.Equal(messages, firstAnObjectResult.ErrorMessages);
            Assert.Equal(messages, secondAnObjectResult.ErrorMessages);
        }

        [Fact]
        public void CanReturnObjecResult()
        {
            var first = AnObjectResult<Player>.ReturnObjectResult(false, "message");
            var second = AnObjectResult<Player>.ReturnObjectResult(true, p.Select(x => x.PlayerName).ToList());
            var third = AnObjectResult<Player>.ReturnObjectResult(p, true, "message");
            var fourth = AnObjectResult<Player>.ReturnObjectResult(p, false, p.Select(x => x.PlayerName).ToList());
            var fifth = AnObjectResult<Player>.ReturnObjectResult(p[0], false, "message");
            var sixth = AnObjectResult<Player>.ReturnObjectResult(p[0], true, p.Select(x => x.PlayerName).ToList());

            Assert.NotNull(first);
            Assert.NotNull(second);
            Assert.NotNull(third);
            Assert.NotNull(fourth);
            Assert.NotNull(fifth);
            Assert.NotNull(sixth);

            Assert.Null(first.Object);
            Assert.Null(second.Object);
            Assert.NotNull(third.Object);
            Assert.NotNull(fourth.Object);
            Assert.NotNull(fifth.Object);
            Assert.NotNull(sixth.Object);

            Assert.Single(first.ErrorMessages);
            Assert.Single(third.ErrorMessages);
            Assert.Single(fifth.ErrorMessages);

            Assert.Equal(3, second.ErrorMessages.Count);
            Assert.Equal(3, fourth.ErrorMessages.Count);
            Assert.Equal(3, sixth.ErrorMessages.Count);

            Assert.False(first.Succeeded);
            Assert.True(second.Succeeded);
            Assert.True(third.Succeeded);
            Assert.False(fourth.Succeeded);
            Assert.False(fifth.Succeeded);
            Assert.True(sixth.Succeeded);
        }

        [Theory]
        [InlineData(1)]
        [InlineData("1")]
        [InlineData("One")]
        [InlineData(false)]
        public void CanReturnObjectList<T>(T obj)
        {
            var item = AnObjectResult<T>.ReturnObjectList(obj);
            Assert.Single(item);
            Assert.NotNull(item);
            Assert.NotEmpty(item);
        }
    }
}
