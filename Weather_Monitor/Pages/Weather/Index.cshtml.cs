using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Weather_Monitor.DbData;
using Weather_Monitor.Models;

namespace Weather_Monitor.Pages.Weather
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public IEnumerable<WeatherData> weatherDatas { get; set; }

        public List<SelectListItem> listItems = new List<SelectListItem>
        {
                new SelectListItem { Value = "0", Text = "All"},
                new SelectListItem { Value = "1", Text = "Only indoor"},
                new SelectListItem { Value = "2", Text = "Only outdoor"},
                new SelectListItem { Value = "3", Text = "Average temperature"}
        };

        [BindProperty]
        public int SelectedListItemId { get; set; }
        [BindProperty]
        public DateTime From { get; set; }
        [BindProperty]
        public DateTime To { get; set; }
        public bool TimeRange = false;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int filters, DateTime from, DateTime to)
        {
            /* DateTime.Compare(a, b) returns
             *  - when a < b
             * 0 when a = b
             * + when a > b 
            */
            if (from != DateTime.MinValue && to != DateTime.MaxValue)
            {
                weatherDatas = _db.WeatherDatas.Where(x => DateTime.Compare(from, x.Date) <= 0 && DateTime.Compare(to, x.Date) >= 0);
                From = from;
                To = to;
                TimeRange = true;
            }
            else
            {
                weatherDatas = _db.WeatherDatas;

                var dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTimeKind.Unspecified);
                var dateAWeekAgo = dateNow.AddDays(-7);
                From = dateAWeekAgo;
                To = dateNow;
                TimeRange = false;
            }

            SelectedListItemId = filters;
            listItems[filters].Selected = true;
        }

        public IActionResult OnPostFilter()
        {
            //return RedirectToPage($"./Index?filters={SelectedListItemId}");
            return RedirectToPage("./Index", "Filter", new { filters = SelectedListItemId, from = From, to = To });

            
        }
    }
}

