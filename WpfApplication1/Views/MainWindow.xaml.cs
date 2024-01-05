using WpfApplication1.ViewModels;
using Microsoft.Maps.MapControl.WPF;
namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            myMap.Mode = new AerialMode(true);
        }
    }
}