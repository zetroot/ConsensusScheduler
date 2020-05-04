using ConsensusScheduler.BizLogic.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsensusScheduler.BizLogic.Abstractions.Models
{
    /// <summary>
    /// Опрос участников
    /// </summary>
    public class Poll : IBizEntity
    {
        /// <inheritdoc/>
        public Guid ID { get; }

        /// <summary>
        /// Тема опроса
        /// </summary>
        public string Subject { get; }

        /// <summary>
        /// Описание опроса
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Дата создания опроса
        /// </summary>
        public DateTime CreationDateTime { get; }

        /// <summary>
        /// Срок действия опроса
        /// </summary>
        public DateTime? DueDate { get; }

        /// <summary>
        /// Автор опроса
        /// </summary>
        public SchedUser Creator { get; }

        /// <summary>
        /// Возможные варианты
        /// </summary>
        public IEnumerable<PollOption> PollOptions { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="subject">Тема опроса</param>
        /// <param name="description">Описание опроса</param>
        /// <param name="creationDateTime">Дата создания</param>
        /// <param name="dueDate">Срок проведения опроса - если null, опрос бессрочный</param>
        /// <param name="creator">Автор-создатель опроса</param>
        /// <param name="pollOptions">Варианты выбора для участников опроса</param>
        public Poll(Guid id, string subject, string description, DateTime creationDateTime, DateTime? dueDate, SchedUser creator, IEnumerable<PollOption> pollOptions)
        {
            ID = id;
            this.Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.CreationDateTime = creationDateTime;
            this.DueDate = dueDate;
            this.Creator = creator ?? throw new ArgumentNullException(nameof(creator));
            this.PollOptions = pollOptions ?? throw new ArgumentNullException(nameof(pollOptions));
        }

        /// <summary>
        /// Копирующий конструктор
        /// </summary>
        /// <param name="origin">Сущность которую надо скопировать</param>
        public Poll(Poll origin)            
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            ID = origin.ID;
            this.Subject = origin.Subject;
            this.Description = origin.Description;
            this.CreationDateTime = origin.CreationDateTime;
            this.DueDate = origin.DueDate;
            this.Creator = origin.Creator;
            this.PollOptions = origin.PollOptions;
        }
    }
}
