namespace backendApi.Models
{
    public class User : BaseEntity
    {
        public Guid UserGuid { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType
        {
            get => (UserType)UserTypeId;
            set => UserTypeId = (int)value;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public string StreetAddress { get; set; }
        public string ZipPostalCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public bool HasProjects { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public DateTime? LastActivityDateUtc { get; set; }
        // public virtual ContactInfo { get; set; }
    }
}