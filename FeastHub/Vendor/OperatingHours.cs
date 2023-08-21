namespace FeastHub
{
    public class OperatingHours
    {
       public int OperatingHoursId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
    }
}