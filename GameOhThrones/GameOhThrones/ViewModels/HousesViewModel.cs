using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GameOhThrones.Core.Models;
using GameOhThrones.Core.Services;
using GameOhThrones.Helpers;

using Microsoft.Toolkit.Uwp.UI.Controls;

namespace GameOhThrones.ViewModels
{
    /// <summary>
    /// Control logic to houses
    /// Acquires and stores the specified houses to show
    /// </summary>
    public class HousesViewModel : Observable
    {
        private House _selected;
        private int limit = 15;

        public House Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<House> SampleItems { get; private set; } =
            new ObservableCollection<House>();

        public HousesViewModel()
        {
        }

        /// <summary>
        /// Loads async all houses from the API and updates the stored houses
        /// </summary>
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();
            var houses = await GameOfThronesDataService.GetAllHousesAsync();
            SubstitueEmptyAttributes(houses);

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }

        /// <summary>
        /// Loads async the houses given the list from the API with limit
        /// and updates the stored houses
        /// </summary>
        /// <param name="urls">list of URLs of houses</param>
        public async Task LoadDataAsync(MasterDetailsViewState viewState, string[] urls = null)
        {
            SampleItems.Clear();
            if (urls != null)
            {
                var houses = await GameOfThronesDataService.GetHouseByURLAsync(urls, limit);
                SampleItems.Clear();
                SubstitueEmptyAttributes(houses);
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
        /// <param name="houses">list</param>
        private void SubstitueEmptyAttributes(List<House> houses)
        {
            foreach (var house in houses)
            {
                if (house != null)
                {
                    if (house.coatOfArms.Length == 0) house.coatOfArms = "N/A";
                    if (house.currentLord.Length == 0) house.currentLord = "N/A";
                    if (house.diedOut.Length == 0) house.diedOut = "N/A";
                    if (house.founded.Length == 0) house.founded = "N/A";
                    if (house.founder.Length == 0) house.founder = "N/A";
                    if (house.heir.Length == 0) house.heir = "N/A";
                    if (house.name.Length == 0) house.name = "N/A";
                    if (house.overlord.Length == 0) house.overlord = "N/A";
                    if (house.region.Length == 0) house.region = "N/A";
                    if (house.words.Length == 0) house.words = "N/A";

                    SampleItems.Add(house);
                }
            }
        }
    }
}
