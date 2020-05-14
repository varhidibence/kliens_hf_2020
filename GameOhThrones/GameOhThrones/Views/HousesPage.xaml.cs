using System;
using System.Collections.Generic;
using GameOhThrones.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GameOhThrones.Views
{
    public sealed partial class HousesPage : Page
    {
        public HousesViewModel ViewModel { get; } = new HousesViewModel();

        public HousesPage()
        {
            InitializeComponent();
            Loaded += HousesPage_Loaded;
        }

        private async void HousesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> houseURL = new List<string>();
            houseURL = e.Parameter as List<string>;
            if (houseURL != null)
                LoadURL(houseURL);

            //base.OnNavigatedTo(e);
        }

        private async void LoadURL(List<string> houseURL)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState, houseURL.ToArray());
        }
    }
}
