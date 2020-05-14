using System;
using System.Collections.Generic;
using GameOhThrones.ViewModels;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GameOhThrones.Views
{

    /// <summary>
    /// Main Page of Characters
    /// </summary>
    public sealed partial class CharactersPage : Page
    {
        public CharactersViewModel ViewModel { get; } = new CharactersViewModel();

        public CharactersPage()
        {
            InitializeComponent();
            Loaded += CharactersPage_Loaded;
        }

        /// <summary>
        /// Default loading datas of characters
        /// </summary>
        private async void CharactersPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        /// <summary>
        /// Loading datas of characters for the page by URLs
        /// </summary>
        /// <param name="e">URLs parameters, if any</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> charactersURL = new List<string>();
            charactersURL = e.Parameter as List<string>;
            if (charactersURL != null)
                LoadURL(charactersURL);
        }

        // 
        /// <summary>
        /// Loading datas of characters for the page by URLs
        /// </summary>
        /// <param name="charactersURL">list of URLs of characters</param>
        private async void LoadURL(List<string> charactersURL)
        {
            await ViewModel.LoadDataAsyncWithURLs(MasterDetailsViewControl.ViewState, charactersURL.ToArray() );
        }
    }
}


