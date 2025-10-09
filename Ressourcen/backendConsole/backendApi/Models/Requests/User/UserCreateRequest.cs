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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
        public List<Project>? Projects { get; set; }
    }
}