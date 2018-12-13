namespace AstralGroupVacancySearcher.Interfaces
{
    /// <summary>
    /// Интерфейс для сохранения данных
    /// </summary>
    /// <typeparam name="TEntity">Тип сохраняемого значения</typeparam>
    /// <typeparam name="TLogger">Тип,который будет использоваться для логирования</typeparam>
    public interface IDataSaver<TEntity, TLogger> : ILoggable where TLogger : ILogger
    {
        /// <summary>
        /// Сохраняет данные в хранилище
        /// </summary>
        /// <param name="data">Данные</param>
        void SaveData(TEntity data);
    }
}
