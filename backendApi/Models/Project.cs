namespace StempelAppCore.Models
{
    public partial class Project : BaseEntity
    {
        public string CustomerName { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public int ContactInfoId { get; set; }
        public ICollection<string> Activities { get; set; } = new List<string>();
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? PlannedTime { get; set; }
        public virtual ContactInfo ContactInfo { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<User> CleaningPersonnel { get; set; } = new List<User>();
    }
}