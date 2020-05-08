using System;

using GameOhThrones.Core.Models;

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
    }
}
