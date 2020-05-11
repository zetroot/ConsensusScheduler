using ConsensusScheduler.BizLogic.Abstractions.Interfaces;
using System;

namespace ConsensusScheduler.BizLogic.Abstractions.Models
{
    /// <summary>
    /// Опция выбора в опросе
    /// </summary>
    public class PollOption : IBizEntity
    {
        /// <inheritdoc/>
        public Guid ID { get; }

        /// <summary>
        /// Это вариант на целый день - без указания времени
        /// </summary>
        public bool IsFullDayOption { get; }

        /// <summary>
        /// Дата время начала
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// Дата время окончания
        /// </summary>
        public DateTime End { get; }

        /// <summary>
        /// Описание варианта
        /// </summary>
        public string Description { get; }        

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор опции</param>
        /// <param name="isFullDayOption">Опция "на весь день"</param>
        /// <param name="start">Дата-время начала опции</param>
        /// <param name="end">Дата-время окончания опции</param>
        /// <param name="description">Описание</param>
        public PollOption(Guid id, bool isFullDayOption, DateTime start, DateTime end, string description)
        {
            ID = id;
            IsFullDayOption = isFullDayOption;
            Start = start;
            End = end;
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        /// <summary>
        /// Copying ctor
        /// </summary>
        /// <param name="origin">Origin to copy from</param>
        public PollOption(PollOption origin)
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            ID = origin.ID;
            IsFullDayOption = origin.IsFullDayOption;
            Start = origin.Start;
            End = origin.End;
            Description = origin.Description;
        }
    }
}