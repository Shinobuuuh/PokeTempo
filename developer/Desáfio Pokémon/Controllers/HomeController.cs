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

        public IActionResult Obter(string city)
        {

            string poketipo = "";

            var api = new ApiTempo();
            var resposta = api.getTemp(city);



            /*            try
                        {
                            return View(@"\Views\Home\Obter.cshtml", resposta.main.temp.ToString());
                        }
                        catch (Exception ex)
                        {
                            return View(@"\Views\Home\SearchCity.cshtml", ex.Message);
                        }
            */


            
            

            string strPegaProvisorio = resposta.main.temp.ToString();

            double provisorioDouble = Convert.ToDouble(strPegaProvisorio);


            var qtipo = provisorioDouble;

            
            // PRECISO CONVERTER A TEMP PARA INT MAS TA DANDO ERRO PQ O INT32.PARSE SÓ ACEITA INTEIRO

            switch (qtipo)
            {
                case < 12: poketipo = "13";
                    break;
                case >= 12: poketipo = "17";
                    break;

            }



            var pokeApi = new ApiPokemon(poketipo);
            var restipo = pokeApi.getType();            
            
            var respostaPoke = string.Empty;

            var posicao = new Random().NextInt64(restipo.pokemon.Count);

            var pokemon = restipo.pokemon[Int32.Parse(posicao.ToString())].pokemon;

            respostaPoke = pokemon.name.ToString();

            return View(@"\Views\Home\Obter.cshtml", respostaPoke);





        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}