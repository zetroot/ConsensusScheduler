using ConsensusScheduler.BizLogic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces
{
    /// <summary>
    /// Интерфейс репозитория пользователей
    /// </summary>
    public interface ISchedUserRepository : IBaseCRUDRepository<SchedUser>
    {
    }
}
