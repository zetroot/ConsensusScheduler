using ConsensusScheduler.BizLogic.Abstractions.Interfaces;
using ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces;
using ConsensusScheduler.BizLogic.Aggregates;
using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Test.BizLogic.Aggregates
{
    /// <summary>
    /// “есты базового агрегата бизнеслогики
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BaseCrudAggregateTests
    {
        private static Mock<IBaseCRUDRepository<BizTypeMock>> GetRepositoryMock()
        {
            var repoMock = new Mock<IBaseCRUDRepository<BizTypeMock>>(MockBehavior.Loose);
            //repoMock.Setup(repo => repo.GetAllAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult((new[] { new BizTypeMock() }).AsEnumerable()));
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
        public void NullRepositoryThrowsException()
        {
            // a&a&a
            Assert.Throws<ArgumentNullException>(() => new MockCrudAggregate(null));
        }
        
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
        public async Task GetAllWithCancellationInvokesGetAllFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            _ = await sut.GetAllAsync(new CancellationTokenSource().Token) ;

            // assert
            repoMock.Verify(repo => repo.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetSignleInvokesGetSingleFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            _ = await sut.GetSingleAsync(Guid.NewGuid());

            // assert
            repoMock.Verify(repo => repo.GetSingleAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetSingleWithCancellationInvokesGetSingleFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            _ = await sut.GetSingleAsync(Guid.NewGuid(), new CancellationTokenSource().Token);

            // assert
            repoMock.Verify(repo => repo.GetSingleAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteInvokesDeleteFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object); 

            // act
            await sut.DeleteAsync(Guid.NewGuid());

            // assert
            repoMock.Verify(repo => repo.DeleteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteWithCancellationInvokesDeleteFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            await sut.DeleteAsync(Guid.NewGuid(), new CancellationTokenSource().Token);

            // assert
            repoMock.Verify(repo => repo.DeleteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddInvokesAddFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            _ = await sut.AddAsync(new BizTypeMock());

            // assert
            repoMock.Verify(repo => repo.AddAsync(It.IsAny<BizTypeMock>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddWithCancellationInvokesAddFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            _ = await sut.AddAsync(new BizTypeMock(), new CancellationTokenSource().Token);

            // assert
            repoMock.Verify(repo => repo.AddAsync(It.IsAny<BizTypeMock>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateInvokesUpdateFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            _ = await sut.UpdateAsync(new BizTypeMock());

            // assert
            repoMock.Verify(repo => repo.UpdateAsync(It.IsAny<BizTypeMock>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateWithCancellationInvokesUpdateFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            _ = await sut.UpdateAsync(new BizTypeMock(), new CancellationTokenSource().Token);

            // assert
            repoMock.Verify(repo => repo.UpdateAsync(It.IsAny<BizTypeMock>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ExistsInvokesExistsFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            await sut.ExistsAsync(Guid.NewGuid());

            // assert
            repoMock.Verify(repo => repo.ExistsAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ExistsWithCancellationInvokesExistsFromRepo()
        {
            // arrange
            var repoMock = GetRepositoryMock();
            var sut = new MockCrudAggregate(repoMock.Object);

            // act
            await sut.ExistsAsync(Guid.NewGuid(), new CancellationTokenSource().Token);

            // assert
            repoMock.Verify(repo => repo.ExistsAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
