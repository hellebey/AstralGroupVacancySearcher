using AstralGroupVacancySearcher.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult">Тип возвращаемого значения</typeparam>
    /// <typeparam name="TLogger">Тип логгера</typeparam>
    public abstract class GetterRest<TResult, TLogger> : Getter<TResult, TLogger>, IDisposable where TLogger : ILogger
    {
        /// <summary>
        /// Клиент для отправки запросов
        /// </summary>
        protected HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Добавление необходимой для выполнений запроса информации
        /// </summary>
        protected abstract void SetuptClient();

        /// <summary>
        /// Ссылка для доступа к api
        /// </summary>
        protected abstract string Endpoint { get; }

        /// <summary>
        /// Данные для отправки
        /// </summary>
        protected abstract string QueryData { get; }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        /// <summary>
        /// Получение и сериализация данных с api
        /// </summary>
        /// <returns></returns>
        protected override TResult GetCurrentData()
        {
            SetuptClient();
            string reult = httpClient.GetStringAsync(Endpoint).Result;
            return JsonConvert.DeserializeObject<TResult>(reult);
        }
    }
}
