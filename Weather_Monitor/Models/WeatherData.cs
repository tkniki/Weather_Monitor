using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_Monitor.Models
{
    public class WeatherData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Range(-70,50)]
        [Required]
        public double InCelsius { get; set; }
        [Range(0, 100)]
        [Required]
        public int Humidity { get; set; }

        [Range(-70, 50)]
        [Required]
        public double OutCelsius { get; set; }
        [Range(0,2000)]
        [Required]
        public double Pressure { get; set; }
        [Range(0, 300)]
        [Required]
        public int Rain { get; set; }
    }
}
