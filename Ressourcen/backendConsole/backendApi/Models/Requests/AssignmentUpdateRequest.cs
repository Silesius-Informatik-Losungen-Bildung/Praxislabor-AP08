namespace StempelAppCore.Models.Requests
{
    public class AssignmentUpdateRequest : BaseRequest
    {
        public string? NewLocationName { get; set; }
        public string? NewComment { get; set; }
        public DateTime? NewTimeStamp { get; set; }
        public DateTime? NewStartTime { get; set; }
        public DateTime? NewEndTime { get; set; }
        public TimeSpan? NewWorkTime => NewEndTime - NewStartTime;
    }
}