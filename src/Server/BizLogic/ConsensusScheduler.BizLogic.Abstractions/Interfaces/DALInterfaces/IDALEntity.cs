using System;
using System.Collections.Generic;
using System.Text;

namespace ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces
{
    /// <summary>
    /// Интерфейс сущности слоя доступа к данным
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IDALEntity<T> where T : IDALEntity<T>
    {
        /// <summary>
        /// Идентификатор сущности - первичный ключ
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Вытянуть изменения из сущности
        /// </summary>
        /// <param name="entity">Сущность из которой необходимо вытянуть изменения</param>
        void PullChangesFrom(T entity);
    }
}
