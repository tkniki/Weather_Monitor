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
        [Required]
        public double InCelsius { get; set; }
        [Required]
        public int Humidity { get; set; }


        [Required]
        public double OutCelsius { get; set; }
        [Required]
        public double Pressure { get; set; }
        [Required]
        public int Rain { get; set; }
    }
}
