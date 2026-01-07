namespace StempelAppCore.Models
{
    public partial class Customer : BaseEntity
    {
        public UserType UserType { get; set; }
        public int UserId { get; set; }
        public ICollection<Address> AddressList { get; set; } = null!;
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        public virtual User User { get; set; } = null!;
    }
}