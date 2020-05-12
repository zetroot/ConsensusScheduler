using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsensusScheduler.BizLogic.Abstractions.Interfaces
{
    /// <summary>
    /// Интерфейс базового CRUD агрегата, позволяет выполняет базовые операции с коллекцией сущностей в сервисе
    /// </summary>
    /// <typeparam name="T">Сущность бизнес слоя</typeparam>
    public interface IBaseCRUDAggregate<T> where T : IBizEntity
    {
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <returns>Перечисление записей - вся коллекция</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Перечисление записей - вся коллекция</returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>Запись из хранилища</returns>
        Task<T> GetSingleAsync(Guid id);

        /// <summary>
        /// Получить запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Запись из хранилища</returns>
        Task<T> GetSingleAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новую запись
        /// </summary>
        /// <param name="entity">Добавляемая запись</param>
        /// <returns>Добавленная запись</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Добавить новую запись
        /// </summary>
        /// <param name="entity">Добавляемая запись</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Добавленная запись</returns>
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить запись
        /// </summary>
        /// <param name="entity">Обновляемая запись</param>
        /// <returns>Обновленная запись</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Обновить запись
        /// </summary>
        /// <param name="entity">Обновляемая запись</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Обновленная запись</returns>
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемой записи</param>        
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Удалить запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификтаор удалемой записи</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить существование записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Существование записи</returns>
        Task<bool> ExistsAsync(Guid id);

        /// <summary>
        /// Проверить существование записи по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Истина - если запись существует</returns>
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
    }
}
