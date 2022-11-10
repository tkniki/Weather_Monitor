using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weather_Monitor.DbData;
using Weather_Monitor.Models;

namespace Weather_Monitor.Pages.Weather.CRUD
{
    public class AddWeatherModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public WeatherData WeatherData { get; set; }
        public AddWeatherModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            /*if (Check)
            {

            }*/
            await _db.weatherDatas.AddAsync(WeatherData);
            await _db.SaveChangesAsync();
            return RedirectToPage("../Index");
        }
    }
}
