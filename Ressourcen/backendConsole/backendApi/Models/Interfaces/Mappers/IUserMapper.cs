using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Requests.User;
using StempelAppCore.Models.Responses.User;

namespace StempelAppCore.Models.Interfaces.Mappers
{
    public interface IUserMapper
    {
        AppUser MapFromCreateToUser(UserCreateRequest request);
        int MapFromGetToUserId(UserGetRequest request);
        AppUser MapFromUpdateToUser(UserUpdateRequest request);
        UserCreateResponse ToCreateResponse(AppUser user);
        UserGetResponse ToGetResponse(AppUser? user);
        UserListResponse ToListResponse(IEnumerable<AppUser?> users, UserListRequest request);
        UserUpdateResponse ToUpdateResponse(AppUser user);
    }
}