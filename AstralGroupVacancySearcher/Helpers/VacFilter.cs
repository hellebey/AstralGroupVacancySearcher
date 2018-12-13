using AstralGroupVacancySearcher.Interfaces;
using AstralGroupVacancySearcher.Models.HHRestModels;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Класс для фильтрации списка вакансий
    /// </summary>
    public sealed class VacFilter : IFilter<Item, Item>
    {
        public IEnumerable<Item> Filter(IEnumerable<Item> source, Item filter)
        {
            // зп от
            source = source.Where(s => filter.from.HasValue ? s.from >= filter.from : true);
            //зп до
            source = source.Where(s => filter.to.HasValue ? s.to <= filter.to : true);

            //дальнейшая фильтрация производится автоматически по полям типа string и bool?
            IEnumerable<PropertyInfo> propertyInfos = typeof(Item).GetProperties();
            object val;
            foreach (PropertyInfo pi in propertyInfos)
            {
                val = pi.GetValue(filter);
                if (pi.PropertyType == typeof(string))
                {
                    //если тип поля строка, то ищем вхождения
                    if (val != null && !string.IsNullOrEmpty(val as string))
                    {
                        source = source.Where(s => ((string)pi.GetValue(s)).Contains((string)val)).ToList();
                    }
                }
                else if (pi.PropertyType == typeof(bool?))
                {
                    //если тип поле bool? то ищем совпадения
                    if (((bool?)val).HasValue)
                    {
                        source = source.Where(s => ((bool?)pi.GetValue(s)).HasValue && ((bool?)pi.GetValue(s)).Value == (bool?)val).ToList();
                    }
                }
            }
            return source;
        }
    }
}
