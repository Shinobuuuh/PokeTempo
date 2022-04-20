using Desáfio_Pokémon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Desáfio_Pokémon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }   

        public IActionResult SearchCity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(string city)
        {
            return Content($"Cidade Pesquisada : {city}");
        }






        public JsonResult GetWeather()
        {
            Weather weath = new Weather();
            return Json(weath.getWeatherForcast(), new Newtonsoft.Json.JsonSerializerSettings());

        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}