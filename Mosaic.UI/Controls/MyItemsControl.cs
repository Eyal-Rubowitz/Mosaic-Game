using Mosaic.UI.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Mosaic.UI.Controls
{
    public class MyItemsControl : ItemsControl
    {
        public static readonly DependencyProperty ItemsSourceBindingsProperty =
            DependencyProperty.Register("ItemsSourceBindings",
                                        typeof(List<TileViewModel>),
                                        typeof(MyItemsControl),
                                        new PropertyMetadata(ItemsSourceBindingsPropertyChanged));

        public List<TileViewModel> ItemsSourceBindings
        {
            get { return (List<TileViewModel>)GetValue(ItemsSourceBindingsProperty); }
            set { SetValue(ItemsSourceBindingsProperty, value); }
        }

        private static void ItemsSourceBindingsPropertyChanged(DependencyObject itemsCtrlObj, DependencyPropertyChangedEventArgs e)
        {
            var itemsCtrl = (MyItemsControl)itemsCtrlObj;
            if (itemsCtrl == null) return;

            // ItemsSourceBindings are the *tiles* that get from the ViewModel
            var tiles = itemsCtrl.ItemsSourceBindings;

            itemsCtrl.Items.Clear();
            foreach (var tile in tiles)
            {
                var contentPresenter = new ContentPresenter()
                {
                    // represent the xaml
                    ContentTemplate = (DataTemplate)itemsCtrl.FindResource(tile.TemplateName),
                    // represent the view-model
                    Content = tile
                };
                itemsCtrl.Items.Add(contentPresenter);
            }
        }
    }
}
