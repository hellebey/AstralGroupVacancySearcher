using AstralGroupVacancySearcher.Interfaces;
using AstralGroupVacancySearcher.Models;
using AstralGroupVacancySearcher.Models.HHRestModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Класс для сохранения списка вакансий в бд
    /// </summary>
    public class SaverHHData : Saver<IEnumerable<Item>, LoggerCurrent>, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db">Контекст, в который будет сохранен список</param>
        /// <param name="rootLogger">Логгер вышестоящего действия</param>
        public SaverHHData(ref CurrentDbContext db, LoggerCurrent rootLogger)
        {
            _db = db;
            Logger = new LoggerCurrent(ref db, rootLogger);
        }

        /// <summary>
        /// Контекст, в который будет сохранен список
        /// </summary>
        private CurrentDbContext _db { get; set; }

        /// <summary>
        /// Сообщение для логгера
        /// </summary>
        public override string LoggerMessage => "Сохранение списка вакансий с сайта hh.ru в базу данных";

        
        public void Dispose()
        {
            _db.Dispose();
        }

        /// <summary>
        /// Сохранение данных (данный метод не сохраняет изменения в бд, для сохрарения изменений вызовите соотв. метод в переданном контексте)
        /// </summary>
        /// <param name="data">Список вакансий </param>
        protected override void SaveDataCurent(IEnumerable<Item> data)
        {
            foreach (Item vac in data)
            {
                ///ef core не поддерживает AddOrUpdate, далее задаются состояниия сущностям
                _db.UpdateEntityState(vac.address);
                _db.UpdateEntityState(vac.type);
                _db.UpdateEntityState(vac.employer);
                _db.UpdateEntityState(vac.contacts);
                _db.UpdateEntityState(vac);
                vac.log = Logger.LogData;
                _db.Entry(vac.log).State = EntityState.Added;
            }
        }
    }
}