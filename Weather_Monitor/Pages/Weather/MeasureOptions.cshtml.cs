using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Weather_Monitor.DbData;

namespace Weather_Monitor.Pages.Weather
{
    public class MeasureOptionsModel : PageModel
    {
		private HttpClient _client;
		private readonly AppDbContext _db;
		[BindProperty]
		public string City { get; set; }
		public MeasureOptionsModel(HttpClient client, AppDbContext db)
		{
			_client= client;
			_db= db;
		}
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
			var response = await _client.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={City}&limit=1&appid=ed3adae2b20a3ce0aee2eccc7e592c3a");
			var result = await response.Content.ReadAsStringAsync();
			if (result != "[]" || City.IsNullOrEmpty())
			{
				JArray array = JArray.Parse(result);
				JObject obj = JObject.Parse(array[0].ToString());
				double lat = double.Parse((obj["lat"]).ToString());
				double lon = double.Parse((obj["lon"]).ToString());


				return RedirectToPage("CRUD/AddWeatherWithAPI", "", new { latitude = lat, longitude = lon });
			}
			else
			{
				ModelState.AddModelError("City", "City name is incorrect.");
				return Page();
			}

		}
    }
}
