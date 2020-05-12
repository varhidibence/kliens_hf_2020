using System;

using GameOhThrones.Core.Models;
using GameOhThrones.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameOhThrones.Views
{
    public sealed partial class HousesDetailControl : UserControl
    {
        public House MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as House; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty =
            DependencyProperty.Register(
                "MasterMenuItem",
                typeof(House),
                typeof(HousesDetailControl),
                new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public HousesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as HousesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }

        private void ShowCurrentLordByUrl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.currentLord);
        }

        private void ShowHeirByUrl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.heir);
        }

        private void ShowOverlordByUrl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(HousesPage), MasterMenuItem.overlord);
        }

        private void ShowFounderByUrl(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.founder);
        }
        private void ShowCadetBranchesByUrls(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(HousesPage), MasterMenuItem.cadetBranches);
        }

        private void ShowSwornMembersByUrls(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.swornMembers);
        }
        
    }
}
