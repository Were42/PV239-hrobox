using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    public interface IUserRepository
    {
        public Task<List<UserModel>> GetAllUsers();
        public Task CreateUser(UserModel user);
        public Task UpdateUser(UserModel user);
        public Task DeleteUser(string id);
        public Task<SignInUserModel> SignIn(UserModel user);
    }
}
