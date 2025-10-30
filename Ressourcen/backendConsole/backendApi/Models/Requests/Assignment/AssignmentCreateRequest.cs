using StempelAppCore.Models.Domain;

namespace StempelAppCore.Models.Requests.Assignment
{
    public class AssignmentCreateRequest : BaseRequest
    {
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public string? Comment { get; set; }
        public bool PictureRequired { get; set; } = false;
        public DateTime? TimeStamp { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}