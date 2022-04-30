﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Hrobox.Model;
using Xamarin.Forms;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace Hrobox.Repository
{
    public class GameRestRepository : IGameRepository
    {
        HttpClient client;

        public GameRestRepository()
        {
            client = new HttpClient();
        }

        public async Task<List<GameModel>> GetAll()
        {

            Uri uri = new Uri("".ToString());
            HttpResponseMessage response = await client.GetAsync(uri);
            List<GameModel> Items = new List<GameModel>();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<List<GameModel>>(content,
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            }

            return Items;
        }

        public async Task<GameModel> GetById(int id)
        {
            Uri uri = new Uri("".ToString());
            
            StringContent content_in = new StringContent(id.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content_in);
            GameModel Item = new GameModel();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Item = JsonSerializer.Deserialize<GameModel>(content,
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            }

            return Item;
        }

        public async Task CreateGame(GameModel game)
        {
            Uri uri = new Uri("".ToString());
            string json = JsonSerializer.Serialize<GameModel>(game,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            
            response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }

        public async Task UpdateGame(GameModel game)
        {
            Uri uri = new Uri("".ToString());
            string json = JsonSerializer.Serialize<GameModel>(game,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }

        public async Task deleteGame(string id)
        {
            Uri uri = new Uri("".ToString());
            HttpResponseMessage response = await client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully deleted.");
            }
        }
    }
}
