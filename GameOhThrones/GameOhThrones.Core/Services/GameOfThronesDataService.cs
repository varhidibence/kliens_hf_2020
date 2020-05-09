using GameOhThrones.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameOhThrones.Core.Services
{
    public class GameOfThronesDataService
    {
        private static readonly Uri serverUrl = new Uri("https://anapioficeandfire.com");

        private static async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public static async Task<List<Book>> GetAllBooksAsync()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books"));
        }

        public async Task<List<Character>> GetAllCharactersAsync()
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters"));
        }

        public async Task<List<House>> GetAllHousesAsync()
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses"));
        }

        /*public async Task<Recipe> GetRecipeAsync(int id)
        {
            return await GetAsync<Recipe>(new Uri(serverUrl, $"api/Recipes/{id}"));
        }*/
    }
}
