using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    internal class TagRestRepository: ITagRepository
    {
        private HttpClient client;
        public TagRestRepository()
        {
            var client = new HttpClient();
        }
        public async Task<List<Tag>> GetAllTags()
        {
            Uri uri = new Uri("".ToString());
            HttpResponseMessage response = await client.GetAsync(uri);
            List<Tag> Items = new List<Tag>();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<List<Tag>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return Items;
        }

        public async Task CreateTag(Tag tag, bool isNewItem)
        {
            Uri uri = new Uri("".ToString());
            string json = JsonSerializer.Serialize<Tag>(tag, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
    }
}
