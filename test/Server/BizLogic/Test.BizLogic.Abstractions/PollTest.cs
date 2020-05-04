using ConsensusScheduler.BizLogic.Abstractions.Models;
using System;
using System.Linq;
using Xunit;

namespace Test.BizLogic.Abstractions
{
    public class PollTest
    {
        [Fact]
        public void TestParametrizedConstructor()
        {
            //arrange
            var id = Guid.NewGuid();
            var subject = "subject";
            var description = "description";
            var created = DateTime.Now;
            DateTime? due = null; 
            var creator = new SchedUser();
            var pollOptions = Enumerable.Empty<PollOption>();

            //act
            Poll poll = new Poll(id: id, subject: subject, description: description, creationDateTime: created, dueDate: due, creator: creator, pollOptions: pollOptions);

            //assert
            Assert.NotNull(poll);
            Assert.Equal(id, poll.ID);
            Assert.Equal(subject, poll.Subject);
            Assert.Equal(description, poll.Description);
            Assert.Equal(created, poll.CreationDateTime);
            Assert.Equal(due, poll.DueDate);
            Assert.Equal(creator, poll.Creator);
            Assert.Equal(pollOptions, poll.PollOptions);
        }

        [Fact]
        public void ParametrizedConstructorDoesNotAcceptNulls()
        {
            //arrange
            var id = Guid.NewGuid();
            var subject = "subject";
            var description = "description";
            var created = DateTime.Now;
            DateTime? due = null;
            var creator = new SchedUser();
            var pollOptions = Enumerable.Empty<PollOption>();

            //act & assert
            Assert.Throws<ArgumentNullException>(() => new Poll(
                id: id,
                subject: null,
                description: description,
                creationDateTime: created,
                dueDate: due,
                creator: creator,
                pollOptions: pollOptions));

            Assert.Throws<ArgumentNullException>(() => new Poll(
                id: id,
                subject: subject,
                description: null,
                creationDateTime: created,
                dueDate: due,
                creator: creator,
                pollOptions: pollOptions));

            Assert.Throws<ArgumentNullException>(() => new Poll(
                id: id,
                subject: subject,
                description: description,
                creationDateTime: created,
                dueDate: due,
                creator: null,
                pollOptions: pollOptions));

            Assert.Throws<ArgumentNullException>(() => new Poll(
                id: id,
                subject: subject,
                description: description,
                creationDateTime: created,
                dueDate: due,
                creator: creator,
                pollOptions: null));
        }

        [Fact]
        public void CopyingCtorThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Poll(null));
        }

        [Fact]
        public void CopyingCtorActuallyCreatesCopy()
        {
            // arrange
            var poll_origin = new Poll(Guid.NewGuid(), "subject", "description", DateTime.Now, DateTime.UtcNow, new SchedUser(), Enumerable.Empty<PollOption>());

            //act
            var poll_copied = new Poll(poll_origin);

            //assert
            Assert.NotSame(poll_origin, poll_copied);
            Assert.Equal(poll_origin.ID, poll_copied.ID);
            Assert.Equal(poll_origin.Subject, poll_copied.Subject);
            Assert.Equal(poll_origin.Description, poll_copied.Description);
            Assert.Equal(poll_origin.CreationDateTime, poll_copied.CreationDateTime);
            Assert.Equal(poll_origin.DueDate, poll_copied.DueDate);
            Assert.Equal(poll_origin.Creator, poll_copied.Creator);
            Assert.Equal(poll_origin.PollOptions, poll_copied.PollOptions);
        }
    }
}
