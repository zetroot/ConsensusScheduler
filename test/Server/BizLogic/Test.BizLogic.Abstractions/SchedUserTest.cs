using ConsensusScheduler.BizLogic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace Test.BizLogic.Abstractions
{
    [ExcludeFromCodeCoverage]
    public class SchedUserTest
    {
        [Fact]
        public void CtorFailsOnNullDisplayName()
        {
            Assert.Throws<ArgumentNullException>(() => new SchedUser(Guid.NewGuid(), null));
        }

        [Fact]
        public void CtorFailsOnNullOrigin()
        {
            Assert.Throws<ArgumentNullException>(() => new SchedUser(null));
        }

        [Fact]
        public void CtorActuallySetsProps()
        {
            // arrange
            var id = Guid.NewGuid();
            var displayName = "displayName";

            // act
            var user = new SchedUser(id, displayName);

            //assert
            Assert.Equal(id, user.ID);
            Assert.Equal(displayName, user.DisplayName);
        }
    }
}
