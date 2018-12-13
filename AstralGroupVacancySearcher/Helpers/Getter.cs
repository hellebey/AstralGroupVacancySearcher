using AstralGroupVacancySearcher.Interfaces;
using System;

namespace AstralGroupVacancySearcher.Helpers
{

    /// <summary>
    /// Класс для получения данных из внешних источников
    /// </summary>
    /// <typeparam name="TResult">Тип возвращаемого значения</typeparam>
    /// <typeparam name="TLogger">Тип логирования</typeparam>
    public abstract class Getter<TResult, TLogger> : IDataGetter<TResult, TLogger> where TLogger : ILogger
    {
        /// <summary>
        /// Создание с объектом-логгером
        /// </summary>
        /// <param name="logger">Объект, записывающий логи выволнения выгрузки</param>
        protected Getter(TLogger logger)
        {
            Logger = logger;
        }

        protected Getter() { }

        /// <summary>
        /// Объект, записывающий логи выволнения выгрузки
        /// </summary>
        protected TLogger Logger { get; set; }

        /// <summary>
        /// Сообщение для логгера
        /// </summary>
        public abstract string LoggerMessage { get; }

        /// <summary>
        /// Название источника данных
        /// </summary>
        public abstract string Source { get; }

        /// <summary>
        /// Метод для получения данных без логирования
        /// </summary>
        /// <returns>Искомые данные</returns>
        protected abstract TResult GetCurrentData();

        /// <summary>
        /// Метод для получения данных с логированием
        /// </summary>
        /// <returns>Искомые данные</returns>
        public TResult GetData()
        {
            try
            {
                Logger.StartLog(LoggerMessage);
                TResult data = GetCurrentData();
                Logger.StopLog(true);
                return data;
            }
            catch (Exception ex)
            {
                Logger.StopLog(false);
                throw new Exception("Не удалось получить данные.", ex);
            }
        }
    }
}
