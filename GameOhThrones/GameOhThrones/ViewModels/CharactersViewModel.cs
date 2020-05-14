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

namespace GameOhThrones.ViewModels
{
    public class CharactersViewModel : Observable
    {
        private Character _selected;

        public Character Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<Character> SampleItems { get; private set; } = new ObservableCollection<Character>();

        public CharactersViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();
            
            var data = await GameOfThronesDataService.GetAllCharactersAsync();

            foreach (var item in data)
                {
                    if (item != null)
                    {
                        SampleItems.Add(item);
                    }  
                }

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }

        public async Task LoadDataAsyncWithURLs(MasterDetailsViewState viewState, string[] urls = null)
        {
            SampleItems.Clear();
            if (urls != null)
            {
                var characters = await GameOfThronesDataService.GetCharacterByURLAsync(urls, 15);
                SampleItems.Clear();
                foreach (var character in characters)
                {
                    if (character != null)
                    {
                        SampleItems.Add(character);
                    }

                }
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }
    }
}
