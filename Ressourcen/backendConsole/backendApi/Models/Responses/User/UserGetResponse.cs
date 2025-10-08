using StempelAppCore.Models.Domain;

namespace StempelAppCore.Models.Responses.User
{
    public class UserGetResponse : BaseResponse
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
        public ContactInfo ContactInfo { get; set; }
    }
}