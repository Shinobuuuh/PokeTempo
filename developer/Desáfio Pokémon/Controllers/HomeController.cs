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
            string poketipo = "";
            ApiTempo api = new ApiTempo();
            dynamic resposta = api.getTemp(city);

            string strPegaProvisorio = resposta.main.temp.ToString();
            double provisorioDouble = Convert.ToDouble(strPegaProvisorio);
            var qtipo = provisorioDouble;

            string chuva = resposta.weather[0].main.ToString();

            if (chuva == "Rain")
            {
                poketipo = "13";
            }
            else
            {
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

            ApiPokemon pokeApi = new ApiPokemon(poketipo);
            dynamic restipo = pokeApi.getType();
            string respostaPoke = "";

            Int64 posicao = new Random().NextInt64(restipo.pokemon.Count);

            Int32 posicaoFinal = Int32.Parse(posicao.ToString());

            dynamic pokemon = restipo.pokemon[posicaoFinal].pokemon;

            respostaPoke = pokemon.name.ToString();

            ViewBag.nomePokemon = respostaPoke;           

            return View(@"\Views\Home\Obter.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}