using AstralGroupVacancySearcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstralGroupVacancySearcher.Models
{

    /// <summary>
    /// Класс для результатов rest api
    /// </summary>
    public class JsonData : IJsonResult
    {
        public JsonData()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error">Флаг присутствия ошибки</param>
        /// <param name="data">Данные</param>
        /// <param name="additionalData">Дополнительная информация</param>
        public JsonData(bool error, object data, object additionalData)
        {
            this.error = error;
            this.data = data;
            this.additionalData = additionalData;
        }

        /// <summary>
        /// Флаг присутствия ошибки
        /// </summary>
        public bool error { get; set; }
        /// <summary>
        /// Данные
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public object additionalData { get; set; }
    }
}
