using System;

using GameOhThrones.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            //await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}
