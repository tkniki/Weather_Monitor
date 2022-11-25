using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Weather_Monitor.Pages.Weather
{
    [BindProperties]
    public class TimeRangeModel : PageModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public void OnGet()
        {
        }

    }
}
