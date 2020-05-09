using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GameOhThrones.Core.Models;
using GameOhThrones.Core.Services;
using GameOhThrones.Helpers;

using Microsoft.Toolkit.Uwp.UI.Controls;

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

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.First();
            }
        }
    }
}
