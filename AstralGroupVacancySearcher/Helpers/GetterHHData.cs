using AstralGroupVacancySearcher.Interfaces;
using AstralGroupVacancySearcher.Models;
using AstralGroupVacancySearcher.Models.HHRestModels;
using System;
using System.Collections.Generic;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Рализация класса Getter для получений списка вакансий с res api hh.ru
    /// </summary>
    public sealed class GetterHHData : Getter<IEnumerable<Item>, LoggerCurrent>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db">Контекст данных для сохранений резервных данных и запили лога</param>
        /// <param name="rootLogger">Логгер вышестоящего действия</param>
        /// <param name="count">Необходимое кол-во заявок</param>
        /// <param name="rootGetter">Объект для получения корневых данных  с res api hh.ru</param>
        public GetterHHData(ref CurrentDbContext db, LoggerCurrent rootLogger, int count, IDataGetter<HHRootData, LoggerCurrent> rootGetter = null)
        {
            RootGetter = rootGetter;
            Logger = new LoggerCurrent(ref db, rootLogger);
            if (RootGetter == null)
            {
                RootGetter = new GetterHHRootData(ref db, Logger, count);
            }
        }

        /// <summary>
        /// Сообщение для логгера
        /// </summary>
        public override string LoggerMessage => "Получение списка вакансий с res api hh.ru";
        /// <summary>
        /// Название источника данных
        /// </summary>
        public override string Source => "Данные с res api hh.ru";

        /// <summary>
        /// Объект для получения корневых данных  с res api hh.ru
        /// </summary>
        private IDataGetter<HHRootData, LoggerCurrent> RootGetter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Список полученных вакансий</returns>
        protected override IEnumerable<Item> GetCurrentData()
        {
            return RootGetter.GetData().items;
        }
    }
}
