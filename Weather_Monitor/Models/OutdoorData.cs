using System.ComponentModel.DataAnnotations;

namespace Weather_Monitor.Models
{
    public class OutdoorData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Kelvin { get; set; }
        [Required]
        public double Pressure { get; set; }
        [Required]
        public int Rain { get; set; }

    }
}
