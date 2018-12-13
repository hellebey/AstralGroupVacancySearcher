using AstralGroupVacancySearcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Класс для получения данных одного типа из хотя бы одного указанного источника
    /// </summary>
    /// <typeparam name="TResult">Тип возвращаемого значения</typeparam>
    /// <typeparam name="TLoger">Тип логгера</typeparam>
    public class TrustedDataGetter<TResult, TLoger> : Getter<TResult, TLoger> where TLoger : ILogger
    {
        /// <summary>
        /// Название источника данных, с кторого получилось получить сведения
        /// </summary>
        private string _source { get; set; }
        public override string Source => _source;

        /// <summary>
        /// Сообщение для лога
        /// </summary>
        public override string LoggerMessage => "Получение списка вакансий с резервным источником данных.";

        /// <summary>
        /// Список источников данных
        /// </summary>
        protected Queue<IDataGetter<TResult, TLoger>> Getters { get; set; }

        /// <summary>
        /// Попытки получить данные из указанных источников, пока хотябы один их не вернет, или пока источники не закончатся
        /// </summary>
        /// <returns></returns>
        protected override TResult GetCurrentData()
        {
            IDataGetter<TResult, TLoger> getter;
            TResult data;
            while (Getters.Any())
            {
                getter = Getters.Dequeue();
                try
                {
                    data = getter.GetData();
                    if (data != null)
                    {
                        _source = getter.Source;
                        Logger.StopLog(true);
                        return data;
                    }
                }
                catch
                {
                }
            }
            throw new Exception("Не удалось получить данные ни из одного источника.");
        }
    }
}
