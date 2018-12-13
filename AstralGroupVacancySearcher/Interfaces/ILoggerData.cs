using System;

namespace AstralGroupVacancySearcher.Interfaces
{
    /// <summary>
    /// Интерфейс для данных лога
    /// </summary>
    public interface ILogData
    {
        /// <summary>
        /// Флаг успешности выполнения
        /// </summary>
        bool? IsSuccess { get; set; }
        /// <summary>
        /// Сообщение о действии
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// Дата/время выполнения
        /// </summary>
        DateTime DateTime { get; set; }
    }
}
