using AstralGroupVacancySearcher.Models;
using System.Collections.Generic;

namespace AstralGroupVacancySearcher.Helpers
{

    /// <summary>
    /// Реализация логгера с записью в БД
    /// </summary>
    public sealed class LoggerCurrent : LoggerGeneric<Log>
    {
        /// <summary>
        /// Контекст сохранения данных
        /// </summary>
        private CurrentDbContext _db { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext">Контекст в который будут сохранены данные</param>
        /// <param name="parentLog">Логгер родительского действия</param>
        public LoggerCurrent(
                    ref CurrentDbContext dbContext,
                    LoggerCurrent parentLog = null) : base()
        {
            _db = dbContext;

            logData = new Log();
            if (parentLog != null)
            {
                logData.Parent = parentLog.LogData;
            }

            
        }

        /// <summary>
        ///  Добавляет сущность лога в контекст бд (данный метод не сохраняет изменения в бд, для сохрарения изменений вызовите соотв. метод в переданном контексте)
        /// </summary>
        protected override void WriteLog()
        {
            _db.Logs.Add(logData);
        }
    }
}
