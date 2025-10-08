using StempelAppCore.Models.Domain;

namespace StempelAppCore.Models.Responses.User
{
    public class UserUpdateResponse : BaseResponse
    {
        public UserType? UpdatedUserType { get; set; }
        public string? UpdatedUsername { get; set; }
        public string? UpdatedFirstName { get; set; }
        public string? UpdatedLastName { get; set; }
        public string? UpdatedEmail { get; set; }
        public string? UpdatedPasswordHash { get; set; }
    }
}