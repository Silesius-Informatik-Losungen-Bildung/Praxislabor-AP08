namespace backendConsoleDemo.Models
{
    public class Entry : BaseEntry
    {
        public DateTime? TimeStamp { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? WorkTime => EndTime - StartTime;
        public virtual User User { get; set; }
    }
}