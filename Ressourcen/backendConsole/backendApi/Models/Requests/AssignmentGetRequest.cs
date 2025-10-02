namespace StempelAppCore.Models.Requests
{
    public class AssignmentGetRequest : BaseRequest
    {
        public int? AssignmentId { get; set; }
        public string? LocationName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}