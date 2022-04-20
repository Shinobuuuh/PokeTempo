using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Desáfio_Pokémon.Models.Pesquisa
{
    public class ApiTempo
    {
        public Object getTemp()
        {


            string city = "Campinas";
            string appid = "14e8cc4f572cda2940a964a98c5b4994";
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + " &APPID=" + appid + "&units=metric";

            var client = new WebClient();
            var content = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<Object>(content);


            return jsonContent;
        }



    }
}
