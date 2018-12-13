using System.Collections.Generic;

namespace AstralGroupVacancySearcher.Interfaces
{
    /// <summary>
    /// Интерфейс для фильтрации коллекций
    /// </summary>
    /// <typeparam name="Tentity">Тип значений коллекции</typeparam>
    public interface IFilter<Tentity, TFilter>
    {
        /// <summary>
        /// Возвращает отфильтрованные данные
        /// </summary>
        /// <param name="source">Коллекция данных</param>
        /// <param name="filter">Параметны фильтрации</param>
        /// <returns>Отфильтрованные данные</returns>
        IEnumerable<Tentity> Filter(IEnumerable<Tentity> source, TFilter filter);
    }
}
