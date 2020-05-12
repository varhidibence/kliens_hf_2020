﻿using System;
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

        public async Task LoadDataAsync(MasterDetailsViewState viewState, string[] urls = null)
        {
            SampleItems.Clear();

            if (urls != null)
            {
                foreach (string url in urls)
                {
                    int i = 0;
                    if (url != null)
                    {
                        var house = await GameOfThronesDataService.GetHouseByUrlAsync(url);
                        if (house != null)
                        {
                            SampleItems.Add(house);
                            if (++i > 15)
                                break;
                        }
                    }
                }
            }
            else
            {
                var data = await GameOfThronesDataService.GetAllHousesAsync();
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        if (item != null)
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
