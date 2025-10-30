using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Interfaces;
using StempelAppCore.Models.Interfaces.Mappers;
using StempelAppCore.Models.Requests.User;
using StempelAppCore.Models.Responses.User;
using StempelAppLib.Exceptions.MapperExceptions;

namespace StempelAppLib.Services
{
    public class UserService : IUserService
    {
        private readonly IUserMapper _userMapper;
        private readonly IRepository<AppUser> _repository;
        public UserService(IUserMapper userMapper, IRepository<AppUser> repository)
        {
            _userMapper = userMapper;
            _repository = repository;
        }

        public async Task<UserCreateResponse> CreateNewUserAsync(UserCreateRequest request)
        {
            var response = new UserCreateResponse();
            try
            {
                var user = _userMapper.MapFromCreateToUser(request);
                await _repository.AddAsync(user);
                await _repository.SaveChangesAsync();
                response = _userMapper.ToCreateResponse(user);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex switch
                {
                    UserMapperException => "There was an error mapping user data.",
                    _ => "Unexpected error."
                };
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<UserGetResponse> GetUserAsync(UserGetRequest request)
        {
            var response = new UserGetResponse();
            try
            {
                var userId = _userMapper.MapFromGetToUserId(request);
                var user = await _repository.GetByIdAsync(userId);
                response = _userMapper.ToGetResponse(user);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex switch
                {
                    UserMapperException => "There was an error mapping user data.",
                    _ => "Unexpected error."
                };
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<UserListResponse> GetUsersAsync(UserListRequest request)
        {
            var response = new UserListResponse();
            try
            {
                var users = await _repository.GetAllAsync();
                if (users != null)
                    response.Users = users.ToList();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = "Unexpected error.";
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<UserUpdateResponse> UpdateUserAsync(UserUpdateRequest request)
        {
            var response = new UserUpdateResponse();
            try
            {
                var user = _userMapper.MapFromUpdateToUser(request);
                _repository.Update(user);
                await _repository.SaveChangesAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex switch
                {
                    UserMapperException => "There was an error mapping user data.",
                    _ => "Unexpected error."
                };
                response.IsSuccess = false;
            }
            return response;
        }
    }
}