using System;

using GameOhThrones.Core.Models;
using GameOhThrones.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameOhThrones.Views
{
    public sealed partial class CharactersDetailControl : UserControl
    {
        public Character MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Character; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty =
            DependencyProperty.Register(
                "MasterMenuItem",
                typeof(Character),
                typeof(CharactersDetailControl),
                new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public CharactersDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CharactersDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }

        private void ShowFatherByUrl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.father);
        }

        private void ShowMotherByUrl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.mother);
        }

        private void ShowSpousesByUrls(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.Spouse);
        }

        private void ShowAllegiancesByUrls(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(HousesPage), MasterMenuItem.allegiances);
        }

        private void ShowBooksByUrls(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(BooksPage), MasterMenuItem.books);
        }
        private void ShowPOVBooksByUrls(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(BooksPage), MasterMenuItem.povBooks);
        }

        




    }
}
