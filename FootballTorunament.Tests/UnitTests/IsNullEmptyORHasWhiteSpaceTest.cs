using Domain.Validations.PlayerValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{[Collection(nameof(Testing))]
    public class IsNullEmptyORHasWhiteSpaceTest
    {
        [Theory]
        [InlineData("   ")]
        [InlineData("")]
        [InlineData(null)]
        public void WithWhiteSpaceEmptyOrNull(string str)
        {
            Assert.True(new ApplicationUserMustBeIncluded().IsNullEmptyORWhiteSpaced(str));
        }

        [Fact]
        public void DoesntHaveWhiteSpaceEmptyOrNull()
        {
            Assert.False(new ApplicationUserMustBeIncluded().IsNullEmptyORWhiteSpaced("something"));
        }
    }
}
