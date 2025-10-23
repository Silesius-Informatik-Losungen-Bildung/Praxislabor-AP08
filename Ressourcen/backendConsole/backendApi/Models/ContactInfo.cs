namespace StempelAppCore.Models
{
    public partial class ContactInfo : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }
}