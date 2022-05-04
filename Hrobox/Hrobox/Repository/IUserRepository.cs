using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task CreateUser(UserModel user);
        Task UpdateUser(UserModel user);
        Task DeleteUser(string id);
        Task<SignInUserModel> SignIn(UserLoginModel user);
    }
}
