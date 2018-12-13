namespace AstralGroupVacancySearcher.Interfaces
{
    /// <summary>
    /// Интерфейс для получения данных
    /// </summary>
    /// <typeparam name="TRelult">Тип возвращаемого значения</typeparam>
    /// <typeparam name="TLogger">Тип,который будет использоваться для логирования</typeparam>
    public interface IDataGetter<TRelult, TLogger> : ILoggable
    {
        /// <summary>
        /// Источник данных
        /// </summary>
        string Source { get; }
        /// <summary>
        /// Метод для получения данных
        /// </summary>
        /// <returns>Найденное значение</returns>
        TRelult GetData();
    }

    /// <summary>
    /// Интерфейс для получения данных и их дальшейшей фильтрации
    /// </summary>
    /// <typeparam name="TRelult">Тип возвращаемого значения</typeparam>
    /// <typeparam name="TLogger">Тип,который будет использоваться для логирования</typeparam>
    /// <typeparam name="TFilter">Тип, в котором передадутся данные для фильтрации</typeparam>
    public interface IDataGetter<TRelult, TFilter, TLogger> : IDataGetter<TRelult, TLogger>
    {
        /// <summary>
        /// Возврвщает отфильтрованные данные
        /// </summary>
        /// <param name="filter">Параметры фильтрации</param>
        /// <returns>Отфильтрованные данные</returns>
        TRelult GetData(TFilter filter);
    }
}
