namespace StempelAppCore.Models
{
    public partial class User : BaseEntity
    {
        public Guid UserGuid { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType
        {
            get => (UserType)UserTypeId;
            set => UserTypeId = (int)value;
        }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public ContactInfo ContactInfo { get; set; } = null!;
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public DateTime? LastActivityDateUtc { get; set; }
        public virtual ContactInfo ContactInfoNav { get; set; } = null!;
}
}