using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Desáfio_Pokémon.Models.Pesquisa
{
    public class ApiTempo
    {
        public dynamic getTemp(string campoPesquisa)
        {
            string appid = "14e8cc4f572cda2940a964a98c5b4994";
            string result = " ";
            dynamic json;

            try
            {
                using (WebClient client = new WebClient())
                {
                    var url = "http://api.openweathermap.org/data/2.5/weather?q=" + campoPesquisa + "&appid=" + appid + "&units=metric";

                    result = client.DownloadString(url);

                    json = JsonConvert.DeserializeObject(result);
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
            return json;
        }



    }
}
