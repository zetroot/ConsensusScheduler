using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces
{
    public interface IBaseCRUDRepository<T> where T : IBizEntity
    {
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Коллекция всех записей</returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Найденая запись</returns>
        Task<T> GetSingleAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новую запись
        /// </summary>
        /// <param name="entity">Добавляемая запись</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Добавленная запись</returns>
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить запись в хранилище
        /// </summary>
        /// <param name="entity">Обновляемая запись</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Обновленная запись</returns>
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить запись по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемой записи</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Удаленная запись</returns>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка существования записи с таким идентификатором
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Истина - если запись существует, ложь в противном случае</returns>
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
    }
}
