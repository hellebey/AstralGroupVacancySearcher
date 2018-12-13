using AstralGroupVacancySearcher.Models;
using AstralGroupVacancySearcher.Models.HHRestModels;
using System.Collections.Generic;
using System.Linq;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Класс для получения заявок из бд
    /// </summary>
    public sealed class GetterHHBackup : Getter<IEnumerable<Item>, LoggerCurrent>
    {
        private CurrentDbContext db = new CurrentDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize">Количество заявок</param>
        public GetterHHBackup(ref CurrentDbContext db, int pageSize, LoggerCurrent parentLogger = null)
        {
            Logger = new LoggerCurrent(ref db, parentLogger);
            _pageSize = pageSize;
        }

        /// <summary>
        /// Сообщение для логгера
        /// </summary>
        public override string LoggerMessage => "Получение резервных данных";

        /// <summary>
        /// Источник данных
        /// </summary>
        public override string Source => "Резервные данны с базы данных.";

        private int _pageSize { get; set; }

        /// <summary>
        /// Возвращает последние {pageSize} добавленных или обновленных данных
        /// </summary>
        /// <returns>Последние {pageSize} добавленных или обновленных данных</returns>
        protected override IEnumerable<Item> GetCurrentData()
        {
            return db.Items.OrderByDescending(i => i.log.id).Take(_pageSize).ToList();
            throw new System.NotImplementedException();
        }
    }
}
