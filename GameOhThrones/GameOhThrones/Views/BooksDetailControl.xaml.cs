using System;

using GameOhThrones.Core.Models;

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
    }
}
