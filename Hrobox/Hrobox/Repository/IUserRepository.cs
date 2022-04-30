using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    internal interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task CreateUser(UserModel user, bool isNewItem);
        Task UpdateUser(UserModel user, bool isNewItem);
        Task deleteUser(string id);
    }
}
