using System.Data.Common;

namespace StempelAppCore.Models.Domain
{
    public partial class UserAssignment : BaseEntity
    {
        public int UserId { get; set; }
        public LocationData Location { get; set; }
        public string? Comment { get; set; }
        public byte[]? Picture { get; set; }
        public DateTime? AssignmentTimeStamp { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? AssignmentDuration => EndTime - StartTime;
        public virtual AppUser User { get; set; }
    }
}