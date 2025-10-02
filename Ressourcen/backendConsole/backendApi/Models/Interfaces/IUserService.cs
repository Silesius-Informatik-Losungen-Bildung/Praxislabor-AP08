namespace StempelAppCore.Models.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateNewUserAsync();
        Task<User> GetUserAsync();
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> UpdateUserAsync();
        Task<User> DeleteUserAsync();
    }
}