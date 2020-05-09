using System;

using GameOhThrones.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameOhThrones.Views
{
    public sealed partial class CharactersPage : Page
    {
        public CharactersViewModel ViewModel { get; } = new CharactersViewModel();

        public CharactersPage()
        {
            InitializeComponent();
            Loaded += CharactersPage_Loaded;
        }

        private async void CharactersPage_Loaded(object sender, RoutedEventArgs e)
        {
            //await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}
