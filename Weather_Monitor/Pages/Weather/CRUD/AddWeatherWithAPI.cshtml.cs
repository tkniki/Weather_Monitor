using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace Weather_Monitor.Pages.Weather.CRUD
{
    public class AddWeatherWithAPIModel : PageModel
    {
        private HttpClient _client;
        public AddWeatherWithAPIModel(HttpClient client)
        {
            _client = client;
        }

        [BindProperty]
        public string City { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _client.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={City}&limit=1&appid=ed3adae2b20a3ce0aee2eccc7e592c3a");
            var result = await response.Content.ReadAsStringAsync();
            JArray array = JArray.Parse(result);
            JObject obj = JObject.Parse(array[0].ToString());
            //JsonResult obj = JsonConvert.DeserializeObject<JsonResult>(result);
            double lat = double.Parse((obj["lat"]).ToString());
            double lon = double.Parse((obj["lon"]).ToString());

            Lat = lat;
            Lon = lon;

            return Page();
		}

        
    }
}
