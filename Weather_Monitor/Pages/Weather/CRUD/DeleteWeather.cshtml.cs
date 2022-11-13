using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weather_Monitor.DbData;
using Weather_Monitor.Models;

namespace Weather_Monitor.Pages.Weather.CRUD
{
    public class RemoveWeatherModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        public WeatherData WeatherData { get; set; }
        public RemoveWeatherModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            WeatherData = _db.WeatherDatas.Find(id);

        }

        public async Task<IActionResult> OnPost()
        {
            WeatherData data = _db.WeatherDatas.Find(WeatherData.Id);
            if (data != null)
            {
                _db.WeatherDatas.Remove(data);
                await _db.SaveChangesAsync();
                return RedirectToPage("../Index");
            }
            return Page();
        }
    }
}
