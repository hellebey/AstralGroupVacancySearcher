using Newtonsoft.Json;
using System;

namespace AstralGroupVacancySearcher.Models.HHRestModels
{
    public class Item
    {

        [JsonIgnore]
        public Log log { get; set; }

        public string id { get; set; }
        public bool? premium { get; set; }
        public string name { get; set; }
        public bool? has_test { get; set; }
        public bool? response_letter_required { get; set; }
        public Type type { get; set; }
        public Address address { get; set; }
        public Employer employer { get; set; }
        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }
        public bool? archived { get; set; }
        public string apply_alternate_url { get; set; }
        public string url { get; set; }
        public string alternate_url { get; set; }
        public Contacts contacts { get; set; }
        [JsonProperty("salary.from")]
        public int? from { get; set; }
        [JsonProperty("salary.to")]
        public int? to { get; set; }
    }
}
