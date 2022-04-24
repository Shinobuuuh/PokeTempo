using Newtonsoft.Json;
using System.Net;
using Desáfio_Pokémon.Controllers;

namespace Desáfio_Pokémon.Models.API_s
{
    public class ApiPokemon
    {
        private string poketipo;

        public ApiPokemon(string poketipo)
        {
            this.poketipo = poketipo;
        }

        public dynamic getType()
        {            
            string result = " ";
            dynamic json;


            try
            {
                using (WebClient client = new WebClient())
                {
                    var url = "https://pokeapi.co/api/v2/type/" + this.poketipo/* PRECISO VER COMO PEGAR O RESULTADO LA DE QTIPO DO HOMECONTROLLER PRA CA */ ;

                    result = client.DownloadString(url);

                    json = JsonConvert.DeserializeObject(result);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return json;
        }


    }
}
