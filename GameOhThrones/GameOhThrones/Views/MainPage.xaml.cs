using System;

using GameOhThrones.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GameOhThrones.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
