using ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces;
using ConsensusScheduler.BizLogic.Abstractions.Models;
using ConsensusScheduler.BizLogic.Aggregates;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Test.BizLogic.Aggregates
{
    [ExcludeFromCodeCoverage]
    public class PollAggregateTests
    {
        private static Mock<IPollRepository> GetRepositoryMock()
        {
            var repoMock = new Mock<IPollRepository>(MockBehavior.Loose);
            //repoMock.Setup(repo => repo.GetAllAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult((new[] { new BizTypeMock() }).AsEnumerable()));
            return repoMock;
        }

        [Fact]
        public void PollAggregateRequiresNotNullRepository()
        {
            // arrange
            IPollRepository repo = GetRepositoryMock().Object;

            //act
            var aggregate = new PollAggregate(repo);

            // assert
            Assert.NotNull(aggregate);
            Assert.Throws<ArgumentNullException>(() => new PollAggregate(null));
        }

        [Fact]
        public async Task GetAllByAuthorInvokesRepo()
        {
            //arrange
            var repoMock = GetRepositoryMock();
            var sut = new PollAggregate(repoMock.Object);

            //act
            await sut.GetAllByAuthorAsync(new SchedUser(Guid.NewGuid(), ""));

            //assert
            repoMock.Verify(repo => repo.GetAllByAuthorAsync(It.IsAny<SchedUser>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetAllByAuthorWithCancellationInvokesRepo()
        {
            //arrange
            var repoMock = GetRepositoryMock();
            var sut = new PollAggregate(repoMock.Object);

            //act
            await sut.GetAllByAuthorAsync(new SchedUser(Guid.NewGuid(), ""), new CancellationTokenSource().Token);

            //assert
            repoMock.Verify(repo => repo.GetAllByAuthorAsync(It.IsAny<SchedUser>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetAllByAuthorDoesNotAcceptNull()
        {
            //arrange
            var repoMock = GetRepositoryMock();
            var sut = new PollAggregate(repoMock.Object);

            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAllByAuthorAsync(null));
        }

        [Fact]
        public async Task GetAllByAuthorWithCancellationDoesNotAcceptNull()
        {
            //arrange
            var repoMock = GetRepositoryMock();
            var sut = new PollAggregate(repoMock.Object);

            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAllByAuthorAsync(null, new CancellationTokenSource().Token));
        }
    }
}
