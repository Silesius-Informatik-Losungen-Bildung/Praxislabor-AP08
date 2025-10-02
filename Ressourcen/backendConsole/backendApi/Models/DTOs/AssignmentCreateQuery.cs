namespace StempelAppCore.Models.DTOs
{
    public class AssignmentCreateQuery : BaseQuery
    {
        public int? UserId { get; set; }
        public double? GPSLongitude { get; set; }
        public double? GPSLatitude { get; set; }
        public string? Comment { get; set; }
        public byte[]? Picture { get; set; }
        public DateTime? TimeStamp { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? WorkTime => EndTime - StartTime;
    }
}