namespace StempelAppCore.Models
{
    public class Customer : BaseEntity
    {
        public UserType UserType { get; set; }
        public string Address { get; set; }
    }
}