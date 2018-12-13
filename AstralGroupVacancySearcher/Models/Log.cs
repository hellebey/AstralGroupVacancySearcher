using AstralGroupVacancySearcher.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AstralGroupVacancySearcher.Models
{
    /// <summary>
    /// Модель данных в текущей бд
    /// </summary>
    public class Log : ILogData
    {
        public long id { get; set; }
        public ICollection<Log> Children { get; set; }
        [JsonIgnore]
        public Log Parent { get; set; }
        public bool? IsSuccess { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
