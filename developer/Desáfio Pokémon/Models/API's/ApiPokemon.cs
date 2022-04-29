using Newtonsoft.Json;
using System.Net;
using Desáfio_Pokémon.Controllers;

namespace Desáfio_Pokémon.Models.API_s
{
    public class ApiPokemon
    {
        public dynamic getType(string poketipo)
        {
            string result = " ";
            dynamic json;

            try
            {
                //var client tipo WebClient será utilizada somente aqui
                using (WebClient client = new WebClient())
                {
                    result = client.DownloadString("https://pokeapi.co/api/v2/type/" + poketipo);

                    json = JsonConvert.DeserializeObject(result);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return json;
        }


        public dynamic getPoke(string respostapoke)
        {

            string result = " ";
            dynamic json;

            try
            {                
                using (WebClient client = new WebClient())
                {
                    result = client.DownloadString("https://pokeapi.co/api/v2/pokemon/" + respostapoke);

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
