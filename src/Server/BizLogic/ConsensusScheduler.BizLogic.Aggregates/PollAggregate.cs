using ConsensusScheduler.BizLogic.Abstractions.Interfaces;
using ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces;
using ConsensusScheduler.BizLogic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsensusScheduler.BizLogic.Aggregates
{
    /// <summary>
    /// Реализация агрегата опросов пользователей
    /// </summary>
    internal class PollAggregate : BaseCRUDAggregate<Poll>, IPollCRUDAggregate
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository">Репозиторий опросов</param>
        public PollAggregate(IPollRepository repository) : base(repository)
        {
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Poll>> GetAllByAuthorAsync(SchedUser author) => GetAllByAuthorAsync(author, CancellationToken.None);

        /// <inheritdoc/>
        public Task<IEnumerable<Poll>> GetAllByAuthorAsync(SchedUser author, CancellationToken cancellationToken)
        {
            if (repository is IPollRepository repo)
                return repo.GetAllByAuthorAsync(author ?? throw new ArgumentNullException(nameof(author)), cancellationToken);
            else
                throw new InvalidOperationException();
        }
    }
}
