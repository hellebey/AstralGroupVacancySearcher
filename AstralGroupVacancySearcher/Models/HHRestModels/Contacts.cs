using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstralGroupVacancySearcher.Models.HHRestModels
{
    public class Contacts
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public List<Phone> phones { get; set; }
    }
}
