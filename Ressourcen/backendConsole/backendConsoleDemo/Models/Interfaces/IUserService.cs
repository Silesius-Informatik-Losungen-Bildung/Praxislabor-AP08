using backendConsoleDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StempelAppCore.Models.Interfaces
{
    public interface IUserService
    {
        Task<BaseUser> CreateNewUser();
        Task<BaseUser> GetUser();
        Task<BaseUser> UpdateUser();
        Task<BaseUser> DeleteUser();
    }
}