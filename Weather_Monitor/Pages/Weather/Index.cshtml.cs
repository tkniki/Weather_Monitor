using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Weather_Monitor.DbData;
using Weather_Monitor.Models;

namespace Weather_Monitor.Pages.Weather
{
    public class IndexModel : PageModel
    {

        private readonly AppDbContext _db;
        public IEnumerable<WeatherData> weatherDatas { get; set; }
        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            weatherDatas = _db.weatherDatas;
        }
    }
}
