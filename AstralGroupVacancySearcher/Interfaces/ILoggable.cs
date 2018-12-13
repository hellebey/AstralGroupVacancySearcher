namespace AstralGroupVacancySearcher.Interfaces
{
    /// <summary>
    /// Интерфейс для указания действия в логе
    /// </summary>
    public interface ILoggable
    {
        /// <summary>
        /// Сообщение для лога
        /// </summary>
        string LoggerMessage { get; }
    }
}
