using System;
using System.Collections.Generic;
using GameOhThrones.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GameOhThrones.Views
{
    /// <summary>
    /// Main Page of Books
    /// </summary>
    public sealed partial class BooksPage : Page
    {
        public BooksViewModel ViewModel { get; } = new BooksViewModel();

        public BooksPage()
        {
            InitializeComponent();
            Loaded += BooksPage_Loaded;
        }

        /// <summary>
        /// Default loading datas of books
        /// </summary>
        private async void BooksPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        /// <summary>
        /// Loading datas of books for the page by URLs
        /// </summary>
        /// <param name="e">URLs parameters, if any</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> booksURL = new List<string>();
            booksURL = e.Parameter as List<string>;
            if (booksURL != null)
            {
                LoadURL(booksURL);
            }
        }

        /// <summary>
        /// Loading datas of books for the page by URLs
        /// </summary>
        /// <param name="booksURL">list of URLs of books</param>
        private async void LoadURL(List<string> booksURL)
        {
            await ViewModel.LoadDataAsyncWithURLs(MasterDetailsViewControl.ViewState, booksURL.ToArray() );
        }
    }
}
