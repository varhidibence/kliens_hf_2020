using System;
using System.Collections.Generic;
using GameOhThrones.ViewModels;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> charactersURL = new List<string>();
            charactersURL = e.Parameter as List<string>;
            LoadURL(charactersURL);
            
            base.OnNavigatedTo(e);
        }

        private async void LoadURL(List<string> charactersURL)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState, charactersURL);
        }
    }
}
