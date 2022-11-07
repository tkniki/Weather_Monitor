using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Weather_Monitor.DbData;
using Weather_Monitor.Models;

namespace Weather_Monitor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        /*public IndexModel(AppDbContext db)
        {
        }*/

        private readonly AppDbContext _db;
        public IEnumerable<IndoorData> indoorDatas { get; set; }
        public IEnumerable<OutdoorData> outdoorDatas { get; set; }

        public void OnGet()
        {
            indoorDatas = _db.indoorDatas;
            outdoorDatas = _db.outdoorDatas;
        }
    }
}