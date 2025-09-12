using StempelApp.Models.Interfaces;

namespace StempelApp.Models
{
    public class EntryStamp : IEntry
    {
        public int EntryId { get; set; }
        public int EmployeeId { get; set; }
        public double GPSLongitude { get; set; }
        public double GPSLatitude { get; set; }
        public string? Comment { get; set; }
        public byte[]? Picture { get; set; }
        //public DateTime TimeStamp { get; set; }
    }
}