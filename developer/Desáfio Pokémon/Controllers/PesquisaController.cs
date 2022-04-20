using Microsoft.AspNetCore.Mvc;
using Desáfio_Pokémon.Models.Pesquisa;

namespace Desáfio_Pokémon.Controllers
{
    public class PesquisaController : Controller
    {
        [HttpPost]
        public IActionResult Index(/*string city*/)
        {
            return View();
            
        }
        

/*
        public JsonResult Pesquisar()
        {
            ApiTempo temp = new ApiTempo();
            return Json(temp.getTemp(), new Newtonsoft.Json.JsonSerializerSettings());
        }
*/
    }
}
