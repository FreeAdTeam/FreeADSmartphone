using Newtonsoft.Json;
using PhoneApp.Helpers;
using PhoneApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhoneApp.ViewModels
{
    public class HomeViewModel
    {
		public async Task<List<Advertisement>> Ads(string category=null,string search="none")
        {
			var categoryId = 0;
			switch (category) {
			case "All":
				categoryId = 0;
				break;
			case "Companies":
				categoryId = 2;
				break;
			case "Recruits":
				categoryId = 4;
				break;
			case "RentRooms":
				categoryId = 6;
				break;
			case "Products":
				categoryId = 7;
				break;
			case "PersonalInfo":
				categoryId = 18;
				break;
			default:
				categoryId = 0;
				break;
			}
            var client = ADHttpClient.GetClient();
			var egsResponse = await client.GetAsync("api/category/"+categoryId.ToString()+"/advertisements?search="+search+"&fields=id,keyword,shortdescription,categoryid");
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
