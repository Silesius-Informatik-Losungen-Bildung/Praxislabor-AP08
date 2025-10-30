using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Requests.User;
using StempelAppCore.Models.Responses.User;

namespace StempelAppCore.Models.Interfaces
{
    public interface IUserService
    {
        Task<UserCreateResponse> CreateNewUserAsync(UserCreateRequest request);
        Task<UserGetResponse> GetUserAsync(UserGetRequest request);
        Task<UserListResponse> GetUsersAsync(UserListRequest request);
        Task<UserUpdateResponse> UpdateUserAsync(UserUpdateRequest request);
    }
}