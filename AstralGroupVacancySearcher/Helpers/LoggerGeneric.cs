using AstralGroupVacancySearcher.Interfaces;
using System;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Типизированный логгер
    /// </summary>
    /// <typeparam name="TLog">Тип данных лога</typeparam>
    public abstract class LoggerGeneric<TLog> : ILogger where TLog : ILogData
    {
        
        protected virtual TLog logData { get; set; }

        /// <summary>
        /// Данные лога
        /// </summary>
        public TLog LogData => logData;

        protected LoggerGeneric()
        {
        }

        /// <summary>
        /// Записывает результат выполнений
        /// </summary>
        /// <param name="isComplite">Флаг успешности выполнения</param>
        public virtual void StopLog(bool isComplite)
        {
            LogData.IsSuccess = isComplite;
            WriteLog();
        }

        /// <summary>
        /// Начинает запись лога
        /// </summary>
        /// <param name="message">Название дейтсвия</param>
        public virtual void StartLog(string message)
        {
            LogData.DateTime = DateTime.Now;
            LogData.Message = message;
        }

        /// <summary>
        /// Записывает лог
        /// </summary>
        protected abstract void WriteLog();
    }
}
