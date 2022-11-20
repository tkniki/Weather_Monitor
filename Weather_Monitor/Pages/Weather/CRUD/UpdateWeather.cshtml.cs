using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Weather_Monitor.DbData;
using Weather_Monitor.Models;

namespace Weather_Monitor.Pages.Weather.CRUD
{
    public class UpdateWeatherModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        public WeatherData WeatherData { get; set; }
        public UpdateWeatherModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            WeatherData = _db.WeatherDatas.Find(id);

        }

        public async Task<IActionResult> OnPost()
        {
            //_db.Entry<WeatherData>(WeatherData).State = EntityState.Detached;
            
            if (!ModelState.IsValid || _db.WeatherDatas.Any(x => x.Id == WeatherData.Id) == false)
            {
                return Page();
            }

            _db.WeatherDatas.Update(WeatherData);
            await _db.SaveChangesAsync();
            return RedirectToPage("../Index");
        }
    }
}
