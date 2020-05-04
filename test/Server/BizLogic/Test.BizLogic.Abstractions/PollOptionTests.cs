using ConsensusScheduler.BizLogic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Test.BizLogic.Abstractions
{
    public class PollOptionTests
    {
        [Fact]
        public void CtorActuallyAssignsAllFields()
        {
            // arrange
            var id = Guid.NewGuid();
            var isFulLDay = true;
            var start = DateTime.Today;
            var end = DateTime.Now;
            var desc = "desc";

            //act
            var pollOption = new PollOption(id, isFulLDay, start, end, desc);

            //assert
            Assert.Equal(id, pollOption.ID);
            Assert.Equal(isFulLDay, pollOption.IsFullDayOption);
            Assert.Equal(start, pollOption.Start);
            Assert.Equal(end, pollOption.End);
            Assert.Equal(desc, pollOption.Description);
        }

        [Fact]
        public void CtorFailsOnNullDescription()
        {
            // arrange
            var id = Guid.NewGuid();
            var isFulLDay = true;
            var start = DateTime.Today;
            var end = DateTime.Now;
            var desc = "desc";

            //act
            Assert.Throws<ArgumentNullException>(() => new PollOption(id, isFulLDay, start, end, null));
        }

        [Fact]
        public void CopyingCtorCreatesCopy()
        {
            // arrange
            var id = Guid.NewGuid();
            var isFulLDay = true;
            var start = DateTime.Today;
            var end = DateTime.Now;
            var desc = "desc";
            var pollOption = new PollOption(id, isFulLDay, start, end, desc);

            //act
            var copy = new PollOption(pollOption);

            //assert
            Assert.Equal(id, copy.ID);
            Assert.Equal(isFulLDay, copy.IsFullDayOption);
            Assert.Equal(start, copy.Start);
            Assert.Equal(end, copy.End);
            Assert.Equal(desc, copy.Description);
        }

        [Fact]
        public void CopyingCtorFailsOnNullOrigin()
        {
            Assert.Throws<ArgumentNullException>(() => new PollOption(null));
        }
    }
}
