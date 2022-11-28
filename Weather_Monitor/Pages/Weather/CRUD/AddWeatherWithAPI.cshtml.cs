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
