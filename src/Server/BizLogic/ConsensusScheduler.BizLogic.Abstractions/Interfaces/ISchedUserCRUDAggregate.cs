using ConsensusScheduler.BizLogic.Abstractions.Models;

namespace ConsensusScheduler.BizLogic.Abstractions.Interfaces
{
    /// <summary>
    /// Интерфейс агрегата коллекции пользователей
    /// </summary>    
    public interface ISchedUserCRUDAggregate : IBaseCRUDAggregate<SchedUser>
    {
    }
}
