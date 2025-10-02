namespace StempelAppCore.Models.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateNewUser();
        Task<User> GetUser();
        Task<User> UpdateUser();
        Task<User> DeleteUser();
    }
}