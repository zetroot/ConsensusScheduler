using ConsensusScheduler.BizLogic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces
{
    /// <summary>
    /// Репозиторий опросов
    /// </summary>
    public interface IPollRepository : IBaseCRUDRepository<Poll>
    {
        /// <summary>
        /// Получить все опросы созданные автором
        /// </summary>
        /// <param name="author">Автор опроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Коллекция опросов созданная указанным пользователем</returns>
        Task<IEnumerable<Poll>> GetAllByAuthorAsync(SchedUser author, CancellationToken cancellationToken);
    }
}
