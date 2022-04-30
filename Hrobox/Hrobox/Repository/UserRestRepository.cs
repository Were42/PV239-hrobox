using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Hrobox.Model;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace Hrobox.Repository
{
    internal class UserRestRepository : IUserRepository
    {
        HttpClient client;

        public UserRestRepository()
        {
            client = new HttpClient();
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            Uri uri = new Uri("".ToString());
            HttpResponseMessage response = await client.GetAsync(uri);
            List<UserModel> Items = new List<UserModel>();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<List<UserModel>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return Items;
        }

        public async Task CreateUser(UserModel user, bool isNewItem)
        {
            Uri uri = new Uri("".ToString());
            string json = JsonSerializer.Serialize<UserModel>(user, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await client.PostAsync(uri, content);
            }

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }

        public async Task UpdateUser(UserModel user, bool isNewItem)
        {
            Uri uri = new Uri("".ToString());
            string json = JsonSerializer.Serialize<UserModel>(user, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await client.PutAsync(uri, content);
            }

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }

        public async Task deleteUser(string id)
        {
            Uri uri = new Uri("".ToString());
            HttpResponseMessage response = await client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully deleted.");
            }
        }

        public async Task SignIn(UserModel user)
        {
            Uri uri = new Uri("".ToString());
            string json = JsonSerializer.Serialize<UserModel>(user, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }
    }
}
