using System;
using System.Collections.Generic;
using System.Text;

namespace ConsensusScheduler.BizLogic.Abstractions.Models
{
    /// <summary>
    /// Интерфейс сущность слоя бизнес-логики
    /// </summary>
    public interface IBizEntity
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        Guid ID { get; }
    }
}
