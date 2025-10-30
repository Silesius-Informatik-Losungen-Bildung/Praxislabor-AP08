using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Interfaces.Mappers;
using StempelAppCore.Models.Requests.User;
using StempelAppCore.Models.Responses.User;
using StempelAppLib.Exceptions.MapperExceptions;

namespace StempelAppLib.Logic.Mapper.QueryAndResponseMappers
{
    public class UserMapper : IUserMapper
    {
        public AppUser MapFromCreateToUser(UserCreateRequest request)
        {
            var user = new AppUser()
            {
                UserType = request.UserType,
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                CreatedOnUtc = request.CreatedOnUtc,
            };
            return user;
        }

        public int MapFromGetToUserId(UserGetRequest request)
        {
            int userId = request.UserId;
            return userId;
        }

        public AppUser MapFromUpdateToUser(UserUpdateRequest request)
        {
            var user = new AppUser();

            if(!string.IsNullOrWhiteSpace(request.UpdatedEmail)) user.Email = request.UpdatedEmail;
            if(!string.IsNullOrWhiteSpace(request.UpdatedFirstName)) user.FirstName = request.UpdatedFirstName;
            if(!string.IsNullOrWhiteSpace(request.UpdatedLastName)) user.LastName = request.UpdatedLastName;
            if(!string.IsNullOrWhiteSpace(request.UpdatedPhoneNumber)) user.PhoneNumber = request.UpdatedPhoneNumber;
            if(!string.IsNullOrWhiteSpace(request.UpdatedPasswordHash)) user.PasswordHash = request.UpdatedPasswordHash;
            
            return user;
        }

        public UserCreateResponse ToCreateResponse(AppUser user)
        {
            if (user == null) throw new UserMapperException($"Mapping failed. User null.");
            var response = new UserCreateResponse()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ContactInfo = user.ContactInfo,
            };

            return response;
        }

        public UserGetResponse ToGetResponse(AppUser? user)
        {
            if (user == null) throw new UserMapperException($"Mapping failed. User null.");
            var response = new UserGetResponse()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ContactInfo = user.ContactInfo,
            };
            return response;
        }

        public UserListResponse ToListResponse(IEnumerable<AppUser?> users, UserListRequest request)
        {
            if (users == null) throw new UserMapperException($"Mapping failed. User list null.");
            if (users.Any(u => u == null)) throw new UserMapperException($"Mapping failed. A user in the list is null.");
            var response = new UserListResponse()
            {
                Users = users.ToList(),
                SearchTerm = request.SearchTerm,
                SortBy = request.SortBy,
                IsAscending = request.IsAscending,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };
            return response;
        }

        public UserUpdateResponse ToUpdateResponse(AppUser user)
        {
            if (user == null) throw new UserMapperException($"Mapping failed. User null.");
            var response = new UserUpdateResponse()
            {
                UpdatedUsername = user.Username,
                UpdatedUserType = user.UserType,
                UpdatedEmail = user.Email,
                UpdatedFirstName = user.FirstName,
                UpdatedLastName = user.LastName,
                UpdatedPasswordHash = user.PasswordHash,
            };

            return response;
        }
    }
}