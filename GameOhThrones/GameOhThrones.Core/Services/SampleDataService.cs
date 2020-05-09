using GameOhThrones.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOhThrones.Core.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // TODO WTS: Delete this file once your app is using real data.
    public static class SampleDataService
    {/*
    
        private static IEnumerable<Book> GetSampleBook()
        {

            return new List<Book>()
            {
                new Book()
                {
                    url = "https://www.anapioficeandfire.com/api/books/1",
                    name = "A Game of Thrones",
                    isbn = "978-0553103540",
                    authors = new List<string>()
                    {
                        "George R. R. Martin"
                    },
                    numberOfPages = 694,
                    publisher = "Bantam Books",
                    country = "United States",
                    mediaType = "Hardcover",
                    released = new DateTime(1996, 8, 1),
                    characters = new List<Character>()
                    {
                        new Character()
                        {
                          url = "https://www.anapioficeandfire.com/api/characters/823",
                          name = "Petyr Baelish",
                          culture = "Valemen",
                          born = "In 268 AC, at the Fingers",
                          died = "",
                          titles = new List<string>(){

                            "Master of coin (formerly)",
                            "Lord Paramount of the Trident",
                            "Lord of Harrenhal",
                            "Lord Protector of the Vale"
                          },
                          aliases = new List<string>()
                          {
                              "Littlefinger"
                          },
                          father = null,
                          mother = null,
                          spouse = new List<Character>(),
                          allegiances = new List<House>()
                          {

                          },
                          books = null,
                          povBooks = null,
                          tvSeries = new List<string>()
                          {
                              "Season 1",
                            "Season 2",
                            "Season 3",
                            "Season 4",
                            "Season 5"
                          },
                          playedBy = new List<string>(){
                            "Aidan Gillen"
                          }
                        }
                    },
                    povCharacters = null
                },
                 new Book()
                {
                    url = "https://www.anapioficeandfire.com/api/books/1",
                    name = "A Game of Thrones",
                    isbn = "978-0553103540",
                    authors = new List<string>()
                    {
                        "George R. R. Martin"
                    },
                    numberOfPages = 694,
                    publisher = "Bantam Books",
                    country = "United States",
                    mediaType = "Hardcover",
                    released = new DateTime(1996, 8, 1),
                    characters = new List<Character>()
                    {
                        new Character()
                        {
                          url = "https://www.anapioficeandfire.com/api/characters/823",
                          name = "Petyr Baelish",
                          culture = "Valemen",
                          born = "In 268 AC, at the Fingers",
                          died = "",
                          titles = new List<string>(){

                            "Master of coin (formerly)",
                            "Lord Paramount of the Trident",
                            "Lord of Harrenhal",
                            "Lord Protector of the Vale"
                          },
                          aliases = new List<string>()
                          {
                              "Littlefinger"
                          },
                          father = null,
                          mother = null,
                          spouse = new List<Character>(),
                          allegiances = new List<House>()
                          {

                          },
                          books = null,
                          povBooks = null,
                          tvSeries = new List<string>()
                          {
                              "Season 1",
                            "Season 2",
                            "Season 3",
                            "Season 4",
                            "Season 5"
                          },
                          playedBy = new List<string>(){
                            "Aidan Gillen"
                          }
                        }
                    },
                    povCharacters = null
                }
            };
        }

        // TODO WTS: Remove this once your MasterDetail pages are displaying real data.
        public static async Task<IEnumerable<Book>> GetSampleBookAsync()
        {
            await Task.CompletedTask;
            return GetSampleBook();
        }

        public static async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            await Task.CompletedTask;
            return new List<Character>()
            {
                 new Character()
                        {
                          url = "https://www.anapioficeandfire.com/api/characters/823",
                          name = "Petyr Baelish",
                          culture = "Valemen",
                          born = "In 268 AC, at the Fingers",
                          died = "",
                          titles = new List<string>(){

                            "Master of coin (formerly)",
                            "Lord Paramount of the Trident",
                            "Lord of Harrenhal",
                            "Lord Protector of the Vale"
                          },
                          aliases = new List<string>()
                          {
                              "Littlefinger"
                          },
                          father = null,
                          mother = null,
                          spouse = new List<Character>(),
                          allegiances = new List<House>()
                          {

                          },
                          books = null,
                          povBooks = null,
                          tvSeries = new List<string>()
                          {
                              "Season 1",
                            "Season 2",
                            "Season 3",
                            "Season 4",
                            "Season 5"
                          },
                          playedBy = new List<string>(){
                            "Aidan Gillen"
                          }
                        },
                  new Character()
                        {
                          url = "https://www.anapioficeandfire.com/api/characters/823",
                          name = "Petyr Baelish",
                          culture = "Valemen",
                          born = "In 268 AC, at the Fingers",
                          died = "",
                          titles = new List<string>(){

                            "Master of coin (formerly)",
                            "Lord Paramount of the Trident",
                            "Lord of Harrenhal",
                            "Lord Protector of the Vale"
                          },
                          aliases = new List<string>()
                          {
                              "Littlefinger"
                          },
                          father = null,
                          mother = null,
                          spouse = new List<Character>(),
                          allegiances = new List<House>()
                          {

                          },
                          books = null,
                          povBooks = null,
                          tvSeries = new List<string>()
                          {
                              "Season 1",
                            "Season 2",
                            "Season 3",
                            "Season 4",
                            "Season 5"
                          },
                          playedBy = new List<string>(){
                            "Aidan Gillen"
                          }
                        }
            };
        }

        public static async Task<IEnumerable<House>> GetHousesAsync()
        {
            await Task.CompletedTask;
            return new List<House>()
            {
                 new House()
                 {
                      url = "https://www.anapioficeandfire.com/api/houses/10",
                      name = "House Baelish of Harrenhal",
                      region = "The Riverlands",
                      coatOfArms = "A field of silver mockingbirds, on a green field",
                      words =  "",
                      titles = new List<string>()
                      {
                           "Lord Paramount of the Trident",
                        "Lord of Harrenhal"
                      },
                      seats = new List<string>(){
                        "Harrenhal"
                      },
                      currentLord = null,
                      heir = null,
                      overlord = new House(){
                          url = "https://www.anapioficeandfire.com/api/houses/16"
                      },
                      founded = "299 AC",
                      founder = null,
                      diedOut = "",
                      ancestralWeapons = new List<string>(),
                      cadetBranches= null,
                      swornMembers= null

                    }
            };
        }*/
    }
}
