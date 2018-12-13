using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstralGroupVacancySearcher.Models.HHRestModels
{
    public class Address
    {
        public string city { get; set; }
        public string street { get; set; }
        public string building { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }
        public string raw { get; set; }
        public string id { get; set; }
    }
}
