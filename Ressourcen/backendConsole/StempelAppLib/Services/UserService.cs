using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Interfaces;

namespace StempelAppLib.Services
{
    public class UserService : IUserService
    {
        public Task<User> CreateNewUserAsync()
        {
            throw new NotImplementedException();
        }
        public Task<User> GetUserAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
        public Task<User> UpdateUserAsync()
        {
            throw new NotImplementedException();
        }
        public Task<User> DeleteUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}