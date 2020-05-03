using System;
using System.Collections.Generic;
using System.Text;

namespace ConsensusScheduler.BizLogic.Abstractions.Interfaces
{
    /// <summary>
    /// Интерфейс сущности слоя бизнес-логики
    /// </summary>
    public interface IBizEntity
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        Guid ID { get; }
    }
}
