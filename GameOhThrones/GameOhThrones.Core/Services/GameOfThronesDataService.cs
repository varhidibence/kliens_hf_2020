using GameOhThrones.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                T result = default(T);
                try
                {
                    result = JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.StackTrace);
                }
                
                return result;
            }
        }

        public static async Task<List<T>> GetByUrlAsync<T>(string[] urls, int limit)
        {
            List<T> list = new List<T>();
            if (urls != null)
            {
                foreach (string url in urls)
                {
                    var elem = await GetAsync<T>(new Uri(url));
                    if (elem != null)
                        list.Add(elem);
                    if (list.Count >= limit)
                        break;
                }
            }
            return list;
        }

        public static async Task<List<Book>> GetAllBooksAsync()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books"));
        }

        public static async Task<List<Character>> GetAllCharactersAsync()
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters"));
        }

        public static async Task<List<Book>> GetBookByUrlAsync(string[] urls, int limit)
        {
            return await GetByUrlAsync<Book>(urls, limit);
        }

        public static async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await GetAsync<Character>(new Uri(serverUrl, $"api/characters/{id}"));
        }

        public static async Task<List<Character>> GetCharacterByURLAsync(string[] urls, int limit)
        {
            return await GetByUrlAsync<Character>(urls, limit);
        }

        public static async Task<List<House>> GetAllHousesAsync()
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses"));
        }

        public static async Task<List<House>> GetHouseByURLAsync(string[] urls, int limit)
        {
            return await GetByUrlAsync<House>(urls, limit);
        }
    }
}
