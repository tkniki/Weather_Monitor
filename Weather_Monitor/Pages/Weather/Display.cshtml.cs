using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Weather_Monitor.DbData;
using Weather_Monitor.Models;

namespace Weather_Monitor.Pages.Weather
{
    public class DisplayModel : PageModel
    {
        private readonly AppDbContext _db;
        public IEnumerable<WeatherData> weatherDatas { get; set; }

        public List<SelectListItem> listItems = new List<SelectListItem>
        {
                new SelectListItem { Value = "0", Text = "All"},
                new SelectListItem { Value = "1", Text = "Only indoor"},
                new SelectListItem { Value = "2", Text = "Only outdoor"}
        };

        [BindProperty]

        public int SelectedListItemId { get; set; }

        public DisplayModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int filters)
        {
            weatherDatas = _db.WeatherDatas;
            SelectedListItemId = filters;
            listItems[filters].Selected = true;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage($"./Display?filters={SelectedListItemId}");
        }
    }
}

