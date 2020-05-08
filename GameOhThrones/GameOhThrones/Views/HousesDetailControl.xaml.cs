using System;

using GameOhThrones.Core.Models;

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
    }
}
