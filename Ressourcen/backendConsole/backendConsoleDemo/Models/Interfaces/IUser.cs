namespace backendConsoleDemo.Models.Interfaces
{
    public interface IUser
    {
        Guid UserGuid { get; set; }
        int UserTypeId { get; set; }
        UserType UserType
        {
            get => (UserType)UserTypeId;
            set => UserTypeId = (int)value;
        }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        DateTime? DateOfBirth { get; set; }
        string Gender { get; set; }
        string CompanyName { get; set; }
        int CompanyId { get; set; }
        string StreetAddress { get; set; }
        string ZipPostalCode { get; set; }
        string City { get; set; }
        string County { get; set; }
        bool HasProjects { get; set; }
        DateTime CreatedOnUtc { get; set; }
        DateTime? LastLoginDateUtc { get; set; }
        DateTime LastActivityDateUtc { get; set; }

    }
}