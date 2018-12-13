using AstralGroupVacancySearcher.Models;
using AstralGroupVacancySearcher.Models.HHRestModels;
using System.Collections.Generic;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Реализация получения заявок с hh.ru с записью данных в резервное хранилище
    /// </summary>
    /// <typeparam name="TEntity">Тип возвращаемых данных</typeparam>
    /// <typeparam name="TLogger">Тип логера</typeparam>
    /// <typeparam name="TGetter">Тип получателя данных</typeparam>
    /// <typeparam name="TBackupper">Тип бекапера данных</typeparam>
    public sealed class GetterBackuperHH : GetterBackuper<IEnumerable<Item>, LoggerCurrent, GetterHHData, SaverHHData>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db">Контекст данных для сохранений резервных данных и запили лога</param>
        /// <param name="rootLogger">Логгер вышестоящего действия</param>
        /// <param name="count">Количество записей</param>
        public GetterBackuperHH(ref CurrentDbContext db, int count, LoggerCurrent rootLogger = null)
        {
            Logger = new LoggerCurrent(ref db, rootLogger);
            Getter = new GetterHHData(ref db, Logger, count);
            Saver = new SaverHHData(ref db, Logger);
        }

        /// <summary>
        /// Сообщение для логгера
        /// </summary>
        public override string LoggerMessage => "Перенос и сохранение данных с сайта hh.ru";

        /// <summary>
        /// Источник данных
        /// </summary>
        public override string Source => "Данные с rest api hh.ru";
    }
}
