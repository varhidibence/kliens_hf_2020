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
    public class HousesViewModel : Observable
    {
        private House _selected;

        public House Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<House> SampleItems { get; private set; } = new ObservableCollection<House>();

        public HousesViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();
            var houses = await GameOfThronesDataService.GetAllHousesAsync();

            if (houses != null)
            {
                foreach (var house in houses)
                {
                    if (house != null)
                        SampleItems.Add(house);
                }
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState, string[] urls = null)
        {
            SampleItems.Clear();
            if (urls != null)
            {
                var houses = await GameOfThronesDataService.GetHouseByURLAsync(urls, 15);
                SampleItems.Clear();
                foreach (var house in houses)
                {
                    if (house != null)
                    {
                        SampleItems.Add(house);
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
