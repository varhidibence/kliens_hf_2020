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
    /// <summary>
    /// Responsible for communicate with the API with HTTP requests, 
    /// loading datas and deserialize from JSON standard format to the models of the application
    /// </summary>
    public class GameOfThronesDataService
    {

        /// <summary>
        /// the URI address of the API
        /// </summary>
        private static readonly Uri serverUrl = new Uri("https://anapioficeandfire.com");

        /// <summary>
        /// Makes async a GET request with the URI and deserialize the JSON in the response
        /// to the general type T. If an exception occurs at deserializing, default instance of
        /// T returns
        /// </summary>
        /// <typeparam name="T">general type to deserialize to</typeparam>
        /// <param name="uri">the address where the GET send to</param>
        /// <returns>deserialized instance of T</returns>
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

        /// <summary>
        /// Makes async GET requests with the number of parameter urls, but not more than limit
        /// and deserialize the JSON in the response
        /// to the general type T. Makes a list of T and returns with it
        /// </summary>
        /// <typeparam name="T">general type to deserialize to</typeparam>
        /// <param name="urls">the addresses where the GET send to</param>
        /// <param name="limit">limit of requests</param>
        /// <returns>list of T</returns>
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

        /// <summary>
        /// Makes a HTTP GET requests with all books from the API
        /// </summary>
        /// <returns>list of books from API</returns>
        public static async Task<List<Book>> GetAllBooksAsync()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books"));
        }

        /// <summary>
        /// Makes a HTTP GET requests with all characters from the API
        /// </summary>
        /// <returns>list of characters from API</returns>
        public static async Task<List<Character>> GetAllCharactersAsync()
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters"));
        }

        /// <summary>
        /// Makes a HTTP GET requests from urls from the API, but not more than limit
        /// </summary>
        /// <returns>list of books</returns>
        public static async Task<List<Book>> GetBookByUrlAsync(string[] urls, int limit)
        {
            return await GetByUrlAsync<Book>(urls, limit);
        }

        /// <summary>
        /// Makes a HTTP GET requests from the API and gets the charachter by id
        /// </summary>
        /// <param name="id">id of character</param>
        /// <returns>character</returns>
        public static async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await GetAsync<Character>(new Uri(serverUrl, $"api/characters/{id}"));
        }

        /// <summary>
        /// Makes a HTTP GET requests from urls from the API, but not more than limit
        /// </summary>
        /// <returns>list of characters</returns>
        public static async Task<List<Character>> GetCharacterByURLAsync(string[] urls, int limit)
        {
            return await GetByUrlAsync<Character>(urls, limit);
        }

        /// <summary>
        /// Makes a HTTP GET requests with all houses from the API
        /// </summary>
        /// <returns>list of houses from API</returns>
        public static async Task<List<House>> GetAllHousesAsync()
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses"));
        }

        /// <summary>
        /// Makes a HTTP GET requests from urls from the API, but not more than limit
        /// </summary>
        /// <returns>list of houses</returns>
        public static async Task<List<House>> GetHouseByURLAsync(string[] urls, int limit)
        {
            return await GetByUrlAsync<House>(urls, limit);
        }
    }
}
