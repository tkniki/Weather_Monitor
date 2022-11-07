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
        public IEnumerable<IndoorData> indoorDatas { get; set; }
        public IEnumerable<OutdoorData> outdoorDatas { get; set; }
        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            indoorDatas = _db.indoorDatas;
            outdoorDatas = _db.outdoorDatas;
        }
    }
}
