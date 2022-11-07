using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_Monitor.Models
{
    public class IndoorData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Kelvin { get; set; }
        [Required]
        public int Humidity { get; set; }
    }
}
