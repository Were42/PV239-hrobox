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
            client = new HttpClient();
        }
        public async Task<TagsModel> GetAllTags()
        {
            Uri uri = new Uri("https://hrobox-backend.herokuapp.com/api/tags");
            HttpResponseMessage response = await client.GetAsync(uri);
            TagsModel Items = new TagsModel();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<TagsModel>(content);
            }

            return Items;
        }

        public async Task CreateTag(Tag tag)
        {
            Uri uri = new Uri("".ToString());
            string json = JsonSerializer.Serialize<Tag>(tag, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }
    }
}
