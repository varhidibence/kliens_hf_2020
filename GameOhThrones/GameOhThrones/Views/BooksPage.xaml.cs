using System;

using GameOhThrones.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
    }
}
