using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Interfaces;

namespace StempelAppLib.Services
{
    public class UserService : IUserService
    {
        public Task<AppUser> CreateNewUserAsync()
        {
            throw new NotImplementedException();
        }
        public Task<AppUser> GetUserAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
        public Task<AppUser> UpdateUserAsync()
        {
            throw new NotImplementedException();
        }
        public Task<AppUser> DeleteUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}