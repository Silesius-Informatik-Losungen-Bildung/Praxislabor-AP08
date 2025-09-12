using backendConsoleDemo.Models.Interfaces;

namespace backendConsoleDemo.Models
{
    public class EntrySpan : IEntry
    {
        public int EntryId { get; set; }
        public int EmployeeId { get; set; }
        public double GPSLongitude { get; set; }
        public double GPSLatitude { get; set; }
        public string? Comment { get; set; }
        public byte[]? Picture { get; set; }
        //public DateTime StartTime { get; set; }
        //public DateTime EndTime { get; set; }
        //public TimeSpan WorkTime => EndTime - StartTime;
    }
}
