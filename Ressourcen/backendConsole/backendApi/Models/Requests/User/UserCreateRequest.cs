using StempelAppCore.Models.Domain;

namespace StempelAppCore.Models.Requests.User
{
    public class UserCreateRequest : BaseRequest
    {
        public int UserTypeId { get; set; }
        public UserType UserType
        {
            get => (UserType)UserTypeId;
            set => UserTypeId = (int)value;
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public ContactInfo ContactInfo { get; set; }
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
        public List<Project>? Projects { get; set; }
    }
}