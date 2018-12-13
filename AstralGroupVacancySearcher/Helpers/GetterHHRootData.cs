using AstralGroupVacancySearcher.Models;
using AstralGroupVacancySearcher.Models.HHRestModels;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Класс для получения корневых данных с rest api hh.ru
    /// </summary>
    public sealed class GetterHHRootData : GetterRest<HHRootData, LoggerCurrent>
    {
        /// <summary>
        /// Кол-во вакансий, которое нужно получить
        /// </summary>
        private int _pageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db">Контекст данных для сохранений резервных данных и запили лога</param>
        /// <param name="rootLogger">Логгер вышестоящего действия</param>
        /// <param name="count">Количество вакансий, которое нужно получить</param>
        public GetterHHRootData(ref CurrentDbContext db, LoggerCurrent rootLogger, int count)
        {
            _pageSize = count;
            Logger = new LoggerCurrent(ref db, rootLogger);
        }

        /// <summary>
        /// Сообщенние для логгера
        /// </summary>
        public override string LoggerMessage => "Получение объекта, содержащего в себе список вакансий  с rest api hh.ru";

        /// <summary>
        /// Ссылка для доступа к api
        /// </summary>
        protected override string Endpoint => $"https://api.hh.ru/vacancies?per_page={_pageSize}";

        /// <summary>
        /// Данные для отправки
        /// </summary>
        protected override string QueryData => string.Empty;

        /// <summary>
        /// Источник данных
        /// </summary>
        public override string Source => "Корневые данные с сайта hh.ru";

        /// <summary>
        /// Добавление необходимой для выполнений запроса информации
        /// </summary>
        protected override void SetuptClient()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "hhVacLoader/1.0 (helle6ey@gmail.com)");
        }
    }
}
