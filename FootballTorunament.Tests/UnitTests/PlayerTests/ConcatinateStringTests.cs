using Infrastructure.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests.PlayerTests
{
    public class ConcatinateStringTests
    {
        [Theory]
        [InlineData("one","two","three")]
        [InlineData("one","two")]
        [InlineData("one")]
        [InlineData("one", "3")]
        [InlineData("", "", "")]
        [InlineData("")]
        public void CanConcatinateStringWithArray(params string[] strings)
        {
            var items = PlayerDA.ConcatinateStrings(strings);
            Assert.NotNull(items);
            Assert.NotEmpty(items);
        }

        [Fact]
        public void CanConcatNumbers()
        {
            List<string> stringList = new List<string>() { "four", "five" };
            var items = PlayerDA.ConcatinateStrings(stringList, "first", "second", "third");
            Assert.NotNull(items);
            Assert.NotEmpty(items);
            Assert.Contains("five", items);
            Assert.Contains("four", items);
            Assert.Contains("third", items);
            Assert.Contains("second", items);
            Assert.Contains("first", items);
            Assert.DoesNotContain("six", items);
            Assert.DoesNotContain("seven", items);
        }
    }
}
