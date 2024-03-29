﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Hrobox.Model;
using Hrobox.Utility;

namespace Hrobox.Repository
{
    internal class TagRestRepository: ITagRepository
    {
        private HttpClient client;
        public TagRestRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<TagsModel> GetAllTags()
        {
            Uri uri = new Uri(String.Format("{0}{1}", Constants.Url, "tags"));
            HttpResponseMessage response = await client.GetAsync(uri);
            TagsModel Items = new TagsModel();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<TagsModel>(content, new JsonSerializerOptions(){ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            }

            return Items;
        }

        public async Task<string> CreateTag(Tag tag)
        {
            Uri uri = new Uri(String.Format("{0}{1}", Constants.Url, "tag"));
            string json = JsonSerializer.Serialize<Tag>(tag, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = content;
            response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return "Successfully created new tag.";
            }
            return "Some error occurred during creating new tag please try validate inputs and try again.";
        }
    }
}
