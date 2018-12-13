using AstralGroupVacancySearcher.Interfaces;
using System;

namespace AstralGroupVacancySearcher.Helpers
{

    /// <summary>
    /// Класс для сохранения данных
    /// </summary>
    /// <typeparam name="TResult">Тип возвращаемого значения</typeparam>
    /// <typeparam name="TLogger">Тип логирования</typeparam>
    public abstract class Saver<TResult, TLogger> : IDataSaver<TResult, TLogger> where TLogger : ILogger
    {
        /// <summary>
        /// Объект, записывающий логи выволнения выгрузки
        /// </summary>
        protected TLogger Logger { get; set; }

        /// <summary>
        /// Сообщение для логгера
        /// </summary>
        public abstract string LoggerMessage { get; }

        /// <summary>
        /// Метод для реализации сохранения данных
        /// </summary>
        protected abstract void SaveDataCurent(TResult data);

        /// <summary>
        /// Метод для сохранения данных с логированием
        /// </summary>
        public void SaveData(TResult data)
        {
            try
            {
                Logger.StartLog(LoggerMessage);
                SaveDataCurent(data);
                Logger.StopLog(true);
            }
            catch (Exception ex)
            {
                Logger.StopLog(false);
                throw new Exception("Не удалось получить данные.", ex);
            }
        }
    }
}
