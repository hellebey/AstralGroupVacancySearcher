using AstralGroupVacancySearcher.Interfaces;
using System;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Реализация класса Getter с резервным копированием данных
    /// </summary>
    /// <typeparam name="TEntity">Тип возвращаемых данных</typeparam>
    /// <typeparam name="TLogger">Тип логера</typeparam>
    /// <typeparam name="TGetter">Тип получателя данных</typeparam>
    /// <typeparam name="TBackupper">Тип объекта для записи данных в резервное хранилище</typeparam>
    public abstract class GetterBackuper<TEntity, TLogger, TGetter, TBackupper> : IDataGetter<TEntity, TLogger>
                                                        where TLogger : ILogger
                                                        where TGetter : IDataGetter<TEntity, TLogger>
                                                        where TBackupper : IDataSaver<TEntity, TLogger>
    {
        /// <summary>
        /// Объект для записи логов
        /// </summary>
        protected TLogger Logger { get; set; }

        /// <summary>
        /// Объект для записи данных в резервное хранилище
        /// </summary>
        protected TBackupper Saver { get; set; }

        /// <summary>
        /// Объект для получения данных 
        /// </summary>
        protected TGetter Getter { get; set; }

        /// <summary>
        /// Сообщение для логгера
        /// </summary>
        public abstract string LoggerMessage { get; }

        /// <summary>
        /// Название источника данных
        /// </summary>
        public abstract string Source { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">Объект для записи логов</param>
        /// <param name="saver">Объект для записи данных в резервное хранилище</param>
        /// <param name="getter">Объект для получения данных</param>
        public GetterBackuper(TLogger logger, TBackupper saver, TGetter getter)
        {
            Logger = logger;
            Saver = saver;
            Getter = getter;
        }


        /// <summary>
        /// Получает данные и сохраняет их в резервное хранилище
        /// </summary>
        /// <returns></returns>
        public TEntity GetData()
        {
            try
            {
                Logger.StartLog(LoggerMessage);
                TEntity data = Getter.GetData();
                Saver.SaveData(data);
                Logger.StopLog(true);
                return data;
            }
            catch (Exception ex)
            {
                Logger.StopLog(false);
                throw new Exception("При получении данных возникла ошибка.", ex);
            }
        }

        protected GetterBackuper() : base()
        {
        }
    }
}
