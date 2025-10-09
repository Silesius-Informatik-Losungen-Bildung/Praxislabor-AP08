namespace StempelAppCore.Models.Requests.Assignment
{
    public class AssignmentListRequest : BaseRequest
    {
        public List<int>? AssignmentIds { get; set; }
        public List<string>? LocationNames { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}