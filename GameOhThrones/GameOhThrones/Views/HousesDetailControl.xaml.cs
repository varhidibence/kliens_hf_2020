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

        /// <summary>
        /// Navigates to the page of characters with the current lord of the actual character
        /// </summary>
        private void ShowCurrentLordByUrl(object sender, RoutedEventArgs e)
        {
            if (MasterMenuItem.currentLord != null && MasterMenuItem.currentLord.Length > 0
                    && MasterMenuItem.currentLord != "N/A")
                NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.currentLord);
        }

        /// <summary>
        /// Navigates to the page of characters with the heir of the actual character
        /// </summary>
        private void ShowHeirByUrl(object sender, RoutedEventArgs e)
        {
            if (MasterMenuItem.heir != null && MasterMenuItem.heir.Length > 0
                && MasterMenuItem.heir != "N/A")
                NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.heir);
        }

        /// <summary>
        /// Navigates to the page of houses with the overlord of the actual character
        /// </summary>
        private void ShowOverlordByUrl(object sender, RoutedEventArgs e)
        {
            if (MasterMenuItem.overlord != null && MasterMenuItem.overlord.Length > 0
                && MasterMenuItem.overlord != "N/A")
                NavigationService.Navigate(typeof(HousesPage), MasterMenuItem.overlord);
        }

        /// <summary>
        /// Navigates to the page of characters with the founder of the actual character
        /// </summary>
        private void ShowFounderByUrl(object sender, RoutedEventArgs e)
        {
            if (MasterMenuItem.founder != null && MasterMenuItem.founder.Length > 0
                 && MasterMenuItem.founder != "N/A")
                NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.founder);
        }

        /// <summary>
        /// Navigates to the page of houses with the list of cadet branches of the actual character
        /// </summary>
        private void ShowCadetBranchesByUrls(object sender, RoutedEventArgs e)
        {
            if (MasterMenuItem.cadetBranches != null && MasterMenuItem.cadetBranches.Count > 0)
                NavigationService.Navigate(typeof(HousesPage), MasterMenuItem.cadetBranches);
        }
        
        /// <summary>
        /// Navigates to the page of characters with the list of sworn members of the actual character
        /// </summary>
        private void ShowSwornMembersByUrls(object sender, RoutedEventArgs e)
        {
            if (MasterMenuItem.swornMembers != null && MasterMenuItem.swornMembers.Count > 0)
                NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.swornMembers);
        }
        
    }
}
