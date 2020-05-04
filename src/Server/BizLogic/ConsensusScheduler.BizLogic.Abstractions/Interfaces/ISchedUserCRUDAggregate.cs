using ConsensusScheduler.BizLogic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsensusScheduler.BizLogic.Abstractions.Interfaces
{
    /// <summary>
    /// Интерфейс агрегата коллекции пользователей
    /// </summary>
    public interface ISchedUserCRUDAggregate : IBaseCRUDAggregate<SchedUser>
    {
    }
}
