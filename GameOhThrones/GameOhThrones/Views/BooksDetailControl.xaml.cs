﻿using System;

using GameOhThrones.Core.Models;
using GameOhThrones.Helpers;
using GameOhThrones.Services;
using GameOhThrones.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameOhThrones.Views
{
    public sealed partial class BooksDetailControl : UserControl
    {
        public Book MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Book; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty =
                DependencyProperty.Register("MasterMenuItem",
                        typeof(Book),
                        typeof(BooksDetailControl),
                        new PropertyMetadata(null,
                        OnMasterMenuItemPropertyChanged));

        public BooksDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as BooksDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }

        /// <summary>
        /// Navigates to the page of characters with the list of characters of the actual book
        /// </summary>
        private void ShowCharacters_Click(object sender, RoutedEventArgs e)
        {
            if (MasterMenuItem.characters != null && MasterMenuItem.characters.Count > 0)
                NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.characters);
        }

        /// <summary>
        /// Navigates to the page of characters with the list of POVcharacters of the actual book
        /// </summary>
        private void ShowPOVCharacters_Click(object sender, RoutedEventArgs e)
        {
            if (MasterMenuItem.povCharacters != null && MasterMenuItem.povCharacters.Count > 0)
                NavigationService.Navigate(typeof(CharactersPage), MasterMenuItem.povCharacters);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //if (searchBox.Text != null && searchBox.Text.Length > 0)
                
        }
    }
}
