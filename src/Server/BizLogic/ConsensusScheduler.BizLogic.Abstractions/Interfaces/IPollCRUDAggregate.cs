using ConsensusScheduler.BizLogic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsensusScheduler.BizLogic.Abstractions.Interfaces
{
    /// <summary>
    /// Интерфейс реестра опросов
    /// </summary>
    public interface IPollCRUDAggregate : IBaseCRUDAggregate<Poll>
    {
        /// <summary>
        /// Получить все опросы по автору
        /// </summary>
        /// <param name="author">Автор опросов</param>
        /// <returns>Коллекция опросов по пользователю</returns>
        Task<IEnumerable<Poll>> GetAllByAuthorAsync(SchedUser author);

        /// <summary>
        /// Получить все опросы по автору
        /// </summary>
        /// <param name="author">Автор опросов</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Коллекция опросов по пользователю</returns>
        Task<IEnumerable<Poll>> GetAllByAuthorAsync(SchedUser author, CancellationToken cancellationToken);
    }
}
