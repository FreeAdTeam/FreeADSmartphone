using Newtonsoft.Json;
using PhoneApp.Helpers;
using PhoneApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp.ViewModels
{
    public class MainViewModel
    {
        public string Keyword { get; set; }
        public async Task<List<Advertisement>> Ads()
        {

            var client = ADHttpClient.GetClient();
            var egsResponse = await client.GetAsync("api/category/0/advertisements?fields=id,keyword,shortdescription,categoryid");
            if (egsResponse.IsSuccessStatusCode)
            {
                string egsContent = await egsResponse.Content.ReadAsStringAsync();
                var lst = JsonConvert
                    .DeserializeObject<List<Advertisement>>(egsContent);
                return lst;
            }
            else
            {
                return null;
            }
        }
    }
}
