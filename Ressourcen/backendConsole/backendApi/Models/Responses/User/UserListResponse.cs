using StempelAppCore.Models.Domain;

namespace StempelAppCore.Models.Responses.User
{
    public class UserListResponse : BaseResponse
    {
        public List<AppUser> Users { get; set; }
    }
}