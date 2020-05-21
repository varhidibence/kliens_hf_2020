using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GameOhThrones.Core.Models;
using GameOhThrones.Core.Services;
using GameOhThrones.Helpers;

using Microsoft.Toolkit.Uwp.UI.Controls;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using Windows.ApplicationModel;

namespace GameOhThrones.ViewModels
{
    /// <summary>
    /// Control logic to characters
    /// Acquires and stores the specified characters to show
    /// </summary>
    public class CharactersViewModel : Observable
    {
        private Character _selected;
        private int limit = 20;
        public Character Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        /// <summary>
        /// stored characters of the page
        /// </summary>
        public ObservableCollection<Character> SampleItems { get; private set; } =
            new ObservableCollection<Character>();

        public CharactersViewModel()
        {
        }

        /// <summary>
        /// Loads async all characters from the API and updates the stored characters
        /// </summary>
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();
            
            var characters = await GameOfThronesDataService.GetAllCharactersAsync();
            SubstitueEmptyAttributes(characters);

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }

        /// <summary>
        /// Loads async the characters given the list from the API with limit
        /// and updates the stored characters
        /// </summary>
        /// <param name="urls">list of URLs of characters</param>
        public async Task LoadDataAsyncWithURLs(MasterDetailsViewState viewState, string[] urls = null)
        {
            SampleItems.Clear();
            if (urls != null)
            {
                var characters = await GameOfThronesDataService.GetCharacterByURLAsync(urls, limit);
                SampleItems.Clear();
                SubstitueEmptyAttributes(characters);
                
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }

        /// <summary>
        /// Substitues empty text in the attributes of given list and add them
        /// to stored list
        /// </summary>
        /// <param name="characters">list</param>
        private void SubstitueEmptyAttributes(List<Character> characters)
        {
            foreach (var character in characters)
            {
                if (character != null)
                {
                    if (character.born.Length == 0) character.born = "N/A";
                    if (character.culture.Length == 0) character.culture = "N/A";
                    if (character.died.Length == 0) character.died = "N/A";
                    if (character.father.Length == 0) character.father = "N/A";
                    if (character.gender.Length == 0) character.gender = "N/A";
                    if (character.mother.Length == 0) character.mother = "N/A";
                    if (character.name.Length == 0) character.name = "N/A";
                    if (character.Spouse.Length == 0) character.Spouse = "N/A";

                    SampleItems.Add(character);
                }
            }
        }
    }
}
