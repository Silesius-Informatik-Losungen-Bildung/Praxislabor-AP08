using backendConsoleDemo.Models;
using StempelAppCore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StempelAppLib.Services
{
    public class UserService : IUserService
    {

        public Task<BaseUser> CreateNewUser()
        {
            throw new NotImplementedException();
        }

        public Task<BaseUser> DeleteUser()
        {
            throw new NotImplementedException();
        }

        public Task<BaseUser> GetUser()
        {
            throw new NotImplementedException();
        }

        public Task<BaseUser> UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}