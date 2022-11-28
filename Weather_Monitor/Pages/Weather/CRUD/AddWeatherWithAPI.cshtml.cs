using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using Weather_Monitor.DbData;
using Weather_Monitor.Models;

namespace Weather_Monitor.Pages.Weather.CRUD
{
    public class AddWeatherWithAPIModel : PageModel
    {
        private HttpClient _client;
		private readonly AppDbContext _db;
        public AddWeatherWithAPIModel(HttpClient client, AppDbContext db)
        {
            _client = client;
            _db = db;
        }
		[BindProperty]
		public WeatherData WeatherData { get; set; }

		// Location data
		public double Lat { get; set; }
		public double Lon { get; set; }
        

        // Outdoor weather
        public double OutTemp { get; set; }
        public double OutPress { get; set; }
        public int OutRain { get; set; }

		public async Task<IActionResult> OnGetAsync(double latitude, double longitude)
		{
			WeatherData = new WeatherData();

			var response = await _client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid=ed3adae2b20a3ce0aee2eccc7e592c3a&units=metric");
			var result = await response.Content.ReadAsStringAsync();
			if (result != "[]")
			{
				JObject obj = JObject.Parse(result.ToString());
				//double lat = double.Parse((obj["lat"]).ToString());
				double temperature = double.Parse((obj["main"]["temp"]).ToString());
				double pressure = double.Parse((obj["main"]["pressure"]).ToString());
				//JToken token = obj["rain"]["rain1h"];

				int rain = obj.SelectToken("rain") == null ? 0 : (int)Math.Floor(double.Parse((obj["rain"]["rain1h"]).ToString()));

				WeatherData.OutCelsius = temperature;
				WeatherData.Pressure = pressure;
				WeatherData.Rain = rain;
			}
			else
			{
				return RedirectToPage("../MeasureOptions");
			}
			return Page();
		}
		/*public async void Ondsssssss(double temperature, double pressure, int rain)
        {
            if (temperature != 0 && pressure != 0 && rain != 0)
            {
				WeatherData.OutCelsius = temperature;
				WeatherData.Pressure = pressure;
				WeatherData.Rain = rain;
			}
        }*/

        /*public async Task<IActionResult> OnPost()
        {
            var response = await _client.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={City}&limit=1&appid=ed3adae2b20a3ce0aee2eccc7e592c3a");
            var result = await response.Content.ReadAsStringAsync();
            //JsonResult obj = JsonConvert.DeserializeObject<JsonResult>(result);
            if (result != "[]" || City.IsNullOrEmpty())
            {
                JArray array = JArray.Parse(result);
                JObject obj = JObject.Parse(array[0].ToString());
				double lat = double.Parse((obj["lat"]).ToString());
				double lon = double.Parse((obj["lon"]).ToString());

				Lat = lat;
				Lon = lon;
                SetOutdoorData(lat, lon);
                OutdoorDataReceived= true;
			}
            else
            {
                ModelState.AddModelError("City", "City name is incorrect.");
            }
            

            //return Page();

			return RedirectToPage("./AddWeatherWithAPI", "OutsideWeather", new { temperature = OutTemp, pressure = OutPress, rain = OutRain });
		}*/

        public async Task<IActionResult> OnPostAdd()
        {
			if (ModelState.IsValid)
			{
                await _db.WeatherDatas.AddAsync(WeatherData);
                await _db.SaveChangesAsync();
                return RedirectToPage("../Index");
            }
			else
			{
				return Page();
			}
		}

        
    }
}
