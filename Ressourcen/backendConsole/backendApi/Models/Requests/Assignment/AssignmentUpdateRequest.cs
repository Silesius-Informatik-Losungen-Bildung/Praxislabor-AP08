namespace StempelAppCore.Models.Requests.Assignment
{
    public class AssignmentUpdateRequest : BaseRequest
    {
        public int? NewLocationId { get; set; }
        public int? NewUserId { get; set; }
        public string? NewComment { get; set; }
        public int? PictureId { get; set; }
        public DateTime? NewTimeStamp { get; set; }
        public DateTime? NewStartTime { get; set; }
        public DateTime? NewEndTime { get; set; }
        public TimeSpan? NewWorkTime => NewEndTime - NewStartTime;
    }
}