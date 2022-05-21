using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<ObservableCollection<OutputGameModel>> GetAll(FilterModel filterModel)
        {

            Uri uri = new Uri("https://hrobox-backend.herokuapp.com/api/games");
            string json = JsonSerializer.Serialize<FilterModel>(filterModel, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, IgnoreNullValues = true});
            StringContent content_post = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content_post);
            ObservableCollection<OutputGameModel> Items = new ObservableCollection<OutputGameModel>();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<ObservableCollection<OutputGameModel>>(content,
                    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }

            return Items;
        }

        public async Task<GameDetailModel> GetById(OutputGameModel game)
        {
            var url = String.Format("https://hrobox-backend.herokuapp.com/api/game/{0}/version/{1}?lang=en", game.Id, game.Version);
            Uri uri = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(uri);
            GameDetailModel Item = new GameDetailModel();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Item = JsonSerializer.Deserialize<GameDetailModel>(content,
                    new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            }

            return Item;
        }

        public async Task<string> CreateGame(NewGameModel game, string jwt)
        {
            var authHeader = new AuthenticationHeaderValue("Bearer", jwt);
            client.DefaultRequestHeaders.Authorization = authHeader;
            Uri uri = new Uri("https://hrobox-backend.herokuapp.com/api/game");
            string json = JsonSerializer.Serialize<NewGameModel>(game, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return "Successfully created new Game.";
            }
            return "Something failed during creation of game, please validate inputs and tr again.";
        }


        public async Task DeleteGame(string id)
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
