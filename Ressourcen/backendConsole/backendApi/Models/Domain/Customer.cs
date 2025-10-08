namespace StempelAppCore.Models.Domain
{
    public partial class Customer : BaseEntity
    {
        public UserType UserType { get; set; }
        public int UserId { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        public virtual ICollection<UserAssignment> Assignments { get; set; } = new List<UserAssignment>();
    }
}