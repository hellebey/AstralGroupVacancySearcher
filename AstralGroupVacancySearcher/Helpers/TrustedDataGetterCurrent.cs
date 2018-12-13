using AstralGroupVacancySearcher.Interfaces;
using AstralGroupVacancySearcher.Models;
using AstralGroupVacancySearcher.Models.HHRestModels;
using System;
using System.Collections.Generic;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Реализация TrustedDataGetter для текущей задачи
    /// </summary>
    public sealed class TrustedDataGetterCurrent : TrustedDataGetter<IEnumerable<Item>, LoggerCurrent>, IDisposable, IDataGetter<IEnumerable<Item>, Item, LoggerCurrent>
    {
        /// <summary>
        /// Кол-во вакансий, который нужно получить
        /// </summary>
        /// <param name="pageSize"></param>
        public TrustedDataGetterCurrent()
        {
            _filter = new VacFilter();
            Logger = new LoggerCurrent(ref _db);
            Getters = new Queue<IDataGetter<IEnumerable<Item>, LoggerCurrent>>();

            int pageSize = Config.VacPageCount;
            Getters.Enqueue(new GetterBackuperHH(ref _db, pageSize, Logger));
            Getters.Enqueue(new GetterHHBackup(ref _db, pageSize, Logger));
        }

        /// <summary>
        /// Фильтр данных
        /// </summary>
        private IFilter<Item, Item> _filter { get; set; }

        private readonly CurrentDbContext _db = new CurrentDbContext();

        /// <summary>
        /// Сохраняет все изменения, которые внесли в бд этот и дочерние действия, включая логи
        /// </summary>
        public void SaveAllChanges()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.SaveChangesAsync();
            _db.Dispose();
        }

        /// <summary>
        /// Фильтрует полученные данные
        /// </summary>
        /// <param name="filter">Объект для данных фильтра</param>
        /// <returns>отфильтрованные данные</returns>
        public IEnumerable<Item> GetData(Item filter)
        {
            return _filter.Filter(GetData(), filter);
        }
    }
}
