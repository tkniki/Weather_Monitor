namespace Weather_Monitor.Models
{
    public class IndoorData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Temperature Temperature { get; set; }
        public int Humidity { get; set; }
    }
}
