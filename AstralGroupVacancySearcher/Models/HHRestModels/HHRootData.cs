using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstralGroupVacancySearcher.Models.HHRestModels
{
    public class HHRootData
    {
        public List<Item> items { get; set; }
        public int found { get; set; }
        public int pages { get; set; }
        public int per_page { get; set; }
        public int page { get; set; }
    }
}
