using ConsensusScheduler.BizLogic.Abstractions.Interfaces;
using System;

namespace ConsensusScheduler.BizLogic.Abstractions.Models
{
    /// <summary>
    /// Пользователь сервиса
    /// </summary>
    public class SchedUser : IBizEntity
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid ID { get; }
             
        /// <summary>
        /// Отображаемое имя пользователя
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <param name="displayName">Отображаемое имя пользователя</param>
        public SchedUser(Guid id, string displayName)
        {
            ID = id;
            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
        }

        /// <summary>
        /// Copying ctor
        /// </summary>
        /// <param name="origin">origin to copy from</param>
        public SchedUser(SchedUser origin)
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            ID = origin.ID;
            DisplayName = origin.DisplayName;
        }
    }
}