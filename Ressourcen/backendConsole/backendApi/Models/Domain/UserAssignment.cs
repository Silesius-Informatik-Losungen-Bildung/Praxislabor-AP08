using System.Data.Common;

namespace StempelAppCore.Models.Domain
{
    public partial class UserAssignment : BaseEntity
    {
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public string? Comment { get; set; }
        public bool PictureRequired { get; set; } = false;
        public int? PictureId { get; set; }
        public DateTime? AssignmentTimeStamp { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? AssignmentDuration => EndTime - StartTime;
        public virtual AppUser User { get; set; }
        public virtual LocationData LocationData { get; set; }
        public virtual AssignmentPicture Picture { get; set; }
    }
}