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

        public async Task LoadDataAsync(MasterDetailsViewState viewState, string[] urls= null)
        {
            SampleItems.Clear();

            if (urls != null)
            {
                foreach (string url in urls)
                {
                    int i = 0;
                    if (url != null)
                    {
                        var character = await GameOfThronesDataService.GetCharacterByURLAsync(url);
                        if(character != null)
                        {
                            if (character.father.Length > 0)
                            {
                                var father = await GameOfThronesDataService.GetCharacterByURLAsync(character.father);
                                character.father = father.name;
                            }
                            if (character.mother.Length > 0)
                            {
                                var mother = await GameOfThronesDataService.GetCharacterByURLAsync(character.mother);
                                character.mother = mother.name;
                            }
                            SampleItems.Add(character);
                            if (++i > 15)
                                break;
                        }
                        
                    }
                    
                }
            }
            else
            {
                var data = await GameOfThronesDataService.GetAllCharactersAsync();

                foreach (var item in data)
                {
                    if (item != null)
                    {
                        if (item.father.Length > 0)
                        {
                            var father = await GameOfThronesDataService.GetCharacterByURLAsync(item.father);
                            item.father = father.name;
                        }
                        if (item.mother.Length > 0)
                        {
                            var mother = await GameOfThronesDataService.GetCharacterByURLAsync(item.mother);
                            item.mother = mother.name;
                        }
                        SampleItems.Add(item);
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
