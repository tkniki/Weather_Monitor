namespace Weather_Monitor
{
    public class AverageTempPerDay
    {
        public DateTime Date { get; set; }
        public double AverageTempInside { get; set; }
        public double AverageTempOutside { get; set; }

        public AverageTempPerDay(DateTime date, double averageTempInside, double averageTempOutside)
        {
            Date = date;
            AverageTempInside = Math.Round(averageTempInside, 2);
            AverageTempOutside = Math.Round(averageTempOutside, 2);
        }
    }
}
