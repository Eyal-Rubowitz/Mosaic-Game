using GalaSoft.MvvmLight;
using System.Windows;
using System.Windows.Controls;
using Mosaic.UI.Main.ViewModels;

namespace Mosaic.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MosaicViewModel();
        }
    }
}
