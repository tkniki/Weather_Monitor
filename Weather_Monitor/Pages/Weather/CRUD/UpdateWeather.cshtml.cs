using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weather_Monitor.DbData;
using Weather_Monitor.Models;

namespace Weather_Monitor.Pages.Weather.CRUD
{
    public class UpdateWeatherModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        public WeatherData weatherData { get; set; }
        public UpdateWeatherModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            weatherData = _db.WeatherDatas.Find(id);

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.WeatherDatas.Update(weatherData);
            await _db.SaveChangesAsync();
            return RedirectToPage("../Index");
        }
    }
}
