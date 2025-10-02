namespace StempelAppCore.Models.Responses
{
    public class AssignmentCreateResponse : BaseResponse
    {
        public int UserId { get; set; }
        public LocationData Location { get; set; }
        public string? Comment { get; set; }
        public byte[]? Picture { get; set; }
        public DateTime? TimeStamp { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? WorkTime => EndTime - StartTime;
    }
}