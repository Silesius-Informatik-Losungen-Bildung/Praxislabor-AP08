using StempelAppCore.Models.Domain;

namespace StempelAppCore.Models.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> CreateNewUserAsync();
        Task<AppUser> GetUserAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> UpdateUserAsync();
        Task<AppUser> DeleteUserAsync();
    }
}