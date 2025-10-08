namespace StempelAppCore.Models.Domain
{
    public partial class Project : BaseEntity
    {
        public string CustomerName { get; set; }
        public Address Address { get; set; }
        public int ContactInfoId { get; set; }
        public ICollection<string> Activities { get; set; } = new List<string>();
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? PlannedTime { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<AppUser> CleaningPersonnel { get; set; } = new List<AppUser>();
    }
}