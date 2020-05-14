﻿using System;
using System.Collections.Generic;
using GameOhThrones.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GameOhThrones.Views
{
    /// <summary>
    /// Main Page of Houses
    /// </summary>
    public sealed partial class HousesPage : Page
    {
        public HousesViewModel ViewModel { get; } = new HousesViewModel();

        public HousesPage()
        {
            InitializeComponent();
            Loaded += HousesPage_Loaded;
        }

        /// <summary>
        /// Default loading datas of houses
        /// </summary>
        private async void HousesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        /// <summary>
        /// Loading datas of houses for the page by URLs
        /// </summary>
        /// <param name="e">URLs parameters, if any</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> houseURL = new List<string>();
            houseURL = e.Parameter as List<string>;
            if (houseURL != null)
                LoadURL(houseURL);
        }

        /// <summary>
        /// Loading datas of houses for the page by URLs
        /// </summary>
        /// <param name="houseURL">list of URLs of houses</param>
        private async void LoadURL(List<string> houseURL)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState, houseURL.ToArray());
        }
    }
}
