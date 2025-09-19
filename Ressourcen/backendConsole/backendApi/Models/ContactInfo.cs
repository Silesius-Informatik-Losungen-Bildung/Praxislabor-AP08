namespace StempelAppCore.Models
{
    public partial class ContactInfo : BaseEntity
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}