using Microsoft.EntityFrameworkCore;
using Weather_Monitor.Models;

namespace Weather_Monitor.DbData
{
    public class AppDbContext : DbContext
    {
        // connection:
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<WeatherData> WeatherDatas { get; set; }

    }
}
