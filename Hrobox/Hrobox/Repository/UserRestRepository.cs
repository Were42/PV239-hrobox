using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Hrobox.Model;
using Hrobox.Utility;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace Hrobox.Repository
{
    public class UserRestRepository : IUserRepository
    {
        HttpClient client;

        public UserRestRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task CreateUser(UserModel user)
        {
            Uri uri = new Uri(String.Format("{0}{1}", Constants.Url, "auth/register"));
            string json = JsonSerializer.Serialize<UserModel>(user, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, IgnoreNullValues = true});
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }

        public async Task<SignInUserModel> SignIn(UserLoginModel user)
        {
            Uri uri = new Uri(String.Format("{0}{1}", Constants.Url, "auth/login"));
            string json = JsonSerializer.Serialize<UserLoginModel>(user, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            SignInUserModel Item = new SignInUserModel();

            if (response.IsSuccessStatusCode)
            {
                string content2 = await response.Content.ReadAsStringAsync();
                Item = JsonSerializer.Deserialize<SignInUserModel>(content2,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return Item;
        }
    }
}
