using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Interfaces.Mappers;
using StempelAppCore.Models.Requests.User;
using StempelAppCore.Models.Responses.User;
using StempelAppLib.Exceptions.MapperExceptions;

namespace StempelAppLib.Logic.Mapper.QueryAndResponseMappers
{
    public class UserMapper : IUserMapper
    {
        public UserCreateResponse ToCreateResponse(AppUser user)
        {
            if (user == null) throw new UserMapperException($"Mapping failed. User null.");
            var response = new UserCreateResponse()
            {
                UserGuid = user.UserGuid,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ContactInfo = user.ContactInfo,
                PageNumber = user.PageNumber,
                PageSize = user.PageSize,
                SearchTerm = user.SearchTerm,
                SortBy = user.SortBy,
                IsAscending = user.IsAscending,
            };

            return response;
        }

        public UserGetResponse ToGetResponse(AppUser? user)
        {
            if (user == null) throw new UserMapperException($"Mapping failed. User null.");
            var response = new UserGetResponse()
            {
                UserGuid = user.UserGuid,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ContactInfo = user.ContactInfo,
                PageNumber = user.PageNumber,
                PageSize = user.PageSize,
                SearchTerm = user.SearchTerm,
                SortBy = user.SortBy,
                IsAscending = user.IsAscending,
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
                PageNumber = user.PageNumber,
                PageSize= user.PageSize,
                IsAscending= user.IsAscending,
                SearchTerm= user.SearchTerm,
                SortBy = user.SortBy,
            };

            return response;
        }
    }
}