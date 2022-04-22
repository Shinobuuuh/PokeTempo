using Newtonsoft.Json;
using System.Net;

namespace Desáfio_Pokémon.Models.API_s
{
    public class ApiPokemon
    {
        public dynamic getType()
        {            
            string result = " ";
            dynamic json;

            try
            {
                using (WebClient client = new WebClient())
                {
                    var url = "https://pokeapi.co/api/v2/type/" + "13/";

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
