using AstralGroupVacancySearcher.Helpers;
using AstralGroupVacancySearcher.Models;
using AstralGroupVacancySearcher.Models.HHRestModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AstralGroupVacancySearcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get([FromQuery]Item filter)
        {
            JsonData result = new JsonData();
            try
            {
                TrustedDataGetterCurrent gg = new TrustedDataGetterCurrent();
                result.data = gg.GetData(filter);
                result.additionalData = new { source = gg.Source };
                gg.SaveAllChanges();
            }
            catch
            {
                result.error = true;
                result.additionalData = new { errorMesage = "Не удалось получить данные" };
            }
            return JsonConvert.SerializeObject(result);
        }
    }
}
