using Desáfio_Pokémon.Models;
using Desáfio_Pokémon.Models.API_s;
using Desáfio_Pokémon.Models.Pesquisa;
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

        public ViewResult Obter(string city)
        {
            try
            {
                string poketipo = "";
                ApiTempo api = new ApiTempo();
                dynamic resposta = api.getTempo(city);

                string strPegaTemp = resposta.main.temp.ToString();

                double qtipo = Convert.ToDouble(strPegaTemp);

                string chuva = resposta.weather[0].main.ToString();

                if (chuva == "Rain")
                {
                    poketipo = "13";

                    chuva = "está chovendo";

                }
                else
                {
                    chuva = "não está chovendo";

                    switch (qtipo)
                    {
                        case > 33:
                            poketipo = "9";
                            break;

                        case 33:
                            poketipo = "1";
                            break;

                        case >= 27:
                            poketipo = "6";
                            break;
                        case >= 23:
                            poketipo = "7";
                            break;
                        case >= 21:
                            poketipo = "1";
                            break;
                        case >= 15:
                            poketipo = "5";
                            break;
                        case >= 12:
                            poketipo = "12";
                            break;
                        case >= 10:
                            poketipo = "1";
                            break;
                        case >= 5:
                            poketipo = "11";
                            break;
                        case < 5:
                            poketipo = "15";
                            break;
                    }

                }

                ApiPokemon pokeApi = new ApiPokemon();
                dynamic restipo = pokeApi.getType(poketipo);
                string respostaPoke = "";


                dynamic pokemon = restipo.pokemon[Int32.Parse(new Random().NextInt64(restipo.pokemon.Count).ToString())].pokemon;

                respostaPoke = pokemon.name.ToString();

                dynamic resImgPoke = pokeApi.getPoke(respostaPoke);

                

                string imgUrl = resImgPoke.sprites.other.home.front_default.ToString();

                ViewBag.nomePokemon = respostaPoke.Replace('-', ' ');
                ViewBag.tempCity = strPegaTemp + " °C";
                ViewBag.taChovendo = chuva;
                ViewBag.nameCity = city;
                ViewBag.imagePoke = imgUrl;

                return View(@"\Views\Home\Obter.cshtml");

            }
            catch(Exception){

                return View(@"\Views\Home\SearchCity.cshtml");

                }



            }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}