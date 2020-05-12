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

        public static async Task<List<Character>> GetAllCharactersAsync()
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters"));
        }

        public static async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await GetAsync<Character>(new Uri(serverUrl, $"api/characters/{id}"));
        }

        public static async Task<Character> GetCharacterByURLAsync(string url)
        {
            return await GetAsync<Character>(new Uri(url));
        }

        public static async Task<List<House>> GetAllHousesAsync()
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses"));
        }
    }
}
