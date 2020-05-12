using System;
using System.Collections.Generic;
using GameOhThrones.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GameOhThrones.Views
{
    public sealed partial class BooksPage : Page
    {
        public BooksViewModel ViewModel { get; } = new BooksViewModel();

        public BooksPage()
        {
            InitializeComponent();
            Loaded += BooksPage_Loaded;
        }

        private async void BooksPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> booksURL = new List<string>();
            booksURL = e.Parameter as List<string>;
            if (booksURL != null)
            {
                LoadURL(booksURL);
            }
            base.OnNavigatedTo(e);
        }

        private async void LoadURL(List<string> booksURL)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState, booksURL.ToArray() );
        }
    }
}
