using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication1.Commands;
using ClassLibrary1;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel
    {
        public ICommand Search { get; set; }
        public ObservableCollection<FormatData> Show { get; set; }

        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Dist { get; set; }

        public MainViewModel()
        {
            Search = new RelayCommand(NewCoords, CanNewCoords);
            Show = new ObservableCollection<FormatData>();
        }

        private bool CanNewCoords(object arg)
        {
            return true;
        }

        private void NewCoords(object obj)
        {
            FormatData newRequest = new FormatData(lon, lat, dist);
        }
    }
}