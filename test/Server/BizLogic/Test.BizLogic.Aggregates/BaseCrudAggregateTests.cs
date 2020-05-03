using ConsensusScheduler.BizLogic.Abstractions.Interfaces;
using ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces;
using ConsensusScheduler.BizLogic.Aggregates;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Test.BizLogic.Aggregates
{
    /// <summary>
    /// “есты базового агрегата бизнеслогики
    /// </summary>
    public class BaseCrudAggregateTests
    {
        private static Mock<IBaseCRUDRepository<BizTypeMock>> GetRepositoryMock()
        {
            var repoMock = new Mock<IBaseCRUDRepository<BizTypeMock>>(MockBehavior.Strict);
            repoMock.Setup(repo => repo.GetAllAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult((new[] { new BizTypeMock() }).AsEnumerable()));
            return repoMock;
        }

        /// <summary>
        /// ћок-тип дл€ тестировани€ базового агрегата
        /// </summary>
        public class BizTypeMock : IBizEntity
        {
            public Guid ID { get; set; } = Guid.NewGuid();
        }

        /// <summary>
        /// ѕр€мой наследник базового класса CRUD агрегата
        /// </summary>
        internal class MockCrudAggregate : BaseCRUDAggregate<BizTypeMock> { public MockCrudAggregate(IBaseCRUDRepository<BizTypeMock> repository) : base(repository) { } }

        [Fact]
        public async Task GetAllInvokesGetAllFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            _ = await sut.GetAllAsync();

            // assert
            repoMock.Verify(repo => repo.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void NullRepositoryThrowsException()
        {
            // a&a&a
            Assert.Throws<ArgumentNullException>(() => new MockCrudAggregate(null));
        }
    }
}
