using ConsensusScheduler.BizLogic.Abstractions.Interfaces;
using ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsensusScheduler.BizLogic.Aggregates
{
    /// <summary>
    /// Абстрактный базовый агрегат бизнеслогики доступа к сущности
    /// </summary>
    /// <typeparam name="T">Тип бизнесовой сущности к которой осуществляется доступ</typeparam>
    internal abstract class BaseCRUDAggregate<T> : IBaseCRUDAggregate<T>
        where T : IBizEntity
    {
        protected readonly IBaseCRUDRepository<T> repository;

        /// <summary>
        /// Защищенный конструктор
        /// </summary>
        /// <param name="repository">репозиторий соответствующей сущности</param>
        protected BaseCRUDAggregate(IBaseCRUDRepository<T> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <inheritdoc/>
        public virtual Task<T> AddAsync(T entity) => AddAsync(entity, CancellationToken.None);

        /// <inheritdoc/>
        public virtual Task<T> AddAsync(T entity, CancellationToken cancellationToken) => repository.AddAsync(entity, cancellationToken);

        /// <inheritdoc/>
        public virtual Task DeleteAsync(Guid id) => DeleteAsync(id, CancellationToken.None);

        /// <inheritdoc/>
        public virtual Task DeleteAsync(Guid id, CancellationToken cancellationToken) => repository.DeleteAsync(id, cancellationToken);

        /// <inheritdoc/>
        public virtual Task<bool> ExistsAsync(Guid id) => ExistsAsync(id, CancellationToken.None);

        /// <inheritdoc/>
        public virtual Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken) => repository.ExistsAsync(id, cancellationToken);

        /// <inheritdoc/>
        public virtual Task<IEnumerable<T>> GetAllAsync() => GetAllAsync(CancellationToken.None);

        /// <inheritdoc/>
        public virtual Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) => repository.GetAllAsync(cancellationToken);

        /// <inheritdoc/>
        public virtual Task<T> GetSingleAsync(Guid id) => GetSingleAsync(id, CancellationToken.None);

        /// <inheritdoc/>
        public virtual Task<T> GetSingleAsync(Guid id, CancellationToken cancellationToken) => repository.GetSingleAsync(id, cancellationToken);

        /// <inheritdoc/>
        public virtual Task<T> UpdateAsync(T entity) => UpdateAsync(entity, CancellationToken.None);

        /// <inheritdoc/>
        public virtual Task<T> UpdateAsync(T entity, CancellationToken cancellationToken) => repository.UpdateAsync(entity, cancellationToken);
    }
}
