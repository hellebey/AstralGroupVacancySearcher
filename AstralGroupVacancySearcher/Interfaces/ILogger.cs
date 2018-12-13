namespace AstralGroupVacancySearcher.Interfaces
{
    /// <summary>
    /// Интерфейс для сборщика логов
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Начать  сборку лога
        /// </summary>
        /// <param name="message">Сообщение о действии</param>
        void StartLog(string message);
        /// <summary>
        /// Завершить сборку логга
        /// </summary>
        /// <param name="isComplite">Флаг успешнойсти выполнений действия</param>
        void StopLog(bool isComplite);
    }
}
