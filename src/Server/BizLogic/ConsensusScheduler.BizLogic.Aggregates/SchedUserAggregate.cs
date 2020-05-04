using ConsensusScheduler.BizLogic.Abstractions.Interfaces;
using ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces;
using ConsensusScheduler.BizLogic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsensusScheduler.BizLogic.Aggregates
{
    /// <summary>
    /// Реализация агрегата коллекции пользователей
    /// </summary>
    internal class SchedUserAggregate : BaseCRUDAggregate<SchedUser>, ISchedUserCRUDAggregate
    {
        public SchedUserAggregate(ISchedUserRepository repository) : base(repository)
        {
        }
    }
}
