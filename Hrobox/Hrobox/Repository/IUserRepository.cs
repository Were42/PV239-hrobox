using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    public interface IUserRepository
    {
        Task CreateUser(UserModel user);
        Task<SignInUserModel> SignIn(UserLoginModel user);
    }
}
